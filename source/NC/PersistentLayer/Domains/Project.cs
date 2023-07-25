using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersistentLayer.Domains
{
    public class Project
    {
        public virtual int Id { get; set; }
        public virtual int ProjectNumber { get; set; }
        public virtual string Name { get; set; }
        public virtual string Customer { get; set; }
        public virtual eProjectStatus Status { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual int Version { get; set; }
        public virtual Group Group { get; set; }
        public virtual IList<Employee> Employees { get; set; }

    }


}
