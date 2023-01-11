using Microsoft.Extensions.Options;
using ProductReview.Repositorio.Contexto;
using ProductReview.Repositorio.Implementacoes;
using ProductReview.Repositorio.Interfaces;
using ProductReview.Servico.Implementacoes;
using ProductReview.Servico.Interfaces;

namespace ProductReview.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            // Adicionando contexto do banco de dados.
            services.Configure<ContextoBD>(builder.Configuration.GetSection("ContextoBD"));
            services.AddSingleton<IContextoBD>(
                serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<ContextoBD>>().Value);

            // Adicionando repositórios.
            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
            services.AddScoped<IRepositorioDeProduto, RepositorioDeProduto>();

            // Adicionando serviços.
            services.AddScoped<IServicoDeProduto, ServicoDeProduto>();
            services.AddScoped<IServicoDeUsuario, ServicoDeUsuario>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}