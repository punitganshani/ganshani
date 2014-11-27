using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample
{
    public class ContactViewModel 
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        public ContactViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
            Contacts.Add(new Contact { Name = "Sam" });
            Contacts.Add(new Contact { Name = "Tan" });
        }       
    }
}
