USE [VideoGameCollection]
GO
/****** Object:  StoredProcedure [dbo].[Col_Search]    Script Date: 10/2/2024 12:47:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<ZX_Yamato>
-- Create date: <8/18/24>
-- Description:	<Edits Entry in Games table>
-- =============================================
CREATE PROCEDURE [dbo].[Games_Update]
	-- Add the parameters for the stored procedure here
	(
	@Name CHAR = NULL,
	@Franchise CHAR = NULL,
	@Developer CHAR = NULL,
	@Platform CHAR = NULL,
	@Released DATE = NULL,
	@Special_Edition BIT = NULL,
	@CiB BIT = NULL,
	@Played BIT = NULL,
	@Beaten BIT = NULL,
	@Favorite BIT = NULL
	)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert original data into temp table
	
	UPDATE Games
	SET Name = @Name, Franchise = @Franchise, Developer = @Developer, Platform = @Platform, Released = @Released, 
	Special_Edition = @Special_Edition, CiB = @CiB, Played = @Played, Beaten = @Beaten, Favorite = @Favorite

END
