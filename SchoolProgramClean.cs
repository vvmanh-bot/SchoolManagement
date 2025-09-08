using System;
using System.Collections.Generic;

public class SchoolProgramClean {
    // Trước: List<string> students = new List<string>();
    // Sau: Dùng List<Student> rõ ràng hơn
    static List<Student> students = new List<Student>();
    static List<Teacher> teachers = new List<Teacher>();
    static List<Course> courses = new List<Course>();
    static List<Enrollment> enrollments = new List<Enrollment>();
    static List<Grade> grades = new List<Grade>();

    public static void Main(string[] args) {
        int menu = 0;
        while (menu != 99) {
            // Trước: menu code lặp lại, khó bảo trì
            // Sau: dùng switch-case gọn gàng hơn
            Console.WriteLine("============= MENU CHINH =============");
            Console.WriteLine("1. Quan ly Sinh vien");
            Console.WriteLine("2. Quan ly Giao vien");
            Console.WriteLine("3. Quan ly Mon hoc");
            Console.WriteLine("4. Quan ly Dang ky hoc");
            Console.WriteLine("5. Quan ly Diem");
            Console.WriteLine("6. Bao cao tong hop");
            Console.WriteLine("99. Thoat");
            Console.Write("Nhap lua chon: ");
            menu = int.Parse(Console.ReadLine());

            switch (menu) {
                case 1: ManageStudents(); break;
                case 2: ManageTeachers(); break;
                case 3: ManageCourses(); break;
                case 4: ManageEnrollments(); break;
                case 5: ManageGrades(); break;
                case 6: Report(); break;
            }
        }
    }

    // -------------------- STUDENT --------------------
    static void ManageStudents() {
        int smenu = 0;
        while (smenu != 9) {
            Console.WriteLine("--- QUAN LY SINH VIEN ---");
            Console.WriteLine("1. Them SV");
            Console.WriteLine("2. Hien thi tat ca SV");
            Console.WriteLine("9. Quay lai");
            smenu = int.Parse(Console.ReadLine());

            if (smenu == 1) {
                // Trước: Lưu students.Add(id + "|" + name + "|" + age + "|" + gpa);
                // Sau: Tạo object Student -> code rõ nghĩa hơn
                Console.Write("Nhap id: "); string id = Console.ReadLine();
                Console.Write("Nhap ten: "); string name = Console.ReadLine();
                Console.Write("Nhap tuoi: "); int age = int.Parse(Console.ReadLine());
                Console.Write("Nhap GPA: "); double gpa = double.Parse(Console.ReadLine());
                students.Add(new Student { Id = id, Name = name, Age = age, GPA = gpa });
            }
            else if (smenu == 2) {
                foreach (var s in students) Console.WriteLine(s);
            }
        }
    }

    // -------------------- TEACHER --------------------
    static void ManageTeachers() {
        int tmenu = 0;
        while (tmenu != 9) {
            Console.WriteLine("--- QUAN LY GIAO VIEN ---");
            Console.WriteLine("1. Them GV");
            Console.WriteLine("2. Hien thi GV");
            Console.WriteLine("9. Quay lai");
            tmenu = int.Parse(Console.ReadLine());

            if (tmenu == 1) {
                Console.Write("Nhap id GV: "); string id = Console.ReadLine();
                Console.Write("Nhap ten GV: "); string name = Console.ReadLine();
                Console.Write("Nhap chuyen mon: "); string major = Console.ReadLine();
                teachers.Add(new Teacher { Id = id, Name = name, Major = major });
            }
            else if (tmenu == 2) {
                foreach (var t in teachers) Console.WriteLine(t);
            }
        }
    }

    // -------------------- COURSE --------------------
    static void ManageCourses() {
        int cmenu = 0;
        while (cmenu != 9) {
            Console.WriteLine("--- QUAN LY MON HOC ---");
            Console.WriteLine("1. Them MH");
            Console.WriteLine("2. Hien thi MH");
            Console.WriteLine("9. Quay lai");
            cmenu = int.Parse(Console.ReadLine());

            if (cmenu == 1) {
                Console.Write("Nhap id MH: "); string id = Console.ReadLine();
                Console.Write("Nhap ten MH: "); string name = Console.ReadLine();
                Console.Write("Nhap so tin chi: "); int tc = int.Parse(Console.ReadLine());
                courses.Add(new Course { Id = id, Name = name, Credits = tc });
            }
            else if (cmenu == 2) {
                foreach (var c in courses) Console.WriteLine(c);
            }
        }
    }

    // -------------------- ENROLLMENT --------------------
    static void ManageEnrollments() {
        int emenu = 0;
        while (emenu != 9) {
            Console.WriteLine("--- QUAN LY DANG KY ---");
            Console.WriteLine("1. Dang ky mon hoc");
            Console.WriteLine("2. Xem tat ca dang ky");
            Console.WriteLine("9. Quay lai");
            emenu = int.Parse(Console.ReadLine());

            if (emenu == 1) {
                Console.Write("Nhap id SV: "); string sid = Console.ReadLine();
                Console.Write("Nhap id MH: "); string cid = Console.ReadLine();
                enrollments.Add(new Enrollment { StudentId = sid, CourseId = cid });
            }
            else if (emenu == 2) {
                foreach (var e in enrollments) Console.WriteLine(e);
            }
        }
    }

    // -------------------- GRADE --------------------
    static void ManageGrades() {
        int gmenu = 0;
        while (gmenu != 9) {
            Console.WriteLine("--- QUAN LY DIEM ---");
            Console.WriteLine("1. Nhap diem");
            Console.WriteLine("2. Hien thi diem");
            Console.WriteLine("9. Quay lai");
            gmenu = int.Parse(Console.ReadLine());

            if (gmenu == 1) {
                Console.Write("Nhap id SV: "); string sid = Console.ReadLine();
                Console.Write("Nhap id MH: "); string cid = Console.ReadLine();
                Console.Write("Nhap diem: "); double d = double.Parse(Console.ReadLine());
                grades.Add(new Grade { StudentId = sid, CourseId = cid, Value = d });
            }
            else if (gmenu == 2) {
                foreach (var g in grades) Console.WriteLine(g);
            }
        }
    }

    // -------------------- REPORT --------------------
    static void Report() {
        // Trước: Code lồng nhiều for, split chuỗi -> khó đọc
        // Sau: Dùng object + LINQ Find -> code gọn, dễ hiểu
        Console.WriteLine("=== BAO CAO TONG HOP ===");
        foreach (var s in students) {
            Console.WriteLine("Sinh vien: " + s.Name);
            foreach (var e in enrollments) {
                if (e.StudentId == s.Id) {
                    var course = courses.Find(c => c.Id == e.CourseId);
                    if (course != null) {
                        Console.Write(" - Mon hoc: " + course.Name);
                        var g = grades.Find(x => x.StudentId == s.Id && x.CourseId == course.Id);
                        if (g != null) Console.Write(" | Diem: " + g.Value);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
