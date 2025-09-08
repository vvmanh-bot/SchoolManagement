// Trước khi sửa: Code cũ dùng ArrayList<String> lưu "id|field1|field2"
// -> Nhược điểm:
//    + Khó đọc, khó bảo trì
//    + Dễ bug khi split chuỗi
//    + Trùng lặp code, không tận dụng OOP
// Sau khi sửa: Tách các class Student, Teacher, Course, Enrollment, Grade
// -> Ưu điểm:
//    + Code rõ ràng, dễ hiểu
//    + Có thể thêm phương thức xử lý riêng cho từng đối tượng
//    + Giảm code trùng lặp, dễ mở rộng

import java.util.*;

class Student {
    String id;
    String name;
    int age;
    double gpa;

    @Override
    public String toString() {
        return "ID:" + id + " | Name:" + name + " | Age:" + age + " | GPA:" + gpa;
    }
}

class Teacher {
    String id;
    String name;
    String major;

    @Override
    public String toString() {
        return "ID:" + id + " | Name:" + name + " | Major:" + major;
    }
}

class Course {
    String id;
    String name;
    int credits;

    @Override
    public String toString() {
        return "ID:" + id + " | Name:" + name + " | Credits:" + credits;
    }
}

class Enrollment {
    String studentId;
    String courseId;

    @Override
    public String toString() {
        return "Student:" + studentId + " | Course:" + courseId;
    }
}

class Grade {
    String studentId;
    String courseId;
    double value;

    @Override
    public String toString() {
        return "Student:" + studentId + " | Course:" + courseId + " | Grade:" + value;
    }
}

