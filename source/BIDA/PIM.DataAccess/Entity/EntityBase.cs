using System;

namespace PIM.DataAccess.Entity
{
    public class EntityBase : IEntity
    {
        public virtual Guid Id { set; get; }
        public virtual int Version { set; get; }
    }
}
