CREATE TABLE [Voix]
(
	[id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [id_film] BIGINT NOT NULL, 
    [id_langue] UNIQUEIDENTIFIER NOT NULL
)
GO
ALTER TABLE [Voix]
	ADD CONSTRAINT [ForeignKeyConstraint4]
	FOREIGN KEY (id_film)
	REFERENCES [Films] (code_barre)
GO
ALTER TABLE [Voix]
	ADD CONSTRAINT [ForeignKeyConstraint5]
	FOREIGN KEY (id_langue)
	REFERENCES [Langues] (id)