using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Models
{
    public class ContentTag
    {
        public int ContentTagId { get; set; }
        public ContentTagMaster ContentTagMaster { get; set; }
        public int ContentTagMasterId { get; set; }
        public int ContentId { get; set; }


    }
}