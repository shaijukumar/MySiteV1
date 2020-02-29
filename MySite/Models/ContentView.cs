using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Models
{
    public class ContentView
    {
        public int ContentViewId { get; set; }
        public int ContentDataId { get; set; }
        public string IP { get; set; }
        public DateTime DateTime { get; set; }
    }
}