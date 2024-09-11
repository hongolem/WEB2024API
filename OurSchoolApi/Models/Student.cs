namespace OurSchoolApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;
        public required Classroom Classroom { get; set; }
        public int ClassroomId { get; set; }
    }
}
