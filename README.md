<h1 align="center">Cadastro_De_Contatos</h1>

## Descrição do desafio

<p align="center">Analisar e desenvolver um sistema de cadastro de pessoas</p>
  
### Requisitos:

- [x] Implementar cadastro (inserção, alteração e exclusão) de contatos com opção de consulta e listagem;
- [x] A consulta e listagem devem considerar todos os dados como filtro.

Realizar o desenvolvimento utilizando C#, JavaScript e o banco de dados de livre escolha (não precisando ser relacional e pode salvar em memória também).

Diferenciais a serem aplicados no desenvolvimento (caso tenha conhecimento):

- [x] ASP.NET MVC, C# e Dar preferência ao Ajax (Não precisa ser preocupar com designer).

### Propriedades:

- [x] Nome [Obrigatório];
- [x] Empresa;
- [x] Email (possibilitando cadastrar vários. Sem limite de quantidade);
- [x] Telefone pessoal;
- [x] Telefone comercial.

## Documentação técnica do desafio

### Escolha da tecnologia e do tipo de projeto a ser utilizado
Para atender o item 1 dos requisitos funcionais poderia criar um projeto API Web do ASP.NET Core (o qual tenho bastante familiaridade) ou Aplicativo Web do ASP.NET Core (Model-View-Controller). Decidi me arriscar na segunda opção para tornar as coisas mais dinamicas e visuais pensando na apresentação das funcionalidades exigidas por este desafio.

## Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [.NET](https://dotnet.microsoft.com/en-us/download). 
Além disto é bom ter um editor para trabalhar com o código como [Visual Studio Code ou Visual Studio](https://code.visualstudio.com/download) 

## 🎲 Rodando o Back End (servidor)

```bash
# Clone este repositório
$ git clone https://github.com/DevClaudinei/Cadastro_De_Contatos.git

# Acesse a pasta do projeto no terminal/cmd
$ cd Cadastro_De_Contatos

# Execute a aplicação
$ Executar o comando dotnet run 

# O servidor inciará na porta:7138 
- Utilizando a URL <https://localhost:7138>
```
## Tela inicial:
![image](https://github.com/DevClaudinei/Cadastro_De_Contatos/assets/103595662/a23256b4-a68b-4758-985d-068a6fc5ebfc)

### Login 
- É utilizado para utilizar as funcionalidades do sistema. Para isso será necessário informar email e senha.

- Usuário padrão cadastrado utiliza o email: admin@teste.com e senha: Admin@1234

### Register
- É utilizado para cadastrar um novo usuário que terá acesso as funcionalidade do sistema, uma vez que estiver cadastrado no banco de dados.

### Cadastros
Nesta pagina teremos as possibilidades:

- Observar a lista de todas os contatos cadastrados (Index);
- Realizar o cadastro de um novo contato (Create);
- Atualizar o cadastro de uma contato (Edit);
- Excluir o cadastro de um contato (Delete);
- Buscar um contato pelo Id (Details);
- Buscar contato pelo nome;
- Buscar contato pelo email;
- Buscar contatos por uma empresa;
- Buscar contato pelo telefone pessoal;
- Buscar contato pelo telefone comercial;

### Tela de Create
![image](https://github.com/DevClaudinei/Cadastro_De_Contatos/assets/103595662/12f61a3f-d0d3-4727-a15e-e461825ae36d)

### Tela de Edit
![image](https://github.com/DevClaudinei/Cadastro_De_Contatos/assets/103595662/b87f5a8e-2e26-44ed-91e5-92ad06fb019d)

### Tela de Delete
![image](https://github.com/DevClaudinei/Cadastro_De_Contatos/assets/103595662/eb922be6-30e4-4ca8-822b-1eb9ffdf592e)

### Tela Cadastro
![image](https://github.com/DevClaudinei/Cadastro_De_Contatos/assets/103595662/8b954521-51bb-4c22-98db-cbb60e0d9c05)


## 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [.NET](https://dotnet.microsoft.com/en-us/)
- [ASP.NET Core MVC](https://learn.microsoft.com/pt-br/aspnet/core/mvc/overview?view=aspnetcore-6.0)
- [Identity](https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio)
- [SQLite](https://sqlite.org/download.html)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/)
- [EntityFramework](https://learn.microsoft.com/pt-br/ef/)

## Licença

Licensed under the [MIT license](LICENSE).

## Autor

<b>Claudinei Santos</b>

Encontrei muitas dificuldades por optar por utilizar o ASP.NET Core MVC, mas com um pouco de estudo e um pouco de resiliência consegui deixar o projeto pronto. Apesar de criar paginas simples e não ter um certo capricho, acredito que consegui melhorar meus conhecimentos sobre o ASP.NET Core MVC e com as adversidades desse projeto adquiri diversos aprendizados.
Ter construido o projeto dessa forma me fez ter um pouco mais de curiosidade para melhorar as minhas habilidades utilizando o padrão Model-View-Controller.

[![Linkedin Badge](https://img.shields.io/badge/-Claudinei-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/claudinei-santos-ti/)](https://www.linkedin.com/in/claudinei-santos-ti/)
[![Gmail Badge](https://img.shields.io/badge/-santos.devclaudinei@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:santos.devclaudinei@gmail.com)](mailto:claudinei.santos@warren.com.br)
