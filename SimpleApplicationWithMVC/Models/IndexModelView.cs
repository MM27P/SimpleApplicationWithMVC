using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleApplicationWithMVC.Models
{
    public class IndexModelView
    {
        public List<SimpleApplicationWithMVC.Database.Model.Book> books;
        public string UserName;
    }
}