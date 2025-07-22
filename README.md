# TesteMouts

# Order Service

## Visão Geral
Este repositório contém a implementação do backend do projeto Order Service, utilizando .NET 8.0 e PostgreSQL. O projeto segue a arquitetura Clean Architecture e CQRS.

## Tecnologias Utilizadas

### Backend
- .NET 8.0
- C#
- MediatR (CQRS)
- Entity Framework Core
- AutoMapper
- FluentValidation
- Moq (Testes)
- xUnit (Testes Unitários)
- Rebus (Mensageria com RabbitMQ)
- Docker (Banco de dados PostgreSQL)
- Swagger (Documentação da API)

### Banco de Dados
- PostgreSQL via Docker
- MongoDB (futuro suporte para logs e eventos)

## Estrutura do Projeto
```
TesteMouts/
│── src/
│   ├── Order.Application/  # Camada de aplicação (CQRS, Handlers)
│   ├── Order.Common/       # Utilitários e serviços compartilhados
│   ├── Order.Domain/       # Entidades e regras de negócio
│   ├── Order.IoC/          # Configuração de Inversão de Controle
│   ├── Order.ORM/          # Camada de persistência
│   ├── Order.WebApi/       # API e Controllers
│── tests/
│   ├── Order.Unit/         # Testes unitários
│   ├── Order.Integration/  # Testes de integração
│   ├── Order.Functional/   # Testes funcionais
│── docker-compose.yml  # Configuração do Docker
│── README.md
```

## Configuração do Ambiente

### Clonando o Repositório
```bash
git clone https://github.com/elanofb/TesteMouts.git
cd TesteMouts
```

### Configurando o Banco de Dados (PostgreSQL via Docker)
```bash
docker-compose up -d
```
Isso iniciará um container PostgreSQL configurado no `docker-compose.yml`.

### Restaurando Dependências
```bash
dotnet restore
```

### Criando o Banco de Dados e Aplicando Migrations
```bash
dotnet ef database update
```

## Regras de Negócio Implementadas

### Pedidos (Orders)
- Criar, obter e deletar vendas
- Validação de quantidade e descontos

### Itens da Pedidos (OrderItems)
- Descontos automáticos baseados na quantidade:
  - 4+ unidades: 10% de desconto
  - 10 a 20 unidades: 20% de desconto
  - Máximo de 20 unidades por produto

## Execução da Aplicação

### Rodar a Aplicação
```bash
dotnet run --project src/Order.WebApi
```

### Acessar a API via Swagger
```
http://localhost:8171/swagger
```

## Testes Unitários e de Integração

### Executar Testes Unitários
```bash
dotnet test tests/Order.Unit
```

### Executar Testes de Integração
```bash
dotnet test tests/Order.Integration
```

## Mensageria com Rebus (RabbitMQ)

### Configurar RabbitMQ no Docker
```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

### Registrar Rebus no Program.cs
```csharp
builder.Services.AddRebus(configure => configure
    .Transport(t => t.UseRabbitMq("amqp://guest:guest@localhost", "sales_queue_abv"))
    .Logging(l => l.Console()));
```

### Iniciar Rebus na Aplicação
```csharp
using (var scope = app.Services.CreateScope())
{
    var bus = scope.ServiceProvider.UseRebus();
}
```

## Deploy e CI/CD

### Criar e Publicar a Imagem Docker
```bash
docker build -t abvelano-api .
docker run -p 5000:80 abvelano-api
```

### CI/CD com GitHub Actions (Exemplo `ci.yml`)
```yaml
name: .NET Build & Test
on: [push]
jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      - name: Setup .NET
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '8.0'
      - name: Restore dependencies
        run: dotnet restore
      - name: Build
        run: dotnet build --no-restore
      - name: Test
        run: dotnet test --no-build --verbosity normal
