﻿using System;
using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Orders.Dto;
using Domain.Orders;

namespace Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderedItemRepository _orderedItemRepository;

        public OrderService(IOrderRepository orderRepository, IOrderedItemRepository orderedItemRepository)
        {
            _orderRepository = orderRepository;
            _orderedItemRepository = orderedItemRepository;
        }

        public IEnumerable<OutputQueryOrder> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public OutputQueryOrder GetById(int orderId)
        {
            var orderFromDb = _orderRepository.GetById(orderId);
            var orderedItems = _orderedItemRepository.GetByOrderId(orderFromDb.Id);
            var userOrder = new UserOrder();
            userOrder.AddOrderedItems(orderedItems);
            
            return new OutputQueryOrder
            {
                Id = orderFromDb.Id,
                IsPaid = orderFromDb.IsPaid,
                OrderedAt = orderFromDb.orderedAt,
                TotalPrice = userOrder.ComputeOrderPrice(),
                Ordered = new OutputQueryOrder.User
                {
                    Id = orderFromDb.Orderer.Id,
                    Firstname = orderFromDb.Orderer.Firstname,
                    Lastname = orderFromDb.Orderer.Lastname,
                    Email = orderFromDb.Orderer.Email,
                },
                OrderedItems = userOrder.OrderedItems.Select(orderedItem => new OutputQueryOrder.Item
                {
                    Id = orderedItem.ItemOrdered.Id,
                    Label = orderedItem.ItemOrdered.Label,
                    Price = orderedItem.ItemOrdered.Price,
                    ImageItem = orderedItem.ItemOrdered.ImageItem,
                    DescriptionItem = orderedItem.ItemOrdered.DescriptionItem
                })
            };
        }

        public OutputAddOrder Create(int userId)
        {
            var orderFromDb = _orderRepository.Create(userId);

            // todo
            throw new NotImplementedException();
        }
    }
}