using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Http;
namespace E_Learning.DAL.Interface
{
    public interface IProjectRepository
    {
        string AssignProject(IFormFile file, string facultyName, string project, string assignTo);
        //Task<Project> SubmitProject(string id, IFormFile file, string studentName);
        //Task<List<Project>> Get(string userName);
        //Task<Project> GetProject(string id);
        //Task<List<Project>> Get();
        //Task<List<Project>> GetUnSubmitted(string userName);
        //Task<Project> Edit(string id, IFormFile file, string project);
        string Delete(string id);
    }
}
