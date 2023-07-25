using AutoMapper;
using PIM.BusinessService.Mapper;
using PIM.BusinessService.Models;
using PIM.DataAccess.UnitOfWorks;
using PIM.DataAccess.Entity;
using PIM.DataAccess.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PIM.BusinessService.Helpers;
using PIM.BusinessService.Exceptions;

namespace PIM.BusinessService.Service
{
    public class ProjectService:IProjectService
    {
        private IProjectRepository _projectRepository;
        private IEmployeeService _employeeService;
        private IGroupService _groupService;
        private readonly IUnitOfWork _unitOfWork;
        private static MapperConfiguration _config = new MapperConfiguration(cfg =>
                                                        {
                                                            cfg.AddProfile(new MappingProfile());
                                                        });
        private IMapper _mapper;
        public ProjectService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
           _mapper = _config.CreateMapper();
        }

        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork, IGroupService groupService, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _groupService = groupService;
            _projectRepository =  projectRepository;
            _unitOfWork = unitOfWork;
            _mapper = _config.CreateMapper();
        }

        public async Task<IList<ProjectModel>> GetAllAsync()
        {
            _unitOfWork.BeginTransaction();
            var projectListFromRepo = await _projectRepository.GetAllAsync();
            _unitOfWork.Commit();
            var projectList = _mapper.Map<IList<Project>, List<ProjectModel>>(projectListFromRepo);
            return projectList;
        }

        public async Task<ProjectModel> GetByProjectNumberAsync(int number)
        {
            _unitOfWork.BeginTransaction();
            var project = await _projectRepository.GetProjectByProjectNumber(number);
            _unitOfWork.Commit();
            return _mapper.Map<Project,ProjectModel>(project);
        }

        public async Task CreateAsync(ProjectViewModel project, string culture)
        {
            var projectExist = await GetByProjectNumberAsync(project.ProjectNumber);
            if(projectExist == null)
            {
                await CreateOrUpdateAsync(project, (projectEntity) => _projectRepository.CreateAsync(projectEntity));
            }
            else
            {
                throw new ProjectAlreadyExistException(project.ProjectNumber.ToString());
            }
        }

        public async Task UpdateAsync(ProjectViewModel project, string culture)
        {
            await CreateOrUpdateAsync(project, (projectEntity) => _projectRepository.UpdateAsync(projectEntity));

        }

        public async Task DeleteProjectListAsync(IList<int> projectNumberList)
        {
            _unitOfWork.BeginTransaction();
            await _projectRepository.DeleteByProjectNumberListAsync(projectNumberList);
            _unitOfWork.Commit();
        }       

        public async Task DeleteOneProjectAsync(int projectNumber)
        {
            _unitOfWork.BeginTransaction();
            await _projectRepository.DeleteByProjectNumberAsync(projectNumber);
            _unitOfWork.Commit();
        }

        public async Task<IList<ProjectModel>> GetProjectFilter(string searchString, string status)
        {
            _unitOfWork.BeginTransaction();
            var projects = await _projectRepository.GetProjectFilter(searchString, status);
            var projectList = _mapper.Map<IList<Project>, List<ProjectModel>>(projects);
            return projectList;
        }

        private async Task CreateOrUpdateAsync(ProjectViewModel project, Func<Project, Task> createOrUpdateFuncAsync)
        {
            var projectModel = _mapper.Map<ProjectViewModel, ProjectModel>(project);
            projectModel.Group = await _groupService.GetByIdAsync(project.GroupId);
            var employeeList = new List<EmployeeModel>();
            foreach (var id in project.EmployeeIdList)
            {
                var employee = await _employeeService.GetByIdAsync(new Guid(id));
                employeeList.Add(employee);
            }
            projectModel.EmployeeList = employeeList;
            projectModel.StartDate = DateTimeHelper.ParseDateTime(project.StartDate);
            if(project.EndDate!= null)
            {
               projectModel.EndDate = DateTimeHelper.ParseDateTime(project.EndDate);
            }
            _unitOfWork.BeginTransaction();
            await createOrUpdateFuncAsync.Invoke(_mapper.Map<ProjectModel, Project>(projectModel));
            _unitOfWork.Commit();
        }
    }
}