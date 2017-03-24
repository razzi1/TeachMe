use Noon
go

delete ContentPages
delete Chapters
delete MediaAuthors
delete Authors
delete Media
delete Publishers
delete Categories
delete Languages
delete Parents
delete Students

INSERT INTO [dbo].Parents([Username], [EncryptedPassword], Fullname, Email) Values(N'razzi', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Rachid Azzi', 'rachid.azzi@yahoo.com')
INSERT INTO [dbo].Parents([Username], [EncryptedPassword], Fullname, Email) Values(N'lseridi', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Loqman Seridi', 'loqman.seridi@gmail.com')

declare @parentId1 int = (select Id from Parents where username = N'razzi')
declare @parentId2 int = (select Id from Parents where username = N'lseridi')

INSERT INTO [dbo].Students([Username], [EncryptedPassword], Fullname, Email, ParentId) Values(N'yazzi', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Yasmine Azzi', 'yasmine.azzi@gmail.com', @parentId1)
INSERT INTO [dbo].Students([Username], [EncryptedPassword], Fullname, Email, ParentId) Values(N'yazzi2', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Youcef Azzi', 'yasmine.azzi@gmail.com', @parentId1)
INSERT INTO [dbo].Students([Username], [EncryptedPassword], Fullname, Email, ParentId) Values(N'mseridi', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Meriem Seridi', 'meriem.seridi@cool.com', @parentId2)

INSERT INTO [dbo].Categories([Type]) Values(N'Language (اللغة)')
INSERT INTO [dbo].Categories([Type]) Values(N'Fiction (خيال)')
INSERT INTO [dbo].Categories([Type]) Values(N'Religion (دين)')
INSERT INTO [dbo].Categories([Type]) Values(N'History (التاريخ)')
INSERT INTO [dbo].Categories([Type]) Values(N'Mathematics (الرياضيات)')
INSERT INTO [dbo].Categories([Type]) Values(N'Computer (الحاسوب)')

declare @categoryId1 int = (select Id from Categories where [Type] = N'Language (اللغة)')
declare @categoryId2 int = (select Id from Categories where [Type] = N'Religion (دين)')

INSERT INTO [dbo].Languages(Name) Values(N'Arabic (العربية)')
INSERT INTO [dbo].Languages(Name) Values(N'English (الإنجليزية)')
INSERT INTO [dbo].Languages(Name) Values(N'French (الفرنسية)')

declare @languageId1 int = (select Id from Languages where Name = N'Arabic (العربية)')
declare @languageId2 int = (select Id from Languages where Name = N'English (الإنجليزية)')

declare @MediaTypeText int = 0
declare @MediaTypeHtml int = 1
declare @MediaTypeImage int = 2
declare @MediaTypeVideo int = 3


INSERT INTO [dbo].[Authors] ([Fullname], [Biography]) VALUES (N'زين الدين محمد عبد الهادي', N'His mother Zainab was the only daughter of a fisherman from Port Said. His father worked for Al Ahram newspaper in Cairo from 1969 to 1993. Zain is the eldest of six brothers.
In 1979, Abdul Hady obtained his B.A. (Bachelor of Arts) from the Department of Libraries and Information Science, the Faculty of Arts at Cairo University, with general mention very good. In 1995, he obtained his masters from the same department in the field of information science, the thesis of his master was titled Expert systems for reference services in IDSC Library. In 1998, he obtained his PhD degree in the field of information science; the thesis was titled The online databases industry in Egypt.
Dr. Abdul Hady holds the academic rank of Professor, and he chaired as Head of the Department of Libraries and Information science in the Faculty of Arts, Helwan University, in Cairo.[1] He also held the post of the Information and System Development Consultant at the Arab Administrative Development Organization from 2005 until October 2008, and between May 2011 and May 2012 worked as Chairman of public authority of the Egyptian National Library and Archives.')
INSERT INTO [dbo].[Authors] ([Fullname], [Biography]) VALUES (N'Samir Abdel Fattah', N'Samir Abdel Fattah is a Yemeni short story writer, novelist and playwright.[1] He moved to Sanaa in 1982, where he studied economics and business at university. He is known for his short story collections, the first of which, Ranin al-matar, appeared in 2002. He has published two more collections since. He has written two novels: Riwayat al-Sayyid Mim (2007) and Ibn al-nasr (2008). He has also written plays for the theatre.
Abdel Fattah is a versatile writer, with a particular interest in European literature, especially that of Russia. He often deals with existential themes and his work is regarded as part of the avant-garde in modern Yemeni literature. In 2009, he teamed up with fellow writers Nadia al-Kokabany, Wajdi al-Ahdal and Ali al-Moqri to form a literary group called Meeting Yesterday.[2] His work has been translated into Italian and was included in an anthology of contemporary Yemeni writers called Perle Dello Yemen (2009).')
INSERT INTO [dbo].[Authors] ([Fullname], [Biography]) VALUES (N'Salwa Bakr', N'Salwa Bakr (born 1949) is an Egyptian critic, novelist and author.[1] She was born in the Matariyya district in Cairo in 1949. Her father was a railway worker. She studied business at Ain Shams University, gaining a BA degree in 1972. She went on to earn another BA in literary criticism in 1976, before embarking on a career in journalism. She worked as a film and theatre critic for various Arabic newspapers and magazines. Bakr lived in Cyprus for a few years with her husband before returning to Egypt in the mid-1980s.
Bakr''s father died early, leaving her mother a poor widow. Her work often deals with the lives of the impoverished and the marginalized.[2] In 1985, she published her first collection of short stories, Zinat at the President''s Funeral, which was an immediate success. She has published several collections of short stories since. Her debut novel was called Wasf al-Bulbul (1993).
Salwa Bakr is married with children and lives in Cairo.')

declare @authorId1 int = (select Id from [Authors] where [Fullname] = N'زين الدين محمد عبد الهادي')
declare @authorId2 int = (select Id from [Authors] where [Fullname] = N'Samir Abdel Fattah')
declare @authorId3 int = (select Id from [Authors] where [Fullname] = N'Salwa Bakr')

INSERT INTO [dbo].Publishers(Name, [Address], Phone) Values(N'Silver Dragon Media', '433 Caredean Dr, Horsham, PA 19044', '(215) 442-9094')
INSERT INTO [dbo].Publishers(Name, [Address], Phone) Values(N'Lippincott Williams & Wilkins', '323 Norristown Rd #200, Ambler, PA 19002', '(215) 646-8700')
INSERT INTO [dbo].Publishers(Name, [Address], Phone) Values(N'Infinity Publishing', '1094 New Dehaven St, Conshohocken, PA 19428', '(877) 289-2665')
INSERT INTO [dbo].Publishers(Name, [Address], Phone) Values(N'Running Press Media', '2300 S 22nd St, Philadelphia, PA 19103', '(215) 567-5080')
INSERT INTO [dbo].Publishers(Name, [Address], Phone) Values(N'Pearl River China Printing', '400 Lincoln Ave, Hatboro, PA 19040', '(888) 725-7817')
declare @publisher1 int = (select Id from Publishers where Name = N'Silver Dragon Media')
declare @publisher2 int = (select Id from Publishers where Name = N'Lippincott Williams & Wilkins')
declare @publisher3 int = (select Id from Publishers where Name = N'Infinity Publishing')
declare @publisher4 int = (select Id from Publishers where Name = N'Running Press Media')
declare @publisher5 int = (select Id from Publishers where Name = N'Pearl River China Printing')

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES (	'978-3-16-148410-0', N'ArabicLetters', N'الحروف العربية',
				N'Arabic Alphabet, the first book in the I Love Arabic series, introduces young learners to the Arabic letters. This helpful and captivating book presents each letter with a delightful illustration, which ensures rapid and enjoyable learning. Arabic Alphabet is an exciting first book for young Arabic learners.هذا الكتاب يعلم الحروف العربية',
				0, 12, @languageId1, @publisher1, 2000, 'True', 5.20, @MediaTypeImage, 'False', null)
declare @mediaId int = (select Id from media where ISBN = '978-3-16-148410-0')
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values(N'1 - I love Arabic', @mediaId, 1)
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values(N'1 - Arabic Alphabet', @mediaId, 5)
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values(N'1 - من ا إلى ت', @mediaId, 6)
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values(N'2 - من ث إلى ح', @mediaId, 9)
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values(N'3 - من خ إلى ي', @mediaId, 12)

INSERT INTO [dbo].MediaCategories(Category_Id, Media_Id) Values(@categoryId1, @mediaId)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, @mediaId)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId2, @mediaId)

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148410-1', N'ArabicWritting', N'الكتابة العربية', N'.هذا الكتاب يعلم الكتابة العربية', 2, 10, @languageId2, @publisher2, 2002, 'True', 3.85, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaCategories(Category_Id, Media_Id) Values(@categoryId1, (select Id from Media where ISBN = '978-3-16-148410-1'))
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId2, (select Id from Media where ISBN = '978-3-16-148410-1'))
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId3, (select Id from Media where ISBN = '978-3-16-148410-1'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148410-2', N'FeeloAbraha', N'Abraha فيل', N'', 1, 10, @languageId1, @publisher3, 2003, 'True', 4.95, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148410-2'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148410-3', N'HisneHaseen', N'حِصنِ حصين', N'', 2, 10, @languageId1, @publisher4, 2014, 'True', 30.00, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148410-3'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148410-4', N'InnaniAstatiou', N' أناأستطيع ', N'', 1, 10, @languageId1, @publisher5, 2015, 'True', 2.50, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148410-4'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148410-5', N'IntabihiYaJoud', N'انتبه Djoud', N'', 1, 10, @languageId1, @publisher4, 2016, 'True', 0.00, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148410-5'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148410-6', N'KalimatounNouhibbouha', N'كلمات نحبهأ Abraha', N'', 1, 10, @languageId1, @publisher3, 2013, 'True', 0.00, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148410-6'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148410-7', N'LaTaklakYaBaba', N'أبي، لا تقلق', N'', 1, 10, @languageId1, @publisher2, 2017, 'True', 0.00, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148410-7'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148410-8', N'LimadhaAnamouBakiran', N'لماذا يمكنني النوم في وقت مبكر', N'', 1, 10, @languageId1, @publisher1, 2014, 'True', 0.00, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148410-8'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148410-9', N'ManFaalaHadha', N'من فعل هذا', N'', 1, 10, @languageId1, @publisher3, 2015, 'True', 0.00, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148410-9'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148411-0', N'ManYusaidouAddajaja', N'من الذى يساعد الدجاجة', N'', 1, 10, @languageId1, @publisher1, 2000, 'True', 0.00, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148411-0'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148412-0', N'MeAndMyGrandma', N'Me And My Grandma', N'', 1, 10, @languageId1, @publisher1, 2009, 'True', 0.00, @MediaTypeText, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148412-0'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148413-0', N'SahihBoukhari', N'صحيح البخاري', N'', 3, 10, @languageId1, @publisher2, 2010, 'True', 0.00, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148413-0'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148414-0', N'SalmaWaLayla', N'Salma Wa Layla', N'', 1, 10, @languageId1, @publisher1, 2017, 'True', 0.00, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148414-0'))

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148415-0', N'YasmineWaAlwahsh', N'Yasmine Wa Alwahsh', N'', 1, 10, @languageId1, @publisher1, 2016, 'True', 0.00, @MediaTypeImage, 'False', null)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, (select Id from Media where ISBN = '978-3-16-148415-0'))

declare @HtmlContent1 nvarchar(MAX) = N'
<p>
    <b>Algeria</b> (
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Arabic_language" class="mw-redirect" title="Arabic language">Arabic</a>
    : <span lang="ar" dir="rtl">الجزائر</span>‎‎ <i><span title="Arabic transliteration" class="Unicode" style="white-space: normal; text-decoration: none">al-Jazā''ir</span></i>; 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Berber_languages" title="Berber languages">Berber</a>: <span lang="ber">ⴷⵣⴰⵢⴻⵔ</span>, <i>Dzayer</i>; 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/French_language" title="French language">French</a>
    : <span lang="fr"><i>Algérie</i></span>
    ), officially the <b>People''s Democratic Republic of Algeria</b>, is a 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Sovereign_state" title="Sovereign state">sovereign state</a>
    in 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/North_Africa" title="North Africa">North Africa</a>
    on the 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Mediterranean_Sea" title="Mediterranean Sea">Mediterranean coast</a>.
'
declare @HtmlContent2 nvarchar(MAX) = N'
<p>
	 Its capital and most populous city is 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Algiers" title="Algiers">Algiers</a>
    , located in the country''s far north. With an area of 2,381,741 square kilometres (919,595&nbsp;sq&nbsp;mi), Algeria is the 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_area" class="mw-redirect" title="List of countries and dependencies by area">tenth-largest country in the world</a>
    , and the largest in Africa.<sup id="cite_ref-11" class="reference">
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Algeria#cite_note-11">[11]</a>
    </sup> Algeria is bordered to the northeast by 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Tunisia" title="Tunisia">Tunisia</a>
    , to the east by 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Libya" title="Libya">Libya</a>
    , to the west by 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Morocco" title="Morocco">Morocco</a>
    , to the southwest by the 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Western_Sahara" title="Western Sahara">Western Saharan</a>
    territory, 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Mauritania" title="Mauritania">Mauritania</a>
    , and 
	<a target="_blank"  href="https://en.wikipedia.org/wiki/Mali" title="Mali">Mali</a>
    , to the southeast by 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Niger" title="Niger">Niger</a>
    , and to the north by the 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Mediterranean_Sea" title="Mediterranean Sea">Mediterranean Sea</a>.
'
declare @HtmlContent3 nvarchar(MAX) = N'
<p>	
	The country is a 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Semi-presidential_system" title="Semi-presidential system">semi-presidential republic</a>
    consisting of 48 provinces and 1,541 communes (counties). 
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Abdelaziz_Bouteflika" title="Abdelaziz Bouteflika">Abdelaziz Bouteflika</a>
     has been <a target="_blank"  href="https://en.wikipedia.org/wiki/President_of_Algeria" title="President of Algeria">President</a> since 1999.
</p>
'

declare @MediaDescription nvarchar(Max) = 
N'
<p>
    <b>Algeria</b> (
    <a target="_blank"  href="https://en.wikipedia.org/wiki/Arabic_language" class="mw-redirect" title="Arabic language">Arabic</a>
    : <span lang="ar" dir="rtl">الجزائر</span>‎‎ <i><span title="Arabic transliteration" class="Unicode" style="white-space: normal; text-decoration: none">al-Jazā''ir</span></i>; 
</p>
'
INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148416-0', null, N'Algeria (الجزائر)', @MediaDescription, 1, 3, @languageId1, @publisher1, 2016, 'True', 0.00, @MediaTypeHtml, 'False', null)
set @mediaId = (select Id from media where ISBN = '978-3-16-148416-0')
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values('1 - Introduction', @mediaId, 1)
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values('2 - Geography', @mediaId, 2)
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values('3 - Political System', @mediaId, 3)
INSERT INTO [dbo].ContentPages(MediaId, [Sequence], Content) Values(@mediaId, 1, @HtmlContent1)
INSERT INTO [dbo].ContentPages(MediaId, [Sequence], Content) Values(@mediaId, 2, @HtmlContent2)
INSERT INTO [dbo].ContentPages(MediaId, [Sequence], Content) Values(@mediaId, 3, @HtmlContent3)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, @mediaId)

declare @textContent1 nvarchar(Max) = N'Algeria is a North African country with a Mediterranean coastline and a Saharan desert interior. Many empires have left legacies here, such as the ancient Roman ruins in seaside Tipaza. In the capital, Algiers, Ottoman landmarks like circa-1612 Ketchaoua Mosque line the hillside Casbah quarter, with its narrow alleys and stairways. The city’s Neo-Byzantine basilica Notre Dame d’Afrique dates to French colonial rule.'
declare @textContent2 nvarchar(Max) = N'Ancient Algeria has known many empires and dynasties, including ancient Numidians, Phoenicians, Carthaginians, Romans, Vandals, Byzantines, Umayyads, Abbasids, Idrisid, Aghlabid, Rustamid, Fatimids, Zirid, Hammadids, Almoravids, Almohads, Spaniards, Ottomans and the French colonial empire. Berbers are the indigenous inhabitants of Algeria.'
declare @textContent3 nvarchar(Max) = N'Algeria is a regional and middle power. The North African country supplies large amounts of natural gas to Europe, and energy exports are the backbone of the economy. According to OPEC Algeria has the 16th largest oil reserves in the world and the second largest in Africa, while it has the 9th largest reserves of natural gas. Sonatrach, the national oil company, is the largest company in Africa. Algeria has one of the largest militaries in Africa and the largest defence budget on the continent; most of Algeria''s weapons are imported from Russia, with whom they are a close ally.[12][13] Algeria is a member of the African Union, the Arab League, OPEC, the United Nations and is the founding member of the Maghreb Union.'
INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148417-0', null, N'Algeria', N'A text document about Algeria', 1, 3, @languageId1, @publisher1, 2016, 'True', 0.00, @MediaTypeText, 'False', null)
set @mediaId = (select Id from media where ISBN = '978-3-16-148417-0')
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values('1 - Geography.', @mediaId, 1)
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values('2 - History', @mediaId, 2)
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values('3 - Politics', @mediaId, 3)
INSERT INTO [dbo].ContentPages(MediaId, [Sequence], Content) Values(@mediaId, 1, @textContent1)
INSERT INTO [dbo].ContentPages(MediaId, [Sequence], Content) Values(@mediaId, 2, @textContent2)
INSERT INTO [dbo].ContentPages(MediaId, [Sequence], Content) Values(@mediaId, 3, @textContent3)
set @mediaId = (select Id from media where ISBN = '978-3-16-148417-0')
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, @mediaId)


set @HtmlContent1 = '
<p>
	<b>HyperText Markup Language</b> (<b>HTML</b>) is the standard
	<a href="https://en.wikipedia.org/wiki/Markup_language" target="_blank" title="Markup language">markup language</a>
		for creating 
	<a href="https://en.wikipedia.org/wiki/Web_page" target="_blank" title="Web page">web pages</a>
	  and 
	<a href="https://en.wikipedia.org/wiki/Web_application" target="_blank" title="Web application">web applications</a>
	  . With
	<a href="https://en.wikipedia.org/wiki/Cascading_Style_Sheets" target="_blank" title="Cascading Style Sheets">Cascading Style Sheets</a>
	 (CSS) and 
	<a href="https://en.wikipedia.org/wiki/JavaScript" target="_blank" title="JavaScript">JavaScript</a>
	  it forms a triad of cornerstone technologies for the 
	<a href="https://en.wikipedia.org/wiki/World_Wide_Web" target="_blank" title="World Wide Web">World Wide Web</a>.
'
set @HtmlContent2 = '
<p>
	  <sup id="cite_ref-1" class="reference">
	<a href="https://en.wikipedia.org/wiki/HTML#cite_note-1">[1]</a></sup> 
	<a href="https://en.wikipedia.org/wiki/Web_browser" target="_blank" title="Web browser">Web browsers</a>
	   receive HTML documents from a 
	<a href="https://en.wikipedia.org/wiki/Webserver" target="_blank" class="mw-redirect" title="Webserver">webserver</a>
	    or from local storage and render them into multimedia web pages. HTML describes the structure of a web page 
	<a href="https://en.wikipedia.org/wiki/Semantic" target="_blank" class="mw-redirect" title="Semantic">semantically</a>
	 and originally included cues for the appearance of the document.
</p>
'
set @MediaDescription =
'
<p>
	<b>HyperText Markup Language</b> (<b>HTML</b>) is the standard
	<a href="https://en.wikipedia.org/wiki/Markup_language" target="_blank" title="Markup language">markup language</a>
		for creating 
	<a href="https://en.wikipedia.org/wiki/Web_page" target="_blank" title="Web page">web pages</a>
	  and 
	<a href="https://en.wikipedia.org/wiki/Web_application" target="_blank" title="Web application">web applications</a>
	  .
</p>
'

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148418-0', null, N'What is Html', @MediaDescription, 1, 2, @languageId1, @publisher1, 2016, 'True', 0.00, @MediaTypeHtml, 'False', null)
set @mediaId = (select Id from media where ISBN = '978-3-16-148418-0')
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values('1 - Html Part I.', @mediaId, 1)
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values('2 - Html - Part II', @mediaId, 2)
INSERT INTO [dbo].ContentPages(MediaId, [Sequence], Content) Values(@mediaId, 1, @HtmlContent1)
INSERT INTO [dbo].ContentPages(MediaId, [Sequence], Content) Values(@mediaId, 2, @HtmlContent2)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, @mediaId)

INSERT INTO [dbo].[Media] (ISBN,  ContentLocation, [Title], [Description], [Level], Pages, [LanguageId], PublisherId, YearPublished, IsFree, Price, MediaType, IsPartOfACollection, MediaCollectionId)
	VALUES ('978-3-16-148419-0', null, N'Earth', 'A video about Earth as seen from ISS Expeditions 28 & 29', 1, 1, @languageId1, @publisher1, 2016, 'True', 0.00, @MediaTypeVideo, 'False', null)
set @mediaId = (select Id from media where ISBN = '978-3-16-148419-0')
INSERT INTO [dbo].Chapters(Title, MediaId, StartingPage) Values('1 - Earch seen from above', @mediaId, 1)
INSERT INTO [dbo].MediaAuthors(Author_Id, Media_Id) Values(@authorId1, @mediaId)

