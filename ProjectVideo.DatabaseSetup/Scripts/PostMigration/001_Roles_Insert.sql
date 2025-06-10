TRUNCATE TABLE dbo.Roles;

INSERT INTO dbo.Roles (Name, RoleGroup, Description)
VALUES 
('Ministry Director', 'EthnicTeam', 'The person organized everyone and leads the project.'),
('Studio / TeamManager', 'EthnicTeam', 'Responsible for taking still photos.'),
('Camera Operator', 'EthnicTeam', 'Takes raw footage and organizes it, adds sound, graphics, and more.'),
('Video Editor', 'EthnicTeam', 'Edits the videos.'),
('Audio Engineer', 'EthinicTeam', 'Music and Sound Effects'),
('Staff', 'ProjectVideoTeam', 'Staff things'),
('Coordinator', 'ProjectVideoTeam', 'Staff things')