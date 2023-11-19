namespace SchoolManagementSystemASPProject.Models
{
    public class TeacherTb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
        public string Shift_type { get; set; }
        public string major { get; set; }
        public string task { get; set; }
        public int exceperiance_years { get; set; }
        public string qualification { get; set; }
        public int date_qualification { get; set; }
        public bool state { get; set; }
        public bool fingerPrintData { get; set; }
    }
}
