﻿using System.Collections.Generic;
using System.Linq;
using Application.Exceptions;
using Application.Repositories;
using Application.Services.OrderedItems.Dto;
using Domain.OrderedItems;

namespace Application.Services.OrderedItems
{
    public class OrderedItemService : IOrderedItemService
    {
        private IOrderedItemRepository _orderedItemRepository;

        public OrderedItemService(IOrderedItemRepository orderedItemRepository)
        {
            _orderedItemRepository = orderedItemRepository;
        }

        public IEnumerable<OutputDtoQueryOrderedItem> GetByOrderId(int orderId)
        {
            return _orderedItemRepository
                .GetByOrderId(orderId)
                .Select(orderedItem => new OutputDtoQueryOrderedItem
                {
                    Id = orderedItem.Id,
                    ItemOrder = new OutputDtoQueryOrderedItem.Order
                    {
                        Id = orderedItem.Order.Id
                    },
                    ItemOrdered = new OutputDtoQueryOrderedItem.Item
                    {
                        Id = orderedItem.ItemOrdered.Id,
                        Label = orderedItem.ItemOrdered.Label,
                        Price = orderedItem.ItemOrdered.Price,
                        ImageItem = orderedItem.ItemOrdered.ImageItem,
                        DescriptionItem = orderedItem.ItemOrdered.DescriptionItem,
                        Quantity = orderedItem.Quantity,
                        Size = orderedItem.Size
                    }
                });
        }

        public OutputDtoQueryOrderedItem GetById(int orderedItemId)
        {
            var orderedItemFromDb = _orderedItemRepository.GetById(orderedItemId);

            return new OutputDtoQueryOrderedItem
            {
                Id = orderedItemFromDb.Id,
                ItemOrder = new OutputDtoQueryOrderedItem.Order
                {
                    Id = orderedItemFromDb.Order.Id
                },
                ItemOrdered = new OutputDtoQueryOrderedItem.Item
                {
                    Id = orderedItemFromDb.ItemOrdered.Id,
                    Label = orderedItemFromDb.ItemOrdered.Label,
                    Price = orderedItemFromDb.ItemOrdered.Price,
                    ImageItem = orderedItemFromDb.ItemOrdered.ImageItem,
                    DescriptionItem = orderedItemFromDb.ItemOrdered.DescriptionItem,
                    Quantity = orderedItemFromDb.Quantity,
                    Size = orderedItemFromDb.Size
                }
            };
        }

        public OutputDtoQueryOrderedItem AddItemToOrder(int orderId, int itemId,
            InputDtoAddOrderedItem inputDtoAddOrderedItem)
        {
            var orderedItemId = _orderedItemRepository.AddItemToOrder(orderId, itemId,
                new OrderedItem {Quantity = inputDtoAddOrderedItem.Quantity, Size = inputDtoAddOrderedItem.Size});

            return GetById(orderedItemId.Id);
        }

        public IEnumerable<OutputDtoQueryOrderedItem> AddItemsToOrder(int orderId,
            InputDtoAddOrderedItems inputDtoAddOrderedItems)
        {
            IList<OutputDtoQueryOrderedItem> orderedItems = new List<OutputDtoQueryOrderedItem>();

            foreach (var orderedItem in inputDtoAddOrderedItems.OrderedItems)
            {
                try
                {
                    orderedItems.Add(AddItemToOrder(orderId, orderedItem.ItemId,
                        new InputDtoAddOrderedItem {Quantity = orderedItem.Quantity, Size = orderedItem.Size}));
                }
                catch (DuplicateSqlPrimaryException) // Not added
                {
                }
            }

            return orderedItems;
        }

        public bool UpdateQuantity(int orderedItemId, InputDtoUpdateOrderedItem inputDtoUpdateOrderedItem)
        {
            return _orderedItemRepository.UpdateQuantity(orderedItemId,
                new OrderedItem {Quantity = inputDtoUpdateOrderedItem.Quantity});
        }

        public bool Delete(int orderedItemId)
        {
            return _orderedItemRepository.Delete(orderedItemId);
        }
    }
}