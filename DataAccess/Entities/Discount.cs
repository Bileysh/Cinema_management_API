﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public string PromotionalOffer { get; set; }
        public int DiscountForRegularCustomers { get; set; }
        public ICollection<User>? Users { get; set; }

    }
}
