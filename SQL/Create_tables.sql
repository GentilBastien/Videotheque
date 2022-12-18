CREATE TABLE [Acteurs] (
    [id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [nom] NVARCHAR(MAX) NULL
) CREATE TABLE [Classifications] (
    [id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [id_film] BIGINT NOT NULL,
    [id_genre] UNIQUEIDENTIFIER NOT NULL
) CREATE TABLE [Clients] (
    [id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [nom] NVARCHAR(MAX) NOT NULL,
    [prenom] NVARCHAR(MAX) NOT NULL,
    [mail] NVARCHAR(MAX) NOT NULL,
    [telephone] NVARCHAR(MAX) NOT NULL,
    [adresse] NVARCHAR(MAX) NOT NULL,
    [date_naissance] DATE NOT NULL
) CREATE TABLE [Films] (
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
) CREATE TABLE [Genres] (
    [id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [nom] NVARCHAR(MAX) NOT NULL
) CREATE TABLE [Langues] (
    [id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [langue] NVARCHAR(MAX) NOT NULL
) CREATE TABLE [Locations] (
    [id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [id_client] UNIQUEIDENTIFIER NOT NULL,
    [id_film] BIGINT NOT NULL,
    [rendu] BIT NOT NULL,
    [date_debut] DATE NOT NULL,
    [date_fin] DATE NOT NULL
) CREATE TABLE [Realisateurs] (
    [id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [nom] NVARCHAR(MAX) NOT NULL
) CREATE TABLE [Roles] (
    [id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [id_film] BIGINT NOT NULL,
    [id_acteur] UNIQUEIDENTIFIER NOT NULL
) CREATE TABLE [Sous_titrages] (
    [id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [id_film] BIGINT NOT NULL,
    [id_langue] UNIQUEIDENTIFIER NOT NULL
) CREATE TABLE [Voix] (
    [id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [id_film] BIGINT NOT NULL,
    [id_langue] UNIQUEIDENTIFIER NOT NULL
) -- références
ALTER TABLE
    [Classifications]
ADD
    CONSTRAINT [FKC_classifications_films] FOREIGN KEY (id_film) REFERENCES [Films] (code_barre)
ALTER TABLE
    [Classifications]
ADD
    CONSTRAINT [FKC_classifications_genres] FOREIGN KEY (id_genre) REFERENCES [Genres] (id)
ALTER TABLE
    [Films]
ADD
    CONSTRAINT [FKC_films_realisateurs] FOREIGN KEY (realisateur) REFERENCES [Realisateurs] (id)
ALTER TABLE
    [Locations]
ADD
    CONSTRAINT [FKC_locations_clients] FOREIGN KEY (id_client) REFERENCES [Clients] (id)
ALTER TABLE
    [Locations]
ADD
    CONSTRAINT [FKC_locations_films] FOREIGN KEY (id_film) REFERENCES [Films] (code_barre)
ALTER TABLE
    [Roles]
ADD
    CONSTRAINT [FKC_roles_acteurs] FOREIGN KEY (id_acteur) REFERENCES [Acteurs] (id)
ALTER TABLE
    [Roles]
ADD
    CONSTRAINT [FKC_roles_films] FOREIGN KEY (id_film) REFERENCES [Films] (code_barre)
ALTER TABLE
    [Sous_titrages]
ADD
    CONSTRAINT [FKC_sous_titrages_films] FOREIGN KEY (id_film) REFERENCES [Films] (code_barre)
ALTER TABLE
    [Sous_titrages]
ADD
    CONSTRAINT [FKC_sous_titrages_langues] FOREIGN KEY (id_langue) REFERENCES [Langues] (id)
ALTER TABLE
    [Voix]
ADD
    CONSTRAINT [FKC_voix_films] FOREIGN KEY (id_film) REFERENCES [Films] (code_barre)
ALTER TABLE
    [Voix]
ADD
    CONSTRAINT [FKC_voix_langues] FOREIGN KEY (id_langue) REFERENCES [Langues] (id)