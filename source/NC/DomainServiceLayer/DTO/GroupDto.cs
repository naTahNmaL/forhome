using PersistentLayer.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTO
{
    public class GroupDto
    {
        public virtual int Id { get; set; }
        public virtual int GroupLeaderId { get; set; }
        public virtual string GroupName { get; set; }
        public virtual int Version { get; set; }
        public virtual Employee Leader { get; set; } 

        public virtual IList<Project> Projects { get; set; }
    }
}
