using System;
using System.Collections.Generic;
namespace PIM.DataAccess.Entity
{
    public class Employee : EntityBase
    {
        public virtual string Visa { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual IList<Project> ProjectList { get; set; }
        public virtual Group Group { get; set; }
    }
}
