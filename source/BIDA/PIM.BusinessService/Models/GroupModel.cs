using System;

namespace PIM.BusinessService.Models
{
    public class GroupModel
    {
        public virtual Guid Id { get; set; }
        public virtual int Version { get; set; }
        public virtual string Name { get; set; }
    }
}
