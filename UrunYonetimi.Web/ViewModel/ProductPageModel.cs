﻿using UrunYonetimi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrunYonetimi.Web.ViewModel
{
    public class ProductPageModel
    {
        public Product CurrentProduct { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}