using VirtualStore.Model;

namespace VirtualStore.Services.PersonService
{
    public interface IPersonService
    {
        public Person Create(Person person);
        public Person GetById(long personId);
        public List<Person> GetAll();
        public Person Update(Person person);
        public void Delete(long personId);
    }
}
