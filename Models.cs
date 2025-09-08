// Trước khi sửa: Code cũ lưu dữ liệu trong List<string> dạng "id|name|field..."
// -> Nhược điểm: 
//    + Khó đọc, khó bảo trì
//    + Dễ lỗi khi split chuỗi
//    + Không tận dụng được OOP
// Sau khi sửa: Tạo các class riêng cho Student, Teacher, Course, Enrollment, Grade
// -> Ưu điểm: 
//    + Code rõ ràng, dễ bảo trì
//    + Dữ liệu có kiểu rõ ràng
//    + Có thể thêm phương thức riêng cho từng đối tượng

using System;

public class Student {
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double GPA { get; set; }

    public override string ToString() {
        return $"ID:{Id} | Name:{Name} | Age:{Age} | GPA:{GPA}";
    }
}

public class Teacher {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Major { get; set; }

    public override string ToString() {
        return $"ID:{Id} | Name:{Name} | Major:{Major}";
    }
}

public class Course {
    public string Id { get; set; }
    public string Name { get; set; }
    public int Credits { get; set; }

    public override string ToString() {
        return $"ID:{Id} | Name:{Name} | Credits:{Credits}";
    }
}

public class Enrollment {
    public string StudentId { get; set; }
    public string CourseId { get; set; }

    public override string ToString() {
        return $"Student:{StudentId} | Course:{CourseId}";
    }
}

public class Grade {
    public string StudentId { get; set; }
    public string CourseId { get; set; }
    public double Value { get; set; }

    public override string ToString() {
        return $"Student:{StudentId} | Course:{CourseId} | Grade:{Value}";
    }
}

