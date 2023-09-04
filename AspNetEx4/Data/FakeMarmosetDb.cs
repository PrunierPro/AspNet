using AspNetEx4.Models;

namespace AspNetEx4.Data
{
    public class FakeMarmosetDb
    {
        private List<Marmoset> _marmosets = new List<Marmoset>(new Marmoset[] {new Marmoset() { Id = 0, Name = "Test", Age = 3} });

        public List<Marmoset> GetAll()
        {
            return _marmosets;
        }

        public Marmoset GetById(int id)
        {
            return _marmosets[id];
        }

        public bool Add(Marmoset m)
        {
            _marmosets.Add(m);
            return true;
        }
    }
}
