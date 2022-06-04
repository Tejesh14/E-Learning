using System.ComponentModel.DataAnnotations;

namespace E_Learning.DAL.Models
{
    public class Calendar
    {
        [DataType(DataType.Upload)]
        public string Id { get; set; } = string.Empty;
        public string Event { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string LoggedUser { get; set; } = string.Empty;
    }
}
