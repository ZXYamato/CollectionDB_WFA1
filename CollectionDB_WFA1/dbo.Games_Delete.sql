USE [VideoGameCollection]
GO
/****** Object:  StoredProcedure [dbo].[Games_Delete]    Script Date: 9/20/2024 2:51:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<ZX_Yamato>
-- Create date: <8/18/24>
-- Description:	<Deletes from Games table>
-- =============================================
ALTER PROCEDURE [dbo].[Games_Delete]
	-- Add the parameters for the stored procedure here
	(
	@Name CHAR
	)

AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Games WHERE Games.Name = @Name;
END
