USE [dbNet]
GO
SET IDENTITY_INSERT [dbo].[T_ROLE] ON 

INSERT [dbo].[T_ROLE] ([id], [role]) VALUES (1, N'ADMIN')
INSERT [dbo].[T_ROLE] ([id], [role]) VALUES (2, N'TRADUCTEUR')
INSERT [dbo].[T_ROLE] ([id], [role]) VALUES (3, N'UTILISATEUR')
SET IDENTITY_INSERT [dbo].[T_ROLE] OFF
SET IDENTITY_INSERT [dbo].[T_USER] ON 

INSERT [dbo].[T_USER] ([id], [pseudo], [email], [password], [roleID]) VALUES (1, N'aaa', N'a@a.a', N'a?U?????r3???????)??S??H^???{???', 1)
INSERT [dbo].[T_USER] ([id], [pseudo], [email], [password], [roleID]) VALUES (2, N'test', N'test@test.fr', N'?????L}e?/???Z???O+?,?]l??
', 3)
INSERT [dbo].[T_USER] ([id], [pseudo], [email], [password], [roleID]) VALUES (3, N'Jean Le traducteur', N'jean@traduc.fr', N'?????L}e?/???Z???O+?,?]l??
', 2)
INSERT [dbo].[T_USER] ([id], [pseudo], [email], [password], [roleID]) VALUES (4, N'admin', N'admin@test.fr', N'?????L}e?/???Z???O+?,?]l??
', 1)
SET IDENTITY_INSERT [dbo].[T_USER] OFF
SET IDENTITY_INSERT [dbo].[T_ARTICLE] ON 

INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (1, 1, CAST(N'2017-06-22T21:45:12.577' AS DateTime), N'WAITING_TRANSLATION', 0)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (2, 1, CAST(N'2017-06-22T21:50:00.000' AS DateTime), N'VALIDATED', 420)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (3, 4, CAST(N'2017-06-22T23:11:00.000' AS DateTime), N'WAITING_VALIDATION', 0)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (4, 4, CAST(N'2017-06-22T23:12:00.000' AS DateTime), N'VALIDATED', 1022)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (5, 4, CAST(N'2017-06-22T23:13:18.000' AS DateTime), N'VALIDATED', 1)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (6, 4, CAST(N'2017-06-22T23:17:17.000' AS DateTime), N'WAITING_TRANSLATION', 0)
SET IDENTITY_INSERT [dbo].[T_ARTICLE] OFF
SET IDENTITY_INSERT [dbo].[T_LANGUAGE] ON 

INSERT [dbo].[T_LANGUAGE] ([id], [language]) VALUES (1, N'FRA')
INSERT [dbo].[T_LANGUAGE] ([id], [language]) VALUES (2, N'ENG')
INSERT [dbo].[T_LANGUAGE] ([id], [language]) VALUES (3, N'ESP')
SET IDENTITY_INSERT [dbo].[T_LANGUAGE] OFF
SET IDENTITY_INSERT [dbo].[T_RESOURCES] ON 

INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (1, N'lol', N'La plage', N'lol.png', 1)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (3, N'Rock you like a hurricane', N'SUPER', N'http://ekladata.com/uE3d2qpOQ4lsuRcj2rSBl77VSwI/Le-chimpanze.pdf', 2)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (4, N'Escargot', N'vie d''un escargot', N'http://ekladata.com/zKPls1UckWoH19rBF23KJf9gwBs/L-escargot-dossier.pdf', 3)
SET IDENTITY_INSERT [dbo].[T_RESOURCES] OFF
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (2, 1)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (4, 4)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (5, 3)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (6, 4)
SET IDENTITY_INSERT [dbo].[T_COMMENT_ARTICLE] ON 

INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (1, 1, 2, CAST(N'2017-06-22T21:54:36.213' AS DateTime), N'AHAA')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (2, 1, 2, CAST(N'2017-06-22T21:54:45.290' AS DateTime), N'AAAAAAA')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (3, 2, 4, CAST(N'2017-06-22T21:54:36.213' AS DateTime), N'Un test')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (4, 2, 4, CAST(N'2017-06-22T21:54:36.213' AS DateTime), N'Un test2')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (5, 3, 4, CAST(N'2017-06-22T21:54:36.213' AS DateTime), N'English please')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (6, 3, 5, CAST(N'2017-06-22T21:54:36.213' AS DateTime), N'English please')
SET IDENTITY_INSERT [dbo].[T_COMMENT_ARTICLE] OFF
SET IDENTITY_INSERT [dbo].[T_TRANSLATION] ON 

INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (1, 2, 1, 1, N'LOREM IPSUM', N'LOVE LOREM')
SET IDENTITY_INSERT [dbo].[T_TRANSLATION] OFF
