# Greenlight

Gerenciamento de contratos sobre creditos de energia 

# Migrations Entity
  
  - dotnet ef migrations add InitialCreate
    - para gerar os scripts
    
  - dotnet ef database update InitialCreate
    - para executar os scripts no banco de dados
  
  
<img width="651" alt="image" src="https://user-images.githubusercontent.com/6618004/192048933-8f7c517b-4f27-4f6a-bf8a-b315584ed1b7.png">

<img width="799" alt="image" src="https://user-images.githubusercontent.com/6618004/192172175-407f0317-c03d-40be-a893-a02c24f17994.png">

<img width="262" alt="image" src="https://user-images.githubusercontent.com/6618004/192172203-058e535b-19cb-4608-993f-3472c5b7dbf6.png">

# Configuração appsettings.json

    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "Jwt": {
        "key": "@c2VuaGEgZGUgYWRtaW4gw6kgZXN0YSBhcXVp@",
        "Issuer": "startup.fiap.com.br",
        "Audience": "http://startup.fiap.com.br"

      },
      "ConnectionStrings": {
        "DefaultConection": "Server=localhost;Port=3306;Database=greenlight_db;Uid=root;Pwd=Acesso@01;"
      },  
      "AllowedHosts": "*"
    }

<img width="913" alt="image" src="https://user-images.githubusercontent.com/6618004/192172273-f77419c7-6236-4053-bcfe-75343a14dc1f.png">
