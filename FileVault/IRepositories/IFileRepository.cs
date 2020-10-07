using FileVault.DAL.Entities;
using System.Collections.Generic;

namespace FileVault.IRepositories
{
    interface IFileRepository
    {
        public void AddFile(File file);
        public File FindFile(byte[] hash);
        public ICollection<UploadFile> FindFilesForUser(int userId);
        public void Delete(int id);
        public void Save();
    }
}
