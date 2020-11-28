﻿using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Items.Dto;
using Domain.Items;

namespace Application.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ItemService(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<OutputDtoQueryItem> Query()
        {
            return _itemRepository
                .Query()
                .Select(item => new OutputDtoQueryItem
                {
                    Id = item.Id,
                    Label = item.Label,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ImageItem = item.ImageItem,
                    DescriptionItem = item.DescriptionItem,
                    Size = item.Size,
                    ItemCategory = new OutputDtoQueryItem.Category
                    {
                        Id = item.Category.Id,
                        Title = item.Category.Title
                    }
                });
        }

        public OutputDtoQueryItem GetById(int id)
        {
            var item = _itemRepository.GetById(id);

            return new OutputDtoQueryItem
            {
                Id = item.Id,
                Label = item.Label,
                Price = item.Price,
                Quantity = item.Quantity,
                ImageItem = item.ImageItem,
                DescriptionItem = item.DescriptionItem,
                Size = item.Size,
                ItemCategory = new OutputDtoQueryItem.Category
                {
                    Id = item.Category.Id,
                    Title = item.Category.Title
                }
            };
        }

        public OutputDtoQueryItem Create(int categoryId, InputDtoAddItem inputDtoAddItem)
        {
            var categoryFromDto = _categoryRepository.GetById(categoryId);

            var itemFromDto = new Item
            {
                Label = inputDtoAddItem.Label,
                Price = inputDtoAddItem.Price,
                Quantity = inputDtoAddItem.Quantity,
                ImageItem = inputDtoAddItem.ImageItem,
                DescriptionItem = inputDtoAddItem.DescriptionItem,
                Size = inputDtoAddItem.Size,
                Category = categoryFromDto
            };

            var itemInDb = _itemRepository.Create(categoryId, itemFromDto);

            return new OutputDtoQueryItem
            {
                Id = itemInDb.Id,
                Label = itemInDb.Label,
                Price = itemInDb.Price,
                Quantity = itemInDb.Quantity,
                ImageItem = itemInDb.ImageItem,
                DescriptionItem = itemInDb.DescriptionItem,
                Size = itemInDb.Size,
                ItemCategory = new OutputDtoQueryItem.Category
                {
                    Id = itemInDb.Category.Id,
                    Title = itemInDb.Category.Title
                }
            };
        }

        /*
        public bool Update(int id, InputDtoUpdateItem inputDtoUpdateItem)
        {
            var itemFromDto = new Item
            {
                Label = inputDtoUpdateItem.Label,
                Price = inputDtoUpdateItem.Price,
                Quantity = inputDtoUpdateItem.Quantity,
                ImageItem = inputDtoUpdateItem.ImageItem,
                DescriptionItem = inputDtoUpdateItem.DescriptionItem,
                Size = inputDtoUpdateItem.Size,
            };

            return _itemRepository.Update(id, itemFromDto);
        }
        */


        public IEnumerable<OutputDtoQueryItem> GetByCategoryId(int categoryId)
        {
            return _itemRepository
                .GetByCategoryId(categoryId)
                .Select(item => new OutputDtoQueryItem
                {
                    Id = item.Id,
                    Label = item.Label,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ImageItem = item.ImageItem,
                    DescriptionItem = item.DescriptionItem,
                    Size = item.Size,
                    ItemCategory = new OutputDtoQueryItem.Category
                    {
                        Id = item.Category.Id,
                        Title = item.Category.Title
                    }
                });
        }
    }
}