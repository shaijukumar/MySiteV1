using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Models
{
    public class AppField
    {
        public int AppFieldID { get; set; }
        public int AppListID { get; set; }
        public string FieldOrder { get; set; }
        public int FieldTypeID { get; set; }
        public string FieldType { get; set; }
        public string FieldDescription { get; set; }
        public string FieldRef { get; set; }
        
    }
}