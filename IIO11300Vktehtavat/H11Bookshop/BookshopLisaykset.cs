﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H11Bookshop {
    public partial class Book {
        public string DisplayName {
            get {
                return this.name + " " + this.author;
            }
        }
        }
        public partial class Customer {
        public string DisplayName {
            get {
                return this.firstname + " " + this.lastname;            }
        }

        public int OrderCount {
            get {
                return this.Orders.Count;
            }
        }
    }
}
