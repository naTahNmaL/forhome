using NHibernate;
using PIM.DataAccess.UnitOfWorks;
using PIM.DataAccess.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using NHibernate.Linq;
using NHibernate.Criterion;
using NHibernate.Transform;
using PIM.DataAccess.Commons;

namespace PIM.DataAccess.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public override async Task<IList<Project>> GetAllAsync()
        {
            var projectList = await Session.QueryOver<Project>().Fetch(SelectMode.FetchLazyProperties, x => x.EmployeeList)
                .Fetch(SelectMode.FetchLazyProperties, x => x.Group).TransformUsing(Transformers.DistinctRootEntity).ListAsync(); 
            return projectList;
        }
        public async Task DeleteByProjectNumberListAsync (IList<int> projectNumberList)
        {
            var projects = await Session.QueryOver<Project>()
                .WhereRestrictionOn(p => p.ProjectNumber).IsIn((System.Collections.ICollection)projectNumberList).ListAsync();
            foreach(var project in projects)
            {
                Session.Delete(project);
            }
        }

        public async Task<bool> DeleteByProjectNumberAsync(int projectNumber)
        {
            var project = Session.QueryOver<Project>()
                    .Where(p => p.ProjectNumber == projectNumber).SingleOrDefaultAsync();
            Session.Delete(await project);
            return true;
        }

        public async Task<Project> GetProjectByProjectNumber(int projectNumber)
        {
            return await Session.QueryOver<Project>()
                    .Where(p => p.ProjectNumber == projectNumber)
                    .Fetch(SelectMode.FetchLazyProperties, x => x.EmployeeList).Fetch(SelectMode.FetchLazyProperties, x => x.Group)
                    .TransformUsing(Transformers.DistinctRootEntity).SingleOrDefaultAsync();
        }
        
        public async Task<IList<Project>> GetProjectFilter(string searchString, string status)
        {
            var restrictions = Restrictions.Conjunction(); 
            if (!string.IsNullOrEmpty(searchString))
            {
                var searchRestriction = Restrictions.Disjunction().Add(Restrictions.InsensitiveLike(nameof(Project.Customer), 
                                                                   CommonConstants.PercentSign + searchString + CommonConstants.PercentSign))
                                                                .Add(Restrictions.InsensitiveLike(nameof(Project.Name), 
                                                                CommonConstants.PercentSign + searchString + CommonConstants.PercentSign));
                if (int.TryParse(searchString, out int number))
                {
                    searchRestriction.Add(Restrictions.Eq(nameof(Project.ProjectNumber), number));
                }
                restrictions.Add(searchRestriction);

            }
            if (!string.IsNullOrEmpty(status))
            {
                var statusRestriction = Restrictions.Eq(nameof(Project.Status), status);
                restrictions.Add(statusRestriction);
            }
            var projectList = Session.QueryOver<Project>().Where(restrictions).
                Fetch(SelectMode.FetchLazyProperties, x => x.EmployeeList).Fetch(SelectMode.FetchLazyProperties, x => x.Group).TransformUsing(Transformers.DistinctRootEntity);
            return await projectList.ListAsync();
        }
    }
}
