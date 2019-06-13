CREATE TABLE Locations (
    locationId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	streetAddr text,
	cityName text,
	stateName text,
	zipCode tinyint,
	countryName text,
	createdDtTime DateTime
);