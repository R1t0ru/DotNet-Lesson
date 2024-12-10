using System.ComponentModel.DataAnnotations;

namespace mvc.Models;

public enum Subject
{
    CS, IT, MATHS, LANGUAGE
}

public class Teacher
{
    //Variables d'instance
    //Gestion d'erreur et message d'erreur
    [Required(ErrorMessage = "L'identifiant est obligatoire")]
    //Affichage
    [Display(Name = "Identifiant")]
    public int Id { get; set; }

    [StringLength(20, MinimumLength = 3)]
    public string Firstname { get; set; }
    public string Lastname { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public int Age { get; set; }
    public Subject Subject { get; set; }
    public DateTime AdmissionDate { get; set; }
}