```

## Configuração Inicial

### Rodar o Projeto

Execute o seguinte comando para rodar o projeto:
```bash
dotnet run --project Order.WebApi
```

---

## Estrutura do Projeto

### Criando a Estrutura
1. Criar bibliotecas e domínios do projeto:
    ```bash
    dotnet new classlib -n Order.Domain
    ```
2. Adicionar uma nova classe de migração EF:
    ```bash
    dotnet ef migrations add InitialCreate --project Order.Infrastructure --startup-project Order.API
    ```
3. Listar as migrações:
    ```bash
    dotnet ef migrations list --project Order.Infrastructure --startup-project Order.API
    ```
4. Atualizar o banco de dados:
    ```bash
    dotnet ef database update --project Order.Infrastructure --startup-project Order.API
    ```

---

## Testes

### Projetos de Teste
1. Criar projetos de testes:
    ```bash
    dotnet new xunit --name Order.UnitTests
    dotnet new xunit --name Order.IntegrationTests
    ```
2. Adicionar os projetos de teste à solução:
    ```bash
    dotnet sln add Order.UnitTests/Order.UnitTests.csproj
    dotnet sln add Order.IntegrationTests/Order.IntegrationTests.csproj
    ```
3. Referenciar bibliotecas nos testes:
    - UnitTests:
        ```bash
        dotnet add Order.UnitTests reference Order.Application
        dotnet add Order.UnitTests reference Order.Domain
        ```
    - IntegrationTests:
        ```bash
        dotnet add Order.IntegrationTests reference Order.API
        dotnet add Order.IntegrationTests reference Order.Infrastructure
        ```

---

## RabbitMQ

Adicionar dependências para suporte ao RabbitMQ:
```bash
dotnet add Order.Infrastructure package RabbitMQ.Client
```
Para uma versão específica:
```bash
dotnet add Order.Infrastructure package RabbitMQ.Client --version 6.5.0
```
Outros pacotes necessários:
```bash
dotnet add Order.Infrastructure package Microsoft.Extensions.Hosting
```
Segue uma evidência da criação das Queues no Rabbit


---

## Configuração de Componentes

### API

Adicionar dependências e referências para o projeto API:
```bash
dotnet add Order.API reference Order.Domain
```
```bash
dotnet add Order.API reference Order.Application
```
```bash
dotnet add Order.API reference Order.CrossCutting
```
```bash
dotnet add Order.API reference Order.Infra
```
Dependências:
```bash
dotnet add Order.API package Microsoft.AspNetCore.Mvc
```
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### Infraestrutura

Adicionar pacotes e referências para infraestrutura:
```bash
dotnet add Order.Infrastructure reference Order.Domain
```
```bash
dotnet add Order.Infrastructure package Microsoft.EntityFrameworkCore
```
```bash
dotnet add Order.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
```
Atualizar banco de dados:
```bash
dotnet ef database update --project Order.Infrastructure --startup-project Order.WebApi
```

### Application

Adicionar referência ao domínio:
```bash
dotnet add Order.Application reference Order.Domain
```

### CrossCutting

Adicionar referências e pacotes:
```bash
dotnet add Order.CrossCutting reference Order.Application
```
Pacotes Serilog:
```bash
dotnet add Order.CrossCutting package Serilog
```
```bash
dotnet add Order.CrossCutting package Serilog.Extensions.Logging
```
```bash
dotnet add Order.CrossCutting package Serilog.Sinks.Console
```
```bash
dotnet add package Serilog.Sinks.File
```

---

### Testes Unitários

Adicionar pacotes úteis para testes unitários:
```bash
dotnet add Order.UnitTests package FluentAssertions
```
```bash
dotnet add Order.UnitTests package Bogus
```
```bash
dotnet add Order.UnitTests package NSubstitute
```
Outros pacotes comuns:
```bash
dotnet add package Moq
```
```bash
dotnet add package xunit
```
```bash
dotnet add package xunit.runner.visualstudio
```

### Testes de Integração

Adicionar pacotes úteis para testes de integração:
```bash
dotnet add Order.IntegrationTests package Testcontainers
```
```bash
dotnet add Order.IntegrationTests package FluentAssertions
```
```bash
dotnet add Order.IntegrationTests package Microsoft.AspNetCore.Mvc.Testing
```
```bash
dotnet add Order.IntegrationTests package Microsoft.EntityFrameworkCore
```
```bash
dotnet add Order.IntegrationTests package Microsoft.EntityFrameworkCore.InMemory
```

Testcontainers específicos:
```bash
dotnet add package Testcontainers.RabbitMq
```
```bash
dotnet add package Testcontainers.MsSql
```
```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

---

## EF Core e Migrações

### Instalação do EF Core
```bash
dotnet tool install --global dotnet-ef
```
Verificar versão instalada:
```bash
dotnet ef --version
```
Adicionar pacote de design:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```
--- 

### Criar e Atualizar Migrações
Criar uma nova migração:
```bash
dotnet ef migrations add InitialCreate
```
Atualizar o banco de dados:
```bash
dotnet ef database update
```

---

## Criar as tabelas através de script

Para criar as tabelas diretamente no banco: 
```bash
-- TABELA: Audits
CREATE TABLE IF NOT EXISTS "Audits" (
    "Id" SERIAL PRIMARY KEY,
    "TableName" TEXT NOT NULL,
    "Operation" TEXT NOT NULL,
    "Timestamp" TIMESTAMPTZ NOT NULL,
    "PerformedBy" TEXT NOT NULL,
    "Details" TEXT NOT NULL
);

-- TABELA: Logs
CREATE TABLE IF NOT EXISTS "Logs" (
    "Id" SERIAL PRIMARY KEY,
    "Event" TEXT NOT NULL,
    "Details" TEXT NOT NULL,
    "Timestamp" TIMESTAMPTZ NOT NULL
);

-- TABELA: Products
create table products (
	id uuid primary key default gen_random_uuid (),
	name varchar(255) not null,
	unitprice numeric(18, 2) not null
);

-- TABELA: Orders
create table orders (
    id uuid primary key default gen_random_uuid(),
    externalid varchar(100) default 'ID_PADRAO',
    customer varchar(100),
    status varchar(50) not null default 'RECEIVED',
    totalvalue numeric(18,2),
    createdat timestamp without time zone not null default now()
);

-- TABELA: OrderItems
create table orderitems (
    id uuid primary key default gen_random_uuid(),
    orderid uuid not null references orders(id) on delete cascade,
    --productid uuid references products(id),
	productid uuid,
    price numeric(18,2) not null,
    quantity int not null
);
```

---

## Docker

Para verificar filas no RabbitMQ:
```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management
```
```bash
docker exec -it rabbitmq rabbitmqctl list_queues
```

## Conclusão
Este documento cobre todo o processo desde a instalação, configuração, execução, testes e deploy do projeto TesteMouts. Se houver dúvidas, consulte os arquivos-fonte ou documentações adicionais.

Contato: elanofb@gmail.com 
+55 (85) 98195.1011
