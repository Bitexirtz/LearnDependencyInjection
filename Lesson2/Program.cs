using System;

namespace UserManagementSystem
{
    public class Program
    {
        private static void Main(string[] args)
        {
            User user = new User(1);
            user.Add();
        }
    }

    public class User
    {
        private IDataAccessLayer _dataAccessLayer;
        public User(int dalType)
        {
            if (dalType == 1)
            {
                _dataAccessLayer = new MsSqlDal();
            }
            else if (dalType == 2)
            {
                _dataAccessLayer = new OracleDal();
            }
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

    public interface IDataAccessLayer
    {
        void Add(string username);
    }

    public class MsSqlDal : IDataAccessLayer
    {
        public void Add(string username)
        {
            Console.WriteLine($"{username} is added to MsSQL DB.");
        }
    }

    public class OracleDal : IDataAccessLayer
    {
        public void Add(string username)
        {
            Console.WriteLine($"{username} is added to Oracle DB.");
        }
    }
}
