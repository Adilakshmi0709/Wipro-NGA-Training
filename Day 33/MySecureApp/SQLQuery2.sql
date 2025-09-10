SELECT TOP (1000) [UserId]
      ,[LoginProvider]
      ,[Name]
      ,[Value]
  FROM [MySecureAppDb].[dbo].[AspNetUserTokens]


 SELECT * FROM AspNetUsers;


  SELECT u.UserName, u.Email, r.Name as Role 
FROM AspNetUsers u
JOIN AspNetUserRoles ur ON u.Id = ur.UserId
JOIN AspNetRoles r ON ur.RoleId = r.Id;