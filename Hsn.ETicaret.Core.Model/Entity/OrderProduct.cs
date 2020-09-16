﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsn.ETicaret.Core.Model.Entity
{
   public  class OrderProduct:EntityBase
    {
        #region Properties
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; } 
        #endregion

    }
}
