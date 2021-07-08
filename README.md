## Configurar a string de conexão
No arquivo "appsettings.json" informar o banco de dados, usuário e senha.
Neste projeto usei MySql e como Entity Framework Core provider usei Pomelo.EntityFrameworkCore.MySql.

## Rodar as Migrations:
//Creates a migration by adding a migration snapshot.
PM> add-migration <migration name>
//Updates the database schema based on the last migration snapshot.
PM> Update-database

Para testar a aplicação:
Rodar o projeto no Visual Studio

##Endpoints que podem ser testados no Postman:

### Cliente
  GET
  /api/Cliente/v{version}
  Ex.: https://localhost:44352/api/Cliente/v1
  //Pega todas as contas existentes na base de dados

POST
/api/Cliente/v{version}
Ex.: https://localhost:44352/api/Cliente/v1
//Insere um cliente na base de dados
//Precisa passar o objeto a ser inserido como um Json no corpo da requisição

PUT
/api/Cliente/v{version}
Ex.: https://localhost:44352/api/Cliente/v1
//Altera um cliente na base de dados
//Precisa passar o objeto a ser alterado como um Json no corpo da requisição

GET
/api/Cliente/v{version}/{id}
Ex.: https://localhost:44352/api/Cliente/v1/1
//Pega o cliente de id=1

PATCH
/api/Cliente/v{version}/{id}
Ex.: https://localhost:44352/api/Cliente/v1/1
//Altera um cliente na base de dados
//Precisa passar o objeto a ser alterado como um Json no corpo da requisição

DELETE
/api/Cliente/v{version}/{id}
Ex.: https://localhost:44352/api/Cliente/v1/1
//Deleta o cliente de id=1


### Conta

GET
/api/Conta/v{version}
Ex.: https://localhost:44352/api/Conta/v1
//Pega todas as contas existentes na base de dados

POST
/api/Conta/v{version}
Ex.: https://localhost:44352/api/Conta/v1
//Insere uma conta na base de dados
//Precisa passar o objeto a ser inserido como um json no corpo da requisição

PUT
/api/Conta/v{version}
Ex.: https://localhost:44352/api/Conta/v1
//Altera uma conta na base de dados
//Precisa passar o objeto a ser alterado como um Json no corpo da requisição

GET
/api/Conta/v{version}/{id}
Ex.: https://localhost:44352/api/Conta/v1/1
//Pega a conta de id=1

DELETE
/api/Conta/v{version}/{id}
Ex.: https://localhost:44352//api/Conta/v1/1
//Deleta a conta de id=1

GET
/api/Conta/v{version}/Depositar
Ex.: https://localhost:44352/api/Conta/v1/Depositar?agencia=XX&numero=YY&valor=ZZ
//Deposita o valor ZZ na conta YY da agência XX
//Poderia usar até outro verbo, mas optei por usar o GET

GET
/api/Conta/v{version}/Sacar?agencia=XX&numero=YY&valor=ZZ
Ex.: https://localhost:44352/
//Saca o valor ZZ na conta YY da agência XX
//Poderia usar até outro verbo, mas optei por usar o GET

GET
/api/Conta/v{version}/Transferir?agenciaOrigem=XX&numeroOrigem=XY&agenciaDestino=YY&numeroDestino=YX&valor=ZZ
Ex.: https://localhost:44352/
//Transfere o valor ZZ da conta XY da agência XX para a conta YX da agênmcia YY.
//Poderia usar até outro verbo, mas optei por usar o GET

Obs.: Nos exemplos estou usando a porta 44352, mas depende da porta que vai pegar quando projeto for rodado pelo seu Visual Studio.
