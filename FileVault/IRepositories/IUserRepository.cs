using FileVault.DAL.Entities;

namespace FileVault.IRepositories
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public User FindUser(int id);
        public void Delete(int id);
        public void Save();
    }
}
