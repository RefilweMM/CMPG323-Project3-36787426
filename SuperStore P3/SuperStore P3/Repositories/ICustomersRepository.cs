using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public interface ICustomersRepository <Customers>
    {
        Customers GetById(int id);
        IEnumerable<Customers> GetAll();
        IEnumerable<Customers> Find(Expression<Func<Customers, bool>> expression);
        void Add(Customers entity);
        void AddRange(IEnumerable<Customers> entities);
        void Remove(Customers entity);
        void RemoveRange(IEnumerable<Customers> entities);
    }
}
