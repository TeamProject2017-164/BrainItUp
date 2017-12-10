CREATE TABLE [dbo].[Answers]
(
	[AnswerId] INT NOT NULL IDENTITY (1,1),
    [QuestionId] INT NOT NULL, 
    [Content] NVARCHAR(50) NOT NULL, 
    [IsCorrect] BIT NOT NULL,
    CONSTRAINT [PK_AnswerId] PRIMARY KEY ([AnswerId],[QuestionId]),
	CONSTRAINT [FK_Answers_Questions] FOREIGN KEY ([QuestionId]) REFERENCES [Questions] ([QuestionId]),
)
