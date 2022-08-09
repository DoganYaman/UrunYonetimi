﻿using UrunYonetimi.Data.Model;
using System;
using System.Web;
using System.Web.Mvc;

namespace UrunYonetimi.Admin.Helpers
{
    public static class ImageHelper
    {
        public static IHtmlString Base64Image(this HtmlHelper helper, ProductImage productImage)
        {
            var imgString = string.Format(@"<img  src='data:{0};base64,{1}' height='250' />",
                productImage.ContentType, 
                Convert.ToBase64String(productImage.Content)
                );

            return new HtmlString(imgString);
        }
    }
}