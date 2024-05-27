namespace TechLibrary
{
    public class Admins
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Admins(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
