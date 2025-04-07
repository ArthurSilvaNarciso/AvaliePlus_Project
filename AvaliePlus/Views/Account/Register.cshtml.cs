using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AvaliePlus.Views.Account
{
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
            // L�gica de GET, se necess�rio
        }

        public void OnPost()
        {
            var result = SomeRegistrationMethod(); // Substitua pelo m�todo real que retorna 'result'

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                Console.WriteLine($"Erro no cadastro: {error.Description}");
            }
        }

        // Exemplo de m�todo simulado (remova isso se j� tiver o seu)
        private dynamic SomeRegistrationMethod()
        {
            return new
            {
                Errors = new[]
                {
                    new { Description = "Email j� cadastrado" },
                    new { Description = "Senha muito fraca" }
                }
            };
        }
    }
}
