USE [sql_ventements_project]
GO
SET IDENTITY_INSERT [dbo].[addressuserv] ON 

INSERT [dbo].[addressuserv] ([id], [street], [homeNumber], [zip], [city]) VALUES (1, N'Bogess Street', 3, N'70A56', N'Boston')
SET IDENTITY_INSERT [dbo].[addressuserv] OFF
GO
SET IDENTITY_INSERT [dbo].[userv] ON 

INSERT [dbo].[userv] ([id], [firstname], [lastname], [birthdate], [email], [encryptedPassword], [gender], [administrator], [addressId]) VALUES (1, N'Sébastien', N'Counen', CAST(N'2000-10-13T00:00:00.000' AS DateTime), N'admin@ventements.com', N'AQAAAAEAACcQAAAAEDzHQpGDomtYgZucqYzBHN0JRr3wM8iejBiqhWDpN+gNXUste1gnYNY083ocxC39aw==', N'M', 1, NULL)
INSERT [dbo].[userv] ([id], [firstname], [lastname], [birthdate], [email], [encryptedPassword], [gender], [administrator], [addressId]) VALUES (3, N'John', N'Doe', CAST(N'1990-10-01T00:00:00.000' AS DateTime), N'johndoe@gmail.com', N'AQAAAAEAACcQAAAAECKFDtIcXk2Qblw/tDF9z2flZv4fOR32poJHn6OrAN970pGl71WXetltu1fwzDynNQ==', N'M', 0, 1)
INSERT [dbo].[userv] ([id], [firstname], [lastname], [birthdate], [email], [encryptedPassword], [gender], [administrator], [addressId]) VALUES (4, N'Lorenzo', N'Ferrari', CAST(N'1999-08-24T00:00:00.000' AS DateTime), N'ferrari@gmail.com', N'AQAAAAEAACcQAAAAELoZjkoMUa89Wa0/pUkrvPcJPr107/HBOUX9iCiysOI5F54Win4UCsqYE+na4nK1NQ==', N'M', 0, NULL)
SET IDENTITY_INSERT [dbo].[userv] OFF
GO
SET IDENTITY_INSERT [dbo].[category] ON 

INSERT [dbo].[category] ([id], [title], [categoryId]) VALUES (1, N'Hauts', NULL)
INSERT [dbo].[category] ([id], [title], [categoryId]) VALUES (2, N'Bas', NULL)
INSERT [dbo].[category] ([id], [title], [categoryId]) VALUES (3, N'Chaussures', NULL)
INSERT [dbo].[category] ([id], [title], [categoryId]) VALUES (4, N'Hoodies', 1)
INSERT [dbo].[category] ([id], [title], [categoryId]) VALUES (5, N'Pulls', 1)
INSERT [dbo].[category] ([id], [title], [categoryId]) VALUES (6, N'T-Shirts', 1)
INSERT [dbo].[category] ([id], [title], [categoryId]) VALUES (7, N'Chemises', 1)
INSERT [dbo].[category] ([id], [title], [categoryId]) VALUES (8, N'Pantalons', 2)
INSERT [dbo].[category] ([id], [title], [categoryId]) VALUES (9, N'Shorts', 2)
INSERT [dbo].[category] ([id], [title], [categoryId]) VALUES (10, N'Sneakers', 3)
SET IDENTITY_INSERT [dbo].[category] OFF
GO
SET IDENTITY_INSERT [dbo].[item] ON 

INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (1, N'[Noir] TREFOIL HOODIE UNISEX - Sweat à capuche', 59.9900016784668, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F160824882448024fbe9d78c4943348e890cc4530888c4.jpeg?alt=media&token=4eae4c01-9ee8-486f-b57a-757844a65a7f', N'Sweat 100% coton. Conseils d''entretien: Ne pas mettre au sèche-linge, lavage en machine à 30°C, lavage textiles délicats.', 4)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (2, N'[Orange] TREFOIL HOODIE UNISEX - Sweat à capuche', 59.9900016784668, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F160824900007648482363fe1a440e8fefb89397f90427.jpeg?alt=media&token=5bff443e-d5d8-4569-b18e-20199cacc9a4', N'Sweat 100% coton. Conseils d''entretien: Ne pas mettre au sèche-linge, lavage en machine à 30°C, lavage textiles délicats.', 4)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (3, N'[Blanc] TREFOIL HOODIE UNISEX - Sweat à capuche', 59.9900016784668, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F1608249155467d9f178dbbc0c4cce91dfdcb2d35358fc.jpeg?alt=media&token=a60829ca-f1f5-4025-b6cc-91db86cb63f8', N'Sweat 100% coton. Conseils d''entretien: Ne pas mettre au sèche-linge, lavage en machine à 30°C, lavage textiles délicats.', 4)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (4, N'Tommy Jeans ORIGINAL STRETCH SLIM FIT - Chemise', 69.989997863769531, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F16082493135432d14e81ca06c4131b552f20b5e78d9a4.jpeg?alt=media&token=a9999242-af37-4fba-9bb0-16150be7abec', N'97% coton, 3% élasthanne. Conseils d''entretien: Lavage en machine à 30°C, lavage textiles délicats.', 7)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (5, N'Jack & Jones JJIPAUL JJFLAKE - Pantalon cargo', 49.9900016784668, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F16082494019674223b64098e549b88b56ac518a40909b.jpeg?alt=media&token=3f193c0f-8497-4bd1-b185-e142252e1264', N'98% coton, 2% élasthanne. Conseils d''entretien: Lavage en machine à 40°C', 8)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (6, N'[Noir] Lacoste T-shirt basique', 39.9900016784668, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F1608249570888dfa8d3ef874641bd9f03f0bedcfcbb65.jpeg?alt=media&token=8c1f2709-56e6-4332-83cf-10ca7309c2cc', N'Composition: 100% coton. Jersey. Conseils d''entretien: Lavage en machine à 40°C, ne pas mettre au sèche-linge.', 6)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (7, N'[Jaune] Lacoste T-shirt basique', 39.9900016784668, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F1608249664398502515d1e0b34dc4b3e5915800d10881.jpeg?alt=media&token=91fb5725-1a04-4a0f-87ad-e442f1c2f853', N'Composition: 100% coton. Jersey. Conseils d''entretien: Lavage en machine à 40°C, ne pas mettre au sèche-linge.', 6)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (8, N'Tommy Hilfiger C-NECK - Pullover', 89.949996948242188, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F16082498099124df44bc2d3a24648a84a0ec1e87a0ca0.jpeg?alt=media&token=ab30b5f3-e018-45aa-9459-e93546a38c16', N'88% coton, 12% soie. Conseils d''entretien: Lavage en machine à 30°C, lavage textiles délicats.', 5)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (9, N'Adidas Originals TREFOIL CREW UNISEX - Sweatshirt', 49.950000762939453, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F1608249938404bd02724b253b42e5909bdf415a67f445.jpeg?alt=media&token=9666ae0b-ee81-457c-955e-3301b549a889', N'Sweat 100% coton. Conseils d''entretien: Lavage en machine à 30°C, lavage textiles délicats.', 5)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (10, N'Levi''s 511 SLIM FIT - Jean slim', 99.949996948242188, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F160825003856566158908d4de4638b095d92a234c5c32.jpeg?alt=media&token=6c0b49fc-cfa4-4e56-b2f1-70f1854d1da3', N'Composition: 93% coton, 4% polyester, 2% polyéthylène, 1% élasthanne. Matière: Denim. Contient des éléments non-textiles d''origine animale: Oui. Conseils d''entretien: Lavage en machine à 30°C.', 8)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (11, N'Adidas Originals veste en sweat zippée', 49.950000762939453, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F16082502418285859155e668d49ad884a30a84a21e8e8.jpeg?alt=media&token=423ace25-9f8e-49f4-8f69-815ac44d998c', N'Composition: 70% coton, 30% polyester. Matière: Sweat. Conseils d''entretien: Ne pas mettre au sèche-linge, lavage en machine à 30°C, lavage textiles délicats.', 5)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (12, N'Nike Sportswear CLUB - Short', 27.950000762939453, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F16082504319321d52252ab81f465a8ab149c4e31b4051.jpeg?alt=media&token=f7f01779-0ee1-4126-8809-c8d6e9f5cf93', N'Composition: 100% coton. Matière: Sweat. Conseils d''entretien: Lavage en machine à 40°C', 9)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (13, N'Petrol Industries Short', 33.450000762939453, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F160825047091123ea9c9a27b846b097b4273531592a1c.jpeg?alt=media&token=c5e6b25d-cbe7-4869-b80d-c80d7a6d6f84', N'Composition: 100% coton. Conseils d''entretien: Ne pas mettre au sèche-linge, lavage en machine à 30°C, lavage textiles délicats.', 9)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (14, N'Nike Sportswear Short', 59.950000762939453, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F1608250564011c4d656b8d6e94f8cb77aa974dac21a33.jpeg?alt=media&token=74ee5c48-8a9c-4356-a6db-febebd3af321', N'Composition: 100% nylon. Conseils d''entretien: Lavage en machine à 30°C.', 9)
INSERT [dbo].[item] ([id], [label], [price], [imageItem], [descriptionItem], [categoryId]) VALUES (15, N'Pier One Sweat à capuche', 32.950000762939453, N'https://firebasestorage.googleapis.com/v0/b/ventements-83dd9.appspot.com/o/images%2F16082507493295fad315f8b7642059e80e28f8053387e.jpeg?alt=media&token=cf320436-195f-43e4-9c0b-53bf19de58c4', N'Composition: 50% polyester, 50% coton. Matière: Sweat. Conseils d''entretien: Ne pas mettre au sèche-linge, lavage en machine à 30°C, lavage textiles délicats.', 4)
SET IDENTITY_INSERT [dbo].[item] OFF
GO
SET IDENTITY_INSERT [dbo].[review] ON 

