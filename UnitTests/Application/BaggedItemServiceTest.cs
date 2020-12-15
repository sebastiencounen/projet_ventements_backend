﻿using System;
using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.BaggedItems;
using Application.Services.BaggedItems.Dto;
using Domain.Addresses;
using Domain.BaggedItems;
using Domain.Categories;
using Domain.Items;
using Domain.Users;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests.Application
{
    [TestFixture]
    public class BaggedItemServiceTest
    {
        // Helper static methods (Domain instances)
        public static IUser CreateUser(int i)
        {
            return new User
            {
                Id = i,
                Firstname = i.ToString(),
                Lastname = i.ToString(),
                Email = $"{i}@gmail.com",
                Birthdate = DateTime.Now,
                EncryptedPassword = i.ToString(),
                Administrator = false,
                Gender = 'M',
                Address = new Address
                {
                    Id = i,
                    Street = i.ToString(),
                    HomeNumber = i,
                    Zip = i.ToString(),
                    City = i.ToString()
                },
            };
        }

        public static IItem CreateItem(int i)
        {
            return new Item
            {
                Id = i,
                Label = $"Item{i}",
                Price = i,
                ImageItem = i.ToString(),
                DescriptionItem = i.ToString(),
                Category = new Category {Id = i}
            };
        }

        public static IBaggedItem CreateBaggedItem(int i)
        {
            return new BaggedItem
            {
                Id = i,
                Quantity = i,
                Size = i.ToString(),
                AddedAt = DateTime.Now,
                BagOwner = CreateUser(1),
                AddedItem = CreateItem(i)
            };
        }

        public static IEnumerable<IBaggedItem> CreateListOfBaggedItems(int listSize)
        {
            IList<IBaggedItem> baggedItems = new List<IBaggedItem>();
            for (var i = 1; i <= listSize; i++)
            {
                baggedItems.Add(CreateBaggedItem(i));
            }

            return baggedItems;
        }

        // Helper static methods (DTO instances)
        public static OutputDtoQueryUserBaggedItem CreateOutputDtoQueryUserBaggedItem(int i, int listSize)
        {
            var userBag = new UserBag();
            userBag.AddItems(CreateListOfBaggedItems(listSize));
            var dtoBaggedItems = userBag.Items
                .Select(baggedItem => new OutputDtoQueryUserBaggedItem.BaggedItem
                {
                    Id = baggedItem.Id,
                    AddedAt = baggedItem.AddedAt,
                    Quantity = baggedItem.Quantity,
                    Size = baggedItem.Size,

                    BagItem = new OutputDtoQueryUserBaggedItem.BaggedItem.Item
                    {
                        Id = baggedItem.AddedItem.Id,
                        Label = baggedItem.AddedItem.Label,
                        Price = baggedItem.AddedItem.Price * baggedItem.Quantity,
                        ImageItem = baggedItem.AddedItem.ImageItem,
                        DescriptionItem = baggedItem.AddedItem.DescriptionItem
                    }
                });

            var bagOwner = CreateUser(1);
             return new OutputDtoQueryUserBaggedItem
             {
                 BagOwner = new OutputDtoQueryUserBaggedItem.User
                 {
                     Id = bagOwner.Id,
                     Firstname = bagOwner.Firstname,
                     Lastname = bagOwner.Lastname
                 },
                 TotalPrice = userBag.ComputeTotalPrice(),
                 Items = dtoBaggedItems
             };           
        }

        [Test]
        public void GetByUserId_SingleNumber_ReturnsOutputDtoQueryUserBaggedItem()
        {
            // ARRANGE //

            // Substitutes
            var userRep = Substitute.For<IUserRepository>();
            var itemRep = Substitute.For<IItemRepository>();
            var baggedItemRep = Substitute.For<IBaggedItemRepository>();

            // Substitutes behavior
            baggedItemRep.GetByUserId(1).Returns(CreateListOfBaggedItems(2));
            userRep.GetById(1).Returns(CreateUser(1));

            // BaggedItem service
            var baggedItemService = new BaggedItemService(baggedItemRep, userRep, itemRep);

            // Expectation
            var expected = CreateOutputDtoQueryUserBaggedItem(1, 2);

            // ACT //
            var outputBaggedItems = baggedItemService.GetByUserId(1);

            // ASSERT //
            Assert.AreEqual(expected, outputBaggedItems);
        }
    }
}