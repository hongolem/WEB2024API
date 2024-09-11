using System.Text.Json.Serialization;

namespace OurSchoolApi.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [JsonIgnore]
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
