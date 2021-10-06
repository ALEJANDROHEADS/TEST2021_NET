using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHeadsBooks.Models
{
    public class Library
    {
        public String titulo { get; set; }
        public String sinopsis { get; set; }
        public Int32 n_paginas { get; set; }
        public String Editorial { get; set; }
        public String Autor { get; set; }
    }
}