TRUNCATE TABLE dbo.Roles;

INSERT INTO dbo.Roles (Name, RoleGroup, Description)
VALUES 
('Project Manager', 'EthnicTeam', 'The person organized everyone and leads the project.'),
('Photographer', 'EthnicTeam', 'Responsible for taking still photos.'),
('Editor', 'EthnicTeam', 'Takes raw footage and organizes it, adds sound, graphics, and more.'),
('Global Coodinator', 'ProjectVideoTeam', 'Coodinates things'),
('Staff', 'ProjectVideoTeam', 'Staff things')