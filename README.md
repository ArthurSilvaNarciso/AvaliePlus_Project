
# 🎬 AvaliePlus

O **AvaliePlus** é uma aplicação web desenvolvida em **ASP.NET Core MVC** para cadastro de filmes, avaliações, gerenciamento de usuários e visualização de dashboards com gráficos. O sistema possui autenticação, controle de permissões por tipo de usuário (administrador e usuário comum), além de uma interface moderna, responsiva e agradável.

---

## 📚 Tabela de Conteúdos

- [Sobre](#-sobre)
- [Pré-requisitos](#-pré-requisitos)
- [Instalação](#-instalação)
- [Uso](#-uso)
- [Tecnologias](#-tecnologias)
- [Contribuição](#-contribuição)
- [Licença](#-licença)
- [Contato](#-contato)

---

## 📖 Sobre

O **AvaliePlus** foi criado com o objetivo de permitir que usuários possam cadastrar filmes, avaliá-los e gerenciar esse conteúdo de forma simples e eficaz. Administradores têm acesso completo ao sistema, podendo gerenciar usuários e visualizar gráficos no dashboard. A interface foi pensada para ser intuitiva, bonita e adaptável a diferentes dispositivos.

---

## 🚀 Pré-requisitos

Antes de rodar o projeto, certifique-se de ter instalado:

- [.NET 6.0 SDK ou superior](https://dotnet.microsoft.com/download)
- [SQL Server ou LocalDB](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Visual Studio 2022 ou superior (com ASP.NET e Entity Framework)](https://visualstudio.microsoft.com/pt-br/)

---

## 🔧 Instalação

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/AvaliePlus.git
```

2. Acesse a pasta do projeto:

```bash
cd AvaliePlus
```

3. Configure o banco de dados:

- Abra o `appsettings.json` e edite a `ConnectionStrings` com os dados do seu servidor SQL.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AvaliePlusDb;Trusted_Connection=True;"
}
```

4. Aplique as migrações (opcional):

```bash
dotnet ef database update
```

5. Rode a aplicação:

```bash
dotnet run
```

---

## 📌 Uso

Acesse o sistema em: [http://localhost:5000](http://localhost:5000)

- Tela de Login e Cadastro
- Cadastro e exibição de filmes
- Avaliações com sistema de notas e comentários
- Dashboard com gráficos animados
- Gerenciamento de usuários (somente para administradores)

---

## 🛠 Tecnologias

- ASP.NET Core MVC - Back-end e Front-end
- Entity Framework Core - ORM
- SQL Server / LocalDB - Banco de dados
- Bootstrap, FontAwesome, SweetAlert2 - Interface moderna
- Chart.js - Gráficos do Dashboard
- jQuery DataTables - Tabelas dinâmicas

---

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch: `git checkout -b minha-feature`
3. Faça suas alterações e commit: `git commit -m 'Adiciona nova funcionalidade'`
4. Envie para o GitHub: `git push origin minha-feature`
5. Abra um Pull Request

---

## 📄 Licença

Este projeto está sob a licença MIT.

---

Se quiser, posso gerar esse README em formato `.md` para você colar direto no seu repositório. Deseja?
