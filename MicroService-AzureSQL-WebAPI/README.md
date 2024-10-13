# How to create .NET8 WebAPI Azure SQL MicroService

## 1. Create Azure SQL 

Create Azure SQL service:

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/59c10a31-802c-47bd-97bf-5f36000a1b61)

Select SQL databases and press **Create** button

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/dd4e2bc2-b4fa-4478-873b-2a103a04351d)

We set the database name and we create a SQL Server

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/d5ac3726-1052-4680-8257-531c771d8727)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/979ecb7d-59c5-4eb0-9182-ef0c1fd56182)

We create SQL Server

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/a95e203c-d8ab-4eaa-9bc4-dddc348fab51)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/be32d9d5-fbfc-4538-ae87-2339563d813a)

We configure the database engine CPUs and Memory

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/7671eab3-e1a9-46dc-98ee-304c26f68d25)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/6dcc6738-6917-45c0-a8eb-04382623585e)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/1dfd45ca-7ce8-47a3-9b2c-74131a216cba)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/ac93019f-e247-4ec6-9f5e-37cd38677cf4)

**IMPORTANT**: 

We copy the connection string to the appsettings.json file

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/6c2d57a6-ac32-4f4a-b579-cc2777cb8115)

Do not forget to set the Server Password in the connection string

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/fba0c7c1-9860-4aae-95f8-fa7049da70e8)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/5c25a311-28c9-46f8-8321-ae7f07d8191b)

We also enter in the SQL Server and add the FireWall rules

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/441f4744-efbc-4ea0-a97a-3aa724418ac5)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/0bd300af-20ea-49ad-bb4b-604d131c8e9d)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/c501ff54-2296-4d70-9d6d-6c08f352a581)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/efbcfaef-e2a5-4f11-b7d4-be7733063575)


## 2. Create .NET8 WebAPI CRUD Microservice

### 2.1. appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:mysqlserver1974luiscoco.database.windows.net,1433;Initial Catalog=mysqldatabasename;Persist Security Info=False;User ID=myadminlogin;Password=Luiscoco123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}
```

### 2.2. Program.cs

```csharp
using Microsoft.EntityFrameworkCore;
using AzureSQLWebAPIMicroservice.Data;
using AzureSQLWebAPIMicroservice.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ExampleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ExampleModelService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
```

### 2.3. Models (ExampleModel.cs)

**ExampleModel.cs**

```csharp
namespace AzureSQLWebAPIMicroservice.Models
{
    public class ExampleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
```

### 2.4. Service (ExampleModelService.cs)

**ExampleModelService.cs**

```csharp
using AzureSQLWebAPIMicroservice.Data;
using AzureSQLWebAPIMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureSQLWebAPIMicroservice.Services
{
    public class ExampleModelService
    {
        private readonly ExampleDbContext _context;

        public ExampleModelService(ExampleDbContext context)
        {
            _context = context;
        }

        // Create
        public async Task<ExampleModel> AddExampleModel(ExampleModel model)
        {
            _context.ExampleModels.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        // Read all
        public async Task<List<ExampleModel>> GetAllExampleModels()
        {
            return await _context.ExampleModels.ToListAsync();
        }

        // Read by ID
        public async Task<ExampleModel> GetExampleModelById(int id)
        {
            return await _context.ExampleModels.FirstOrDefaultAsync(e => e.Id == id);
        }

        // Update
        public async Task<ExampleModel> UpdateExampleModel(int id, ExampleModel model)
        {
            var existingModel = await _context.ExampleModels.FirstOrDefaultAsync(e => e.Id == id);
            if (existingModel == null)
            {
                return null;
            }

            existingModel.Name = model.Name;
            // Update other properties as necessary

            _context.Entry(existingModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingModel;
        }

        // Delete
        public async Task<bool> DeleteExampleModel(int id)
        {
            var model = await _context.ExampleModels.FindAsync(id);
            if (model == null)
            {
                return false;
            }

            _context.ExampleModels.Remove(model);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
```

### 2.5. Data (ExampleDbContext.cs)

**ExampleDbContext.cs**

```csharp
using Microsoft.EntityFrameworkCore;
using AzureSQLWebAPIMicroservice.Models;

namespace AzureSQLWebAPIMicroservice.Data
{
    public class ExampleDbContext:DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options)
        : base(options)
        {
        }

        public DbSet<ExampleModel> ExampleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the primary key for ExampleModel
            modelBuilder.Entity<ExampleModel>().HasKey(e => e.Id);

            // Configure some properties with more details
            modelBuilder.Entity<ExampleModel>()
                .Property(e => e.Name)
                .IsRequired() // Makes the Name field required
                .HasMaxLength(100); // Sets maximum length of the Name field to 100 characters

            modelBuilder.Entity<ExampleModel>()
                .Property(e => e.Description)
                .HasMaxLength(255); // Sets maximum length of the Description field to 255 characters

            // Set a default value for the CreatedDate field
            modelBuilder.Entity<ExampleModel>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()"); // This will use the SQL Server GETDATE() function to set the default value

            // Seed data
            modelBuilder.Entity<ExampleModel>().HasData(
                new ExampleModel { Id = 1, Name = "Sample Name 1", Description = "Sample Description 1", CreatedDate = DateTime.Now },
                new ExampleModel { Id = 2, Name = "Sample Name 2", Description = "Sample Description 2", CreatedDate = DateTime.Now }
                // Add more seed data as needed
            );
        }
    }
}
```


### 2.6. Controllers (ExampleModelsController.cs)

**ExampleModelsController.cs**

```csharp
using Microsoft.AspNetCore.Mvc;
using AzureSQLWebAPIMicroservice.Models;
using AzureSQLWebAPIMicroservice.Services;
using System.Threading.Tasks;

namespace AzureSQLWebAPIMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleModelsController : ControllerBase
    {
        private readonly ExampleModelService _service;

        public ExampleModelsController(ExampleModelService service)
        {
            _service = service;
        }

        // POST: api/ExampleModels
        [HttpPost]
        public async Task<ActionResult<ExampleModel>> PostExampleModel(ExampleModel model)
        {
            var createdModel = await _service.AddExampleModel(model);
            return CreatedAtAction(nameof(GetExampleModel), new { id = createdModel.Id }, createdModel);
        }

        // GET: api/ExampleModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExampleModel>>> GetExampleModels()
        {
            return await _service.GetAllExampleModels();
        }

        // GET: api/ExampleModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExampleModel>> GetExampleModel(int id)
        {
            var model = await _service.GetExampleModelById(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        // PUT: api/ExampleModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExampleModel(int id, ExampleModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var updatedModel = await _service.UpdateExampleModel(id, model);

            if (updatedModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/ExampleModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExampleModel(int id)
        {
            var success = await _service.DeleteExampleModel(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
```

**IMPORTANT**: 

In the AzureSQLWebAPIMicroservice.csproj set **InvariantGlobalization** to **false**

```xml
<InvariantGlobalization>false</InvariantGlobalization>
```

This is the whole **AzureSQLWebAPIMicroservice.csproj**

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <InvariantGlobalization>false</InvariantGlobalization>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.1">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.1" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />
  </ItemGroup>

</Project>
```

## 3. Add First Migration

Add the package **Microsoft.EntityFrameworkCore.Design**

Add/create first migration with this command:

```
dotnet ef migrations add InitialCreate
```

Also update the database with this command

```
dotnet ef database update
```

## 4. Verify application

https://localhost:7217/swagger/index.html

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/d7510f3c-8998-4e6b-b4ae-8b07c3679727)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-SQL/assets/32194879/505699e3-a916-4666-b235-c7a4e0251763)
