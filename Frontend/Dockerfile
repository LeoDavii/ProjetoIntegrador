# Etapa 1: Construção da imagem
FROM node:18-alpine AS build

# Definindo o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copiar o package.json e o package-lock.json para instalar as dependências
COPY package*.json ./

# Instalar as dependências
RUN npm install

# Copiar o restante do código do projeto para o diretório de trabalho
COPY . .

# Construir o projeto
RUN npm run build

# Etapa 2: Servir a aplicação
FROM nginx:alpine

# Copiar os arquivos construídos no estágio anterior para o nginx
COPY --from=build /app/build /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf


# Expor a porta 80 (padrão do nginx)
EXPOSE 80

# Rodar o nginx no contêiner
CMD ["nginx", "-g", "daemon off;"]