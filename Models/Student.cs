namespace SchoolManagementSystemASPProject.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; } = DateTime.Now.Date;
        public int Phone { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }

    }
}
