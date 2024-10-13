# How to create with .NET Aspire a Blazor WebAssambly application consuming a MicroService CRUD AzureSQL

For more info about .NET Aspire Microservices visit this URL: 

https://github.com/luiscoco/Curso_Aprende_Blazor-Nivel_Intermedio-Microservices-with-Aspire-PostgreSQL

## 1. Create a Blazor WebAssembly application consuming a Microservice AzureSQL with CRUD operations

See this repo for a detailed explanation: 

https://github.com/luiscoco/Curso_Aprende_Blazor-Nivel_Intermedio-Microservice-AzureSQL

![image](https://github.com/user-attachments/assets/ff6131b1-3e59-4469-b95e-33103b024342)

## 2. Add .NET Aspire support in the Web API application

Right click on the **Microservice-AzureSQL** project and select the menu option 

![image](https://github.com/user-attachments/assets/54154a53-d9d9-4cba-b918-b6a2de9a2f31)

Add .NET Aspire support

![image](https://github.com/user-attachments/assets/a7d1be5c-66f4-43b5-b8b3-cf93386add62)

Two projects will be created:

![image](https://github.com/user-attachments/assets/2420851b-a001-405f-a8ad-0124ef0dec19)

Verify the new projects in the Solution Explorer

![image](https://github.com/user-attachments/assets/665ce2e3-b111-40a0-98ba-f2e469649dd2)

## 3. Add .NET Aspire support in the Blazor WebAssembly application

Right click on the Blazor WebAssembly project and also add .NET Aspire Orchestrator support:

![image](https://github.com/user-attachments/assets/aed7c104-b1cd-42d0-8815-4248d9f5e4f9)

![image](https://github.com/user-attachments/assets/505c3462-efb6-46e9-a9c9-393ddb0acbdf)

You will be shown the following message, press the Ok button 

![image](https://github.com/user-attachments/assets/8fb029c0-831b-4053-a49c-a5024ce494d4)

## 4. Add the Blazor WebAssembly project reference in the Aspire Host project

![image](https://github.com/user-attachments/assets/74f8f4fa-3c7c-4a1c-bc6d-01e73def64a9)

## 5. Add the Blazor WebAssembly project in the Aspire Host project middleware(Program.cs)

Add this code:

```csharp
builder.AddProject<Projects.BlazorWebAssemblyUI>("blazorwebassemblyui");
```

![image](https://github.com/user-attachments/assets/7b3db30a-86fd-4ddb-ad08-33d5039d57f3)

## 6. Removing these code in the BlazorWebAssemblyUI (launchSettings.json)

![image](https://github.com/user-attachments/assets/d7066523-1915-4473-85b6-a2d7fd304384)

After removing the code this is the result

![image](https://github.com/user-attachments/assets/7f821f3f-77ef-48c6-89c7-f814ac3edbc4)

## 7. Run and verify the application

Run the application with the HTTPS protocol ![image](https://github.com/user-attachments/assets/fe7826f3-6adc-41ce-af46-e07d4cc9b5f6)

![image](https://github.com/user-attachments/assets/5aed30f1-01a4-4848-871a-4557c27ed3e5)

See the Aspire .NET desktop

![image](https://github.com/user-attachments/assets/6ce2d4b6-33b6-4764-ae2d-126b56f071b5)

See the Web API

![image](https://github.com/user-attachments/assets/82ab2b4d-ecd7-4558-98a5-9435a7690404)

See the Blazor WebAssembly application

![image](https://github.com/user-attachments/assets/67622162-760c-4740-af2b-5b0290139b7e)





