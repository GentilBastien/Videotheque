/*
Script de déploiement pour MaVideotheque

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "MaVideotheque"
:setvar DefaultFilePrefix "MaVideotheque"
:setvar DefaultDataPath "C:\Users\fbelh\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"
:setvar DefaultLogPath "C:\Users\fbelh\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Création de $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de [dbo].[Acteurs]...';


GO
CREATE TABLE [dbo].[Acteurs] (
    [Id]  UNIQUEIDENTIFIER NOT NULL,
    [nom] TEXT             NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[Classifications]...';


GO
CREATE TABLE [dbo].[Classifications] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [id_film]  BIGINT           NOT NULL,
    [id_genre] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[Clients]...';


GO
CREATE TABLE [dbo].[Clients] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [nom]            TEXT             NOT NULL,
    [prenom]         TEXT             NOT NULL,
    [mail]           TEXT             NOT NULL,
    [telephone]      TEXT             NOT NULL,
    [adresse]        TEXT             NOT NULL,
    [date_naissance] DATE             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[Films]...';


GO
CREATE TABLE [dbo].[Films] (
    [code_barre]        BIGINT           NOT NULL,
    [realisateur]       UNIQUEIDENTIFIER NOT NULL,
    [titre]             TEXT             NOT NULL,
    [synopsis]          TEXT             NOT NULL,
    [annee]             INT              NULL,
    [duree]             INT              NULL,
    [image]             TEXT             NULL,
    [stock_total]       INT              NOT NULL,
    [exemplaires_loues] INT              NOT NULL,
    [commandes]         INT              NOT NULL,
    [prix]              FLOAT (53)       NOT NULL,
    PRIMARY KEY CLUSTERED ([code_barre] ASC)
);


GO
PRINT N'Création de [dbo].[Genres]...';


GO
CREATE TABLE [dbo].[Genres] (
    [Id]  UNIQUEIDENTIFIER NOT NULL,
    [nom] TEXT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[Langues]...';


GO
CREATE TABLE [dbo].[Langues] (
    [Id]     UNIQUEIDENTIFIER NOT NULL,
    [langue] TEXT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[Locations]...';


GO
CREATE TABLE [dbo].[Locations] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [id_client]  UNIQUEIDENTIFIER NOT NULL,
    [id_film]    BIGINT           NOT NULL,
    [rendu]      BIT              NOT NULL,
    [date_debut] DATE             NOT NULL,
    [date_fin]   DATE             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[Realisateurs]...';


GO
CREATE TABLE [dbo].[Realisateurs] (
    [Id]  UNIQUEIDENTIFIER NOT NULL,
    [nom] TEXT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[Roles]...';


GO
CREATE TABLE [dbo].[Roles] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [id_film]   BIGINT           NOT NULL,
    [id_acteur] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[Sous-titrages]...';


GO
CREATE TABLE [dbo].[Sous-titrages] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [id_film]   BIGINT           NOT NULL,
    [id_langue] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[Voix]...';


GO
CREATE TABLE [dbo].[Voix] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [id_film]   BIGINT           NOT NULL,
    [id_langue] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint11]...';


GO
ALTER TABLE [dbo].[Classifications]
    ADD CONSTRAINT [ForeignKeyConstraint11] FOREIGN KEY ([id_genre]) REFERENCES [dbo].[Genres] ([Id]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint10]...';


GO
ALTER TABLE [dbo].[Classifications]
    ADD CONSTRAINT [ForeignKeyConstraint10] FOREIGN KEY ([id_film]) REFERENCES [dbo].[Films] ([code_barre]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint1]...';


GO
ALTER TABLE [dbo].[Films]
    ADD CONSTRAINT [ForeignKeyConstraint1] FOREIGN KEY ([realisateur]) REFERENCES [dbo].[Realisateurs] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint2]...';


GO
ALTER TABLE [dbo].[Locations]
    ADD CONSTRAINT [ForeignKeyConstraint2] FOREIGN KEY ([id_client]) REFERENCES [dbo].[Clients] ([Id]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint3]...';


GO
ALTER TABLE [dbo].[Locations]
    ADD CONSTRAINT [ForeignKeyConstraint3] FOREIGN KEY ([id_film]) REFERENCES [dbo].[Films] ([code_barre]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint8]...';


GO
ALTER TABLE [dbo].[Roles]
    ADD CONSTRAINT [ForeignKeyConstraint8] FOREIGN KEY ([id_film]) REFERENCES [dbo].[Films] ([code_barre]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint9]...';


GO
ALTER TABLE [dbo].[Roles]
    ADD CONSTRAINT [ForeignKeyConstraint9] FOREIGN KEY ([id_acteur]) REFERENCES [dbo].[Acteurs] ([Id]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint6]...';


GO
ALTER TABLE [dbo].[Sous-titrages]
    ADD CONSTRAINT [ForeignKeyConstraint6] FOREIGN KEY ([id_film]) REFERENCES [dbo].[Films] ([code_barre]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint7]...';


GO
ALTER TABLE [dbo].[Sous-titrages]
    ADD CONSTRAINT [ForeignKeyConstraint7] FOREIGN KEY ([id_langue]) REFERENCES [dbo].[Langues] ([Id]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint4]...';


GO
ALTER TABLE [dbo].[Voix]
    ADD CONSTRAINT [ForeignKeyConstraint4] FOREIGN KEY ([id_film]) REFERENCES [dbo].[Films] ([code_barre]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint5]...';


GO
ALTER TABLE [dbo].[Voix]
    ADD CONSTRAINT [ForeignKeyConstraint5] FOREIGN KEY ([id_langue]) REFERENCES [dbo].[Langues] ([Id]);


GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
