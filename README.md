# Trabalho_Api - API de Gerenciamento Musical

## Como rodar o projeto:

### Pré-requisitos
- Visual Studio 2022
- .NET 8.0
- SQL Server (ou LocalDB)

### Passos
1. Clone o repositório
2. Abra o arquivo .sln no Visual Studio
3. Restaure os pacotes NuGet (automático)
4. Ajuste a connection string no appsettings.json
5. Execute no Package Manager Console: `Update-Database`
6. Pressione F5 para executar
7. Acesse https://localhost:7176/swagger

### Endpoints disponíveis
- CRUD de Alunos
- CRUD de Avaliações
- Histórico do aluno
- Ficha de aprovação