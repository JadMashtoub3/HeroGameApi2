
USE master
GO

USE HeroDB



DROP TABLE IF EXISTS VILLAIN
DROP TABLE IF EXISTS HERO
DROP TABLE IF EXISTS GAME

CREATE TABLE GAME(
    GameId INT Primary KEY,
    Winner NVARCHAR(1)
    CHECK(Winner IN ('W','L')),
    [DateTime] Date
)

CREATE TABLE HERO(
    heroId INT PRIMARY KEY,
    CharacterName NVARCHAR(100),
    MAXDAMAGE INT NOT NULL, 
    MINDAMAGE INT NOT NULL
)

CREATE TABLE VILLAIN(
    VillainId INT PRIMARY KEY,
    VillanName NVARCHAR(100),
    VHealth INT
)

INSERT INTO Hero VALUES(1,'Hero1',6, 1)
INSERT INTO Hero VALUES (2,'Hero2', 10, 4)

INSERT INTO Villain VALUES(1,'Villain1',1)
INSERT INTO Villain VALUES(2,'Villain2',1)
INSERT INTO Villain VALUES(3,'Villain3',1)
INSERT INTO Villain VALUES(4,'Villain4',1)

INSERT INTO GAME VALUES(1,'W','1-11-2021')
INSERT INTO GAME VALUES(2,'W','1-11-2020')


Select * From Villain
SELECT * FROM Hero
SELECT * FROM GAME

IF OBJECT_ID('ADD_HERO') IS NOT NULL
DROP PROCEDURE ADD_HERO
GO
--add_hero
CREATE PROCEDURE ADD_HERO @pHEROID INT, @pNAME NVARCHAR(100), @pMINDICE INT, @pMAXDICE INT AS
BEGIN
    BEGIN TRY
        INSERT INTO HERO(heroID, [CharacterName], MINDAMAGE, MAXDAMAGE)
        VALUES (@pHEROID, @pNAME, @pMINDICE, @pMAXDICE);

    END TRY

    BEGIN CATCH
        IF ERROR_NUMBER() = 2627
            THROW 50010, 'Hero ID in use', 1
    END CATCH
END

GO

--Add_villain
IF OBJECT_ID('ADD_VILLAIN') IS NOT NULL
DROP PROCEDURE ADD_VILLAIN
GO

CREATE PROCEDURE ADD_VILLAIN @pVILLAINID INT, @pNAME NVARCHAR(100) AS
BEGIN
    BEGIN TRY
        INSERT INTO VILLAIN(villainID, [VillanName])
        VALUES(@pVILLAINID, @pNAME);
    END TRY

    BEGIN CATCH
        IF ERROR_NUMBER() = 2627
            THROW 50020, 'Villain ID in use', 1
    END CATCH
END

GO

-- update_hero
IF OBJECT_ID('UPDATE_HERO') IS NOT NULL
DROP PROCEDURE UPDATE_HERO
GO

CREATE PROCEDURE UPDATE_HERO @pHEROID INT, @pNAME NVARCHAR(100), @pMINDICE INT, @pMAXDICE INT AS
BEGIN
    BEGIN TRY
        UPDATE HERO
        SET [CharacterName] = @pNAME, MINDAMAGE = @pminDICE, MAXDAMAGE = @pMAXDICE
        WHERE heroID = @pHEROID;

        IF @@ROWCOUNT = 0
            THROW 50030, 'HeroID not found', 1
    END TRY

    BEGIN CATCH
        IF ERROR_NUMBER() = 50030
            THROW
    END CATCH
END

GO

--update_villain
IF OBJECT_ID('UPDATE_VILLAIN') IS NOT NULL
DROP PROCEDURE UPDATE_VILLAIN
GO

CREATE PROCEDURE UPDATE_VILLAIN @pVILLAINID INT, @pNAME NVARCHAR(100) AS
BEGIN
    BEGIN TRY
        UPDATE VILLAIN
        SET VillanName = @pNAME
        WHERE villainID = @pVILLAINID;

        IF @@ROWCOUNT = 0
            THROW 50040, 'VillainID not found', 1
    END TRY

    BEGIN CATCH
        IF ERROR_NUMBER() = 50040
            THROW
    END CATCH
END

GO

--delete_hero
IF OBJECT_ID('DELETE_HERO') IS NOT NULL
DROP PROCEDURE DELETE_HERO
GO

CREATE PROCEDURE DELETE_HERO @pHEROID INT AS
BEGIN
    BEGIN TRY
        DELETE FROM HERO
        WHERE heroID = @pHEROID;

        IF @@ROWCOUNT = 0
            THROW 50050, 'HeroID not found', 1
    END TRY

    BEGIN CATCH
        IF ERROR_NUMBER() = 50050
            THROW
    END CATCH
END

GO

--delete_villain
IF OBJECT_ID('DELETE_VILLAIN') IS NOT NULL
DROP PROCEDURE DELETE_VILLAIN
GO

CREATE PROCEDURE DELETE_VILLAIN @pVILLAINID INT AS
BEGIN
    BEGIN TRY
        DELETE FROM VILLAIN
        WHERE villainID = @pVILLAINID;

        IF @@ROWCOUNT = 0
            THROW 50060, 'VillainID not found', 1
    END TRY

    BEGIN CATCH
        IF ERROR_NUMBER() = 50060
            THROW
    END CATCH
END

GO