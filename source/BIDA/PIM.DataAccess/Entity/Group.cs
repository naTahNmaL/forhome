using System.Collections.Generic;
namespace PIM.DataAccess.Entity
{
    public class Group : EntityBase
    {
        public virtual string Name { get; set; }    
        public virtual Employee GroupLeader { get; set; }
        public virtual IList<Project> ProjectList { get; set; }
    }
}
