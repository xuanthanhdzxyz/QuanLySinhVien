using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Models;
using QuanLySinhVien.Data;

namespace QuanLySinhVien.Controllers
{
    public class StudentController : Controller
    {
        // GET: /Student/Index - Hiển thị danh sách
        public IActionResult Index()
        {
            var students = DataContext.Students;
            return View(students);
        }

        // GET: /Student/Detail/5 - Xem chi tiết
        public IActionResult Detail(int id)
        {
            var student = DataContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: /Student/Create - Hiển thị form thêm mới
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create - Xử lý thêm mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                // Tạo ID mới
                int newId = DataContext.Students.Max(s => s.Id) + 1;
                student.Id = newId;

                DataContext.Students.Add(student);

                TempData["Success"] = "Thêm sinh viên thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: /Student/Edit/5 - Hiển thị form sửa
        public IActionResult Edit(int id)
        {
            var student = DataContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: /Student/Edit - Xử lý cập nhật
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = DataContext.Students.FirstOrDefault(s => s.Id == student.Id);
                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Email = student.Email;
                    existingStudent.Phone = student.Phone;
                    existingStudent.DateOfBirth = student.DateOfBirth;
                    existingStudent.Address = student.Address;

                    TempData["Success"] = "Cập nhật sinh viên thành công!";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: /Student/Delete/5 - Hiển thị xác nhận xóa
        public IActionResult Delete(int id)
        {
            var student = DataContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: /Student/DeleteConfirmed - Xử lý xóa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = DataContext.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                DataContext.Students.Remove(student);
                TempData["Success"] = "Xóa sinh viên thành công!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}