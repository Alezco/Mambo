USE [dbNet]
GO
SET IDENTITY_INSERT [dbo].[T_ROLE] ON 

INSERT [dbo].[T_ROLE] ([id], [role]) VALUES (1, N'ADMIN')
INSERT [dbo].[T_ROLE] ([id], [role]) VALUES (2, N'TRADUCTEUR')
INSERT [dbo].[T_ROLE] ([id], [role]) VALUES (3, N'UTILISATEUR')
SET IDENTITY_INSERT [dbo].[T_ROLE] OFF
SET IDENTITY_INSERT [dbo].[T_USER] ON 

INSERT [dbo].[T_USER] ([id], [pseudo], [email], [password], [roleID]) VALUES (1, N'Admin', N'admin@test.fr', N'?????L}e?/???Z???O+?,?]l??
', 1)
INSERT [dbo].[T_USER] ([id], [pseudo], [email], [password], [roleID]) VALUES (2, N'Translator', N'translator@test.fr', N'?????L}e?/???Z???O+?,?]l??
', 2)
INSERT [dbo].[T_USER] ([id], [pseudo], [email], [password], [roleID]) VALUES (3, N'User1', N'user1@test.fr', N'?????L}e?/???Z???O+?,?]l??
', 3)
INSERT [dbo].[T_USER] ([id], [pseudo], [email], [password], [roleID]) VALUES (4, N'User2', N'user2@test.fr', N'?????L}e?/???Z???O+?,?]l??
', 3)
SET IDENTITY_INSERT [dbo].[T_USER] OFF
SET IDENTITY_INSERT [dbo].[T_ARTICLE] ON 

INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (1, 1, CAST(N'2017-06-28T18:41:29.887' AS DateTime), N'VALIDATED', 11)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (2, 1, CAST(N'2017-06-28T18:47:27.070' AS DateTime), N'VALIDATED', 2)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (3, 1, CAST(N'2017-06-28T19:01:28.850' AS DateTime), N'WAITING_TRANSLATION', 0)
INSERT [dbo].[T_ARTICLE] ([id], [adminID], [creationDate], [status], [nbViews]) VALUES (4, 1, CAST(N'2017-06-28T19:07:54.130' AS DateTime), N'WAITING_TRANSLATION', 0)
SET IDENTITY_INSERT [dbo].[T_ARTICLE] OFF
SET IDENTITY_INSERT [dbo].[T_ARTICLE_LIKE] ON 

INSERT [dbo].[T_ARTICLE_LIKE] ([id], [userID], [articleID]) VALUES (1, 1, 1)
INSERT [dbo].[T_ARTICLE_LIKE] ([id], [userID], [articleID]) VALUES (2, 3, 1)
INSERT [dbo].[T_ARTICLE_LIKE] ([id], [userID], [articleID]) VALUES (3, 4, 1)
SET IDENTITY_INSERT [dbo].[T_ARTICLE_LIKE] OFF
SET IDENTITY_INSERT [dbo].[T_LANGUAGE] ON 

INSERT [dbo].[T_LANGUAGE] ([id], [language]) VALUES (1, N'FRA')
INSERT [dbo].[T_LANGUAGE] ([id], [language]) VALUES (2, N'ENG')
INSERT [dbo].[T_LANGUAGE] ([id], [language]) VALUES (3, N'ESP')
SET IDENTITY_INSERT [dbo].[T_LANGUAGE] OFF
SET IDENTITY_INSERT [dbo].[T_RESOURCES] ON 

INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (1, N'Musique', N'Logo musique', N'http://www.lattesloisirsculture.fr/images/llc/musique.jpg', 1)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (2, N'Guns N''Roses', N'Guns logo FR', N'http://1000logos.net/wp-content/uploads/2017/02/Guns-N%E2%80%99-Roses-Logo.png', 1)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (3, N'Guns N''Roses', N'Guns logo EN', N'http://1000logos.net/wp-content/uploads/2017/02/Guns-N%E2%80%99-Roses-Logo.png', 2)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (4, N'Guns N''Roses', N'Guns logo ES', N'http://1000logos.net/wp-content/uploads/2017/02/Guns-N%E2%80%99-Roses-Logo.png', 3)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (5, N'Guns N''Roses', N'Guns partition FR', N'http://www.uncleguns.elcom.ru/songbook/songbook01.pdf', 1)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (6, N'Guns N''Roses', N'Guns partition EN', N'http://www.uncleguns.elcom.ru/songbook/songbook01.pdf', 2)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (7, N'Guns N''Roses', N'Guns partition ES', N'http://www.uncleguns.elcom.ru/songbook/songbook01.pdf', 3)
INSERT [dbo].[T_RESOURCES] ([id], [title], [description], [path], [languageID]) VALUES (8, N'Eagles album', N'Eagles album logo', N'https://s-media-cache-ak0.pinimg.com/originals/40/80/b8/4080b8d101a9146ff3502de2f8cfa386.jpg', 2)
SET IDENTITY_INSERT [dbo].[T_RESOURCES] OFF
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (1, 1)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (2, 2)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (2, 3)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (2, 4)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (2, 5)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (2, 6)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (2, 7)
INSERT [dbo].[T_ARTICLE_RESOURCES] ([articleID], [resourceID]) VALUES (4, 8)
SET IDENTITY_INSERT [dbo].[T_COMMENT_ARTICLE] ON 

INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (1, 1, 1, CAST(N'2017-06-28T19:18:47.113' AS DateTime), N'Great article !')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (2, 1, 1, CAST(N'2017-06-28T19:18:58.420' AS DateTime), N'I''ll go to this next year')
INSERT [dbo].[T_COMMENT_ARTICLE] ([id], [userID], [articleID], [creationDate], [commentContent]) VALUES (3, 3, 1, CAST(N'2017-06-28T19:19:28.640' AS DateTime), N'Intéressant')
SET IDENTITY_INSERT [dbo].[T_COMMENT_ARTICLE] OFF
SET IDENTITY_INSERT [dbo].[T_TRANSLATION] ON 

INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (1, 1, 1, 1, N'Créée en 1982 par Jack Lang, alors ministre de la culture, et le compositeur et critique musical Maurice Fleuret (1932-1990), la Fête de la musique est devenue une institution qui continue de résonner trente-cinq ans plus tard dans toute la France et même au-delà de ses frontières. En bas de chez soi, sur une place, au détour d’un carrefour, dans un jardin, des groupes amateurs de reprises de chansons pop et rock, du jazz, de la musique classique, des fanfares, des chorales partagent leur passion, mais aussi des vedettes participent à cet événement dont la gratuité est le maître-mot. Pour l’édition 2017, le site Internet de la Fête de la musique recense plus de 2 000 concerts en France. Voici une sélection, évidemment non exhaustive, de rendez-vous organisés à Paris et ses environs, Lyon, Marseille et Toulouse.
En savoir plus sur http://www.lemonde.fr/musiques/article/2017/06/21/fete-de-la-musique-2017_5148543_1654986.html#mlRMu6kuCOdI1eUX.99', N'Fête de la musique')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (2, 1, 2, 2, N'Created in 1982 by Jack Lang, then Minister of Culture, and composer and music critic Maurice Fleuret (1932-1990), the Festival of Music became an institution that continued to resonate thirty-five years later throughout France And even beyond its borders. At the bottom of the house, in a square, at the turn of a crossroads, in a garden, bands enjoying pop and rock songs, jazz, classical music, marching bands, choirs share their passion, but Also celebrities participate in this event of which the free word is the key word. For the 2017 edition, the website of the Fête de la musique lists over 2,000 concerts in France. Here is a selection, obviously not exhaustive, of appointments organized in Paris and its surroundings, Lyon, Marseille and Toulouse. Learn more about http://www.lemonde.fr/musiques/article/2017/06/21/fete-de-la-musique-2017_5148543_1654986.html#mlRMu6kuCOdI1eUX.99', N'Music party')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (3, 2, 1, 1, N'C''est l''une des histoires les plus mystérieuses du rock. Celle d''un groupe qui a vendu 100 millions d''albums et qui n''a pourtant vécu que six ans. Celle d''un autiste qu''on a pris pour une diva. Celle de cinq rock stars sans lesquelles le grunge de Kurt Cobain n''existerait pas. Il n''y a qu''une chose de vraie dans ce qu''on dit des Guns N'' Roses : avec eux, on ne savait jamais ce qui allait se passer. À quelle heure arriveraient-ils sur scène ? Six heures après ? Jamais ? Et qu''a-t-il pu se passer ce 17 juillet 1993, quand, après avoir joué devant 70 000 personnes à Buenos Aires, concert qui clôturait deux ans et demi de tournée, l''une des plus longues qu''un groupe ait jamais connues – 195 dates, dans 27 pays –, ils jurent, en pleine gloire, de ne plus jamais remonter sur scène ensemble ?', N'Guns''n''Roses')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (4, 3, 1, 1, N'"Viva Vendetta !", souffle Billie Joe Armstrong sur Bang Bang, l''un des titres les plus forts de Revolution Radio, nouvel album de Green Day, disponible le 7 octobre. Un vent de rébellion s''apprête à souffler dans vos bronches. Ce disque fort et très politisé puise dans les conflits sociaux qui agitent la société américaine. Notamment, les violences policières qui ont amené au mouvement Black Lives Matter, et la guerre, thème cher au trio californien, qui n''a jamais été tendre envers les puissants. Revolution Radio s''inscrit ainsi dans son temps, mais propose un retour à un son punk très classique, sans surprise mais efficace.', N'Revolution Radio')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (5, 2, 2, 2, N'This is one of the most mysterious stories of rock. That of a group that sold 100 million albums and who has lived only six years. That of an autistic one that was taken for a diva. That of five rock stars without which the grunge of Kurt Cobain would not exist. There is only one thing in Guns N ''Roses that is true: with them you never knew what was going to happen. What time would they arrive on stage? Six hours later? Never ? And what could have happened on July 17, 1993, when, having played before 70,000 people in Buenos Aires, a concert that ended two and a half years of touring, one of the longest Never known - 195 dates, in 27 countries - they swear, in full glory, never to go back on stage together?', N'Guns''n''roses')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (6, 2, 2, 3, N'Esta es una de las más misteriosas historias de roca. La de una banda que ha vendido 100 millones de discos y tiene todavía vivían seis años. La de un autista que tomó para una diva. Sin la cual no existirían este cinco estrellas de rock del grunge Kurt Cobain. Sólo hay una cosa en verdad lo que dicen de Guns N ''Roses con ellos, nunca se sabía lo que iba a pasar. ¿A qué hora llegaron en el escenario? Seis horas? Jamas ? Y lo que tenía que ocurrir Esta 17ª julio de 1993, cuando, después de jugar ante 70.000 personas en el concierto Buenos Aires que cerró dos años y medio recorrido, uno de los más largos que un grupo tiene jamás conocido - 195 fechas en 27 países - juran en plena gloria, de no volver juntos en el escenario?', N'Guns''n''roses')
INSERT [dbo].[T_TRANSLATION] ([id], [articleID], [translatorID], [language], [translationArticleContent], [translationArticleTitle]) VALUES (7, 4, 1, 2, N'With Hotel California, the Eagles sought to capture the excesses and self-destructive behavior that had become status quo in the rock world. It was a scene they were uniquely qualified to address. Their previous album, 1975''s One of These Nights, had spawned three Top 10 singles, and their greatest-hits album sold in such stratospheric numbers – on its way to becoming the best-selling album of the 20th century in the United States – that the RIAA had to invent to platinum certification. "We were under the microscope," Glenn Frey said of the time. "Everybody was going to look at the next record we made and pass judgment. Don [Henley] and I were going, ''Man, this better be good.''"', N'Hotel California')
SET IDENTITY_INSERT [dbo].[T_TRANSLATION] OFF
