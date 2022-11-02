/*
Script de déploiement pour MaVideothequeFinale

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "MaVideothequeFinale"
:setvar DefaultFilePrefix "MaVideothequeFinale"
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
    [id]  UNIQUEIDENTIFIER NOT NULL,
    [nom] NVARCHAR (MAX)   NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de [dbo].[Classifications]...';


GO
CREATE TABLE [dbo].[Classifications] (
    [id]       UNIQUEIDENTIFIER NOT NULL,
    [id_film]  BIGINT           NOT NULL,
    [id_genre] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de [dbo].[Clients]...';


GO
CREATE TABLE [dbo].[Clients] (
    [id]             UNIQUEIDENTIFIER NOT NULL,
    [nom]            NVARCHAR (MAX)   NOT NULL,
    [prenom]         NVARCHAR (MAX)   NOT NULL,
    [mail]           NVARCHAR (MAX)   NOT NULL,
    [telephone]      NVARCHAR (MAX)   NOT NULL,
    [adresse]        NVARCHAR (MAX)   NOT NULL,
    [date_naissance] NVARCHAR (MAX)   NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de [dbo].[Films]...';


GO
CREATE TABLE [dbo].[Films] (
    [code_barre]        BIGINT           NOT NULL,
    [realisateur]       UNIQUEIDENTIFIER NOT NULL,
    [titre]             NVARCHAR (MAX)   NOT NULL,
    [synopsis]          NVARCHAR (MAX)   NOT NULL,
    [annee]             INT              NULL,
    [duree]             INT              NULL,
    [image]             NVARCHAR (MAX)   NULL,
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
    [id]  UNIQUEIDENTIFIER NOT NULL,
    [nom] NVARCHAR (MAX)   NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de [dbo].[Langues]...';


GO
CREATE TABLE [dbo].[Langues] (
    [id]     UNIQUEIDENTIFIER NOT NULL,
    [langue] NVARCHAR (MAX)   NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de [dbo].[Locations]...';


GO
CREATE TABLE [dbo].[Locations] (
    [id]         UNIQUEIDENTIFIER NOT NULL,
    [id_client]  UNIQUEIDENTIFIER NOT NULL,
    [id_film]    BIGINT           NOT NULL,
    [rendu]      BIT              NOT NULL,
    [date_debut] DATE             NOT NULL,
    [date_fin]   DATE             NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de [dbo].[Realisateurs]...';


GO
CREATE TABLE [dbo].[Realisateurs] (
    [id]  UNIQUEIDENTIFIER NOT NULL,
    [nom] NVARCHAR (MAX)   NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de [dbo].[Roles]...';


GO
CREATE TABLE [dbo].[Roles] (
    [id]        UNIQUEIDENTIFIER NOT NULL,
    [id_film]   BIGINT           NOT NULL,
    [id_acteur] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de [dbo].[Sous_titrages]...';


GO
CREATE TABLE [dbo].[Sous_titrages] (
    [id]        UNIQUEIDENTIFIER NOT NULL,
    [id_film]   BIGINT           NOT NULL,
    [id_langue] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de [dbo].[Voix]...';


GO
CREATE TABLE [dbo].[Voix] (
    [id]        UNIQUEIDENTIFIER NOT NULL,
    [id_film]   BIGINT           NOT NULL,
    [id_langue] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint11]...';


GO
ALTER TABLE [dbo].[Classifications]
    ADD CONSTRAINT [ForeignKeyConstraint11] FOREIGN KEY ([id_genre]) REFERENCES [dbo].[Genres] ([id]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint10]...';


GO
ALTER TABLE [dbo].[Classifications]
    ADD CONSTRAINT [ForeignKeyConstraint10] FOREIGN KEY ([id_film]) REFERENCES [dbo].[Films] ([code_barre]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint1]...';


GO
ALTER TABLE [dbo].[Films]
    ADD CONSTRAINT [ForeignKeyConstraint1] FOREIGN KEY ([realisateur]) REFERENCES [dbo].[Realisateurs] ([id]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint2]...';


GO
ALTER TABLE [dbo].[Locations]
    ADD CONSTRAINT [ForeignKeyConstraint2] FOREIGN KEY ([id_client]) REFERENCES [dbo].[Clients] ([id]);


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
    ADD CONSTRAINT [ForeignKeyConstraint9] FOREIGN KEY ([id_acteur]) REFERENCES [dbo].[Acteurs] ([id]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint6]...';


GO
ALTER TABLE [dbo].[Sous_titrages]
    ADD CONSTRAINT [ForeignKeyConstraint6] FOREIGN KEY ([id_film]) REFERENCES [dbo].[Films] ([code_barre]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint7]...';


GO
ALTER TABLE [dbo].[Sous_titrages]
    ADD CONSTRAINT [ForeignKeyConstraint7] FOREIGN KEY ([id_langue]) REFERENCES [dbo].[Langues] ([id]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint4]...';


GO
ALTER TABLE [dbo].[Voix]
    ADD CONSTRAINT [ForeignKeyConstraint4] FOREIGN KEY ([id_film]) REFERENCES [dbo].[Films] ([code_barre]);


GO
PRINT N'Création de [dbo].[ForeignKeyConstraint5]...';


GO
ALTER TABLE [dbo].[Voix]
    ADD CONSTRAINT [ForeignKeyConstraint5] FOREIGN KEY ([id_langue]) REFERENCES [dbo].[Langues] ([id]);


GO
-- Étape de refactorisation pour mettre à jour le serveur cible avec des journaux de transactions déployés

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '02b2dc8d-ee31-486c-8357-856e8f553025')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('02b2dc8d-ee31-486c-8357-856e8f553025')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '120c5e29-5885-4d26-b59b-6a98932d4a0a')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('120c5e29-5885-4d26-b59b-6a98932d4a0a')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '11499e10-859a-49d4-a839-66ff9c92e0d8')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('11499e10-859a-49d4-a839-66ff9c92e0d8')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a7f21674-6823-432e-a6bc-7e4f5c5efdc8')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a7f21674-6823-432e-a6bc-7e4f5c5efdc8')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c6ad2b04-5342-4592-847f-bb9050b8c56e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c6ad2b04-5342-4592-847f-bb9050b8c56e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '73eea60e-03f0-459d-b859-bc6fd280db60')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('73eea60e-03f0-459d-b859-bc6fd280db60')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '9d0b5f5d-eff1-4efe-b89a-a0c17d8ea1fd')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('9d0b5f5d-eff1-4efe-b89a-a0c17d8ea1fd')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '0b6b4a0f-65b6-4cd9-b505-7ee9697a1880')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('0b6b4a0f-65b6-4cd9-b505-7ee9697a1880')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '32dfcf56-355e-40c7-8ffb-fca1d5a1b87e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('32dfcf56-355e-40c7-8ffb-fca1d5a1b87e')

GO

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
