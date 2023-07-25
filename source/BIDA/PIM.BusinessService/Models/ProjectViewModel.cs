using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using PIM.BusinessService.Helpers;

namespace PIM.BusinessService.Models
{
    public class ProjectViewModel : IValidatableObject
    {
        public Guid Id { get; set; }
        public virtual int Version { get; set; }
        
        [Required]
        public Guid GroupId { get; set; }
        
        [Required]
        public int ProjectNumber { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Customer { get; set; }
        
        [Required]
        public string Status { get; set; }

        [Required]
        public IList<string> EmployeeIdList { get; set; }

        [Required]
        public string StartDate { get; set; }

        public string? EndDate { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            if (EndDate != null)
            {
                if (DateTimeHelper.ParseDateTime(StartDate) > DateTimeHelper.ParseDateTime(EndDate))
                {
                    errors.Add(new ValidationResult($"{nameof(EndDate)} needs to be greater than From date.", new List<string> { nameof(EndDate) }));
                }
            }
            return errors;
        }
    }
}
