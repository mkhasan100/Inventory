using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    [Serializable]
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public int  GroupId { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public string GroupName { get; set; }
    }
}
