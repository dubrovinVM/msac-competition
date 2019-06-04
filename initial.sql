USE [msac_competition]
--insert into [dbo].[Teams] values ('Kiev');
--insert into [dbo].[Teams] values ('Kharkiv');
--insert into [dbo].[Competitions] values ('World Championship');
--insert into [dbo].TeamCompetition values (1,1), (2,1)

select * from [dbo].TeamCompetition

INSERT INTO [dbo].[Regions]
           ([Name])
     VALUES
          
(N'Одеська область'),
(N'Дніпропетровська область'),
(N'Чернігівська область'),
(N'Харківська область'),
(N'Житомирська область'),
(N'Полтавська область'),
(N'Херсонська область'),
(N'Київська область'),
(N'Запорізька область'),
(N'Луганська область'),
(N'Донецька область'),
(N'Вінницька область'),
(N'Автономна Республіка Крим'),
(N'Миколаївська область'),
(N'Кіровоградська область'),
(N'Сумська область'),
(N'Львівська область'),
(N'Черкаська область'),
(N'Хмельницька область'),
(N'Волинська область'),
(N'Рівненська область'),
(N'Івано-Франківська область'),
(N'Тернопільська область'),
(N'Закарпатська область'),
(N'Чернівецька область'),
(N'м. Севастополь'),
(N'м. Київ')


INSERT INTO [dbo].[Cities]
           ([Name]
           ,[RegionId])
     VALUES
           (N'Ірпінь', 8),
		   (N'Буча',8 ),
		   (N'Гостомель',8 ),
		   (N'ЗХарків', 4),
		   (N'Зміїв', 4),
		   (N'Есхар', 4)

INSERT INTO [dbo].[Coaches]
           ([Name]
           ,[Surname]
           ,[Lastname]
           ,[DaTeOfBirth]
           ,[SportRank]
           ,[Sex]
           ,[CityId]
           ,[Avatar])
     VALUES
           (N'Пристінський'
           ,N'Олександр'
           ,N'Васильович'
           ,N'1980-04-30'
           ,1
           ,1
           ,1
           ,N''),
		   (N'Ришковець'
           ,N'Андрій'
           ,N'Мирославович'
           ,N'1980-04-30'
           ,1
           ,1
           ,4
           ,N'')
GO

INSERT INTO [dbo].[Fsts]
           ([Name])
     VALUES
           (N'ЗСУ'),
           (N'НГУ'),
           (N'ВФ ВСБ'),
           (N'Динамо'),
           (N'Колос')
GO


INSERT INTO [dbo].[Teams]
           ([Name]
           ,[ShortName]
           ,[FstId]
           ,[CoachId]
           ,[CityId]
           ,[Logo])
     VALUES
           (N'Зібрна Київської області'
           ,N'Київ обл.'
           ,1
           ,4
           ,1
           ,N''),
		    (N'Зібрна Харківської області'
           ,N'Харків. обл.'
           ,2
           ,5
           ,4
           ,N'')
GO


INSERT INTO [dbo].[Sportmen]
           ([Name]
           ,[Surname]
           ,[Lastname]
           ,[DaTeOfBirth]
           ,[SportRank]
           ,[Sex]
           ,[Avatar]
           ,[CoachId]
           ,[TeamId])
     VALUES
           (N'Журавльов'
           ,N'Вячеслав'
           ,N'Олександрович'
           ,N'1984-04-25'
           ,1
           ,1
           ,N''
           ,4
           ,2),
		   (N'Бусяк'
           ,N'Андрій'
           ,N'Олександрович'
           ,N'1996-04-24'
           ,1
           ,1
           ,N''
           ,5
           ,3)
GO