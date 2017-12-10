CREATE TABLE [dbo].[UserAnswers]
(
	[UserAnswerId] INT NOT NULL CONSTRAINT [PK_UserAnswers] PRIMARY KEY IDENTITY (1,1), 
    [UserId] INT NOT NULL,
    [AnswerId] INT NOT NULL, 
	[QuestionId] INT NOT NULL, 
    CONSTRAINT [FK_UsersAnswers_Users] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]),
	CONSTRAINT [FK_UsersAnswers_Answers] FOREIGN KEY ([AnswerId],[QuestionId]) REFERENCES [Answers] ([AnswerId], [QuestionId])
)
