# Developer Evaluation Project

<br>

# 🛒 Projeto Vendas: Uma API Moderna com .NET 8

Este projeto consiste em uma API RESTful robusta e escalável para gerenciamento de vendas, construída com as mais recentes tecnologias .NET.

<br>

## 🛠️ Tecnologias de Ponta Utilizadas

Este projeto foi desenvolvido utilizando um conjunto de ferramentas modernas e eficientes:

  * **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0):** O mais recente framework de desenvolvimento da Microsoft, oferecendo performance e recursos avançados para a construção de aplicações modernas.
  * **[ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-8.0):** Um framework poderoso para a criação de APIs RESTful e aplicações web de alta performance.
  * **[Entity Framework Core](https://learn.microsoft.com/pt-br/ef/core/):** Um Object-Relational Mapper (ORM) que facilita a interação com o banco de dados de forma elegante e produtiva.
  * **[PostgreSQL](https://www.postgresql.org/):** Um sistema de gerenciamento de banco de dados relacional (SGBDR) robusto, confiável e de código aberto.
  * **[Docker](https://www.docker.com/):** Uma plataforma de conteinerização que simplifica a implantação e o gerenciamento da aplicação e do banco de dados em diferentes ambientes.
  * **[xUnit.net](https://xunit.net/):** Um framework moderno para a criação de testes unitários e de integração automatizados, garantindo a qualidade e a estabilidade do código.
  * **[Swagger/OpenAPI](https://swagger.io/):** Uma ferramenta essencial para a documentação interativa da API, permitindo que os desenvolvedores explorem e testem os endpoints de forma fácil.

<br>

## 🚀 Primeiros Passos: Executando o Projeto

Siga estas instruções para configurar e executar o projeto em seu ambiente local:

### 1\. ⚙️ Pré-requisitos

Antes de começar, certifique-se de ter as seguintes ferramentas instaladas em sua máquina:

  * **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0):** Você precisará do SDK para compilar e executar a aplicação .NET.
      * ➡️ [Download .NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
  * **[Docker](https://www.docker.com/get-started/):** O Docker é necessário para executar o banco de dados PostgreSQL e a aplicação em containers isolados.
      * ➡️ [Download Docker](https://www.docker.com/get-started/)

### 2\. 💾 Clonando o Repositório

Primeiro, clone o repositório do projeto para sua máquina local utilizando o Git:

bash
git clone [https://github.com/silvioantonio/projeto-vendas.git](https://github.com/silvioantonio/projeto-vendas.git)
cd projeto-vendas
git checkout feature/cadastra-venda

Certifique-se de fazer o checkout para a branch feature/cadastra-venda para trabalhar com a versão mais recente do recurso de cadastro de vendas.

### 3\. ⚙️ Configurando as Variáveis de Ambiente
Na raiz do projeto, crie um arquivo chamado .env e adicione as seguintes variáveis de ambiente com suas respectivas configurações:

Snippet de código <br>

DB_HOST=localhost <br>
DB_PORT=5432 <br>
DB_NAME=projeto_vendas <br>
DB_USER=seu_usuario <br>
DB_PASSWORD=sua_senha <br>

Importante: Substitua seu_usuario e sua_senha pelas credenciais do seu banco de dados PostgreSQL.

### 4\. 🐳 Iniciando os Containers Docker
Utilize o Docker Compose para iniciar os containers da aplicação e do banco de dados em segundo plano:

Bash

docker-compose up -d
Este comando irá construir as imagens (se necessário) e iniciar os containers definidos no arquivo docker-compose.yml.

### 5\. ⚙️ Aplicando as Migrações do Banco de Dados
As migrações do Entity Framework Core são necessárias para criar o esquema do banco de dados. Execute o seguinte comando dentro do diretório src/ProjetoVendas.Infrastructure:

Bash

dotnet ef database update
Este comando irá aplicar as migrações pendentes ao banco de dados PostgreSQL.

### 6\. 🚀 Executando a Aplicação
Finalmente, para executar a API, navegue até o diretório src/ProjetoVendas.Api no seu terminal e execute o seguinte comando:

Bash

dotnet run
Após a execução, a API estará acessível através da URL: http://localhost:5000. Você poderá interagir com a documentação da API utilizando o Swagger, que geralmente está disponível em uma rota como http://localhost:5000/swagger.

`READ CAREFULLY`

## Instructions
**The test below will have up to 7 calendar days to be delivered from the date of receipt of this manual.**

- The code must be versioned in a public Github repository and a link must be sent for evaluation once completed
- Upload this template to your repository and start working from it
- Read the instructions carefully and make sure all requirements are being addressed
- The repository must provide instructions on how to configure, execute and test the project
- Documentation and overall organization will also be taken into consideration

## Use Case
**You are a developer on the DeveloperStore team. Now we need to implement the API prototypes.**

As we work with `DDD`, to reference entities from other domains, we use the `External Identities` pattern with denormalization of entity descriptions.

Therefore, you will write an API (complete CRUD) that handles sales records. The API needs to be able to inform:

* Sale number
* Date when the sale was made
* Customer
* Total sale amount
* Branch where the sale was made
* Products
* Quantities
* Unit prices
* Discounts
* Total amount for each item
* Cancelled/Not Cancelled

It's not mandatory, but it would be a differential to build code for publishing events of:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled

If you write the code, **it's not required** to actually publish to any Message Broker. You can log a message in the application log or however you find most convenient.

### Business Rules

* Purchases above 4 identical items have a 10% discount
* Purchases between 10 and 20 identical items have a 20% discount
* It's not possible to sell above 20 identical items
* Purchases below 4 items cannot have a discount

These business rules define quantity-based discounting tiers and limitations:

1. Discount Tiers:
   - 4+ items: 10% discount
   - 10-20 items: 20% discount

2. Restrictions:
   - Maximum limit: 20 items per product
   - No discounts allowed for quantities below 4 items

## Overview
This section provides a high-level overview of the project and the various skills and competencies it aims to assess for developer candidates. 

See [Overview](/.doc/overview.md)

## Tech Stack
This section lists the key technologies used in the project, including the backend, testing, frontend, and database components. 

See [Tech Stack](/.doc/tech-stack.md)

## Frameworks
This section outlines the frameworks and libraries that are leveraged in the project to enhance development productivity and maintainability. 

See [Frameworks](/.doc/frameworks.md)

<!-- 
## API Structure
This section includes links to the detailed documentation for the different API resources:
- [API General](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

## Project Structure
This section describes the overall structure and organization of the project files and directories. 

See [Project Structure](/.doc/project-structure.md)
