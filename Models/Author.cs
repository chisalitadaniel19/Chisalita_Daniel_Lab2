using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chisalita_Daniel_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // Proprietate calculată utilă pentru afișarea completă a numelui în dropdown-uri
        [Display(Name = "Author Name")]
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Book>? Books { get; set; }
    }
}