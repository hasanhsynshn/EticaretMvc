using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsn.ETicaret.Core.Model.Entity
{
    public class Category:EntityBase
    {

        //Default değeri sıfır çünkü üst Id sıfırsa ana kategori olur.
        #region Properties
        public int ParentId { get; set; } = 0;
        public string Name { get; set; }
        public bool IsActive { get; set; } 
        #endregion 

    }
}
