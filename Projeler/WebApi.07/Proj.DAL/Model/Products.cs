﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proj.DAL
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int ProductId { get; set; }
        [Required(ErrorMessage ="Ürün adı boş geçilemez")]
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool? Discontinued { get; set; }

        public Categories Category { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
