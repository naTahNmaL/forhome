using AutoMapper;
using Common;
using Common.Constants;
using Common.DTO;
using Common.Exceptions;
using Common.UnitOfWork;
using Microsoft.Extensions.Localization;
using PersistentLayer.Domains;
using PersistentLayer.Repositories;
using ServiceLayer.DTO;

namespace ServiceLayer.Services
{
    public interface IProjectService
    {
        Task<UpdateProjectDto> GetProjectByIdAsync(int projectId);
        Task<PagedObjectResult<ProjectDto>> GetAllProjects(PagedProjectSearchFilter pagedProjectSearchFilter);
        Task<int> CreateProjectAsync(CreateProjectDto project);
        Task<bool> UpdateProject(UpdateProjectDto project);
        Task<bool> DeleteProjectAsync(int projectId);
        bool IsProjectExisted(int projectNumber);
        Task DeleteMultipleProjectAsync(List<int> projectIds);
    }
    public class ProjectService : IProjectService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        private readonly IStringLocalizer<SharedResource> _localizer;

        public ProjectService(IProjectRepository projectRepository,
                                    IUnitOfWork unitOfWork,
                                    IStringLocalizer<SharedResource> localizer,
                                    IMapper mapper)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }




        public async Task<UpdateProjectDto> GetProjectByIdAsync(int projectId)
        {
            var transaction = _unitOfWork.BeginTransaction();

            var project = await _projectRepository.GetProjectById(projectId);
            var updateProjectRequest = _mapper.Map<UpdateProjectDto>(project);
            transaction.Commit();
            return updateProjectRequest;
        }

        public async Task<int> CreateProjectAsync(CreateProjectDto createProjectRequest)
        {
            var transaction = _unitOfWork.BeginTransaction();
            var isProjectExisted = _projectRepository.IsProjectNumberExisted((int)createProjectRequest.ProjectNumber);
            if (isProjectExisted)
            {
                var errorMessage = String.Format(_localizer.GetString(ErrorMessageConst.Project_Number_Existed_Error), createProjectRequest.ProjectNumber);
                throw new UserFriendlyException(errorMessage);
            }
            var project = _mapper.Map<Project>(createProjectRequest);
            project.ProjectNumber = (int)createProjectRequest.ProjectNumber;
            var result = await _projectRepository.CreateProject(project);
            transaction.Commit();
            return result;
        }

        public async Task<bool> UpdateProject(UpdateProjectDto updateProjectRequest)
        {
            var transaction = _unitOfWork.BeginTransaction();
            var project = _mapper.Map<Project>(updateProjectRequest);
            project.Id = updateProjectRequest.Id;
            var result = await _projectRepository.UpdateProject(project);
            transaction.Commit();
            return result;

        }

        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            var transaction = _unitOfWork.BeginTransaction();
            var result = await _projectRepository.DeleteProjectAsync(projectId);
            transaction.Commit();
            return result;
        }
        public bool IsProjectExisted(int projectNumber)
        {
            var transaction = _unitOfWork.BeginTransaction();
            var result =  _projectRepository.IsProjectNumberExisted(projectNumber);
            transaction.Commit();
            return result;

        }

        public async Task<PagedObjectResult<ProjectDto>> GetAllProjects(PagedProjectSearchFilter pagedProjectSearchFilter)
        {
            var transaction = _unitOfWork.BeginTransaction();
            var query = _projectRepository.GetProjectsQuery(pagedProjectSearchFilter);


            var totalCount = query.RowCount();

            var projects = await query.Skip((pagedProjectSearchFilter.Page - 1) * pagedProjectSearchFilter.PageSize)
                                  .Take(pagedProjectSearchFilter.PageSize)
                                  .ListAsync<Project>();
            transaction.Commit();
            var projectDtos = _mapper.Map<IList<ProjectDto>>(projects);
            return new PagedObjectResult<ProjectDto> { Data = projectDtos, TotalCount = totalCount };
        }

        public async Task DeleteMultipleProjectAsync(List<int> projectIds)
        {
            var transaction = _unitOfWork.BeginTransaction();
            foreach (var projectId in projectIds)
            {
                await _projectRepository.DeleteProjectAsync(projectId);
            }
            transaction.Commit();
        }
    }

}