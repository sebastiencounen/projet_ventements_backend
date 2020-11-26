﻿namespace Application.Services.Items.Dto
{
    public class OutputDtoQueryItem
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string ImageItem { get; set; }
        public string DescriptionItem { get; set; }
        public string Size { get; set; } 
        public int SubcategoryId { get; set; }
    }
}