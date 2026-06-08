using QuanLySinhVien.Models;

namespace QuanLySinhVien.Data
{
    public class DataContext
    {
        private static List<Student> _students = new List<Student>
        {
            new Student { Id = 1, Name = "Nguyễn Văn A", Email = "nguyenvana@example.com", Phone = "0123456789", DateOfBirth = new DateTime(2000, 1, 1), Address = "Hà Nội" },
            new Student { Id = 2, Name = "Trần Thị B", Email = "tranthib@example.com", Phone = "0987654321", DateOfBirth = new DateTime(2001, 2, 2), Address = "Hồ Chí Minh" },
            new Student { Id = 3, Name = "Lê Văn C", Email = "levanc@example.com", Phone = "0912345678", DateOfBirth = new DateTime(2002, 3, 3), Address = "Đà Nẵng" }
        };

        public static List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }
    }
}