using AutoMapper;
using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository;
using Fiap.Web.AspNet4.Repository.Interface;
using Fiap.Web.AspNet4.ViewModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

var connectionString = builder.Configuration.GetConnectionString("databaseUrl");
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging(true)
);

var mapperConfig = new AutoMapper.MapperConfiguration(c => {

    c.AllowNullDestinationValues = true;

    c.CreateMap<LoginViewModel, UsuarioModel>();
    c.CreateMap<UsuarioModel, LoginViewModel>();

    c.CreateMap<RepresentanteViewModel, RepresentanteModel>();
    c.CreateMap<RepresentanteModel, RepresentanteViewModel>();

    c.CreateMap<ClienteViewModel, ClienteModel>();
    c.CreateMap<ClienteModel, ClienteViewModel>();

    c.CreateMap<LojaViewModel, LojaModel>();
    c.CreateMap<LojaModel, LojaViewModel>();

    c.CreateMap<ProdutoModel, ProdutoViewModel>();
    c.CreateMap<ProdutoViewModel, ProdutoModel>();

    c.CreateMap<ProdutoLojaModel, ProdutoLojaViewModel>();
    c.CreateMap<ProdutoLojaViewModel, ProdutoLojaModel>();


});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ILojaRepository, LojaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
