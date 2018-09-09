using System;
using System.Collections;
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
            messenger.PostMessage(await CreateCountersChangedMessage());
        }

        public async Task IncrementCounter(string counterName)
        {
            var counter = (await counterService.GetAllCounters()).FirstOrDefault(c => c.Name.Equals(counterName));
            if (counter == null) return;
            await counterService.IncrementCount(counter);
            messenger.PostMessage(await CreateCountersChangedMessage());
        }

        private async Task<CountersChangedMessage> CreateCountersChangedMessage()
        {
            return new CountersChangedMessage(await counterService.GetAllCounters());
        }
    }
}
