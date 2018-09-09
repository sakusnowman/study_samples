using Counter_wfa.Configuration;
using Counter_wfa.Contollers;
using Counter_wfa.Views;
using IocLabo;
using MessengerHelper.Messengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Counter_wfa
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new SetUp().SetUP();
            Application.Run(new CountersView(Labo.Resolve<IMessenger>(), Labo.ConstructByLongestArgs<CountersViewController>()));
        }
    }
}
