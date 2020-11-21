﻿using Domain.Shared;

namespace Domain.Categories
{
    public interface ICategory : IEntity
    {
        public string Title { get; set; }
    }
}