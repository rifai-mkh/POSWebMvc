﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_order_details")]
    public class OrderDetailsEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }
        
        public OrdersEntity Orders { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        public ProductEntity Product { get; set; }

        [Column("unit_price")]
        public int UnitPrice { get; set; }

        [Column("quantity")]
        public long Quantity { get; set; }

        [Column("discount")]
        public Double Discount { get; set; }
    }
}
