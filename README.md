ProductApi

Uma API RESTful desenvolvida em .NET utilizando os princípios da Clean Architecture e DDD, combinados com CQRS, Value Objects, autenticação básica e mapeamento com AutoMapper. Toda a aplicação foi publicada na Railway, com banco de dados PostgreSQL rodando no mesmo ambiente, em um Monolito Modular.

🎯 Este projeto foi pensado para demonstrar habilidades profissionais em arquitetura moderna, boas práticas de organização de código, deploy e integração com banco na nuvem.

⚙️ Tecnologias Utilizadas

ASP.NET Core 6

Entity Framework Core

PostgreSQL (Railway Docker Image)

Clean Architecture

DDD (Domain-Driven Design)

CQRS (Command and Query Responsibility Segregation)

AutoMapper

MediatR

Railway (Deploy CI/CD e Banco de Dados)

🏗️ Arquitetura - Monolito Modular

O projeto segue um padrão de monolito modular, com separação clara entre as camadas e responsabilidades, facilitando futura migração para microserviços. As camadas são:

ProductApi.sln
│
├── ProductApi.Application      # Casos de uso, DTOs, Interfaces, CQRS (Commands, Queries)
├── ProductApi.Domain           # Entidades, Enums, Value Objects e Interfaces de domínio
├── ProductApi.Infrastructure  # Acesso a dados, contexto EF, repositórios e migrations
├── ProductApi.WebAPI          # Interface da aplicação (Controllers, Autenticação, Program.cs)
├── ProductApi.Tests           # Projeto base para testes

🚀 Funcionalidades

CRUD de produtos

Enum para tipos (Product, Service)

Value Object para encapsular lógica de preço

Autenticação básica com Authorization: Basic

Migrations automáticas aplicadas em ambiente de produção

Deploy contínuo integrado ao GitHub + Railway

☁️ Deploy na Railway

Durante o processo de publicação, foi necessário realizar ajustes técnicos:

Downgrade da versão do .NET de 8 para 6, para compatibilidade com o ambiente da Railway.

Ajuste nas dependências NuGet devido ao downgrade (ex: MediatR)

Alteração da string de conexão para seguir o padrão aceito pelo PostgreSQL via DATABASE_URL

Banco e API foram colocados no mesmo ambiente da Railway para evitar erros de conexão por rede pública

Variáveis de Ambiente Configuradas:

ConnectionStrings__DefaultConnection com valor extraído de DATABASE_URL da Railway

Auth__Username e Auth__Password para autenticação básica

As configurações do appsettings.json local são ignoradas em produção. Toda a configuração sensível está nas variáveis de ambiente.

🧪 Execução local (não suportada neste momento)

Importante: o projeto não está mais configurado para execução local, pois utiliza banco provisionado na nuvem e exige variáveis presentes apenas no ambiente da Railway.

Caso deseje rodar localmente:

Crie um PostgreSQL local

Atualize o appsettings.json com sua connection string

Rode as migrations:

$ dotnet ef database update --project ProductApi.Infrastructure --startup-project ProductApi.WebAPI

Execute o projeto:

$ dotnet run --project ProductApi.WebAPI

✅ Status Atual

✔️ Deploy 100% funcional na Railway

✔️ Migrations aplicadas automaticamente

✔️ API responde com autenticação básica e CRUD de produtos

✔️ Produto real persistido e visualizado diretamente no painel de dados da Railway

## 🌐 Acesse a API em Produção

A API está publicada e disponível publicamente para consulta:

🔗 **[https://productapi-production-9905.up.railway.app](https://productapi-production-9905.up.railway.app/swagger)**

> ⚠️ Nota: A API roda no plano gratuito do Railway. Se estiver fora do ar, pode ter atingido o limite mensal — volte a tentar mais tarde!

Desenvolvido com foco em aprendizado avançado, publicação de API na nuvem e domínio de arquitetura limpa no ecossistema .NET.
