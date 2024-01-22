# Guide.Variacao.Backend

## Funcionamento

:bangbang:**Importante**:bangbang:

É esperado que seu banco esteja devidamente configurado para que os dados sejam entregues,
Clone e execute esse repositório antes de executar esse código!
[PostgreSQL](https://www.postgresql.org/download/windows/)

### Configurando o appSettings
Foi inserido um appsettings padrão no app, é preciso configurar para as credenciais de seu banco local para que todo o código seja executado.

Seguindo o exemplo:
```
"ConnectionStrings": {
  "DefaultConnection": "Host=localHost;Database=GuideVariacao;User Id=MeuUsuarioPadrao;Password=123"
},
```

Devemos trocar o `Id=MeuUsuarioPadrao` pelo usuario admin do local e `Password=123` pela sua senha,
o banco e estrutura são criados pelo próprio *EF Core* :tada:

### Execução

### Finalizando