using System;

namespace PIM.DataAccess.Entity
{
    interface IEntity
    {
        Guid Id { set; get; }
        int Version { set; get; }
    }
}
