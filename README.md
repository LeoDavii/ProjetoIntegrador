# ProjetoIntegrador
Projeto Integrador - Cruzeiro do Sul Virtual

Pré-requisitos:
Docker ou Rancher Desktop

Get Started:
- É possível criar um container com este projeto, para fazê-lo basta ter o Docker Desktop ou Rancher Desktop:
   - Utilizando o powershell na pasta: \ProjetoIntegrador executar o comando:
 
     ![image](https://github.com/user-attachments/assets/b34b0345-129a-4f4c-96a9-51832290c78c)


   - Basta acessar o localhost em seu navegador para execução

Login:
- Os seguintes logins estão criados e habilitados:
  - Manager:
     - Login: johnM@test.com.br / Senha: test
     - Login: johnC@test.com.br / Senha: test


Instalação Rancher:
Configurações Banco de Dados - Desenvolvimento:
Utilizaremos instâncias locais do banco postgres através de contêiner gerenciado via docker-cli:

Instalação Windows Subsystem For Linux e Docker Cli:
Fazer download do Rancher Desktop: https://rancherdesktop.io/:  a própria ferramenta se encarregará de instalar o Linux e o docker-cli

Após instalação, desabilitar o recurso Kubernetes, não faremos utilização e pode ajudar a economizar os recursos da máquina:

![image](https://github.com/user-attachments/assets/0c149f60-32c0-4a3c-b1aa-1f8f3153fc8f)

Como engine, é possível utilizar tanto o dockerd (recomendado), como o containerd (há diferenças de sintaxe)

![image](https://github.com/user-attachments/assets/4378a831-2e25-41dc-a1bb-2b5ce10419c6)

Sugestão: instalar a extensão LogsExplorer para acompanhamento dos logs dos serviços:

![image](https://github.com/user-attachments/assets/4584c375-3670-4c89-94e6-6ea5920e37a8)

