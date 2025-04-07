using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AvaliePlus.Views.Account
{
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
            // Lógica de GET, se necessário
        }

        public void OnPost()
        {
            var result = SomeRegistrationMethod(); // Substitua pelo método real que retorna 'result'

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                Console.WriteLine($"Erro no cadastro: {error.Description}");
            }
        }

        // Exemplo de método simulado (remova isso se já tiver o seu)
        private dynamic SomeRegistrationMethod()
        {
            return new
            {
                Errors = new[]
                {
                    new { Description = "Email já cadastrado" },
                    new { Description = "Senha muito fraca" }
                }
            };
        }
    }
}
