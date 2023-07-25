using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PIM.BusinessService.Models;
using PIM.Web.Common.Constants;
using System;

namespace PIM.Web.Controllers
{
    public class ErrorController: Controller
    {
        [AllowAnonymous]
        [Route(ErrorConstant.ErrorString)]
        public IActionResult Exceptionhandling()
        {
            var viewModel = new ErrorViewModel();
            viewModel.Status = TempData[ErrorConstant.ErrorString].ToString();
            viewModel.Message = TempData[ErrorConstant.ErrorMessage]?.ToString();
            viewModel.StackTrace = TempData[ErrorConstant.ErrorStackTrace]?.ToString();
            return View(ErrorConstant.ErrorString, viewModel);
        }
        [AllowAnonymous]
        [Route("Error/{statusCode}")]
        public IActionResult ErrorHandling(int statusCode)
        {
            var errorCode = statusCode;
            Console.WriteLine(errorCode);
            var viewModel = new ErrorViewModel();
            switch (errorCode)
            {
                case 404:
                    viewModel.Status = ErrorConstant.NotFound;
                    break;
                default:
                    viewModel.Status = ErrorConstant.Undefined;
                    break;
            }
            return View("ErrorStatusCode",viewModel);
        }
    }
}
