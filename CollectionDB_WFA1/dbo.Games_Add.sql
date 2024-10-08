USE [VideoGameCollection]
GO
/****** Object:  StoredProcedure [dbo].[Games_Add]    Script Date: 9/25/2024 12:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<ZX_Yamato>
-- Create date: <8/18/24>
-- Description:	<Adds to Games table>
-- =============================================
ALTER PROCEDURE [dbo].[Games_Add]
	-- Add the parameters for the stored procedure here
	(
	@Name CHAR(60),
	@Franchise CHAR(40),
	@Developer CHAR(40),
	@Platform CHAR(40),
	@Released DATE,
	@Special_Edition BIT,
	@CiB BIT,
	@Played BIT,
	@Beaten BIT,
	@Favorite BIT
	)

AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Games VALUES (@Name, @Franchise, @Developer, @Platform, @Released, @Special_Edition, @CiB, @Played, @Beaten, @Favorite)
END
