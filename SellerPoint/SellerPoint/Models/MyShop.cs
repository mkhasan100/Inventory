﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class MyShop
    {
        [Key]
        public string StreetAddress { get; set; }
        public string Area { get; set; }
        public string Thana { get; set; }

        [DisplayName("Post Code")]
        public int PostCode { get; set; }
        public string District  { get; set; }
        public string Country { get; set; }
        public int Phone { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public int ContactPerson { get; set; }
        public int ContactPersonPhone { get; set; }
        public string About { get; set; }
        public string LogoURL { get; set; }
        public string Remarks { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("Expire Date")]
        public DateTime ExpireDate { get; set; }
        public int DeliveryCharge { get; set; }
        public string RecieptName{ get; set; }
        public string ChalanName { get; set; }
    }
}