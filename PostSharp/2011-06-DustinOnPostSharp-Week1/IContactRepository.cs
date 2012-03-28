
namespace PostSharpDemo1
{
    interface IContactRepository
    {
        void Delete(Contact contact);
        System.Linq.IQueryable<Contact> GetAll();
        System.Linq.IQueryable<Contact> GetByID(int id);
        System.Linq.IQueryable<Contact> GetByName(string value);
        void Insert(Contact contact);
        void Update(Contact contact);
    }
}
