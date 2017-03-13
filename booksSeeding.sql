INSERT INTO [dbo].BookType(Type) Values('Fiction (خيال)')
INSERT INTO [dbo].BookType(Type) Values('Religion (دين)')
INSERT INTO [dbo].BookType(Type) Values('History (التاريخ)')
INSERT INTO [dbo].BookType(Type) Values('Mathematics (الرياضيات)')
INSERT INTO [dbo].BookType(Type) Values('Computer (الحاسوب)')
INSERT INTO [dbo].BookType(Type) Values('Religion (دين)')



INSERT INTO [dbo].[Authors] ([Fullname], [Biography]) VALUES (N'Zain Abdul Hady', N'His mother Zainab was the only daughter of a fisherman from Port Said. His father worked for Al Ahram newspaper in Cairo from 1969 to 1993. Zain is the eldest of six brothers.
In 1979, Abdul Hady obtained his B.A. (Bachelor of Arts) from the Department of Libraries and Information Science, the Faculty of Arts at Cairo University, with general mention very good. In 1995, he obtained his masters from the same department in the field of information science, the thesis of his master was titled Expert systems for reference services in IDSC Library. In 1998, he obtained his PhD degree in the field of information science; the thesis was titled The online databases industry in Egypt.
Dr. Abdul Hady holds the academic rank of Professor, and he chaired as Head of the Department of Libraries and Information science in the Faculty of Arts, Helwan University, in Cairo.[1] He also held the post of the Information and System Development Consultant at the Arab Administrative Development Organization from 2005 until October 2008, and between May 2011 and May 2012 worked as Chairman of public authority of the Egyptian National Library and Archives.')
INSERT INTO [dbo].[Authors] ([Fullname], [Biography]) VALUES (N'Samir Abdel Fattah', N'Samir Abdel Fattah is a Yemeni short story writer, novelist and playwright.[1] He moved to Sanaa in 1982, where he studied economics and business at university. He is known for his short story collections, the first of which, Ranin al-matar, appeared in 2002. He has published two more collections since. He has written two novels: Riwayat al-Sayyid Mim (2007) and Ibn al-nasr (2008). He has also written plays for the theatre.
Abdel Fattah is a versatile writer, with a particular interest in European literature, especially that of Russia. He often deals with existential themes and his work is regarded as part of the avant-garde in modern Yemeni literature. In 2009, he teamed up with fellow writers Nadia al-Kokabany, Wajdi al-Ahdal and Ali al-Moqri to form a literary group called Meeting Yesterday.[2] His work has been translated into Italian and was included in an anthology of contemporary Yemeni writers called Perle Dello Yemen (2009).')
INSERT INTO [dbo].[Authors] ([Fullname], [Biography]) VALUES (N'Salwa Bakr', N'Salwa Bakr (born 1949) is an Egyptian critic, novelist and author.[1] She was born in the Matariyya district in Cairo in 1949. Her father was a railway worker. She studied business at Ain Shams University, gaining a BA degree in 1972. She went on to earn another BA in literary criticism in 1976, before embarking on a career in journalism. She worked as a film and theatre critic for various Arabic newspapers and magazines. Bakr lived in Cyprus for a few years with her husband before returning to Egypt in the mid-1980s.
Bakr''s father died early, leaving her mother a poor widow. Her work often deals with the lives of the impoverished and the marginalized.[2] In 1985, she published her first collection of short stories, Zinat at the President''s Funeral, which was an immediate success. She has published several collections of short stories since. Her debut novel was called Wasf al-Bulbul (1993).
Salwa Bakr is married with children and lives in Cairo.')

INSERT INTO [dbo].[Books] ([Id], [Title], [Description]) VALUES (N'ArabicLetters', N'الحروف العربية', N'.هذا الكتاب يعلم الحروف العربية')
INSERT INTO [dbo].[Books] ([Id], [Title], [Description]) VALUES (N'ArabicWritting', N'الكتابة العربية', N'.هذا الكتاب يعلم الكتابة العربية')

INSERT INTO [dbo].BookAuthors(Author_Id, Book_Id) Values(1, 'ArabicLetters')
INSERT INTO [dbo].BookAuthors(Author_Id, Book_Id) Values(2, 'ArabicLetters')
INSERT INTO [dbo].BookAuthors(Author_Id, Book_Id) Values(2, 'ArabicWritting')
INSERT INTO [dbo].BookAuthors(Author_Id, Book_Id) Values(3, 'ArabicWritting')
