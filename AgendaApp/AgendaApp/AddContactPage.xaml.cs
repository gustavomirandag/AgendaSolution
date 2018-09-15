using AgendaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddContactPage : ContentPage
	{
        private List<Contact> _contacts;

        public event EventHandler ContactAdded;
		public AddContactPage (List<Contact> contacts)
		{
			InitializeComponent ();
            _contacts = contacts;
		}

        private void ButtonCreate_Clicked(object sender, EventArgs e)
        {
            //Add the new contact to database
            _contacts.Add(CreateNewContact());

            ContactAdded(this, new EventArgs());

            //Pop Modal Async (go back to MainPage)
            Navigation.PopModalAsync(true);
        }

        /// <summary>
        /// Function that creates a new contact
        /// </summary>
        /// <returns></returns>
        private Contact CreateNewContact()
        {
            var contact = new Contact();
            contact.Name = EntryName.Text;
            contact.Phone = EntryPhone.Text;
            contact.Email = EntryEmail.Text;

            return contact;
        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}