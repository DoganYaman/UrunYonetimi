﻿using UrunYonetimi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrunYonetimi.Web.ViewModel
{
    public class CategoryPageModel
    {
        public Category CurrentCategory { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Product> ProductList { get; set; }
    }
}