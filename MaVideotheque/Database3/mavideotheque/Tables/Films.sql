CREATE TABLE [Films]
(
	[code_barre] BIGINT NOT NULL PRIMARY KEY, 
    [realisateur] UNIQUEIDENTIFIER NOT NULL, 
    [titre] NVARCHAR(MAX) NOT NULL, 
    [synopsis] NVARCHAR(MAX) NOT NULL, 
    [annee] INT NULL, 
    [duree] INT NULL, 
    [image] NVARCHAR(MAX) NULL, 
    [stock_total] INT NOT NULL, 
    [exemplaires_loues] INT NOT NULL, 
    [commandes] INT NOT NULL, 
    [prix] FLOAT NOT NULL
)
GO
ALTER TABLE [Films]
	ADD CONSTRAINT [ForeignKeyConstraint1] FOREIGN KEY (realisateur)
	REFERENCES [Realisateurs] (id)
	ON DELETE CASCADE
	ON UPDATE CASCADE
;