CREATE TABLE Users (
    userId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	firstName nvarchar(50),
	lastName nvarchar(50),
	age tinyint,
	addressId int FOREIGN KEY REFERENCES Locations(locationId),
	interests text,
	userImage text,
	createdDtTime DateTime
);