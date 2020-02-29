using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MySite.Models
{
    public class SiteConfig
    {
        public int SiteConfigID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}