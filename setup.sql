CREATE DATABASE testDb;
GO
USE testDb;
GO
CREATE TABLE [dbo].[Users] ( 
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Email]              NVARCHAR (MAX)  NOT NULL,
    [PasswordHash]       VARBINARY (MAX) NOT NULL,
    [PasswordSalt]       VARBINARY (MAX) NOT NULL,
    [VerificationToken]  NVARCHAR (MAX)  NULL,
    [VerifiedAt]         DATETIME2 (7)   NULL,
    [PasswordResetToken] NVARCHAR (MAX)  NULL,
    [ResetTokenExpires]  DATETIME2 (7)   NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Debts] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [UsersDebt] INT NOT NULL,
    [UserId]    INT NOT NULL,
    CONSTRAINT [PK_Debts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Debts_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Debts_UserId]
    ON [dbo].[Debts]([UserId] ASC);
GO
CREATE DATABASE Hangfire;