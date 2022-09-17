use master
go
alter database VotingSystem set single_user with rollback immediate
go
drop database VotingSystem
create database VotingSystem
alter database VotingSystem collate chinese_prc_ci_as
use VotingSystem
go

CREATE TABLE [dbo].[Subject] (
    [subject_id]      INT          NOT NULL,
    [subject_content] NTEXT        NULL,
    [select_mode]     NCHAR (2)    NULL,
    [deadline]        DATE         NULL,
    [votable]         VARCHAR (5)  DEFAULT ('true') NULL,
    [user_name]       VARCHAR (15) NULL,
    CONSTRAINT [PK_Subject] PRIMARY KEY ([subject_id]),
);


CREATE TABLE [dbo].[Item] (
    [item_id]      INT   IDENTITY (1, 1) NOT NULL,
    [subject_id]   INT   NOT NULL,
    [item_content] NTEXT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([item_id] ASC),
    CONSTRAINT [FK2] FOREIGN KEY ([subject_id]) REFERENCES [dbo].[Subject] ([subject_id])
);



CREATE TABLE [dbo].[UserInf] (
    [user_id]        INT          IDENTITY (1, 1) NOT NULL,
    [user_name]      VARCHAR (15) NOT NULL,
    [user_pwd]       VARCHAR (10) NULL,
    [user_status]    INT          DEFAULT ((0)) NULL,
    [user_email]     NTEXT        NULL,
    [user_phone]     VARCHAR (11) NULL,
    [user_sex]       NCHAR (1)    NULL,
    [user_birthday]  DATE         NULL,
    [user_residence] NTEXT        NULL,
    [user_photopath] NTEXT        NULL,
    [user_signature] NTEXT        NULL,
    CONSTRAINT [PK_UserInf] PRIMARY KEY CLUSTERED ([user_id] ASC),
);

CREATE TABLE [dbo].[UserVote] (
    [user_id]         INT NOT NULL,
    [votedSubject_id] INT NOT NULL,
    [votedItem_id]    INT NOT NULL,
    CONSTRAINT [FK4] FOREIGN KEY ([votedItem_id]) REFERENCES [dbo].[Item] ([item_id]),
    CONSTRAINT [FK3] FOREIGN KEY ([votedSubject_id]) REFERENCES [dbo].[Subject] ([subject_id]),
    CONSTRAINT [FK1] FOREIGN KEY ([user_id]) REFERENCES [dbo].[UserInf] ([user_id])
);

CREATE TABLE [dbo].[SystemInfo]
(
	[id] INT NOT NULL DEFAULT 1, 
	[regiterUserSum] INT NULL DEFAULT 0, 
    [publishedSubjectSum] NCHAR(10) NULL DEFAULT 0, 
    [visitSum] NCHAR(10) NULL DEFAULT 0, 
    CONSTRAINT [PK_SystemInfo] PRIMARY KEY ([id])
)
