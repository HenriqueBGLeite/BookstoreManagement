# Bookstore Management API

Uma API para gerenciamento de catálogo de livros. O projeto foi desenvolvido em C# / .NET focado em demonstrar a implementação de um CRUD completo utilizando validações de negócio com FluentValidation.

# Como executar

1. Clone o repositório
2. Execute o projeto
3. A documentação interativa (Swagger) estará disponível em: http://localhost:PORTA/swagger

# Endpoints

Livros (/api/books)
* POST /api/books: Cadastra um livro. Retorna o ID e título.

* GET /api/books: Lista todos os livros cadastrados.

* GET /api/books/{id}: Detalhes completos de um livro específico.

* PUT /api/books/{id}: Atualiza os dados de um livro.

* DELETE /api/books/{id}: Remove um livro do catálogo.

# Regras de Negócio Implementadas

* Validação de Campos: Título, autor e gênero não podem ser nulos.

* Título Único: A API impede o cadastro de dois livros com o mesmo título e autor na memória.

* Gêneros Aceitos: Validação via FluentValidation para garantir que apenas gêneros pré-definidos sejam aceitos.

* Tratamento de Erros: Respostas padronizadas com status 400 (Bad Request) e 404 (Not Found) contendo a lista de erros.