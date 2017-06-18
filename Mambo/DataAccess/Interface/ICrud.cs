using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo.DataAccess.Interface
{
    public interface ICrud<T>
    {
        bool Create(T obj);
        bool Update(T obj);
        bool Delete(int key);
        T Get(int key);
        List<T> GetAll();
    }
}
