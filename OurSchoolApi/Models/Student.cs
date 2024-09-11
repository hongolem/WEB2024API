namespace OurSchoolApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public Classroom? Classroom { get; set; }
        public required int ClassroomId { get; set; }
    }
}
