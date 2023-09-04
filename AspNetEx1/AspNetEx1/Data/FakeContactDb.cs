using AspNetEx1.Models;
using Microsoft.AspNetCore.SignalR;

namespace AspNetEx1.Data
{
    public class FakeContactDb
    {
        private List<Contact> _contacts = new List<Contact>(new Contact[] { new Contact() { Id = 0, FName = "John ", LName = "Doe" }, new Contact() { Id = 1, FName = "Jane", LName = "Doe" } });

        public Contact Get(int id)
        {
            return _contacts[id];
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public void Add(Contact c)
        {
            _contacts.Add(c);
        }
    }
}
