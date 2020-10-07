using FileVault.DAL;
using FileVault.DAL.Entities;
using FileVault.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace FileVault.Repositories
{
    public class FileRepository : IFileRepository
    {
        private VaultFileContext _db;

        public FileRepository()
        {
            _db = new VaultFileContext();;
        }

        public void AddFile(File file)
        {
            _db.Files.Add(file);
        }

        public File FindFile(byte[] hash)
        {
            return _db.Files.Find(hash);
        }

        public ICollection<UploadFile> FindFilesForUser(int userId)
        {
            return _db.UploadFiles.Where(r => r.UserId == userId).ToList();
        }

        public void Delete(int id)
        {
            var file = _db.Files.Find(id);

            if (file != null)
            {
                _db.Files.Remove(file);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
