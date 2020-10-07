using FileVault.DAL.Entities;

namespace FileVault.IRepositories
{
    interface IUserRepository
    {
        public void AddUser(User user);

        public User FindUser(User id);

        public void Delete(int id);
        public void Save();
    }
}
