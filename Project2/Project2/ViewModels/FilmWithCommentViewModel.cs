﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.ViewModels
{
    public class FilmWithCommentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Watched { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
