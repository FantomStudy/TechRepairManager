namespace TechLibrary
{
    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Users(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
