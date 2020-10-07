using FileVault.DAL.Entities;
using System.Collections.Generic;

namespace FileVault.IRepositories
{
    public interface IFileRepository
    {
        public void AddFile(File file);
        public File FindFile(string hash);
        public ICollection<UploadFile> FindFilesForUser(int userId);
        public void Delete(int id);
        public void Save(); 
    }
}
