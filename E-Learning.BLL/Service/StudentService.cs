using E_Learning.DAL.Models;
using E_Learning.BLL.Interface;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Repositories;

namespace E_Learning.BLL.Service
{
    public class StudentService : ILearnService<Student>
    {
        private readonly ILearnRepository<Student> _studentRepo;

        public StudentService(ILearnRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public string Add(Student data)
        {
            return _studentRepo.Add(data);
        }

        public string Delete(string id)
        {
            return _studentRepo.Delete(id);
        }

        public string Edit(string id, Student data)
        {
            return _studentRepo.Edit(id, data);
        }

        public List<Student> Get()
        {
            return _studentRepo.Get();
        }

        public Student GetByUserName(string username)
        {
            return _studentRepo.GetByUserName(username);
        }

        public Student Search(string id)
        {
            return _studentRepo.Search(id);
        }
    }
}
