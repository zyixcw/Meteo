using Meteo.Model;
using Meteo.Services;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Meteo
{
    public partial class MainWindow : Window
    {
        private readonly WeatherService _weatherService;

        public MainWindow()
        {
            InitializeComponent();
            _weatherService = new WeatherService();

            // villes de la combobox
            cityComboBox.Items.Add(new ComboBoxItem { Content = "Annecy" });
            cityComboBox.Items.Add(new ComboBoxItem { Content = "Lyon" });
            cityComboBox.Items.Add(new ComboBoxItem { Content = "Paris" });
            cityComboBox.Items.Add(new ComboBoxItem { Content = "Marseille" });
            cityComboBox.SelectedIndex = 0;

            // pour charger les données
            LoadWeatherData((cityComboBox.SelectedItem as ComboBoxItem).Content.ToString());
        }

        private async void LoadWeatherData(string city)
        {
            try
            {
                WeatherData weatherData = await _weatherService.GetWeatherDataAsync(city);

                if (weatherData != null)
                {
                    cityTextBlock.Text = $"Ville: {weatherData.City.Name}, Pays: {weatherData.City.Country}";

                    if (weatherData.CurrentCondition != null)
                    {
                        temperatureTextBlock.Text = $"Température: {weatherData.CurrentCondition.TempC}°C";
                        descriptionTextBlock.Text = weatherData.CurrentCondition.Condition;

                        if (!string.IsNullOrEmpty(weatherData.CurrentCondition.Icon))
                        {
                            weatherIcon.Source = new BitmapImage(new Uri(weatherData.CurrentCondition.Icon));
                        }
                        else
                        {
                            weatherIcon.Source = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Informations de condition non disponibles");
                    }

                    DisplayForecasts(weatherData);
                }
                else
                {
                    MessageBox.Show("Impossible de charger les informations météo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue: {ex.Message}");
            }
        }

        private void DisplayForecasts(WeatherData weatherData)
        {
            TB_Day1_day_Date.Text = $"Jour 1: {weatherData.Day1.Date}";
            TB_Day1_TempMini.Text = $"Min: {weatherData.Day1.MinTemp}°C";
            TB_Day1_TempMax.Text = $"Max: {weatherData.Day1.MaxTemp}°C";
            TB_Day1_condition.Text = $"Condition: {weatherData.Day1.Condition}";
            day1Icon.Source = new BitmapImage(new Uri(weatherData.Day1.Icon));

            TB_Day2_day_Date.Text = $"Jour 2: {weatherData.Day2.Date}";
            TB_Day2_TempMini.Text = $"Min: {weatherData.Day2.MinTemp}°C";
            TB_Day2_TempMax.Text = $"Max: {weatherData.Day2.MaxTemp}°C";
            TB_Day2_condition.Text = $"Condition: {weatherData.Day2.Condition}";
            day2Icon.Source = new BitmapImage(new Uri(weatherData.Day2.Icon));

            TB_Day3_day_Date.Text = $"Jour 3: {weatherData.Day3.Date}";
            TB_Day3_TempMini.Text = $"Min: {weatherData.Day3.MinTemp}°C";
            TB_Day3_TempMax.Text = $"Max: {weatherData.Day3.MaxTemp}°C";
            TB_Day3_condition.Text = $"Condition: {weatherData.Day3.Condition}";
            day3Icon.Source = new BitmapImage(new Uri(weatherData.Day3.Icon));

            TB_Day4_day_Date.Text = $"Jour 4: {weatherData.Day4.Date}";
            TB_Day4_TempMini.Text = $"Min: {weatherData.Day4.MinTemp}°C";
            TB_Day4_TempMax.Text = $"Max: {weatherData.Day4.MaxTemp}°C";
            TB_Day4_condition.Text = $"Condition: {weatherData.Day4.Condition}";
            day4Icon.Source = new BitmapImage(new Uri(weatherData.Day4.Icon));
        }

        private void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cityComboBox.SelectedItem is ComboBoxItem selectedCity)
            {
                string cityName = selectedCity.Content.ToString();
                LoadWeatherData(cityName);
            }
        }
    }
}
