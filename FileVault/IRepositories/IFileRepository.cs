using System.Collections;
using System.Collections.Generic;
using FileVault.DAL.Entities;

namespace FileVault.IRepositories
{
    interface IFileRepository
    {
        public void AddFile(File file);
        public File FindFile(byte[] hash);

        public ICollection<File> FindFilesForUser(int userId);
    }
}
