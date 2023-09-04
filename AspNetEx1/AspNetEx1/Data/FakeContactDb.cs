using AspNetEx1.Models;
using Microsoft.AspNetCore.SignalR;

namespace AspNetEx1.Data
{
    public static class FakeContactDb
    {
        static public List<Contact> Contacts { get; } = new List<Contact>(new Contact[] { new Contact() { Id = 0, FName = "John", LName = "Doe" }, new Contact() { Id = 1, FName = "Jane", LName = "Doe" } });
        static public int Count { get => Contacts.Count; }

        public static Contact Get(int id)
        {
            return Contacts[id];
        }

        public static void Add(Contact c)
        {
            Contacts.Add(c);
        }
    }
}
