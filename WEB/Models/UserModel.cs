using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; } // Это поле связано с первичным ключом USER_ID

        [Required]
        [StringLength(20, ErrorMessage = "Имя не может быть длиннее 20 символов.")]
        public string FName { get; set; } // Поле FNAME

        [Required]
        [StringLength(20, ErrorMessage = "Фамилия не может быть длиннее 20 символов.")]
        public string LName { get; set; } // Поле LNAME

        [Required]
        [EmailAddress(ErrorMessage = "Введите корректный адрес электронной почты.")]
        [StringLength(80, ErrorMessage = "Email не может быть длиннее 80 символов.")]
        public string Email { get; set; } // Поле EMAIL

        [Required]
        [StringLength(16, ErrorMessage = "Пароль не может быть длиннее 16 символов.")]
        public string Password { get; set; } // Поле PASSWORD
    }
}
