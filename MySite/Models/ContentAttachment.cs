using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Models
{
    public class ContentAttachment
    {
        public int ContentAttachmentId { get; set; }
        public ContentData ContentData { get; set; }
        public int ContentDataId { get; set; }
        public string Title { get; set; }
        public string FileType { get; set; }
        public string Path { get; set; }
    }
}