CREATE TABLE [Roles]
(
	[id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [id_film] BIGINT NOT NULL, 
    [id_acteur] UNIQUEIDENTIFIER NOT NULL
)
GO
ALTER TABLE [Roles]
	ADD CONSTRAINT [ForeignKeyConstraint8]
	FOREIGN KEY (id_film)
	REFERENCES [Films] (code_barre)
GO
ALTER TABLE [Roles]
	ADD CONSTRAINT [ForeignKeyConstraint9]
	FOREIGN KEY (id_acteur)
	REFERENCES [Acteurs] (id)