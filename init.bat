@echo off
Title API_AA_MS

:: Dentro del directorio actual, creamos la solución 
dotnet new sln 
:: Creamos los proyectos que harán parte de la solución
dotnet new classlib -o Persistence
dotnet new classlib -o Application
dotnet new classlib -o Domain
dotnet new classlib -o Security
dotnet new webapi   -o WebAPI
:: Añadimos los proyectos a la solución
dotnet sln add Persistence/
dotnet sln add Application/
dotnet sln add Domain/
dotnet sln add Security/
dotnet sln add WebAPI/

:: 1. En el proyecto persistencia, agregamos la referencia a dominio
:: 		Además, instalamos los paquetes necesarios. 
cd Persistence
dotnet add reference ../Domain/

dotnet add package Microsoft.EntityFrameworkCore  
dotnet add package Microsoft.EntityFrameworkCore.Tools 
dotnet add package Pomelo.EntityFrameworkCore.MySql

cd ..
cd Application
dotnet add reference ../Domain/
dotnet add reference ../Persistence/

dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package FluentValidation.AspNetCore
dotnet add package iTextSharp.LGPLv2.Core
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.AspNetCore.App


cd ..
cd WebAPI
dotnet add reference ../Application

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.AspNetCore.OpenApi
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Newtonsoft.Json
dotnet add package Swashbuckle.AspNetCore

cd ..



cd .. 
cd Domain 
dotnet add package Microsoft.AspNetCore.App
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package System.Runtime

cd ..
cd Security
dotnet add reference ../Application

dotnet add package Microsoft.AspNetCore.App
dotnet add package System.IdentityModel.Tokens.Jwt


