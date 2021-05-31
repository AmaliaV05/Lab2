using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.ViewModels
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool Important { get; set; }
        public Film Film { get; set; }

        public CommentViewModel()
        {
        }
    }
}
