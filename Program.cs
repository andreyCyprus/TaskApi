using TaskApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Регистрируем сервис для работы с задачами
builder.Services.AddSingleton<TaskService>();

//  Добавляем контроллеры
builder.Services.AddControllers();

// Добавляем Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger только для разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//  Регистрируем маршруты контроллеров
app.MapControllers();

app.Run();
