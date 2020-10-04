using System.Collections.Generic;

namespace FileVault.DAL.Entities
{
    public partial class File
    {
        public File()
        {
            UploadFiles = new HashSet<UploadFile>();
        }

        public int Id { get; set; }
        public string Hash { get; set; }
        public byte[] Content { get; set; }

        public virtual ICollection<UploadFile> UploadFiles { get; set; }
    }
}
