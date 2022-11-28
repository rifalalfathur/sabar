using API.Models;

namespace API.Repository.Interface
{
    public interface IAccountRepositories
    {
        public User Login(string email, string password);
        public int Register (string fullName, string email, string password, DateTime birthDate);
        public int ChangePassword(string email, string password, string baru);
        public int ForgotPassword(string email, string password, string baru);

    }
}
