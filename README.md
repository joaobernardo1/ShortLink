
# 🔗 ShortLink

Um serviço de encurtamento de URL desenvolvido em .NET, utilizando arquitetura limpa (DDD). Permite criar links curtos para URLs longas, com controle de redirecionamento e tempo de expiração.

## 🚀 Funcionalidades

- 🔗 Gerar um link curto a partir de uma URL longa.
- 🔄 Redirecionamento automático ao acessar o link curto.
- 🕓 Definir tempo de expiração para o link (ex.: 15 dias).
- 💾 Persistência em banco de dados MySQL.
- ⚙️ Tratamento centralizado de erros e exceções.

---

## 🏗️ Arquitetura do Projeto

O projeto segue os princípios de **Clean Architecture** e **DDD**, distribuindo responsabilidades em camadas bem definidas.

```
/ShortLink
├── API                → Camada de apresentação (Controllers, Program.cs)
├── Application        → Casos de uso, regras de aplicação
├── Communication      → Contratos (DTOs, Responses, Requests)
├── Domain             → Entidades, Interfaces, regras de negócio
├── Exception          → Tratamento de exceções e middlewares
├── Infrastructure     → Persistência (MySQL), Migrations, Repositórios
```

---

## ⚙️ Tecnologias

- ✔️ .NET 8
- ✔️ Entity Framework Core
- ✔️ MySQL
- ✔️ Swagger (documentação de API)
- ✔️ Clean Architecture + DDD

---

## 🚀 Como rodar o projeto localmente

### 1️⃣ Clone o repositório

```bash
git clone https://github.com/joaobernardo1/ShortLink.git
cd ShortLink
```

---

### 2️⃣ Configure o banco de dados MySQL

Garanta que tenha um banco MySQL rodando localmente ou na nuvem.

Atualize sua `ConnectionString` no arquivo `appsettings.Development.json` da camada `API`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=shortlinkdb;user=root;password=suaSenha"
}
```

---

### 3️⃣ Execute as migrations

```bash
dotnet ef database update --project Infrastructure --startup-project API
```

---

### 4️⃣ Rode a aplicação

```bash
dotnet run --project API
```

A API estará disponível em:

```
https://localhost:5001
```

A documentação Swagger estará disponível em:

```
https://localhost:5001/swagger
```

---

## 🛠️ Endpoints principais

| Método | Rota                | Descrição                      |
|--------|----------------------|---------------------------------|
| POST   | `/api/shortlink`     | Cria um link curto             |
| GET    | `/{shortCode}`       | Redireciona para a URL original|

---

## 📜 Exemplo de requisição para gerar link curto

**POST `/api/shortlink`**

```json
{
  "originalUrl": "https://youtube.com/watch?v=abc123"
}
```

**Response:**

```json
{
  "shortUrl": "https://localhost:5001/AbC123d"
}
```

---

## 🔄 Fluxo de funcionamento

1. O cliente faz uma requisição com a URL original.
2. O serviço gera um código curto (via hash).
3. Salva no banco (MySQL) com informações como URL, código e data de expiração.
4. Ao acessar o link curto (`/{shortCode}`), a API busca o registro no banco e redireciona para a URL original.

---

## 🧠 Melhorias futuras

- [ ] Interface web para gerenciamento de links.
- [ ] Dashboard com estatísticas (analytics).
- [ ] Suporte a autenticação de usuários.
- [ ] Monitoramento de acessos por link.

---

## 💥 Tratamento de exceções

A camada **Exception** gerencia:

- 💡 Middlewares globais de captura de erros.
- 💡 Respostas padronizadas de erros para o cliente.
- 💡 Logs de erros centralizados.

---

## 🤝 Contribuição

Contribuições são bem-vindas!  
Sinta-se livre para abrir issues, sugerir melhorias ou enviar pull requests. 🚀

---
