using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PIM.Web.Common.Constants;
using PIM.BusinessService.Models;
using PIM.BusinessService.Service;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using PIM.BusinessService.Exceptions;
using PIM.BusinessService.Mapper;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Newtonsoft.Json;

namespace PIM.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private IProjectService _projectService;
        private IEmployeeService _employeeService;
        private IGroupService _groupService;
        private static MapperConfiguration _config;
        private IMapper _mapper;

        public ProjectsController(IProjectService projectService, IGroupService groupService, IEmployeeService employeeService)
        {
            _projectService = projectService;
            _employeeService = employeeService;
            _groupService = groupService;
            _config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = _config.CreateMapper();
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? searchString, string? status, string? sortString)
        {
            if (string.IsNullOrEmpty(searchString) && (status == ProjectConstant.AllStatus || status == null))
            {
                try
                {
                    var getAllProjects = _projectService.GetAllAsync();
                    var projectListGetAll = await getAllProjects;
                    var getAllGroup = _groupService.GetAllAsync();
                    ViewBag.GroupList = await getAllGroup;
                    var getAllEmployee = _employeeService.GetAllAsync();
                    ViewBag.EmployeeList = await getAllEmployee;
                    ViewBag.ProjectList = projectListGetAll;
                }
                catch(Exception e)
                {
                    return ErrorExceptionHandling(e, ProjectConstant.UndefinedException);
                }
            }
            else
            {
                try
                {
                    var statusSearch = status == ProjectConstant.AllStatus ? null : status;
                    var getProjectByFilter = _projectService.GetProjectFilter(searchString, statusSearch);
                    var projectListGetFilter = await getProjectByFilter;
                    var getAllGroup = _groupService.GetAllAsync();
                    ViewBag.GroupList = await getAllGroup;
                    var getAllEmployee = _employeeService.GetAllAsync();
                    ViewBag.EmployeeList = await getAllEmployee;
                    ViewBag.ProjectList = projectListGetFilter;
                    ViewBag.SearchString = searchString;
                    ViewBag.Status = status;
                }
                catch (Exception e)
                {
                    return ErrorExceptionHandling(e, ProjectConstant.UndefinedException);
                }
            }
            IList<ProjectModel> projectList = ViewBag.ProjectList;
            ViewBag.NumberSort = (sortString != ProjectConstant.NumberSortDesc ? ProjectConstant.NumberSortDesc : ProjectConstant.NumberSortAsc);
            ViewBag.NameSort = (sortString != ProjectConstant.NameSortAsc ? ProjectConstant.NameSortAsc : ProjectConstant.NameSortDesc);
            ViewBag.StartDateSort = sortString != ProjectConstant.StartDateSortAsc ? ProjectConstant.StartDateSortAsc : ProjectConstant.StartDateSortDesc;
            ViewBag.StatusSort = sortString != ProjectConstant.StatusSortAsc ? ProjectConstant.StatusSortAsc : ProjectConstant.StatusSortDesc;
            ViewBag.ProjectList = sortString switch
            {
                ProjectConstant.NumberSortDesc => projectList.OrderByDescending(p=>p.ProjectNumber).ToList(),
                ProjectConstant.NameSortAsc => projectList.OrderBy(p => p.Name).ToList(),
                ProjectConstant.NameSortDesc => projectList.OrderByDescending(p => p.Name).ToList(),
                ProjectConstant.StatusSortAsc => projectList.OrderBy(p => p.Status).ToList(),
                ProjectConstant.StatusSortDesc => projectList.OrderByDescending(p => p.Status).ToList(),
                ProjectConstant.StartDateSortAsc => projectList.OrderBy(p => p.StartDate).ToList(),
                ProjectConstant.StartDateSortDesc => projectList.OrderByDescending(p => p.StartDate).ToList(),
                _ => projectList.OrderBy(p => p.ProjectNumber).ToList(),
            };
            return View();
        }

        [HttpGet]
        [Route("Projects/Create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewBag.GroupList = await _groupService.GetAllAsync();
                ViewBag.EmployeeList = await _employeeService.GetAllAsync();
                return View();
            }
            catch (Exception e)
            {
                return ErrorExceptionHandling(e, ProjectConstant.UndefinedException);
            }
        }

        [HttpGet]
        public  async Task<bool> ValidateProjectNumber(int number)
        {
            var projectExist = await _projectService.GetByProjectNumberAsync(number);
            return projectExist == null ? true : false;
        }

        [HttpPost]
        public async Task<IActionResult> GetProjectByProjectNumber(int number)
        {
            try
            {
                var projectExist = await _projectService.GetByProjectNumberAsync(number);
                return projectExist != null ? Json(new
                {
                    id = projectExist.Id,
                    version = projectExist.Version,
                    number = projectExist.ProjectNumber,
                    name = projectExist.Name,
                    employeeList = JsonConvert.SerializeObject(projectExist.EmployeeList),
                    customer = projectExist.Customer,
                    status = projectExist.Status,
                    startDate = projectExist.StartDate,
                    endDate = projectExist.EndDate,
                    groupId = projectExist.Group.Id
                }) : Json(new
                {
                    number = number,
                    notExist = true
                });
            }
            catch(Exception e)
            {
                return ErrorExceptionHandling(e, ProjectConstant.UndefinedException);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectViewModel project)
        {
            var culture = HttpContext.Request.Cookies[ProjectConstant.CultureCookie];
            if(ModelState.IsValid)
            {
                try
                {
                    await _projectService.CreateAsync(project, culture);
                }
                catch(ProjectAlreadyExistException e)
                {
                    return ErrorExceptionHandling(e, ProjectConstant.AlreadyExistException);
                }
                catch (OutOfMemoryException e)
                {
                    return ErrorExceptionHandling(e, ProjectConstant.OutOfMemoryException);
                }
                catch (SystemException e)
                {
                    return ErrorExceptionHandling(e, ProjectConstant.SystemException);
                }
                catch (Exception e)
                {
                    return ErrorExceptionHandling(e, ProjectConstant.UndefinedException);
                }
            } 
            else
            {
                Console.WriteLine(ModelState.IsValid);
                TempData["Error"] = ProjectConstant.UndefinedException;
                return Redirect(ProjectConstant.RedirectToErrorPage);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectViewModel project, string culture)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _projectService.UpdateAsync(project, culture);
                    return RedirectToAction(nameof(Index));
                }
                catch(StaleObjectStateException e)
                {
                    return ErrorExceptionHandling(e, ProjectConstant.UpdatedOrDeletedException);
                }
                catch (OutOfMemoryException e)
                {
                    return ErrorExceptionHandling(e, ProjectConstant.OutOfMemoryException);
                }
                catch (ArgumentNullException e)
                {
                    return ErrorExceptionHandling(e, ProjectConstant.NulLReferencesException);
                }
                catch (SystemException e)
                {
                    return ErrorExceptionHandling(e, ProjectConstant.SystemException);
                }
                catch (Exception e)
                {
                    return ErrorExceptionHandling(e, ProjectConstant.UndefinedException);
                }
            }
            else
            {
                Console.WriteLine(ModelState.IsValid);
                TempData["Error"] = ProjectConstant.UndefinedException;
                return Redirect(ProjectConstant.RedirectToErrorPage);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOne(int projectNumber)
        {
            try
            {
                await _projectService.DeleteOneProjectAsync(projectNumber);
            }
            catch (ArgumentNullException e)
            {
                return ErrorExceptionHandling(e, ProjectConstant.NulLReferencesException);
            }
            catch (Exception e)
            {
                return ErrorExceptionHandling(e, ProjectConstant.UndefinedException);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("DeleteList")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteList(string projectNumberList)
        {
            IList<int> projectNumbers = projectNumberList.Split(ProjectConstant.SplitListChars).Select(x=>int.Parse(x)).ToList();
            try
            {
                await _projectService.DeleteProjectListAsync(projectNumbers);
            }
            catch(ArgumentNullException e)
            {
                return ErrorExceptionHandling(e, ProjectConstant.NulLReferencesException);
            }
            catch (Exception e)
            {
                return ErrorExceptionHandling(e, ProjectConstant.UndefinedException);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CultureManagement(string culture, string returntUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), 
                                    new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            return LocalRedirect(returntUrl);
        }

        private IActionResult ErrorExceptionHandling(Exception e, string errorContent)
        {
            Console.WriteLine(e.Message);
            TempData["Error"] = errorContent;
            TempData["Message"] = e.Message;
            TempData["StackTrace"] = e.StackTrace;
            return Redirect(ProjectConstant.RedirectToErrorPage);
        }
    }
}
