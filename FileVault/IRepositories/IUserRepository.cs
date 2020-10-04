using FileVault.DAL.Entities;

namespace FileVault.IRepositories
{
    interface IUserRepository
    {
        public void AddUser();

        public User FindUser();
    }
}
