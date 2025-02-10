USE [weapons_cards];

--INSERT INTO [dbo].[weapons_items] (Name, Type, isVisible, Model)
--VALUES
--('��', '���������', 1, '��������'),
--('��', '���������', 1, '��������� ��������'),
--('Sarsilmaz SAR 9', '���������', 1, '��������'),
--('���', '��������', 1, '�������'),
--('������-�', '��������', 1, '�������'),
--('Sa vz. 58', '��������', 1, '�������'),
--('G3', '��������', 0, '��������� ��������'),
--('���', '�������� � ��������', 0, '������������ �������'),
--('���', '�������� � ��������', 1, '����������� ��������'),
--('Barrett M82', '�������� � ��������', 1, '���������������� ����������� ��������'),
--('Mossberg 500', '�������� � ��������', 0, '�������� �����'),
--('���-74', '�������', 0, '������ ������'),
--('��-7,62', '�������', 1, '������ ������'),
--('MG3', '�������', 1, '������ ������'),
--('M134 Minigun', '�������', 1, '�������������� ������'),
--('��-25', '����������', 1, '������������ ���������'),
--('���-17', '����������', 1, '�������������� ��������� ���������'),
--('���-40', '����������', 0, '�������������� ��������� ���������'),
--('Mk 19', '����������', 1, '�������������� ��������� ���������')

--INSERT INTO [dbo].[weapons_properties] (price, weight, Vendor, FK_IdWeaponsItem, Description)
--VALUES
--(22590, 1.34, '����', 1, '�� ���������� � 1951 ����. ������� �� ���������� ��� ����.'),
--(32600, 1.76, '����', 2, '�� ���������� � 1967 ����. ������� �� ���������� ��� ����. ������������ ��������������� ������� ��������'),
--(28900, 0.95, '������', 3, '������������ � 2020 ����. ����������� "��������������" � ����� 2020 ���� ��������� � ������� 250 �������� ���������� ����������.'),
--(45200, 3.25, '����', 4, '�� ���������� � 1959 ����. ������� �� ���������� ��� ����. �� ���������� ��������� ��������� ��������������.'),
--(120132, 3.3, '�������', 5, '�� ���������� � 2017 ����.'),
--(23000, 3.77, '������������', 6, '	������������� �������� 5 000 ������ �� ����� � 2022 ����.'),
--(170000, 3.53, '����������', 7, '	���������� ����������� � 2022 ����.'),
--(202000, 4.56, '����', 8, '�� ���������� � 1949 ����. ������� �� ���������� ��� ����. ������������ ��������������� ��������� �������.'),
--(350000, 3.35, '����', 9, '�� ���������� � 1963 ����. ������� �� ���������� ��� ����. �������������� 12 ������ ������������� �������� �� ����� � 2022 ����.'),
--(686700, 6.36, '���', 10, 'Barrett M107A1 � 11 ������� 2014 ��� �������� �������� � ��������� �Barrett Firearms� � ��������� �� �������'),
--(30624, 3.2, '���', 11, '�������� ��� � 2022 ����.'),
--(65600, 4.16, '����', 12, '	�� ���������� � 1974 ����. ������� �� ���������� ��� ����.'),
--(510000, 12.6, '�������', 13, '�� ���������� � 1961 ����. ������� �� ���������� ��� ����. ���������� ������������ ��-7,62 - �� ���������� � 2011 ����.'),
--(110000, 3.35, '��������', 14, '�������� ��������� 100 ������ � 2022 ����.'),
--(1200000, 30, '���', 15, '�������� ��� � 2022 ����.['),
--(34000, 1.65, '����', 16, '�� ���������� � 1978 ����. ������� �� ���������� ��� ����.'),
--(320000, 18, '����', 17, '�� ���������� � 1971 ����. ������� �� ���������� ��� ����. �� ���������� ����� ���������� ������ ���-117'),
--(360000, 17, '�������', 18, '�� ���������� � 2017 ����.'),
--(120000, 32.7, '���', 19, '��������� ����� �������� � 2022 ����.')

--INSERT INTO [dbo].[weapons_images] (name, path, FK_IdWeaponsItem)
--VALUES
--('��', 'https://weaponsimages.blob.core.windows.net/images/��.png', 1),
--('��', 'https://weaponsimages.blob.core.windows.net/images/��.png', 2),
--('Sarsilmaz SAR 9', 'https://weaponsimages.blob.core.windows.net/images/Sarsilmaz_SAR_9.png', 3),
--('���', 'https://weaponsimages.blob.core.windows.net/images/���.png', 4),
--('������-�', 'https://weaponsimages.blob.core.windows.net/images/������-�.png', 5),
--('Sa vz. 58', 'https://weaponsimages.blob.core.windows.net/images/Sa_vz._58.png', 6),
--('G3', 'https://weaponsimages.blob.core.windows.net/images/G3.png', 7),
--('���', 'https://weaponsimages.blob.core.windows.net/images/���.png', 8),
--('���', 'https://weaponsimages.blob.core.windows.net/images/���.png', 9),
--('Barrett M82', 'https://weaponsimages.blob.core.windows.net/images/Barrett_M82.png', 10),
--('Mossberg 500', 'https://weaponsimages.blob.core.windows.net/images/Mossberg_500.png', 11),
--('���-74', 'https://weaponsimages.blob.core.windows.net/images/���-74.png', 12),
--('��-7,62', 'https://weaponsimages.blob.core.windows.net/images/��-762.png', 13),
--('MG3', 'https://weaponsimages.blob.core.windows.net/images/MG3.png', 14),
--('M134 Minigun', 'https://weaponsimages.blob.core.windows.net/images/M134_Minigun.png', 15),
--('��-25', 'https://weaponsimages.blob.core.windows.net/images/��-25.png', 16),
--('���-17', 'https://weaponsimages.blob.core.windows.net/images/���-17.png', 17),
--('���-40', 'https://weaponsimages.blob.core.windows.net/images/���-40.png', 18),
--('Mk 19', 'https://weaponsimages.blob.core.windows.net/images/Mk19.png', 19)

SELECT [wi].[Model], 'category ' + [wi].[Type] AS [category], [wp].[price], [wp].[weight], [wp].[Vendor], [wp].[Description], [wm].[path] FROM [dbo].[weapons_items] AS [wi]
INNER JOIN [dbo].[weapons_properties] AS [wp]
ON [wi].[id] = [wp].[FK_IdWeaponsItem]
INNER JOIN [dbo].[weapons_images] as [wm]
ON [wi].[id] = [wm].[FK_IdWeaponsItem]
WHERE [wi].[Type] = '�������'

SELECT * FROM [dbo].[weapons_items]
SELECT * FROM [dbo].[weapons_properties];
SELECT * FROM [dbo].[weapons_images];