﻿using Demo.Data;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace Demo
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

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            // Set path to the SQLite database (it will be created if it does not exist)
            var dbPath =
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    @"Demo.db");
            // Register WeatherForecastService and the SQLite database
            builder.Services.AddSingleton<WeatherForecastService>(
                s => ActivatorUtilities.CreateInstance<WeatherForecastService>(s, dbPath));

            // Set path to the SQLite database (it will be created if it does not exist)
            
            // Register WeatherForecastService and the SQLite database
            builder.Services.AddSingleton<EmployeeService>(
                s => ActivatorUtilities.CreateInstance<EmployeeService>(s, dbPath));



            builder.Services.AddMudServices();

            return builder.Build();
        }
    }
}