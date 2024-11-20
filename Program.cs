using cat.itb.M6UF2EA3.connections;

namespace ColorBlindProyect_Api
{
    public class Program
    {
        public const string CORSPolicyName = "CORSPolicy";
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            //DI de la cadena de connexió de la BBDD
            //permet que el servei estigui disponible per a tota l'aplicació
            /*builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });*/
            SessionFactoryCloud.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? String.Empty;
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: CORSPolicyName,
                                  policy =>
                                  {
                                      policy.AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .AllowAnyOrigin();
                                  });
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(CORSPolicyName);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}