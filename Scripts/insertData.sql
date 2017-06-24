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
INSERT [dbo].[T_USER] ([id], [pseudo], [email], [password], [roleID]) VALUES (5, N'francois', N'fr@test.fr', N'?????L}e?/???Z???O+?,?]l??
', 3)
INSERT [dbo].[T_USER] ([id], [pseudo], [email], [password], [roleID]) VALUES (6, N'Le test', N'a@a.fr', N'?????L}e?/???Z???O+?,?]l??
', 3)
INSERT [dbo].[T_USER] ([id], [pseudo], [email], [password], [roleID]) VALUES (7, N'William', N'william.wakim@epita.fr', N'?????L}e?/???Z???O+?,?]l??
', 3)
SET IDENTITY_INSERT [dbo].[T_USER] OFF
SET IDENTITY_INSERT [dbo].[T_ARTICLE] ON 

INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (1, 1, CAST(N'2017-06-22T21:45:12.000' AS DateTime), N'WAITING_TRANSLATION', 0)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (2, 1, CAST(N'2017-06-22T21:50:00.000' AS DateTime), N'VALIDATED', 430)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (3, 4, CAST(N'2017-06-22T23:11:00.000' AS DateTime), N'WAITING_VALIDATION', 0)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (4, 4, CAST(N'2017-06-22T23:12:00.000' AS DateTime), N'VALIDATED', 1022)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (5, 4, CAST(N'2017-06-22T23:13:18.000' AS DateTime), N'VALIDATED', 1)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (6, 4, CAST(N'2017-06-22T23:17:17.000' AS DateTime), N'WAITING_TRANSLATION', 0)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (7, 4, CAST(N'2017-06-23T18:29:48.000' AS DateTime), N'WAITING_TRANSLATION', 12)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (8, 1, CAST(N'2017-06-23T18:30:50.000' AS DateTime), N'WAITING_VALIDATION', 154)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (9, 1, CAST(N'2017-05-05T16:25:57.000' AS DateTime), N'WAITING_TRANSLATION', 0)
SET IDENTITY_INSERT [dbo].[T_ARTICLE] OFF
SET IDENTITY_INSERT [dbo].[T_ARTICLE_LIKE] ON 

INSERT [dbo].[T_ARTICLE_LIKE] ([id], [userID], [articleID]) VALUES (1, 4, 2)
INSERT [dbo].[T_ARTICLE_LIKE] ([id], [userID], [articleID]) VALUES (2, 4, 7)
INSERT [dbo].[T_ARTICLE_LIKE] ([id], [userID], [articleID]) VALUES (3, 1, 8)
SET IDENTITY_INSERT [dbo].[T_ARTICLE_LIKE] OFF
SET IDENTITY_INSERT [dbo].[T_LANGUAGE] ON 

INSERT [dbo].[T_LANGUAGE] ([id], [language]) VALUES (1, N'FRA')
INSERT [dbo].[T_LANGUAGE] ([id], [language]) VALUES (2, N'ENG')
INSERT [dbo].[T_LANGUAGE] ([id], [language]) VALUES (3, N'ESP')
SET IDENTITY_INSERT [dbo].[T_LANGUAGE] OFF
SET IDENTITY_INSERT [dbo].[T_RESOURCES] ON 

INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (1, N'lol', N'La plage', N'http://geeko.lesoir.be/wp-content/uploads/sites/58/2015/08/lol.jpg', 1)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (3, N'Rock you like a hurricane', N'SUPER', N'http://ekladata.com/uE3d2qpOQ4lsuRcj2rSBl77VSwI/Le-chimpanze.pdf', 2)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (4, N'Escargot', N'vie d''un escargot', N'http://ekladata.com/zKPls1UckWoH19rBF23KJf9gwBs/L-escargot-dossier.pdf', 3)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (5, N'Rock', N'Rock is everything', N'http://media.torah-box.com/note-de-musique-juive-1724.jpg', 2)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (7, N'World', N'Music is great', N'http://mondoblog.org/wp-content/uploads/2016/07/musique.jpg', 1)
SET IDENTITY_INSERT [dbo].[T_RESOURCES] OFF
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (1, 3)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (2, 1)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (4, 4)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (5, 3)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (6, 4)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (8, 5)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (8, 7)
SET IDENTITY_INSERT [dbo].[T_COMMENT_ARTICLE] ON 

INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (1, 1, 2, CAST(N'2017-06-22T21:54:36.213' AS DateTime), N'AHAA')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (2, 1, 2, CAST(N'2017-06-22T21:54:45.290' AS DateTime), N'AAAAAAA')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (3, 2, 4, CAST(N'2017-06-22T21:54:36.213' AS DateTime), N'Un test')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (4, 2, 4, CAST(N'2017-06-22T21:54:36.213' AS DateTime), N'Un test2')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (5, 3, 4, CAST(N'2017-06-22T21:54:36.213' AS DateTime), N'English please')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (6, 3, 5, CAST(N'2017-06-22T21:54:36.213' AS DateTime), N'English please')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (7, 4, 2, CAST(N'2017-06-23T18:22:51.407' AS DateTime), N'test')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (8, 1, 8, CAST(N'2017-06-25T00:17:43.830' AS DateTime), N'This is the best articles in the history of articles !')
SET IDENTITY_INSERT [dbo].[T_COMMENT_ARTICLE] OFF
SET IDENTITY_INSERT [dbo].[T_TRANSLATION] ON 

INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (1, 2, 1, 1, N'LOREM IPSUM', N'LOVE LOREM')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (2, 7, 4, 2, N'pipo', N'Hello this is me ')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (7, 7, 3, 1, N'william', N'Bonjour c''est moi')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (17, 8, 3, 1, N'Si vous lisez régulièrement GQ, vous connaissez Mapstr, inventée en 2014 par le Français Sébastien Caron. L''appli cartographie vos endroits préférés par genre (restos, musées, bars, magasins...) avec des codes couleurs personnalisables. Des endroits que vous pouvez ensuite partager à loisir avec votre réseau. Pour la 36ème Fête de la musique (créée donc en... 1982), Mapstr propose une carte de l''Hexagone avec plus de 2000 adresses où artistes jazz, électro, musique classique, variété et autre reggae viendront à la rencontre du public. On ne vous promet pas que du bon, mais vous pouvez au moins savoir ce qui vous attend plutôt que d''espérer vainement trouver le bon spot.', N'Fete de la musique')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (23, 8, 3, 2, N'If you regularly read GQ, you know Mapstr, invented in 2014 by Frenchman Sébastien Caron. The app mapping your favorite places by genre (restaurants, museums, bars, shops ...) with customizable color codes. Places you can then share at leisure with your network. For the 36th Fête de la Musique (created in 1982), Mapstr proposes a map of France with more than 2000 addresses where jazz, electro, classical music, variety and other reggae will come to meet the public. We do not promise you that good, but you can at least know what awaits you rather than hoping in vain to find the right spot.', N'Music Festival')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (24, 8, 3, 3, N'Si se lee con regularidad GQ, sabes Mapstr, inventado en 2014 por el francés Sébastien Caron. La aplicación de mapeo de sus lugares preferidos por tipo (restaurantes, museos, bares, tiendas ...) con los códigos de color personalizable. Lugares a los que pueden compartir con su red en el ocio. Para el 36º Festival de Música (así creada en 1982 ...) Mapstr ofrece la tarjeta de hexágono con más de 2.000 direcciones donde los artistas de jazz, electro, música clásica, la variedad y otra de reggae vendrá al encuentro del público. No prometemos que bueno, pero al menos puede saber lo que le espera en lugar de esperar en vano de encontrar el lugar correcto.', N'Fiesta de la Música')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (26, 9, 1, 1, N'Une petite machine aux airs de smartphone qui lui permet de mesurer en direct son taux de sucre dans le sang, comme on peut suivre les fluctuations de la bourse.  L’auteur de Diabétiquement vôtre, essai salué sur le syndrome qui l’affecte, s’apprête à sortir Les choses qu’on ne peut dire à personne, très beau nouvel album à découvrir en avant-première sur le site de GQ. Pour accompagner cette écoute, on a demandé à Julien Gasc, auteur avec Kiss Me You Fool! d’un des plus beaux disques de 2016, de jouer à l’apprenti journaliste. Le membre du groupe Aquaserge connaît le patron du label Tricatel depuis une décennie et, par-delà les références communes, partage avec lui une idée exigeante de la musique - sensible, on l’espère, dans cette libre conversation.', N'Le nouvel album de Bertrand Burgalat')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (28, 9, 1, 2, N'A small smartphone machine that allows it to measure its blood sugar levels directly, as can be tracked fluctuations in the stock market. The author of Diabetically yours, a test greeted on the syndrome that affects it, is about to leave The things that can not be said to anyone, very beautiful new album to be previewed on the site of GQ. To accompany this listening, we asked Julien Gasc, author with Kiss Me You Fool! Of one of the most beautiful records of 2016, to play the apprentice journalist. The band member Aquaserge has known the boss of the label Tricatel for a decade and, beyond the common references, shares with him a demanding idea of ??music - hopefully, sensitive in this free conversation.', N'Bertrand Burgalat''s new album')
SET IDENTITY_INSERT [dbo].[T_TRANSLATION] OFF
