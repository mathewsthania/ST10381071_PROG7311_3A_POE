using System.ComponentModel.DataAnnotations;

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*START*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//

namespace ST10381071_PROG7311_3A_POE.Models
{
    public class Farmer
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

    }
}

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*END*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//
