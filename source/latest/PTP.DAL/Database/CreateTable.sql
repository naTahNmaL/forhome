create table Country
(
    Id        bigint identity
        primary key,
    Name      nvarchar(255),
    Code      nvarchar(10),
    Continent nvarchar(255),
    Version   bigint default 0
)
    go

create table Currency
(
    Id      bigint identity
        primary key,
    Name    nvarchar(100),
    Symbol  nvarchar(5),
    Version bigint default 0
)
    go

create table Place
(
    CountryId bigint
        references Country,
    Id        bigint identity
        primary key,
    Name      nvarchar(255),
    Version   bigint default 0
)
    go

create table UserAvatar
(
    Id      bigint identity
        primary key,
    Avatar  varbinary(max),
    Version bigint default 0
)
    go

create table UserInfo
(
    Id       bigint identity
        primary key,
    UserName varchar(255),
    PassWord varchar(255),
    Name     nvarchar(255),
    Email    varchar(320),
    AvatarId bigint
        references UserAvatar,
    Version  bigint default 0
)
    go

create table Journey
(
    Id          bigint identity
        primary key,
    UserId      bigint
        references UserInfo,
    Name        nvarchar(255),
    Description nvarchar(max),
    CountryId   bigint
        references Country,
    PlaceId     bigint
        references Place,
    StartDate   date,
    EndDate     date,
    CurrencyId  bigint
        references Currency,
    Status      nvarchar(20),
    Amount      bigint,
    Version     bigint default 0
)
    go

create index IX_UserInfo_UserName
    on UserInfo (UserName)
    go

create index IX_UserInfo_Email
    on UserInfo (Email)
    go

create table UsersRole
(
    Id       bigint identity
        primary key,
    RoleName varchar(255),
    RoleCode bigint,
    Version  bigint default 0
)
    go

create table UsersRolesMapping
(
    UserId     bigint not null
        references UserInfo,
    UserRoleId bigint not null
        references UsersRole,
    primary key (UserId, UserRoleId)
)
    go

