using System;

namespace Microfrontend.two.models
{
    public class WeatherData
    {
        public string? Name { get; set; }
        public WeatherDataMain? Main { get; set; }
        public Weather[]? Weather { get; set; }
    }
}

