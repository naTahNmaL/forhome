using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PTP.DAL.Domains.Mappings;

public class UserInfoMapping  : ClassMapping<UserInfo>
{
    public UserInfoMapping()
    {
        Table("UserInfo");
        
        Id(x => x.Id, m =>
        {
            m.Column("Id");
            m.Generator(Generators.Native);
        });

        Property(x => x.UserName, map =>
        {
            map.Column("UserName");
            map.NotNullable(true);
            map.Length(255);
        });
        Property(x => x.Password, map => 
        {
            map.Column("PassWord");
            map.NotNullable(true);
            map.Length(255);
        });
        Property(x => x.Name, map =>
        {
            map.Column("Name");
            map.Length(255);
        });
        Property(x => x.Email, map =>
        {
            map.Column("Email");
            map.Length(320);
        });
        
        OptimisticLock(OptimisticLockMode.Version);
        Version(x => x.Version, m =>
        {
            m.Column("Version");
            m.Generated(VersionGeneration.Always);
            m.UnsavedValue(0);
        });
        
        // ManyToOne(x => x.Avatar, map =>
        // {
        //     map.Column("AvatarId");
        //     map.Cascade(Cascade.None); // Adjust the cascade type based on your requirements
        // });
        OneToOne(x => x.Avatar, map =>
        {
            map.Cascade(Cascade.All | Cascade.DeleteOrphans);
            map.Lazy(LazyRelation.Proxy);
        });
        
        Bag(x => x.Journeys, map => {
            map.Table("Journey");
            map.Key(x => x.Column("UserId"));
            map.Cascade(Cascade.DeleteOrphans);
            map.Inverse(true);
            map.Lazy(CollectionLazy.Lazy);
        }, relation => relation.OneToMany());
        
        Bag(x => x.Roles, map =>
        {
            map.Table("UsersRolesMapping");
            map.Key(keyMap => keyMap.Column("UserId"));
            map.Cascade(Cascade.None); // Adjust the cascade type based on your requirements
        }, relation => relation.ManyToMany(map =>
        {
            map.Column("UserRoleId"); // Map the foreign key column for UsersRole
        }));
        
    }
}