-- Create a new table called '[Studies]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Studies]', 'U') IS NOT NULL
DROP TABLE [dbo].[Studies]
GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Studies]
(
    [StudyId] UNIQUEIDENTIFIER PRIMARY KEY default NEWID(), -- Primary Key column
    [Modality] VARCHAR(50) default ('CT'),
    [NumImages] int Not NULL,
    [PatientId] UNIQUEIDENTIFIER not NULL
);
GO

-- Create a new table called '[Patients]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Patients]', 'U') IS NOT NULL
DROP TABLE [dbo].[Patients]
GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Patients]
(
    [PatientId] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- Primary Key column
    [FirstName] VARCHAR(100) NOT NULL default 'Anonymous',
    [LastName] VARCHAR(100) NOT NULL default 'Anonymous'
);
GO

alter table dbo.Studies with NOCHECK
    add FOREIGN key (PatientId) references dbo.Patients (PatientId) -- add the fk constraint
GO

-- Seed the tables with test data
insert into Patients (FirstName, LastName) values ('John', 'Doe');

declare @CurrentPatientId uniqueidentifier = (select top 1 PatientId from Patients);

insert into Studies (Modality,  NumImages, PatientId) values ('CT', 32, @CurrentPatientId)

insert into Studies (Modality, NumImages, PatientId) values ('MR', 25, @CurrentPatientId)