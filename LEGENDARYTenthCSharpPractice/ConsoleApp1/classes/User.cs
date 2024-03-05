namespace ConsoleApp1.classes
{
    internal class User : ICloneable
    {
        public int id;
        public string login;
        public string password;
        public int post;
        public User(int id, string login, string password, int post)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.post = post;
        }

        public object Clone()
        {
            return (User)this.MemberwiseClone();
        }
    }
}
