using Common.Enums;
using PersistentLayer.Domains;
using System.ComponentModel.DataAnnotations;

namespace PIMTool.Models
{
    public class ProjectViewModel
    {
        public virtual int Id { get; set; }
        [Display(Name = "ProjectNumber")]
        public virtual int ProjectNumber { get; set; }
        [Display(Name = "Name")]
        public virtual string Name { get; set; }
        [Display(Name = "Customer")]
        public virtual string Customer { get; set; }
        [Display(Name = "Status")]
        public virtual eProjectStatus Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:D}")]
        [Display(Name = "StartDate")]
        public virtual DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:D}")]
        [Display(Name = "EndDate")]
        public virtual DateTime? EndDate { get; set; }
        public virtual int Version { get; set; }
        public virtual Group Group { get; set; }
        public virtual IList<Employee> Employees { get; set; }

    }

}
