CREATE TABLE [Classifications]
(
	[id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [id_film] BIGINT NOT NULL, 
    [id_genre] UNIQUEIDENTIFIER NOT NULL
)
GO
ALTER TABLE [Classifications]
	ADD CONSTRAINT [ForeignKeyConstraint11]
	FOREIGN KEY (id_genre)
	REFERENCES [Genres] (id)
GO
ALTER TABLE [Classifications]
	ADD CONSTRAINT [ForeignKeyConstraint10]
	FOREIGN KEY (id_film)
	REFERENCES [Films] (code_barre)