public class Vd1Clean {
    static ArrayList<Student> students = new ArrayList<>();
    static ArrayList<Teacher> teachers = new ArrayList<>();
    static ArrayList<Course> courses = new ArrayList<>();
    static ArrayList<Enrollment> enrollments = new ArrayList<>();
    static ArrayList<Grade> grades = new ArrayList<>();

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int menu = 0;
        while (menu != 99) {
            // Trước: menu lặp lại nhiều đoạn if-else
            // Sau: dùng switch-case cho gọn
            System.out.println("============= MENU CHINH =============");
            System.out.println("1. Quan ly Sinh vien");
            System.out.println("2. Quan ly Giao vien");
            System.out.println("3. Quan ly Mon hoc");
            System.out.println("4. Quan ly Dang ky hoc");
            System.out.println("5. Quan ly Diem");
            System.out.println("6. Bao cao tong hop");
            System.out.println("99. Thoat");
            System.out.print("Nhap lua chon: ");
            menu = sc.nextInt(); sc.nextLine();

            switch (menu) {
                case 1 -> manageStudents(sc);
                case 2 -> manageTeachers(sc);
                case 3 -> manageCourses(sc);
                case 4 -> manageEnrollments(sc);
                case 5 -> manageGrades(sc);
                case 6 -> report();
            }
        }
    }

    // -------------------- STUDENTS --------------------
    static void manageStudents(Scanner sc) {
        int smenu = 0;
        while (smenu != 9) {
            System.out.println("--- QUAN LY SINH VIEN ---");
            System.out.println("1. Them SV");
            System.out.println("2. Hien thi tat ca SV");
            System.out.println("9. Quay lai");
            smenu = sc.nextInt(); sc.nextLine();

            if (smenu == 1) {
                // Trước: students.add(id + "|" + name + "|" + age + "|" + gpa);
                // Sau: dùng object Student -> rõ ràng hơn
                Student st = new Student();
                System.out.print("Nhap id: "); st.id = sc.nextLine();
                System.out.print("Nhap ten: "); st.name = sc.nextLine();
                System.out.print("Nhap tuoi: "); st.age = sc.nextInt(); sc.nextLine();
                System.out.print("Nhap GPA: "); st.gpa = sc.nextDouble(); sc.nextLine();
                students.add(st);
            } else if (smenu == 2) {
                for (Student s : students) System.out.println(s);
            }
        }
    }

    // -------------------- TEACHERS --------------------
    static void manageTeachers(Scanner sc) {
        int tmenu = 0;
        while (tmenu != 9) {
            System.out.println("--- QUAN LY GIAO VIEN ---");
            System.out.println("1. Them GV");
            System.out.println("2. Hien thi GV");
            System.out.println("9. Quay lai");
            tmenu = sc.nextInt(); sc.nextLine();

            if (tmenu == 1) {
                Teacher t = new Teacher();
                System.out.print("Nhap id GV: "); t.id = sc.nextLine();
                System.out.print("Nhap ten GV: "); t.name = sc.nextLine();
                System.out.print("Nhap chuyen mon: "); t.major = sc.nextLine();
                teachers.add(t);
            } else if (tmenu == 2) {
                for (Teacher t : teachers) System.out.println(t);
            }
        }
    }

    // -------------------- COURSES --------------------
    static void manageCourses(Scanner sc) {
        int cmenu = 0;
        while (cmenu != 9) {
            System.out.println("--- QUAN LY MON HOC ---");
            System.out.println("1. Them MH");
            System.out.println("2. Hien thi MH");
            System.out.println("9. Quay lai");
            cmenu = sc.nextInt(); sc.nextLine();

            if (cmenu == 1) {
                Course c = new Course();
                System.out.print("Nhap id MH: "); c.id = sc.nextLine();
                System.out.print("Nhap ten MH: "); c.name = sc.nextLine();
                System.out.print("Nhap so tin chi: "); c.credits = sc.nextInt(); sc.nextLine();
                courses.add(c);
            } else if (cmenu == 2) {
                for (Course c : courses) System.out.println(c);
            }
        }
    }

    // -------------------- ENROLLMENTS --------------------
    static void manageEnrollments(Scanner sc) {
        int emenu = 0;
        while (emenu != 9) {
            System.out.println("--- QUAN LY DANG KY ---");
            System.out.println("1. Dang ky mon hoc");
            System.out.println("2. Xem tat ca dang ky");
            System.out.println("9. Quay lai");
            emenu = sc.nextInt(); sc.nextLine();

            if (emenu == 1) {
                Enrollment e = new Enrollment();
                System.out.print("Nhap id SV: "); e.studentId = sc.nextLine();
                System.out.print("Nhap id MH: "); e.courseId = sc.nextLine();
                enrollments.add(e);
            } else if (emenu == 2) {
                for (Enrollment e : enrollments) System.out.println(e);
            }
        }
    }

    // -------------------- GRADES --------------------
    static void manageGrades(Scanner sc) {
        int gmenu = 0;
        while (gmenu != 9) {
            System.out.println("--- QUAN LY DIEM ---");
            System.out.println("1. Nhap diem");
            System.out.println("2. Hien thi diem");
            System.out.println("9. Quay lai");
            gmenu = sc.nextInt(); sc.nextLine();

            if (gmenu == 1) {
                Grade g = new Grade();
                System.out.print("Nhap id SV: "); g.studentId = sc.nextLine();
                System.out.print("Nhap id MH: "); g.courseId = sc.nextLine();
                System.out.print("Nhap diem: "); g.value = sc.nextDouble(); sc.nextLine();
                grades.add(g);
            } else if (gmenu == 2) {
                for (Grade g : grades) System.out.println(g);
            }
        }
    }

    // -------------------- REPORT --------------------
    static void report() {
        // Trước: vòng for lồng + split chuỗi
        // Sau: duyệt object, code dễ hiểu
        System.out.println("=== BAO CAO TONG HOP ===");
        for (Student s : students) {
            System.out.println("Sinh vien: " + s.name);
            for (Enrollment e : enrollments) {
                if (e.studentId.equals(s.id)) {
                    Course c = courses.stream().filter(x -> x.id.equals(e.courseId)).findFirst().orElse(null);
                    if (c != null) {
                        System.out.print(" - Mon hoc: " + c.name);
                        Grade g = grades.stream()
                                .filter(x -> x.studentId.equals(s.id) && x.courseId.equals(c.id))
                                .findFirst().orElse(null);
                        if (g != null) System.out.print(" | Diem: " + g.value);
                        System.out.println();
                    }
                }
            }
        }
    }
}
