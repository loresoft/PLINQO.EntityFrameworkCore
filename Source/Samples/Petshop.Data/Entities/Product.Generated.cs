﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop.Data.Entities
{
    public partial class Product
    {
        public Product()
        {
            Items = new HashSet<Item>();
        }

        public string ProductId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Descn { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual Category Category1 { get; set; }
    }
}