using System;
using System.Collections.Generic;

namespace FileVault
{
    public partial class UploadFiles
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? FileId { get; set; }
        public DateTime? UploadDate { get; set; }
        public string FileName { get; set; }

        public virtual Files File { get; set; }
        public virtual Users User { get; set; }
    }
}
