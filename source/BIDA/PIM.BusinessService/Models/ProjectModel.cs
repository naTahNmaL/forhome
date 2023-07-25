using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PIM.BusinessService.Models
{
    public class ProjectModel
    {
        [Required] public virtual Guid Id { get; set; }

        [Required] public virtual int Version { get; set; }

        [Required] public virtual GroupModel Group { get; set; }

        [Required] public virtual int ProjectNumber { get; set; }

        [Required] public virtual string Name { get; set; }

        [Required] public virtual string Customer { get; set; }

        [Required] public virtual string Status { get; set; }

        [Required] public virtual IList<EmployeeModel> EmployeeList { get; set; } = new List<EmployeeModel>();

        [Required] public virtual DateTime StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
    }
}
