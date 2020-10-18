using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Hash { get; set; }
        public byte[] Content { get; set; }

        public virtual ICollection<UploadFile> UploadFiles { get; set; }
    }
}
