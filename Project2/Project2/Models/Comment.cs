using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool Important { get; set; }
        public Film Film { get; set; }

        public Comment()
        { 
        }
    }
}
