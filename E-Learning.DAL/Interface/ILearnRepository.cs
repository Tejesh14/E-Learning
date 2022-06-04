using System.Collections.Generic;

namespace E_Learning.DAL.Interface
{
    public interface ILearnRepository<T>
    {
        List<T> Get();
        T GetByUserName(string username);
        T Search(string id);
        string Add(T data);
        string Delete(string id);
        string Edit(string id, T data);
    }
}
