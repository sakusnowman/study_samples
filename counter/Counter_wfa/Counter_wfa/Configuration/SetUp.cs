using Counter_wfa.Repositories;
using Counter_wfa.Services;
using IocLabo;
using MessengerHelper.Messengers;
using MessengerHelper.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_wfa.Configuration
{
    class SetUp
    {
        public void SetUP()
        {
            RegisterImplement();
            RegisterSingleton();
        }

        void RegisterImplement()
        {
            Labo.Register<ICountersService, CountersService>();
            Labo.Register<IPostsService, PostService>();
        }

        void RegisterSingleton()
        {
            Labo.RegisterSingleton<ICountersRepository>(new CountersTemporarilyRepository());
            Labo.RegisterSingleton<IMessenger>(new MessageHub(Labo.Resolve<IPostsService>()));
        }
    }
}
