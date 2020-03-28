using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{    
    [Table("test")]
    public class test
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
