


SET IDENTITY_INSERT [dbo].[Item] ON
INSERT INTO [dbo].[Item] ([Id], [Name], [Type], [Attack], [Defense]) VALUES (1, N'Sword', N'Weapon', 5, 0)
INSERT INTO [dbo].[Item] ([Id], [Name], [Type], [Attack], [Defense]) VALUES (2, N'Shield', N'Armor', 0, 3)
SET IDENTITY_INSERT [dbo].[Item] OFF

SET IDENTITY_INSERT [dbo].[Equipment] ON
INSERT INTO [dbo].[Equipment] ([Id], [WeaponId], [ArmorId]) VALUES (1, 1, 2)
SET IDENTITY_INSERT [dbo].[Equipment] OFF


Update Players SET EquipmentID = 1 Where Id = 1