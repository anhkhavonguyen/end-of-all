﻿using System;
using System.Collections.Generic;

namespace KVSolution.PIM.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set;}
        public string Phone { get; set; }
        public string POCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
