using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Constants;
using Common.DTO;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using NHibernate.Util;
using PIMTool.Models;
using ServiceLayer.DTO;
using ServiceLayer.Services;

namespace PIMTool.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _localizer;


        public ProjectController(
            IProjectService projectService, IMapper mapper, IStringLocalizer<SharedResource> localizer)
        {
            _projectService = projectService;
            _mapper = mapper;
            _localizer = localizer;
        }



        // GET: Project
        public async Task<IActionResult> Index(PagedProjectSearchFilter pagedProjectSearchFilter)
        {

            ViewData["PreviousQuery"] = pagedProjectSearchFilter;

            var pagedProjectDtos = await _projectService.GetAllProjects(pagedProjectSearchFilter);

            var projectViewModels = _mapper.Map<List<ProjectViewModel>>(pagedProjectDtos.Data);
            var paginationModel = new PaginationModel<ProjectViewModel>
            {
                Count = pagedProjectDtos.TotalCount,
                Data = projectViewModels,
                PageSize = pagedProjectSearchFilter.PageSize,
            };

            return View(paginationModel);
        }

        // GET: Project/Create
        public async Task<IActionResult> CreateAsync()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProjectDto createProjectRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _projectService.CreateProjectAsync(createProjectRequest);
                    return RedirectToAction(nameof(Index));
                }
                ViewData[ErrorMessageConst.Required_Field_Missing] = ErrorMessageConst.Required_Field_Missing;
            }
            catch (Exception ex)
            {
                if (ex is not UserFriendlyException) throw;
                //handle ErrorMessage Of Existed Number
                ModelState.AddModelError(nameof(createProjectRequest.ProjectNumber), _localizer.GetString(ErrorMessageConst.Project_Number_Is_Existed));
            }
            ViewData[ErrorMessageConst.Required_Field_Missing] = ErrorMessageConst.Required_Field_Missing;

            return View(createProjectRequest);
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ValidateId(id);

            var project = await _projectService.GetProjectByIdAsync(id.Value);
            if (project == null)
            {
                var errorMessage = String.Format(_localizer.GetString(ErrorMessageConst.Project_Id_Not_Existed), id);
                throw new Common.Exceptions.NullException(errorMessage); ;
            }


            return View(project);
        }

        private void ValidateId(int? id)
        {
            if (id.GetValueOrDefault() == 0)
            {
                var errorMessage = String.Format(_localizer.GetString(ErrorMessageConst.Project_Id_Not_Existed), id);
                throw new Common.Exceptions.NullException(errorMessage);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateProjectDto updateProjectRequest)
        {
            try
            {
                ValidateId(updateProjectRequest.Id);

                if (ModelState.IsValid)
                {
                    await _projectService.UpdateProject(updateProjectRequest);
                    return RedirectToAction(nameof(Index));
                }
                ViewData[ErrorMessageConst.Required_Field_Missing] = ErrorMessageConst.Required_Field_Missing;
            }
            catch (Exception ex)
            {
                if (ex is not UserFriendlyException) throw;
                ViewData["ErrorMessage"] = ex.Message;
            }

            return View(updateProjectRequest);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            ValidateId(id);

            await _projectService.DeleteProjectAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("MultipleDelete")]
        public async Task<IActionResult> MultipleDelete([FromBody] DeleteProjectDto deleteProjectRequest)
        {
            if (deleteProjectRequest.ProjectIds.Count == 0)
            {
                return NotFound();
            }
            await _projectService.DeleteMultipleProjectAsync(deleteProjectRequest.ProjectIds);
            return RedirectToAction(nameof(Index));
        }

    }
}
