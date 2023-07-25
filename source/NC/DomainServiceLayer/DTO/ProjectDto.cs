using Common.Enums;
using System.ComponentModel;

namespace ServiceLayer.DTO
{
    public class ProjectDto
    {
        public int Id { get; set; }
        [DisplayName("ProjectNumber")]
        public int ProjectNumber { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Customer")]
        public string Customer { get; set; }
        [DisplayName("Status")]
        public eProjectStatus Status { get; set; }
        [DisplayName("StartDate")]
        public DateTime StartDate { get; set; }
        [DisplayName("EndDate")]
        public DateTime? EndDate { get; set; }
        public int Version { get; set; }
        public int GroupId { get; set; }
        public List<EmployeeDto> EmployeeDtos { get; set; } = new List<EmployeeDto>();

    }
}
