﻿CREATE TABLE [Clients]
(
	[id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [nom] NVARCHAR(MAX) NOT NULL, 
    [prenom] NVARCHAR(MAX) NOT NULL, 
    [mail] NVARCHAR(MAX) NOT NULL, 
    [telephone] NVARCHAR(MAX) NOT NULL, 
    [adresse] NVARCHAR(MAX) NOT NULL, 
    [date_naissance] NVARCHAR(MAX) NOT NULL
)