SET IDENTITY_INSERT [dbo].[MemberCategories] ON
INSERT INTO [dbo].[MemberCategories] ([Id], [Name], [Description], [TotalLoan], [ReturningDays]) VALUES (1, N'Gold', N'this is the gold membership package.... ', N'5', N'15 days')
INSERT INTO [dbo].[MemberCategories] ([Id], [Name], [Description], [TotalLoan], [ReturningDays]) VALUES (2, N'Silver', N'this is the silver package...', N'2', N'5 days')
INSERT INTO [dbo].[MemberCategories] ([Id], [Name], [Description], [TotalLoan], [ReturningDays]) VALUES (3, N'Platinum', N'this is the platinum package.', N'10', N'20 days')
SET IDENTITY_INSERT [dbo].[MemberCategories] OFF
