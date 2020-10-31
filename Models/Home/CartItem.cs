using Online_Shopping.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping.Models.Home
{
    public class CartItem
    {
        public Tbl_Product Product { get; set; }
        public int Quantity { get; set; }

    }
}