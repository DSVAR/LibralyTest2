﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libraly_test2_.Areas.Account.View.AC
{
    public static class ManageNavPages
    {
        public static string Index => "Index";
        public static string AddBooks => "AddBooks"; 

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string AddBoobsNavClass(ViewContext viewContext) => PageNavClass(viewContext, AddBooks);


        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
