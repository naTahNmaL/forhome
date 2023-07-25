using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.DTO
{
    public class CreateProjectDto : BaseProjectDto
    {
        [Remote("ValidateProjectNumber", "Validation", ErrorMessage = ErrorMessageConst.Project_Number_Is_Existed)]
        [Required(ErrorMessage = ErrorMessageConst.Project_Number_Is_Required)]
        [Range(1, 9999, ErrorMessage = ErrorMessageConst.Project_Number_Is_Invalid)]
        public new int? ProjectNumber { get; set; }
    }


}
