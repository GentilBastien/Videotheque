CREATE TABLE [Locations]
(
	[id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [id_client] UNIQUEIDENTIFIER NOT NULL, 
    [id_film] BIGINT NOT NULL, 
    [rendu] BIT NOT NULL, 
    [date_debut] DATE NOT NULL, 
    [date_fin] DATE NOT NULL
)
GO
ALTER TABLE [Locations]
	ADD CONSTRAINT [ForeignKeyConstraint2]
	FOREIGN KEY (id_client)
	REFERENCES [Clients] (id)
GO
ALTER TABLE [Locations]
	ADD CONSTRAINT [ForeignKeyConstraint3]
	FOREIGN KEY (id_film)
	REFERENCES [Films] (code_barre)