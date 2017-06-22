USE [dbNet]
GO
SET IDENTITY_INSERT [dbo].[T_ROLE] ON 

INSERT [dbo].[T_ROLE] ([id], [role]) VALUES (1, N'ADMIN')
INSERT [dbo].[T_ROLE] ([id], [role]) VALUES (2, N'TRADUCTEUR')
INSERT [dbo].[T_ROLE] ([id], [role]) VALUES (3, N'UTILISATEUR')
SET IDENTITY_INSERT [dbo].[T_ROLE] OFF
SET IDENTITY_INSERT [dbo].[T_USER] ON 

INSERT [dbo].[T_USER] ([id], [pseudo], [email], [password], [roleID]) VALUES (7, N'aaa', N'a@a.a', N'a?U?????r3???????)??S??H^???{???', 1)
SET IDENTITY_INSERT [dbo].[T_USER] OFF
SET IDENTITY_INSERT [dbo].[T_ARTICLE] ON 

INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (1, 7, CAST(N'2017-06-22T21:45:12.577' AS DateTime), N'WAITING_TRANSLATION', 0)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (4, 7, CAST(N'2017-06-22T21:50:00.000' AS DateTime), N'VALIDATED', 15)
SET IDENTITY_INSERT [dbo].[T_ARTICLE] OFF
SET IDENTITY_INSERT [dbo].[T_LANGUAGE] ON 

INSERT [dbo].[T_LANGUAGE] ([id], [language]) VALUES (1, N'FRA')
INSERT [dbo].[T_LANGUAGE] ([id], [language]) VALUES (2, N'ENG')
INSERT [dbo].[T_LANGUAGE] ([id], [language]) VALUES (3, N'ESP')
SET IDENTITY_INSERT [dbo].[T_LANGUAGE] OFF
SET IDENTITY_INSERT [dbo].[T_RESOURCES] ON 

INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (1, N'lol', N'La plage', N'lol.png', 1)
SET IDENTITY_INSERT [dbo].[T_RESOURCES] OFF
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (4, 1)
SET IDENTITY_INSERT [dbo].[T_COMMENT_ARTICLE] ON 

INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (1, 7, 4, CAST(N'2017-06-22T21:54:36.213' AS DateTime), N'AHAA')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (2, 7, 4, CAST(N'2017-06-22T21:54:45.290' AS DateTime), N'AAAAAAA')
SET IDENTITY_INSERT [dbo].[T_COMMENT_ARTICLE] OFF
SET IDENTITY_INSERT [dbo].[T_TRANSLATION] ON 

INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (2, 4, 7, 1, N'LOREM IPSUM', N'LOVE LOREM')
SET IDENTITY_INSERT [dbo].[T_TRANSLATION] OFF
