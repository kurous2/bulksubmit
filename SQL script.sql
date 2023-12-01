USE [AstekTest]
GO

/****** Object:  StoredProcedure [dbo].[SPInsertData]    Script Date: 11/23/2023 3:50:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- STORE PROCEDURE
-- =============================================
CREATE PROCEDURE [dbo].[SPInsertData]
    @PersonalData dbo.PersonalType READONLY
AS
BEGIN
    SET NOCOUNT ON;
	SET IDENTITY_INSERT dbo.tblM_Gender ON;
    INSERT INTO dbo.tblM_Gender (Id, Nama)
    SELECT DISTINCT
		CASE WHEN IdGender = 1 THEN 1 ELSE 2 END AS Id,
        CASE WHEN IdGender = 1 THEN 'Pria' ELSE 'Wanita' END
    FROM @PersonalData

    INSERT INTO dbo.tblM_Hobi (Id, Nama)
    SELECT DISTINCT
        IdHobi,
        CASE
            WHEN IdHobi = 'A' THEN 'Sebak Bola'
            WHEN IdHobi = 'B' THEN 'Badminton'
            WHEN IdHobi = 'C' THEN 'Tennis'
            WHEN IdHobi = 'D' THEN 'Renang'
            WHEN IdHobi = 'E' THEN 'Bersepeda'
        END
    FROM @PersonalData

    INSERT INTO dbo.tblT_Personal (Nama, IdGender, IdHobi, Umur)
    SELECT Nama, IdGender, IdHobi, Umur FROM @PersonalData

    -- Insert into tblT_Umur (assuming Total is calculated)
    INSERT INTO dbo.tblT_Umur (Age, Total)
    SELECT DISTINCT Umur, COUNT(Umur) FROM @PersonalData GROUP BY Umur
END
GO

select * from tblM_Gender
select * from tblM_Hobi
select * from tblT_Personal
select * from tblT_Umur

-- =============================================
-- UDTT
-- =============================================

USE [AstekTest]
GO

/****** Object:  UserDefinedTableType [dbo].[PersonalType]    Script Date: 11/23/2023 3:53:27 PM ******/
CREATE TYPE [dbo].[PersonalType] AS TABLE(
	[Nama] [nvarchar](255) NULL,
	[IdGender] [int] NULL,
	[IdHobi] [char](1) NULL,
	[Umur] [int] NULL
)
GO



