
# Estudos de .NET
#### API com duas Tabelas `Admins` e `Cameras` para mostrar os conceitos básicos do Desenvolvimento Web
## Geral
Quando o Projeto for rodado. Será criado um Usuário Padrão
- Email: `admin@email.com`
- Senha: `12345678`

## Requerimentos para rodar o projeto
- Docker
## Rodar projeto
```bash
# Build
docker-compose build

# Run
docker-compose up
```
## Swagger
- O Swagger: http://localhost:{port}/swagger

### Autenticação 

`POST /api/Auth/login`
```json
{
  "Email": "charles@email.com",
  "Password": "123456"
}
```

`RESPONSE POST /api/Auth/login`
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiaGVucmlxdWVAZ21haWwu"
}
```

### Body `POST /api/Admin`
```json
{
  "Name": "Charles",
  "Email": "charles@email.com",
  "Password": "123456"
}
```
### Body `PUT /api/Admin`
```json
{
  "Id": "asdasdadb-123123123-asdasdasd-asfsdf",
  "Name": "Charles",
  "Email": "charles@email.com"
}
```

### Response `GET /api/Admin`
```json
[
  {
    "id": "4fd84626-4193-4018-89db-cf91bff467ff",
    "name": "Rafael",
    "email": "rafael@gmail.com",
    "updatedAt": "2022-03-16T11:25:09.3049+00:00",
    "createdAt": "2022-03-16T11:25:09.305011+00:00"
  },
  {
    "id": "4fd84626-4193-4018-89db-cf91bff467ff",
    "name": "Charles",
    "email": "charles@gmail.com",
    "updatedAt": "2022-03-16T11:25:09.3049+00:00",
    "createdAt": "2022-03-16T11:25:09.305011+00:00"
  }
]
```

### Response `GET /api/Admin/{id}`
```json
{
  "id": "4fd84626-4193-4018-89db-cf91bff467ff",
  "name": "Charles",
  "email": "charles@gmail.com",
  "updatedAt": "2022-03-16T11:25:09.3049+00:00",
  "createdAt": "2022-03-16T11:25:09.305011+00:00"
}
```

### Body `POST /api/Camera`
```json
{
  "Name": "Camera 1",
  "Address": "Av. Paulista, 816",
  "VideoUrl": "https://video.com.br/link.mp4"
}
```
### Body `PUT /api/Camera`
```json
{
  "Id": "07b1f725-5260-470d-83c3-9ab10056b697",
  "Name": "Camera 1.2",
  "Address": "Av. Jose Firmino, 21",
  "VideoUrl": "https://video.com.br/link.mp4"
}
```

### Response `GET /api/Camera`
```json
[
  {
    "Id": "07b1f725-5260-470d-83c3-9ab10056b697",
    "Name": "Camera 1.1",
    "Address": "Av. Jose Firmino, 21",
    "VideoUrl": "https://video.com.br/link.mp4"
  },
  {
    "Id": "07b1f725-5260-470d-83c3-9ab10056b697",
    "Name": "Camera 1.2",
    "Address": "Av. Jose Firmino, 54",
    "VideoUrl": "https://video.com.br/link.mp4"
  }
]
```

### Response `GET /api/Camera/{id}`
```json
  {
    "Id": "07b1f725-5260-470d-83c3-9ab10056b697",
    "Name": "Camera 1.2",
    "Address": "Av. Jose Firmino, 54",
    "VideoUrl": "https://video.com.br/link.mp4"
  }
```
## Thanks🖖
#### Created by https://github.com/henriquemrc12
#### Issues and doubts: henriquemarcel2244@gmail.com