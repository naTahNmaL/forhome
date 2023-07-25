using Common.Constants;
using Common.DTO;
using Common.Enums;
using Common;
using Common.UnitOfWork;
using Microsoft.Extensions.Localization;
using NHibernate;
using NHibernate.Criterion;
using PersistentLayer.Domains;

namespace PersistentLayer.Repositories
{

    public interface IProjectRepository
    {
        Task<Project> GetProjectById(int projectId);
        Task<int> CreateProject(Project project);
        Task<bool> UpdateProject(Project project);
        Task<bool> DeleteProjectAsync(int projectId);
        IQueryOver<Project, Project> GetProjectsQuery(PagedProjectSearchFilter projectSearchFilter);
        bool IsProjectNumberExisted(int projectNumber);

        Task<IList<Project>> GetProjectByMultipleIdsAsync(List<int> projectIds);

        void DeleteProject(int projectId);


    }

    public class ProjectRepository : IProjectRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ProjectRepository(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public bool IsProjectNumberExisted(int projectNumber)
        {
            var session = _unitOfWork.GetActiveSession();
            var result = session.QueryOver<Project>()
                .Where(p => p.ProjectNumber == projectNumber)
                .RowCount() > 0;
            return result;
        }

        public async Task<IList<Project>> GetProjectByMultipleIdsAsync(List<int> projectIds)
        {
            var session = _unitOfWork.GetActiveSession();
            var project = session.QueryOver<Project>()
                   .Where(p => projectIds.Contains(p.Id));
            var result = await project.ListAsync();

            return result;
        }

        public async Task<Project> GetProjectById(int projectId)
        {
            var session = _unitOfWork.GetActiveSession();
            var query = session.QueryOver<Project>()
                   .Where(p => p.Id == projectId)
                   .Fetch(p => p.Employees).Eager; // Specify the fetch mode for employees
            var project = await query.SingleOrDefaultAsync();
            return project;
        }

        public IQueryOver<Project, Project> GetProjectsQuery(PagedProjectSearchFilter projectSearchFilter)
        {
            var session = _unitOfWork.GetActiveSession();
            var query = session.QueryOver<Project>();

            // Apply search string filter
            if (!string.IsNullOrEmpty(projectSearchFilter.Search))
            {
                var searchString = $"%{projectSearchFilter.Search}%";
                query.Where(Restrictions.Disjunction()
                  .Add(Expression.Like(
                      Projections.Cast(NHibernateUtil.String, Projections.Property<Project>(cl => cl.ProjectNumber)),
                      searchString,
                      MatchMode.Anywhere))
                    .Add(Restrictions.On<Project>(x => x.Customer).IsLike(searchString))
                    .Add(Restrictions.On<Project>(x => x.Name).IsLike(searchString)));
            }
            ApplyFilter(query, projectSearchFilter.Number, projectSearchFilter.Name,
                projectSearchFilter.Customer);

            //Apply Sorting
            ApplySorting(query, projectSearchFilter.SortOrder, projectSearchFilter.IsSortAscending);

            // Apply project status filter
            if (projectSearchFilter.Status.HasValue)
            {
                query.Where(x => x.Status == projectSearchFilter.Status.Value);
            }

            return query;
        }

        private static void ApplyFilter(IQueryOver<Project, Project> query, int? projectNumberFilter, string nameFilter, string customerNameFilter)
        {
            if (projectNumberFilter.HasValue)
            {
                query.Where(Expression.Like(
                  Projections.Cast(NHibernateUtil.String, Projections.Property<Project>(cl => cl.ProjectNumber)),
                  projectNumberFilter.ToString(),
                  MatchMode.Anywhere));
            }
            if (!string.IsNullOrEmpty(nameFilter))
            {
                query.WhereRestrictionOn(d => d.Name).IsLike($"%{nameFilter}%");
            }

            if (!string.IsNullOrEmpty(customerNameFilter))
            {
                query.WhereRestrictionOn(d => d.Customer).IsLike($"%{customerNameFilter}%");
            }
        }


        private static void ApplySorting(IQueryOver<Project, Project> query, string sortOrder, bool? isSortAscending)
        {
            if (!string.IsNullOrEmpty(sortOrder) && isSortAscending.HasValue)
            {
                var sortPropertyName = sortOrder;

                // Add sorting to the query
                if (isSortAscending.Value)
                {
                    query.OrderBy(Projections.Property(sortPropertyName)).Asc();
                }
                else
                {
                    query.OrderBy(Projections.Property(sortPropertyName)).Desc();
                }
            }
        }


        public async Task<int> CreateProject(Project project)
        {
            var session = _unitOfWork.GetActiveSession();
            await session.SaveAsync(project);
            await session.FlushAsync();
            return project.Id;
        }


        public async Task<bool> UpdateProject(Project updateProject)
        {
            var session = _unitOfWork.GetActiveSession();
            var currentProject = session.Get<Project>(updateProject.Id);
            CheckNullEntity(currentProject, updateProject.ProjectNumber);
            CheckVersionControl(updateProject.Version, currentProject.Version, updateProject.ProjectNumber);

            UpdateProjectProperties(currentProject, updateProject);

            UpdateEmployeesCollection(currentProject, updateProject);
            await session.UpdateAsync(currentProject);
            await session.FlushAsync();

            return true;
        }
        private void CheckNullEntity(Project currentProject, int projectNumber)
        {
            if (currentProject == default)
            {
                var errorMessage = String.Format(_localizer.GetString(ErrorMessageConst.Project_Number_Is_Deleted), projectNumber);
                throw new Common.Exceptions.NullException(errorMessage); ;
            }
        }

        private void CheckVersionControl(int updateVersion, int currentVersion, int projectNumber)
        {
            if (!updateVersion.Equals(currentVersion))
            {
                var errorMessage = String.Format(_localizer.GetString(ErrorMessageConst.Project_Number_Is_Edited), projectNumber);
                throw new Common.Exceptions.ConcurrencyOperationException(errorMessage); ;
            }
        }

        private static void UpdateProjectProperties(Project existingProject, Project updatedProject)
        {
            existingProject.Name = updatedProject.Name;
            existingProject.Customer = updatedProject.Customer;
            existingProject.Status = updatedProject.Status;
            existingProject.StartDate = updatedProject.StartDate;
            existingProject.EndDate = updatedProject.EndDate;
            existingProject.Group = updatedProject.Group;
        }

        private static void DeleteEmployees(Project existingProject, Project updatedProject)
        {
            foreach (var employee in existingProject.Employees.ToList())
            {
                if (!updatedProject.Employees.Any(e => e.Id == employee.Id))
                {
                    existingProject.Employees.Remove(employee);
                }
            }
        }

        private static void UpdateExistingEmployees(Project existingProject, Project updatedProject)
        {
            foreach (var employee in updatedProject.Employees)
            {
                var existingEmployee = existingProject.Employees.FirstOrDefault(e => e.Id == employee.Id);
                if (existingEmployee != null)
                {
                    existingEmployee.FirstName = employee.FirstName;
                    existingEmployee.LastName = employee.LastName;
                    // Update other properties as needed
                }
            }
        }

        private static void AddNewEmployees(Project existingProject, Project updatedProject)
        {
            foreach (var employee in updatedProject.Employees)
            {
                if (!existingProject.Employees.Any(e => e.Id == employee.Id))
                {
                    existingProject.Employees.Add(employee);
                }
            }
        }

        private static void UpdateEmployeesCollection(Project existingProject, Project updatedProject)
        {
            DeleteEmployees(existingProject, updatedProject);
            UpdateExistingEmployees(existingProject, updatedProject);
            AddNewEmployees(existingProject, updatedProject);
        }

        public static bool IsStatusNew(Project project)
        {
            return eProjectStatus.NEW == project.Status;
        }

        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            var session = _unitOfWork.GetActiveSession();
            var project = await session.GetAsync<Project>(projectId);
            var result = false;
            if (project != null)
            {
                if (!IsStatusNew(project))
                {
                    var errorMessage = String.Format(_localizer.GetString(ErrorMessageConst.Action_Delete_Is_Invalid), projectId, project.Status);
                    throw new Common.Exceptions.UserFriendlyException(errorMessage);

                }
                project.Employees.Clear();
                await session.DeleteAsync(project);
                await session.FlushAsync();
                result = true;
            }
            return result;
        }


        public void DeleteProject(int projectId)
        {
            var session = _unitOfWork.GetActiveSession();
            var project = session.Get<Project>(projectId);

            if (project != null)
            {
                if (!IsStatusNew(project))
                {
                    var errorMessage = String.Format(_localizer.GetString(ErrorMessageConst.Action_Delete_Is_Invalid), projectId, project.Status.ToString());
                    throw new Common.Exceptions.UserFriendlyException(errorMessage);
                }
                project.Employees.Clear();
                session.Delete(project);

            }
        }
    }


}