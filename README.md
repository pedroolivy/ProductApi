# 🧪 ProductApi – API RESTful com Clean Architecture e DDD

Uma API RESTful desenvolvida com **.NET 6**, utilizando os princípios da **Clean Architecture** e **Domain-Driven Design (DDD)**, combinados com **CQRS**, **Value Objects**, **autenticação básica** e mapeamento com **AutoMapper**.  
Publicada na **Railway** com **PostgreSQL**, em um **Monolito Modular**.

---

## 🎯 Objetivo

Demonstrar habilidades profissionais em:

- Arquitetura moderna com Clean Architecture + DDD  
- Organização de código com separação clara de camadas  
- Implementação de CQRS com MediatR  
- Deploy na nuvem com banco provisionado (Railway)  
- Aplicação de boas práticas em .NET  

---

## ⚙️ Tecnologias Utilizadas

- ASP.NET Core 6  
- Entity Framework Core  
- PostgreSQL (Railway Docker Image)  
- Clean Architecture  
- DDD (Domain-Driven Design)  
- CQRS (Command and Query Responsibility Segregation)  
- AutoMapper  
- MediatR  
- Railway (CI/CD + Banco de Dados)
  
---

## 🚀 Funcionalidades

- CRUD completo de produtos  
- Enum para diferenciar tipos (Product, Service)  
- Value Object para lógica de preço  
- Autenticação básica (`Authorization: Basic`)  
- Migrations automáticas aplicadas em produção  
- Deploy contínuo integrado com GitHub + Railway

---

## ☁️ Deploy na Railway

Durante a publicação na Railway, foram realizados ajustes:

- ⬇️ Downgrade do .NET 8 → .NET 6 (compatibilidade do ambiente)  
- 🔄 Ajuste em dependências NuGet (ex: MediatR)  
- 🔗 Adaptação da string de conexão (`DATABASE_URL`)  
- 🌐 Banco de dados e API publicados no mesmo ambiente para evitar problemas de rede

### 🔐 Variáveis de Ambiente Configuradas

| Variável                         | Descrição                                         |
|----------------------------------|---------------------------------------------------|
| `ConnectionStrings__DefaultConnection` | Extraída da `DATABASE_URL` da Railway         |
| `Auth__Username`                | Usuário da autenticação básica                    |
| `Auth__Password`                | Senha da autenticação básica                      |

⚠️ O `appsettings.json` local é ignorado em produção. Toda a configuração sensível está via **variáveis de ambiente**.

https://productapi-production-9905.up.railway.app/swagger/index.html
