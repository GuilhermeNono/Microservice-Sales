
# Reverse Proxy with YARP and Microservices

Este projeto foi criado para explorar a tecnologia de *reverse proxy* utilizando o [YARP (Yet Another Reverse Proxy)](https://microsoft.github.io/reverse-proxy/). Ele é composto por um *gateway* que atua como *reverse proxy* para três APIs de microserviços:

- **Sales API**: Gerenciamento de vendas.
- **Product API**: Gerenciamento de produtos.
- **User API**: Gerenciamento de usuários.

## Rotas Configuradas

O YARP foi configurado para rotear chamadas para as APIs com as seguintes rotas:

| Rota                     | API Responsável    |
|--------------------------|--------------------|
| `http://localhost:5123/api/sale`    | Sales API         |
| `http://localhost:5123/api/product` | Product API       |
| `http://localhost:5123/api/user`    | User API          |

## Tecnologias Utilizadas

- **YARP**: Reverse proxy da Microsoft para ASP.NET.
- **.NET 8**: Framework para construir o projeto.
- **APIs**: Três serviços independentes (Sales, Product, User).
- **Docker** (opcional): Para configurar o ambiente de desenvolvimento.

## Configuração e Execução

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/) (opcional, para execução com containers)
