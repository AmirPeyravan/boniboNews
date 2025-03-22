using BoniboNews.Models;
using BoniboNews.Data;
using BoniboNews.Models;

namespace BoniboNews.Data.Repositories
{
    public interface IUserRepository
    {
        bool IsExistUserByUserName(string userName);
        void AddUser(Users users);
        Users GetUserForLogin(string username, string password);
    }


    public class UserRepository : IUserRepository
    {
        MyContext _Context;
        public UserRepository(MyContext context)
        {
            _Context = context;
        }
        public void AddUser(Users users)
        {
            _Context.Add(users);
            _Context.SaveChanges();
        }

        public Users GetUserForLogin(string username, string password)
        {
            return _Context.Users
                   .SingleOrDefault(u => u.UserName == username && u.Password == password);
        }

        public bool IsExistUserByUserName(string userName)
        {
            return _Context.Users.Any(c => c.UserName == userName);
        }
    }
}
