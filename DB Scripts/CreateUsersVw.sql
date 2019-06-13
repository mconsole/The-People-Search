CREATE VIEW [dbo].[UsersVw]
AS
SELECT        dbo.Users.userId, dbo.Users.firstName, dbo.Users.lastName, dbo.Users.interests, dbo.Users.userImage, dbo.Locations.streetAddr, dbo.Locations.cityName, dbo.Locations.stateName, dbo.Locations.zipCode, 
                         dbo.Locations.countryName
FROM            dbo.Locations INNER JOIN
                         dbo.Users ON dbo.Locations.locationId = dbo.Users.addressId
GO