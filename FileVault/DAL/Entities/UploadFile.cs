using System;

namespace FileVault.DAL.Entities
{
    public partial class UploadFile
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? FileId { get; set; }
        public DateTime? UploadDate { get; set; }
        public string FileName { get; set; }

        public virtual File File { get; set; }
        public virtual User User { get; set; }
    }
}
