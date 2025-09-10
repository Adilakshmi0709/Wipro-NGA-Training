[HttpPost]
public JsonResult createStudent(Student std)
{
    context.Students.Add(std);
    context.SaveChanges();
    string message = "SUCCESS";
    return Json(new { Message = message });
}

[HttpGet]
public JsonResult getStudent()
{
    List<Student> students = new List<Student>();
    students = context.Students.ToList();
    return Json(students, JsonRequestBehavior.AllowGet);
}