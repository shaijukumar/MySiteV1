using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MySite.Models
{
    public class ContentData
    {
        public int ContentDataId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }        
        public string URLString { get; set; }
        public string Content { get; set; }
    }
}