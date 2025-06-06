using TaskApi.Services;

var builder = WebApplication.CreateBuilder(args);

// ������������ ������ ��� ������ � ��������
builder.Services.AddSingleton<TaskService>();

//  ��������� �����������
builder.Services.AddControllers();

// ��������� Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger ������ ��� ����������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//  ������������ �������� ������������
app.MapControllers();

app.Run();
