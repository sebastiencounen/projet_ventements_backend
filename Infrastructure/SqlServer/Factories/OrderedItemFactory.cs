﻿using System.Data.SqlClient;
using Domain.Categories;
using Domain.Items;
using Domain.OrderedItems;
using Domain.Orders;
using Domain.Users;
using Infrastructure.SqlServer.Items;
using Infrastructure.SqlServer.OrderedItems;
using Infrastructure.SqlServer.Orders;

namespace Infrastructure.SqlServer.Factories
{
    public class OrderedItemFactory : IInstanceFromReader<IOrderedItem>
    {
        public IOrderedItem CreateFromReader(SqlDataReader reader)
        {
            return new OrderedItem
            {
                Id = reader.GetInt32(reader.GetOrdinal(OrderedItemSqlServer.ColId)),
                Quantity = reader.GetInt32(reader.GetOrdinal(OrderedItemSqlServer.ColQuantity)),
                Size = reader.GetString(reader.GetOrdinal(OrderedItemSqlServer.ColSize)),
                ItemOrdered = new Item
                {
                  Id = reader.GetInt32(reader.GetOrdinal(OrderedItemSqlServer.ColItemId)),
                  Label = reader.GetString(reader.GetOrdinal(ItemSqlServer.ColLabel)),
                  Price = (float) reader.GetDouble(reader.GetOrdinal(ItemSqlServer.ColPrice)),
                  ImageItem = reader.GetString(reader.GetOrdinal(ItemSqlServer.ColImageItem)),
                  DescriptionItem = reader.GetString(reader.GetOrdinal(ItemSqlServer.ColDescriptionItem)),
                  Category = new Category { Id = reader.GetInt32(reader.GetOrdinal(ItemSqlServer.ColCategoryId)) }
                },
                Order = new Order
                {
                    Id = reader.GetInt32(reader.GetOrdinal(OrderedItemSqlServer.ColOrderId)),
                    IsPaid = reader.GetBoolean(reader.GetOrdinal(OrderSqlServer.ColIsPaid)),
                    OrderedAt = reader.GetDateTime(reader.GetOrdinal(OrderSqlServer.ColOrderedAt)),
                    Orderer = new User { Id = reader.GetInt32(reader.GetOrdinal(OrderSqlServer.ColUserId)) }
                }
            };
        }
    }
}