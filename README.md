## Configurar a string de conexão
No arquivo **appsettings.json** informar o banco de dados, usuário e senha.<br />
Neste projeto usei **MySql** e como **Entity Framework Core provider** usei **Pomelo.EntityFrameworkCore.MySql**.<br /><br />

## Rodar as Migrations:
//Creates a migration by adding a migration snapshot.<br />
**PM> add-migration <migration name>**<br />
//Updates the database schema based on the last migration snapshot.<br />
**PM> Update-database**<br /><br />

Para testar a aplicação:<br />
Rodar o projeto no Visual Studio<br /><br />

##Endpoints que podem ser testados no Postman:

### Cliente
  **GET**<br />
  /api/Cliente/v{version}<br />
  Ex.: https://localhost:44352/api/Cliente/v1<br />
  //Pega todas as contas existentes na base de dados<br /><br />
  
  **POST**<br />
  /api/Cliente/v{version}<br />
  Ex.: https://localhost:44352/api/Cliente/v1<br />
  //Insere um cliente na base de dados<br />
  //Precisa passar o objeto a ser inserido como um Json no corpo da requisição<br /><br />
  
  **PUT**<br />
  /api/Cliente/v{version}<br />
  Ex.: https://localhost:44352/api/Cliente/v1<br />
  //Altera um cliente na base de dados<br />
  //Precisa passar o objeto a ser alterado como um Json no corpo da requisição<br /><br />
  
  **GET**<br />
  /api/Cliente/v{version}/{id}<br />
  Ex.: https://localhost:44352/api/Cliente/v1/1<br />
  //Pega o cliente de id=1<br /><br />
  
  **PATCH**<br />
  /api/Cliente/v{version}/{id}<br />
  Ex.: https://localhost:44352/api/Cliente/v1/1<br />
  //Altera um cliente na base de dados<br />
  //Precisa passar o objeto a ser alterado como um Json no corpo da requisição<br /><br />
  
  **DELETE**<br />
  /api/Cliente/v{version}/{id}<br />
  Ex.: https://localhost:44352/api/Cliente/v1/1<br />
  //Deleta o cliente de id=1<br /><br />


### Conta
  
  **GET**<br />
  /api/Conta/v{version}<br />
  Ex.: https://localhost:44352/api/Conta/v1<br />
  //Pega todas as contas existentes na base de dados<br /><br />
  
  **POST**<br />
  /api/Conta/v{version}<br />
  Ex.: https://localhost:44352/api/Conta/v1<br />
  //Insere uma conta na base de dados
  //Precisa passar o objeto a ser inserido como um json no corpo da requisição<br /><br />
  
  **PUT**<br />
  /api/Conta/v{version}<br />
  Ex.: https://localhost:44352/api/Conta/v1<br />
  //Altera uma conta na base de dados<br />
  //Precisa passar o objeto a ser alterado como um Json no corpo da requisição<br /><br />
  
  **GET**<br />
  /api/Conta/v{version}/{id}<br />
  Ex.: https://localhost:44352/api/Conta/v1/1<br />
  //Pega a conta de id=1<br />
  
  **DELETE**<br />
  /api/Conta/v{version}/{id}<br />
  Ex.: https://localhost:44352//api/Conta/v1/1<br />
  //Deleta a conta de id=1<br /><br />
  
  **GET**<br />
  /api/Conta/v{version}/Depositar<br />
  Ex.: https://localhost:44352/api/Conta/v1/Depositar?agencia=XX&numero=YY&valor=ZZ<br /><br />
  //Deposita o valor ZZ na conta YY da agência XX<br />
  //Poderia usar até outro verbo, mas optei por usar o GET<br />
  
  **GET**<br />
  /api/Conta/v{version}/Sacar<br />
  Ex.: https://localhost:44352/api/Conta/v1/Sacar?agencia=XX&numero=YY&valor=ZZ<br />
  //Saca o valor ZZ na conta YY da agência XX<br />
  //Poderia usar até outro verbo, mas optei por usar o GET<br /><br />
  
  **GET**<br />
  /api/Conta/v{version}/Transferir<br />
  Ex.: https://localhost:44352/api/Conta/v1/Transferir?agenciaOrigem=XX&numeroOrigem=XY&agenciaDestino=YY&numeroDestino=YX&valor=ZZ<br />
  //Transfere o valor ZZ da conta XY da agência XX para a conta YX da agência YY.<br />
  //Poderia usar até outro verbo, mas optei por usar o GET<br /><br />
  
  **Obs.:** Nos exemplos estou usando a porta 44352, mas depende da porta que vai pegar quando projeto for rodado pelo seu Visual Studio.
