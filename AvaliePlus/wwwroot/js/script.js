// Mostrar/ocultar a caixa de avaliação (exemplo)
document.addEventListener("DOMContentLoaded", function () {
    const avaliarBotoes = document.querySelectorAll(".btn-avaliar");
    const caixasChat = document.querySelectorAll(".chatbox");

    avaliarBotoes.forEach((botao, index) => {
        botao.addEventListener("click", () => {
            caixasChat[index].classList.toggle("show");
        });
    });

    // Enviar avaliação (exemplo)
    const forms = document.querySelectorAll(".avaliacao-form");

    forms.forEach(form => {
        form.addEventListener("submit", function (e) {
            e.preventDefault();
            const input = form.querySelector("input[name='mensagem']");
            const lista = form.parentElement.querySelector(".mensagens");

            const novaMensagem = document.createElement("li");
            novaMensagem.textContent = input.value;
            lista.appendChild(novaMensagem);

            input.value = "";
        });
    });
});
