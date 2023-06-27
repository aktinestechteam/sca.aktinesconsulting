CREATE PROCEDURE [dbo].[Permissions_GetByUserId]
@UserId INT
AS
BEGIN
SELECT u.UserId,r.RoleId,p.[Name] as PermissionName, p.PermissionId,
rp.[View],rp.[Create],rp.[Modify],rp.[Delete] 
FROM [dbo].Users u
INNER JOIN [dbo].UserRoles ur ON ur.UserId=u.UserId
INNER JOIN [dbo].Roles r ON r.RoleId=ur.RoleId
INNER JOIN [dbo].RolePermissions rp ON rp.RoleId=r.RoleId
INNER JOIN [dbo].[Permissions] p on p.PermissionId=rp.PermissionId
WHERE u.UserId=@UserId
END