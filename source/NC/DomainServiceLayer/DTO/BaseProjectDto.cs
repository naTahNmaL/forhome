using Common.Constants;
using Common.Enums;
using ServiceLayer.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.DTO
{
    public abstract class BaseProjectDto
    {
        [DisplayName("ProjectNumber")]
        public int ProjectNumber { get; set; }


        [DisplayName("Name")]
        [Required(ErrorMessage = ErrorMessageConst.Name_Is_Required)]
        public string Name { get; set; }

        [DisplayName("Customer")]
        [Required(ErrorMessage = ErrorMessageConst.Customer_Is_Required)]
        public string Customer { get; set; }

        [DisplayName("GroupID")]
        [Required(ErrorMessage = ErrorMessageConst.Group_Is_Required)]
        public int? GroupID { get; set; }

        [DisplayName("Status")]
        [Required(ErrorMessage = ErrorMessageConst.Status_Is_Required)]
        public eProjectStatus Status { get; set; }

        [DisplayName("StartDate")]
        [Required(ErrorMessage = ErrorMessageConst.StartDate_Is_Required)]
        [DisplayFormat(DataFormatString = "{0:D}")]
        [CompareEndDate(nameof(EndDate))]
        public DateTime? StartDate { get; set; }

        [DisplayName("EndDate")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Employees")]
        public List<string> Employees { get; set; } = new List<string>();

        public int Version { get; set; }

    }
}
