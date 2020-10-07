using System.Collections.Generic;

namespace FileVault.DAL.Entities
{
    public partial class File
    {
        private File()
        {
            UploadFiles = new HashSet<UploadFile>();
        }

        public File(byte[] content, string hash)
        {
            Content = content;

            Hash = hash;
        }

        public int Id { get; set; }
        public string Hash { get; set; }
        public byte[] Content { get; set; }

        public virtual ICollection<UploadFile> UploadFiles { get; set; }
    }
}
