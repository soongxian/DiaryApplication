# DiaryApplication 📖

This originally created web-based application is created for recording daily life in the diary.

## Learning Checkpoint: 📜
1. Utilize entity framework to create database in SQL Server (✅)
2. Developed CRUD functions with C# .NET 8.0 (✅)
3. Created user interface with Blazor (✅)

## Tips and Guide: 😎
#### Create database in SQL server
1. Launch DiaryApplication.sln 
2. Open terminal and write the command: dotnet ef migrations add initial --project DiaryApplication.Shared --startup-project DiaryApplication
3. Write another command: dotnet ef database update --project DiaryApplication.Shared --startup-project DiaryApplication
4. Database will be created in SQL Server.

#### Info on Blazor
- Blazor web framework allows Razor components to be hosted from server-side in ASP.NET Core (Blazor Server) and client-side in the browser on a WebAssembly-based .NET runtime (Blazor WebAssembly or Blazor WASM).
