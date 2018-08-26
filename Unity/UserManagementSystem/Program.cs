using System;
using Unity;

namespace UserManagementSystem
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IDataAccessLayer, OracleDal>();

            User user = container.Resolve<User>();
            user.Add();
        }
    }

    public class User
    {
        private IDataAccessLayer _dataAccessLayer;

        public User(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
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