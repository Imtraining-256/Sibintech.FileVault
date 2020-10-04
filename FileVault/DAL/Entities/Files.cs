using System.Collections.Generic;

namespace FileVault.DAL.Entities
{
    public partial class Files
    {
        public Files()
        {
            UploadFiles = new HashSet<UploadFiles>();
        }

        public int Id { get; set; }
        public string Hash { get; set; }
        public byte[] Content { get; set; }

        public virtual ICollection<UploadFiles> UploadFiles { get; set; }
    }
}
