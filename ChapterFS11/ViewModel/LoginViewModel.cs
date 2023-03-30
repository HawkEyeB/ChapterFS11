using System.ComponentModel.DataAnnotations;

namespace ChapterFS11.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail do usuário")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe o senha do usuário")]
        public string senha { get; set; }

    }
}
