USE [weapons_cards];

--INSERT INTO [dbo].[weapons_items] (Name, Type, isVisible, Model)
--VALUES
--('ПМ', 'Пистолеты', 1, 'Пистолет'),
--('ПБ', 'Пистолеты', 1, 'Бесшумный пистолет'),
--('Sarsilmaz SAR 9', 'Пистолеты', 1, 'Пистолет'),
--('АКМ', 'Автоматы', 1, 'Автомат'),
--('Вулкан-М', 'Автоматы', 1, 'Автомат'),
--('Sa vz. 58', 'Автоматы', 1, 'Автомат'),
--('G3', 'Автоматы', 0, 'Батальная винтовка'),
--('СКС', 'Винтовки и карабины', 0, 'Самозарядный карабин'),
--('СВД', 'Винтовки и карабины', 1, 'Снайперская винтовка'),
--('Barrett M82', 'Винтовки и карабины', 1, 'Крупнокалиберная снайперская винтовка'),
--('Mossberg 500', 'Винтовки и карабины', 0, 'Помповое ружьё'),
--('РПК-74', 'Пулемёты', 0, 'Ручной пулемёт'),
--('КМ-7,62', 'Пулемёты', 1, 'Единый пулемёт'),
--('MG3', 'Пулемёты', 1, 'Единый пулемёт'),
--('M134 Minigun', 'Пулемёты', 1, 'Многоствольный пулемёт'),
--('ГП-25', 'Гранатомёты', 1, 'Подствольный гранатомёт'),
--('АГС-17', 'Гранатомёты', 1, 'Автоматический станковый гранатомёт'),
--('УАГ-40', 'Гранатомёты', 0, 'Автоматический станковый гранатомёт'),
--('Mk 19', 'Гранатомёты', 1, 'Автоматический станковый гранатомёт')

--INSERT INTO [dbo].[weapons_properties] (price, weight, Vendor, FK_IdWeaponsItem, Description)
--VALUES
--(22590, 1.34, 'СССР', 1, 'На вооружении с 1951 года. Перешли от Вооружённых Сил СССР.'),
--(32600, 1.76, 'СССР', 2, 'На вооружении с 1967 года. Перешли от Вооружённых Сил СССР. Используется подразделениями военной разведки'),
--(28900, 0.95, 'Турция', 3, 'Используется с 2020 года. Госкомпания "Укрспецэкспорт" в конце 2020 года поставила в Украину 250 турецких полимерных пистолетов.'),
--(45200, 3.25, 'СССР', 4, 'На вооружении с 1959 года. Перешли от Вооружённых Сил СССР. На вооружении отдельных категорий военнослужащих.'),
--(120132, 3.3, 'Украина', 5, 'На вооружении с 2017 года.'),
--(23000, 3.77, 'Чехословакия', 6, '	Запланировано передать 5 000 единиц из Чехии в 2022 году.'),
--(170000, 3.53, 'Португалия', 7, '	Передаются Португалией в 2022 году.'),
--(202000, 4.56, 'СССР', 8, 'На вооружении с 1949 года. Перешли от Вооружённых Сил СССР. Используется подразделениями почётного караула.'),
--(350000, 3.35, 'СССР', 9, 'На вооружении с 1963 года. Перешли от Вооружённых Сил СССР. Дополнительные 12 единиц запланировано получить от Чехии в 2022 году.'),
--(686700, 6.36, 'США', 10, 'Barrett M107A1 — 11 декабря 2014 был подписан контракт с компанией «Barrett Firearms» о поставках на Украину'),
--(30624, 3.2, 'США', 11, 'Передано США в 2022 году.'),
--(65600, 4.16, 'СССР', 12, '	На вооружении с 1974 года. Перешли от Вооружённых сил СССР.'),
--(510000, 12.6, 'Украина', 13, 'На вооружении с 1961 года. Перешли от Вооружённых сил СССР. Украинская модернизация КМ-7,62 - на вооружении с 2011 года.'),
--(110000, 3.35, 'Германия', 14, 'Передано Германией 100 единиц в 2022 году.'),
--(1200000, 30, 'США', 15, 'Переданы США в 2022 году.['),
--(34000, 1.65, 'СССР', 16, 'На вооружении с 1978 года. Перешли от Вооружённых сил СССР.'),
--(320000, 18, 'СССР', 17, 'На вооружении с 1971 года. Перешли от Вооружённых сил СССР. На вооружении также украинский аналог КБА-117'),
--(360000, 17, 'Украина', 18, 'На вооружении с 2017 года.'),
--(120000, 32.7, 'США', 19, 'Несколько сотен передано в 2022 году.')

--INSERT INTO [dbo].[weapons_images] (name, path, FK_IdWeaponsItem)
--VALUES
--('ПМ', 'https://weaponsimages.blob.core.windows.net/images/ПМ.png', 1),
--('ПБ', 'https://weaponsimages.blob.core.windows.net/images/ПБ.png', 2),
--('Sarsilmaz SAR 9', 'https://weaponsimages.blob.core.windows.net/images/Sarsilmaz_SAR_9.png', 3),
--('АКМ', 'https://weaponsimages.blob.core.windows.net/images/АКМ.png', 4),
--('Вулкан-М', 'https://weaponsimages.blob.core.windows.net/images/Вулкан-М.png', 5),
--('Sa vz. 58', 'https://weaponsimages.blob.core.windows.net/images/Sa_vz._58.png', 6),
--('G3', 'https://weaponsimages.blob.core.windows.net/images/G3.png', 7),
--('СКС', 'https://weaponsimages.blob.core.windows.net/images/СКС.png', 8),
--('СВД', 'https://weaponsimages.blob.core.windows.net/images/СВД.png', 9),
--('Barrett M82', 'https://weaponsimages.blob.core.windows.net/images/Barrett_M82.png', 10),
--('Mossberg 500', 'https://weaponsimages.blob.core.windows.net/images/Mossberg_500.png', 11),
--('РПК-74', 'https://weaponsimages.blob.core.windows.net/images/РПК-74.png', 12),
--('КМ-7,62', 'https://weaponsimages.blob.core.windows.net/images/КМ-762.png', 13),
--('MG3', 'https://weaponsimages.blob.core.windows.net/images/MG3.png', 14),
--('M134 Minigun', 'https://weaponsimages.blob.core.windows.net/images/M134_Minigun.png', 15),
--('ГП-25', 'https://weaponsimages.blob.core.windows.net/images/ГП-25.png', 16),
--('АГС-17', 'https://weaponsimages.blob.core.windows.net/images/АГС-17.png', 17),
--('УАГ-40', 'https://weaponsimages.blob.core.windows.net/images/УАГ-40.png', 18),
--('Mk 19', 'https://weaponsimages.blob.core.windows.net/images/Mk19.png', 19)

SELECT [wi].[Model], 'category ' + [wi].[Type] AS [category], [wp].[price], [wp].[weight], [wp].[Vendor], [wp].[Description], [wm].[path] FROM [dbo].[weapons_items] AS [wi]
INNER JOIN [dbo].[weapons_properties] AS [wp]
ON [wi].[id] = [wp].[FK_IdWeaponsItem]
INNER JOIN [dbo].[weapons_images] as [wm]
ON [wi].[id] = [wm].[FK_IdWeaponsItem]
WHERE [wi].[Type] = 'Пулемёты'

SELECT * FROM [dbo].[weapons_items]
SELECT * FROM [dbo].[weapons_properties];
SELECT * FROM [dbo].[weapons_images];