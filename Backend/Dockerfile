# Etapa 1: Construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Defina o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copie o arquivo .csproj específico para o diretório de trabalho
# Ajuste o caminho para refletir a estrutura do diretório
COPY ProjetoIntegrador/Presentation.csproj ./ProjetoIntegrador/

# Restaure as dependências do NuGet para o arquivo específico
RUN dotnet restore ProjetoIntegrador/Presentation.csproj

# Copie o restante dos arquivos do projeto
COPY . .

# Publique a aplicação em modo Release
RUN dotnet publish ProjetoIntegrador/Presentation.csproj -c Release -o /app/publish

# Etapa 2: Criação da imagem de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Defina o diretório de trabalho no contêiner
WORKDIR /app

# Exponha a porta que o ASP.NET Core irá usar
EXPOSE 80

# Copie os artefatos da etapa anterior (os arquivos publicados)
COPY --from=build /app/publish .

# Defina o ponto de entrada do contêiner para iniciar a aplicação
ENTRYPOINT ["dotnet", "Presentation.dll"]
