CREATE TABLE [Sous_titrages]
(
	[id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [id_film] BIGINT NOT NULL, 
    [id_langue] UNIQUEIDENTIFIER NOT NULL
)
GO
ALTER TABLE [Sous_titrages]
	ADD CONSTRAINT [ForeignKeyConstraint6]
	FOREIGN KEY (id_film)
	REFERENCES [Films] (code_barre)
GO
ALTER TABLE [Sous_titrages]
	ADD CONSTRAINT [ForeignKeyConstraint7]
	FOREIGN KEY (id_langue)
	REFERENCES [Langues] (id)