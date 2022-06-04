using Dapper;
using E_Learning.DAL.Authentication;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.IO;
using System.Text;

namespace E_Learning.DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private string _connectionString;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectRepository(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public string AssignProject(IFormFile file, string facultyName, string project, string assignTo)
        {
            if (file.Length > 0 && file != null)
            {
                string path = _webHostEnvironment.ContentRootPath + "\\uploads\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string ID = Guid.NewGuid().ToString();
                using (FileStream fs = System.IO.File.Create(path + ID))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                    using(var conn = new NpgsqlConnection(_connectionString))
                    {
                        var query = $"INSERT INTO PROJECTS (Id, ProjectName, FileNameAssigned, FileTypeAssigned, AssignBy, AssignedAt, AssignTo) VALUES ('{Guid.NewGuid().ToString()}', '{project}', '{file.FileName}', '{file.ContentType}', '{facultyName}', '{DateTime.Now}', '{assignTo}');";
                        var res = conn.Execute(query);
                        if (res > 0)
                            return "Project assigned successfully";
                        else
                            return "Project assigned failure!!!";
                    }
                }
            }
            return "File is empty";
        }

        public string Delete(string id)
        {
            string path = _webHostEnvironment.ContentRootPath + "\\uploads\\";
            System.IO.File.Delete(path + id);
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var query = $"DELETE FROM PROJECTS WHERE Id='{id}';";
                var res = conn.Execute(query);
                if (res > 0)
                    return "Project DELETED successfully";
                else
                    return "Project DELETE failure!!!";
            }
        }

        //public async Task<Project> Edit(string id, IFormFile file, string project)
        //{
        //    var projectData = await _dbContext.Projects.FindAsync(id);
        //    if (file.Length > 0 && file != null)
        //    {
        //        string path = _webHostEnvironment.ContentRootPath + "\\uploads\\";
        //        System.IO.File.Delete(path + id);

        //        using (FileStream fs = System.IO.File.Create(path + id))
        //        {
        //            file.CopyTo(fs);
        //            fs.Flush();
        //            projectData.ProjectName = project;
        //            projectData.FileTypeAssigned = file.ContentType;
        //            projectData.FileNameAssigned = file.FileName;

        //            await _dbContext.SaveChangesAsync();
        //            return projectData;
        //        }
        //    }
        //    else
        //    {
        //        projectData.ProjectName = project;
        //        await _dbContext.SaveChangesAsync();
        //        return projectData;
        //    }
        //}

        //public async Task<List<Project>> Get()
        //{
        //    var list = await _dbContext.Projects.ToListAsync();
        //    return list;
        //}

        //public async Task<List<Project>> Get(string userName)
        //{
        //    var user = await _userManager.FindByNameAsync(userName);
        //    var role = await _userManager.GetRolesAsync(user);
        //    List<Project> list;
        //    if(role[0] == "Student")
        //    {
        //        list = await _dbContext.Projects.Where(x => x.AssignTo == userName).ToListAsync();
        //        return list;
        //    }else if(role[0] == "Faculty")
        //    {
        //        list = await _dbContext.Projects.Where(x => x.AssignBy == userName).ToListAsync();
        //        return list;
        //    }
        //    return null;
        //}

        //public async Task<List<Project>> GetUnSubmitted(string userName)
        //{
        //    var user = await _userManager.FindByNameAsync(userName);
        //    var role = await _userManager.GetRolesAsync(user);
        //    List<Project> list;
        //    if (role[0] == "Student")
        //    {
        //        list = await _dbContext.Projects.Where(x => x.AssignTo == userName && x.FileNameSubmitted == null).ToListAsync();
        //        return list;
        //    }
        //    return null;
        //}

        //public async Task<Project> GetProject(string id)
        //{
        //    return await _dbContext.Projects.FindAsync(id);
        //}

        //public async Task<Project> SubmitProject(string id, IFormFile file, string studentName)
        //{
        //    var projectData = await _dbContext.Projects.FindAsync(id);
        //    string path = _webHostEnvironment.ContentRootPath + "\\uploads\\";
        //    if (file.Length > 0 && file != null)
        //    {
        //        using (FileStream fs = System.IO.File.Create(path + file.FileName))
        //        {
        //            file.CopyTo(fs);
        //            fs.Flush();
        //            projectData.SubmittedAt = DateTime.Now;
        //            projectData.FileTypeSubmitted = file.ContentType;
        //            projectData.FileNameSubmitted = file.FileName;

        //            await _dbContext.SaveChangesAsync();
        //            return projectData;
        //        }
        //    }
        //    return null;
        //}
    }
}
