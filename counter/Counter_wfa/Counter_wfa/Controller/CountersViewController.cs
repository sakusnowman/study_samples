using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Counter_wfa.Messages;
using Counter_wfa.Services;
using MessengerHelper.Messengers;

namespace Counter_wfa.Contollers
{
    public class CountersViewController
    {
        private readonly ICountersService counterService;
        private readonly IMessenger messenger;

        public CountersViewController(ICountersService counterService, IMessenger messenger)
        {
            this.counterService = counterService;
            this.messenger = messenger;
        }

        public async Task AddNewCounter(string counterName)
        {
            if (await counterService.AddNewCounter(counterName) == false) return;
            var message = new CountersChangedMessage(await counterService.GetAllCounters());
            messenger.PostMessage(message);
        }
    }
}
