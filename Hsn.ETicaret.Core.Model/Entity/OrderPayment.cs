using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsn.ETicaret.Core.Model.Entity
{
   public class OrderPayment:EntityBase
    {
        #region Properties

        public int OrderId { get; set; }
        public _OrderType OrderType { get; set; }
        public decimal Price { get; set; }
        public string Bank { get; set; } 
        #endregion
    }
    public enum _OrderType
    {
        Havale=0,
        Kredikarti=1
    }
}
