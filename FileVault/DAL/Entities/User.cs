using System.Collections.Generic;

namespace FileVault.DAL.Entities
{
    public partial class User
    {
        public User()
        {
            UploadFiles = new HashSet<UploadFile>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UploadFile> UploadFiles { get; set; }
    }
}
