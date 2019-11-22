using System;
using System.Collections.Generic;
using System.Text;

namespace DotMailerCore.Models
{
    public class Attachment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FileName { get; set; }

        public int FileSize { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
