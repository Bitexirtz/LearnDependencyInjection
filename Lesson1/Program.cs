using System;

namespace UserManagementSystem
{
    public class Program
    {
        private static void Main(string[] args)
        {
            User user = new User();
            user.Add();
        }
    }

    public class User
    {
        private MsSqlDal _dataAccessLayer;

        public User()
        {
            _dataAccessLayer = new MsSqlDal();
        }

        private bool IsValid { get { return true; } }

        public void Add()
        {
            if (IsValid == true)
            {
                _dataAccessLayer.Add("SAT-A");
            }
        }
    }

    public class MsSqlDal
    {
        public void Add(string username)
        {
            Console.WriteLine($"{username} is added to MsSQL DB.");
        }
    }
}