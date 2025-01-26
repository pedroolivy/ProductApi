# Product API
API desenvolvida para gerenciar produtos e permitir operações básicas como leitura, criação, atualização e deleção, além de fornecer dados agregados por tipo.

## **Configuração do Banco de Dados**
A aplicação foi configurada para criar e atualizar o banco de dados automaticamente utilizando o **Entity Framework**. Não é necessário rodar comandos manuais ou criar tabelas diretamente no PostgreSQL.

### Como Funciona
1. **Ao iniciar o projeto no Visual Studio pela primeira vez, basta iniciar uma nova migração pelo gerenciador de pacotes e em seguida utilizar update-database, o banco de dados será criado automaticamente.**
2. **Aqui pode ocorrer um erro inicialmente, pois o EF tenta primeiro achar o Banco, como ele não existe ele irá criar um novo.**

Obs: "Caso seja necessário, e apenas se realmente for necessário, você poderá apagar as migrações para realizar uma nova"

### Connection String
Certifique-se de configurar a string de conexão no arquivo `appsettings.json` do projeto:
```json
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=ProductApi;Username=seu_usuario;Password=sua_senha"
}

