using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Http;

namespace E_Learning.BLL.Interface
{
    public interface IProjectService
    {
        string AssignProject(IFormFile file, string facultyName, string project, string assignTo);
        //Task<Project> SubmitProject(string id, IFormFile file, string studentName);
        //Task<List<Project>> Get(string userName);
        //Task<List<Project>> Get();
        //Task<List<Project>> GetUnSubmitted(string userName);
        //Task<Project> GetProject(string id);
        //Task<Project> Edit(string id, IFormFile file, string project);
        string Delete(string id);
    }
}
