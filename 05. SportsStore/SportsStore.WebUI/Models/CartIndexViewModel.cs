namespace SportsStore.WebUI.Models
{
    using System;
    using Domain.Entities;

    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }

        public String ReturnUrl { get; set; }
    }
}