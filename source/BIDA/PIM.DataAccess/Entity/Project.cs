using System;
using System.Collections.Generic;

namespace PIM.DataAccess.Entity
{
    public class Project : EntityBase
    {
        public override int Version { set; get; }
        public virtual Group Group { get; set; }
        public virtual int ProjectNumber { get; set; }
        public virtual string Name { get; set; }
        public virtual string Customer { get; set; }
        public virtual string Status { get; set; }
        private IList<Employee> _employeeList = new List<Employee>();
        public virtual IList<Employee> EmployeeList
        {
            get { return _employeeList; }
            set { _employeeList = value; }
        }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
    }
}
