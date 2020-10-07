using FileVault.DAL;
using FileVault.DAL.Entities;
using FileVault.IRepositories;

namespace FileVault.Repositories
{
    public class UserRepository : IUserRepository
    {
        private VaultFileContext _db;
        public UserRepository()
        {
            _db = new VaultFileContext();
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
        }

        public User FindUser(User id)
        {
            return _db.Users.Find(id);
        }

        public void Delete(int id)
        {
            var user = _db.Users.Find(id);

            if (user != null)
            {
                _db.Users.Remove(user);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
