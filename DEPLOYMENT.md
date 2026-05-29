# Guia de Deployment - HealthSchedule WebApi no Render

## 📋 Pré-requisitos

1. **Conta no Render**: Crie uma conta em [render.com](https://render.com)
2. **GitHub**: Repositório conectado ao Render (recomendado)
3. **Docker**: Instalado localmente para testes (opcional)

## 🚀 Opção 1: Deploy automático via GitHub (Recomendado)

### Passo 1: Preparar o repositório

1. Push do projeto para seu repositório GitHub:
```bash
git add .
git commit -m "Add Dockerfile and render.yaml for production deployment"
git push origin main
```

### Passo 2: Conectar no Render

1. Acesse [dashboard.render.com](https://dashboard.render.com)
2. Clique em **"New"** → **"Web Service"**
3. Conecte seu repositório GitHub
4. Selecione o repositório `HealthSchedule`
5. Configure:
   - **Name**: `health-schedule-api` (ou seu nome preferido)
   - **Region**: Oregon (ou sua região preferida)
   - **Branch**: `main`
   - **Runtime**: `Docker`
   - **Plan**: Free (ou conforme sua necessidade)

### Passo 3: Configurar variáveis de ambiente

Clique em **Environment** e adicione as variáveis conforme necessário:
- `ASPNETCORE_ENVIRONMENT`: `Production`

### Passo 4: Deploy

Clique em **"Deploy"** e acompanhe o log de build.

## 🔧 Opção 2: Deploy manual via Render CLI

```bash
# Instalar Render CLI
npm install -g @render-oss/render-cli

# Fazer login
render login

# Deploy
render push
```

## 🗄️ Configuração do Banco de Dados (Importante!)

Atualmente o projeto está configurado com **banco em memória** (`UseInMemoryDatabase`).

### Opção A: PostgreSQL (Recomendado no Render)

1. No Render Dashboard, crie um novo PostgreSQL database:
   - **Name**: `health-schedule-db`
   - **Plan**: Free
   - **Region**: Mesma da Web Service

2. Obtenha a connection string do PostgreSQL

3. Atualize o `Program.cs` para usar PostgreSQL:
```csharp
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDataContext>(x => 
    x.UseNpgsql(connectionString)); // Use PostgreSQL
```

4. Instale o pacote NuGet:
```bash
dotnet add HealthSchedule.Infra package Npgsql.EntityFrameworkCore.PostgreSQL
```

5. Adicione a connection string no Render:
   - Vá em **Environment** da Web Service
   - Adicione:
     - **Key**: `DefaultConnection`
     - **Value**: (copie da página do PostgreSQL database)

### Opção B: SQL Server

1. Atualize `Program.cs` para usar SQL Server
2. Configure a connection string nas variáveis de ambiente do Render

## 🧪 Testando localmente com Docker

```bash
# Build da imagem
docker build -t health-schedule-api:latest .

# Run
docker run -p 8080:8080 health-schedule-api:latest

# Acessar
# http://localhost:8080/swagger
```

## 📊 Monitorando o Deploy

### Logs em tempo real:
```bash
render logs --service-id <seu-service-id>
```

### No Dashboard do Render:
- Clique na Web Service
- Vá para a aba **Logs**
- Acompanhe o build e execução

## ⚠️ Troubleshooting

### Erro: "Port is already in use"
- O Dockerfile expõe a porta 8080 automaticamente
- Render gerencia portas automaticamente

### Erro: "Build failed"
- Verifique os logs do build
- Certifique-se de que o `Dockerfile` e `.dockerignore` estão no root

### Erro: "Connection string inválida"
- Verifique a configuração do banco de dados
- Atualize o `Program.cs` conforme necessário

### API lenta no startup (Plano Free)
- Planos free têm recursos limitados e cold starts lentos
- Considere upgrade para plano pago se necessário

## 🔒 Segurança

1. **Nunca committar secrets** no repositório
2. Use variáveis de ambiente para:
   - Connection strings
   - API keys
   - Credentials
3. Valide inputs no seu código
4. Configure CORS conforme necessário no `Program.cs`

## 📝 Próximos passos

1. ✅ Configurar banco de dados apropriado
2. ✅ Revisar e atualizar `launchSettings.json` para produção
3. ✅ Adicionar logging estruturado
4. ✅ Configurar CI/CD pipeline
5. ✅ Setup de monitoramento e alertas

## 🔗 Recursos úteis

- [Documentação Render - Docker Deploys](https://render.com/docs/docker)
- [Microsoft Docs - ASP.NET Core em Docker](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/docker)
- [Render Environment Variables](https://render.com/docs/environment-variables)

---

**Dúvidas?** Consulte os logs do Render ou a documentação oficial.
