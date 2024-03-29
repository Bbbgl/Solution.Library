﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Options
{
    public class AddingBookViewModel
    {
        
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string PublishingHouse { get; set; }
        public int Quantity { get; set; }

        public AddingBookViewModel(string title, string authorName, string authorSurname,
            string publishingHouse, int quantity)
        {
            
            this.Title = title;
            this.AuthorName = authorName;
            this.AuthorSurname = authorSurname;
            this.PublishingHouse = publishingHouse;
            this.Quantity = quantity;
            
        }

    }
}
