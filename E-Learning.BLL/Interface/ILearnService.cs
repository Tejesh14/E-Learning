namespace E_Learning.BLL.Interface
{
    public interface ILearnService<T>
    {
        List<T> Get();
        T GetByUserName(string username);
        T Search(string id);
        string Add(T data);
        string Delete(string id);
        string Edit(string id, T data);
    }
}
