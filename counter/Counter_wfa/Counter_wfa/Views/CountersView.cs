using Counter_wfa.Contollers;
using Counter_wfa.Messages;
using IocLabo;
using MessengerHelper.Messengers;
using MessengerHelper.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Counter_wfa.Views
{
    public partial class CountersView : Form
    {
        CountersViewController controller;
        IPost post;
        public CountersView(IMessenger messenger, CountersViewController countersViewController)
        {
            InitializeComponent();
            controller = countersViewController;
            post = messenger.Register<CountersChangedMessage>(ChangedCounters);
        }

        private async void _addNewCounterButton_Click(object sender, EventArgs e)
        {
            await controller.AddNewCounter(_newCounterNameTextBox.Text);
        }

        private async void _incrementButton_Click(object sender, EventArgs e)
        {
            var selectedItem = _countersListBox.SelectedItem;
            if (selectedItem == null) return;
            var counterName = selectedItem.ToString().Split('\t')[1];
            await controller.IncrementCounter(counterName);
        }

        private void ChangedCounters(CountersChangedMessage message)
        {
            _countersListBox.Items.Clear();
            message.CountersToString().ToList().ForEach(c => _countersListBox.Items.Add(c));
        }
    }
}
