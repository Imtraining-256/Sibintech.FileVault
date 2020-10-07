using System.Collections.Generic;

namespace FileVault.DAL.Entities
{
    public partial class User
    {
        private User()
        {
            UploadFiles = new HashSet<UploadFile>();
        }

        public User(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UploadFile> UploadFiles { get; set; }
    }
}
