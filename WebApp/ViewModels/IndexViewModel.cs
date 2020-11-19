using ServiceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class IndexViewModel
    {
        public IOrderedEnumerable<Product> ordererdProducts {get;set;}
        public string patchResult { get; set; }
    }
}
