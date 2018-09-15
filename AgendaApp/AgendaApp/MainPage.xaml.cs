using AgendaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendaApp
{
    public partial class MainPage : ContentPage
    {
        private static List<Contact> _contacts;

        public MainPage()
        {
            InitializeComponent();
            _contacts = new List<Contact>();
            FillContacts(); //FillContacts for the first time
        }

        public void FillContacts()
        {
            StackLayoutContactsList.Children.Clear();
            foreach(var contact in _contacts)
            {
                var stackLayoutContact = new StackLayout();
                var labelName = new Label
                {
                    Text = contact.Name
                };
                var labelPhone = new Label
                {
                    Text = contact.Phone
                };
                var labelEmail = new Label
                {
                    Text = contact.Email
                };
                stackLayoutContact.Children.Add(labelName);
                stackLayoutContact.Children.Add(labelPhone);
                stackLayoutContact.Children.Add(labelEmail);
                StackLayoutContactsList.Children.Add(stackLayoutContact);
            }
        }

        private void ButtonAddContact_Clicked(object sender, EventArgs e)
        {
            AddContact();
        }

        private void AddContact()
        {
            var addContactPage = new AddContactPage(_contacts);

            addContactPage.ContactAdded += AddContactPage_ContactAdded;

            Navigation.PushModalAsync(addContactPage, true);
        }

        private void AddContactPage_ContactAdded(object sender, EventArgs e)
        {
            FillContacts();
        }
    }
}
