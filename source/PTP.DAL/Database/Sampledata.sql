insert into dbo.Country (Id, Name, Code, Continent)
values  (1, N'United States', N'US', N'North America'),
        (2, N'United Kingdom', N'UK', N'Europe');

insert into dbo.Currency (Id, Name, Symbol)
values  (1, N'US Dollar', N'USD'),
        (2, N'British Pound', N'GBP');

insert into dbo.Journey (Id, UserId, Name, Description, CountryId, PlaceId, StartDate, EndDate, CurrencyId, Status, Amount, Version)
values  (1, 1, N'New York trip', N'A trip to New York', 1, 1, N'2023-07-15', N'2023-07-20', 1, N'Planned', 500, 0),
        (2, 2, N'LA trip', N'A trip to Los Angeles', 1, 2, N'2023-08-01', N'2023-08-05', 1, N'Planned', 700, 0),
        (3, 1, N'London trip', N'A trip to London', 2, 1, N'2023-09-01', N'2023-09-10', 2, N'Planned', 1000, 0);

insert into dbo.Place (CountryId, Id, Name)
values  (1, 1, N'New York'),
        (1, 2, N'Los Angeles'),
        (2, 3, N'London');

insert into dbo.UserAvatar (Id, Avatar, Version)
values  (1, 0x89504E470D0A1A0A0000000D49484452, 0);

insert into dbo.UserInfo (Id, UserName, PassWord, Name, Email, AvatarId, Version)
values  (1, N'john', N'password', N'John Smith', N'john@example.com', 1, 0),
        (2, N'jane', N'password', N'Jane Doe', N'jane@example.com', 1, 0),
        (3, N'admin', N'password', N'Admin User', N'admin@example.com', 1, 0);

insert into dbo.UsersRole (Id, RoleName, RoleCode)
values  (1, N'Client', 100),
        (2, N'User', 200);

insert into dbo.UsersRolesMapping (UserId, UserRoleId)
values  (1, 1),
        (2, 1),
        (3, 2);