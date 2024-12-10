namespace mvc.Models;

public enum Subject
{
    CS, IT, MATHS, LANGUAGE
}

public class Teacher
{
    //Variables d'instance
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
    public Subject Subject { get; set; }
    public DateTime AdmissionDate { get; set; }
}