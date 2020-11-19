using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceProject.Models
{
    public class UpdateModel
    {
        public int Value { get; set; }
        public string Path { get; set; }
        public string Op { get; set; }   
        public string From { get; set; }
    }
}
