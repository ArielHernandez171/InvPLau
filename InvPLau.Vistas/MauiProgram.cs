using Microsoft.Extensions.Logging;
using InvPLau.Vistas.Logica;
using InvPLau.Vistas.Clases;
namespace InvPLau.Vistas
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<JsonQuery<Producto>>();
            builder.Services.AddSingleton<JsonQuery<Legajo>>();
            builder.Services.AddSingleton<JsonQuery<RegistroServs>>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
