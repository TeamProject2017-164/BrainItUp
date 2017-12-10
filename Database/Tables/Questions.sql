CREATE TABLE [dbo].[Questions]
(
	[QuestionId] INT NOT NULL CONSTRAINT [PK_QuestionId] PRIMARY KEY IDENTITY (1,1), 
    [Content] NVARCHAR(100) NOT NULL
)
