using Newtonsoft.Json;

namespace Meteo.Model
{
    public class WeatherData
    {
        [JsonProperty("city_info")]
        public required CityInfo City { get; set; }

        [JsonProperty("current_condition")]
        public required CurrentCondition CurrentCondition { get; set; }

        [JsonProperty("forecast_info")]
        public required ForecastInfo ForecastInfo { get; set; }

        [JsonProperty("fcst_day_1")]
        public required ForecastDay Day1 { get; set; }

        [JsonProperty("fcst_day_2")]
        public required ForecastDay Day2 { get; set; }

        [JsonProperty("fcst_day_3")]
        public required ForecastDay Day3 { get; set; }

        [JsonProperty("fcst_day_4")]
        public required ForecastDay Day4 { get; set; }
    }

    public class CityInfo
    {
        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("country")]
        public required string Country { get; set; }
    }

    public class CurrentCondition
    {
        [JsonProperty("date")]
        public required string Date { get; set; }

        [JsonProperty("hour")]
        public required string Hour { get; set; }

        [JsonProperty("tmp")]
        public required int TempC { get; set; }

        [JsonProperty("condition")]
        public required string Condition { get; set; }

        [JsonProperty("icon")]
        public required string Icon { get; set; }
    }

    public class ForecastInfo
    {
        [JsonProperty("condition")]
        public required string Condition { get; set; }
    }

    public class ForecastDay
    {
        [JsonProperty("date")]
        public required string Date { get; set; }

        [JsonProperty("tmin")]
        public required int MinTemp { get; set; }

        [JsonProperty("tmax")]
        public required int MaxTemp { get; set; }

        [JsonProperty("condition")]
        public required string Condition { get; set; }

        [JsonProperty("icon")]
        public required string Icon { get; set; }
    }
}
