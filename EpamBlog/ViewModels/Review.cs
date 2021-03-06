﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EpamBlog.ViewModels
{
    public class Review
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [DisplayName("Author")]
        public string Authorname { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        [DisplayName("Date of publishing")]
        public DateTime Date { get; set; }
    }
}