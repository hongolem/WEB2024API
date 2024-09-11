namespace OurSchoolApi.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
