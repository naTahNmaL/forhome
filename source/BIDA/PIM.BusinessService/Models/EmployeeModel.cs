using System;
using System.ComponentModel.DataAnnotations;

namespace PIM.BusinessService.Models
{
    public class EmployeeModel
    {
        public virtual Guid Id { get; set; }
        public virtual int Version { get; set; }
        [StringLength(3)]
        public virtual string Visa { get; set; }
        [StringLength(50)]
        public virtual string FirstName { get; set; }
        [StringLength(50)]
        public virtual string LastName { get; set; }
        [DataType(DataType.Date)]
        public virtual DateTime BirthDate { get; set; }
        public GroupModel Group { get; set; }
    }
}