INSERT [dbo].[review] ([id], [stars], [title], [descriptionReview], [itemId], [uservId]) VALUES (1, 5, N'Très bon rapport qualité-prix', N'Et le design est vraiment très beau !', 15, 3)
INSERT [dbo].[review] ([id], [stars], [title], [descriptionReview], [itemId], [uservId]) VALUES (6, 5, N'Excellent', N'Parfait !', 1, 1)
INSERT [dbo].[review] ([id], [stars], [title], [descriptionReview], [itemId], [uservId]) VALUES (7, 5, N'Excellent', N'Tres beau !', 4, 4)
INSERT [dbo].[review] ([id], [stars], [title], [descriptionReview], [itemId], [uservId]) VALUES (8, 5, N'J''adore l''orange', N'Ceci est ma marque préférée et ma couleur préférée ! Le choix est donc vite fait.', 2, 4)
SET IDENTITY_INSERT [dbo].[review] OFF
GO
SET IDENTITY_INSERT [dbo].[wishlist] ON 

INSERT [dbo].[wishlist] ([id], [uservId], [itemId], [addedAt]) VALUES (1, 1, 1, CAST(N'2020-12-18T00:53:43.040' AS DateTime))
INSERT [dbo].[wishlist] ([id], [uservId], [itemId], [addedAt]) VALUES (3, 4, 4, CAST(N'2020-12-18T22:32:34.460' AS DateTime))
SET IDENTITY_INSERT [dbo].[wishlist] OFF
GO
SET IDENTITY_INSERT [dbo].[baggedItem] ON 

INSERT [dbo].[baggedItem] ([id], [addedAt], [quantity], [size], [uservId], [itemId]) VALUES (1, CAST(N'2020-12-18T01:28:29.067' AS DateTime), 1, N'L', 3, 15)
SET IDENTITY_INSERT [dbo].[baggedItem] OFF
GO
SET IDENTITY_INSERT [dbo].[orderv] ON 

INSERT [dbo].[orderv] ([id], [isPaid], [orderedAt], [uservid]) VALUES (1, 0, CAST(N'2020-12-18T01:34:41.047' AS DateTime), 1)
INSERT [dbo].[orderv] ([id], [isPaid], [orderedAt], [uservid]) VALUES (2, 0, CAST(N'2020-12-18T22:40:22.160' AS DateTime), 4)
SET IDENTITY_INSERT [dbo].[orderv] OFF
GO
SET IDENTITY_INSERT [dbo].[orderedItem] ON 

INSERT [dbo].[orderedItem] ([id], [quantity], [size], [ordervId], [itemId]) VALUES (1, 2, N'L', 1, 1)
INSERT [dbo].[orderedItem] ([id], [quantity], [size], [ordervId], [itemId]) VALUES (2, 1, N'M', 1, 14)
INSERT [dbo].[orderedItem] ([id], [quantity], [size], [ordervId], [itemId]) VALUES (3, 1, N'L', 2, 2)
SET IDENTITY_INSERT [dbo].[orderedItem] OFF
GO
