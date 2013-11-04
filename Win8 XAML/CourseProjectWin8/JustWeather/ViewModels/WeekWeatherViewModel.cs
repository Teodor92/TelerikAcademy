using JustWeather.Behavor;
using JustWeather.Data;
using JustWeather.Models;
using JustWeather.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using Windows.Storage.Pickers;
using Windows.UI.Popups;

namespace JustWeather.ViewModels
{
    public class WeekWeatherViewModel : BaseViewModel
    {
        private ObservableCollection<DailyForecast> weekWeatherInfo;
        private ForecastIOResponse allInfo;
        private ICommand saveWeatherInfoCommand;

        public ICommand SaveWeatherInfo
        {
            get
            {
                if (this.saveWeatherInfoCommand == null)
                {
                    this.saveWeatherInfoCommand = new DelegateCommand<object>(this.HandleSaveWeatherInfoCommand);
                }
                return this.saveWeatherInfoCommand;
            }
        }

        public ForecastIOResponse AllInfo
        {
            get
            {
                return this.allInfo;
            }
            set
            {
                this.allInfo = value;
                this.OnPropertyChanged("AllInfo");
            }
        }

        public IEnumerable<DailyForecast> WeekWeatherInfo
        {
            get
            {
                if (this.weekWeatherInfo == null)
                {
                    this.weekWeatherInfo = new ObservableCollection<DailyForecast>();
                }
                return this.weekWeatherInfo;
            }
            set
            {
                if (this.weekWeatherInfo == null)
                {
                    this.weekWeatherInfo = new ObservableCollection<DailyForecast>();
                }
                this.SetObservableValues(this.weekWeatherInfo, value);
            }
        }

        public WeekWeatherViewModel()
        {
            this.GetWeatherInfo();
        }

        private async void GetWeatherInfo()
        {
            var helper = new Helpers();

            Coordinate positon = await helper.GetCoordinates();
            ForecastIOResponse info = null;
            MessageDialog msg = null;

            try
            {
                info = await DataPersister.GetInfo(positon.Lat, positon.Lon);
            }
            catch (Exception)
            {
                msg = new MessageDialog("Info loading failed!");
            }

            if (msg != null)
            {
                await msg.ShowAsync();
                return;
            }

            this.allInfo = info;
            List<DailyForecast> rawData = info.Daily.Data;
            for (int i = 0; i < rawData.Count; i++)
            {
                rawData[i].IconPath = string.Format("/Assets/WeatherIcons/{0}.png", rawData[i].Icon);
                DateTime date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(rawData[i].Time);
                rawData[i].FormatedDate = date.DayOfWeek;
            }

            this.WeekWeatherInfo = rawData;

        }

        private async void HandleSaveWeatherInfoCommand(object parameter)
        {
            await AsyncCatcher.Try(async () =>
            {
                var savePicker = new Windows.Storage.Pickers.FileSavePicker();
                var plainTextFileTypes = new List<string>(new string[] { ".txt" });
                var webPageFileTypes = new List<string>(new string[] { ".html", ".htm" });

                savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;

                savePicker.FileTypeChoices.Add(
                    new KeyValuePair<string, IList<string>>("Web Page", webPageFileTypes)
                    );

                savePicker.FileTypeChoices.Add(
                    new KeyValuePair<string, IList<string>>("Plain Text", plainTextFileTypes)
                    );

                var saveFile = await savePicker.PickSaveFileAsync();

                if (saveFile != null)
                {
                    StringBuilder fileContent = new StringBuilder();

                    if (saveFile.FileType == ".html" || saveFile.FileType == ".htm")
                    {
                        string styles = @"html { font-family: 'Segoe UI'; }
                                        section { border: 1px solid #00a000; margin: 10px auto; padding: 10px;
                                        width: 50%; } h1 { text-align: center; }";

                        fileContent.AppendLine(string.Format(
                            "<html><head><title>Week Weather Info</title><style>{0}</style></head><body>", styles));
                        fileContent.AppendLine("<h1>Week Weather Info</h1>");
                        foreach (var item in this.WeekWeatherInfo)
                        {
                            fileContent.AppendLine("<section>");
                            fileContent.AppendFormat("<p><strong>Day of the week:</strong> {0} </p>", item.FormatedDate);
                            fileContent.AppendFormat("<p><strong>Max Temperature:</strong> {0} </p>", item.TemperatureMax);
                            fileContent.AppendFormat("<p><strong>Min Temperature:</strong> {0} </p>", item.TemperatureMin);
                            fileContent.AppendFormat("<p><strong>Apparent Min Temperature:</strong> {0} </p>", item.ApparentTemperatureMin);
                            fileContent.AppendFormat("<p><strong>Apparent Min Temperature time:</strong> {0} </p>", item.TemperatureMinTime);
                            fileContent.AppendFormat("<p><strong>Apparent Max Temperature:</strong> {0} </p>", item.ApparentTemperatureMax);
                            fileContent.AppendFormat("<p><strong>Apparent Max Temperature time:</strong> {0} </p>", item.TemperatureMaxTime);
                            fileContent.AppendFormat("<p><strong>Cloud Cover:</strong> {0} </p>", item.CloudCover);
                            fileContent.AppendFormat("<p><strong>Pressure:</strong> {0} </p>", item.Pressure);
                            fileContent.AppendFormat("<p><strong>Visibility:</strong> {0} </p>", item.Visibility);
                            fileContent.AppendLine("</section>");
                        }
                        fileContent.AppendLine("</body></html>");
                    }
                    else
                    {
                        foreach (var item in this.WeekWeatherInfo)
                        {
                            fileContent.AppendFormat("Day of the week: {0}", item.FormatedDate);
                            fileContent.AppendLine();
                            fileContent.AppendFormat("Max Temperature: {0}", item.TemperatureMax);
                            fileContent.AppendLine();
                            fileContent.AppendFormat("Min Temperature: {0}", item.TemperatureMin);
                            fileContent.AppendLine();
                            fileContent.AppendFormat("Apparent Min Temperature: {0}", item.ApparentTemperatureMin);
                            fileContent.AppendLine();
                            fileContent.AppendFormat("Apparent Min Temperature time: {0}", item.TemperatureMinTime);
                            fileContent.AppendLine();
                            fileContent.AppendFormat("Apparent Max Temperature: {0}", item.ApparentTemperatureMax);
                            fileContent.AppendLine();
                            fileContent.AppendFormat("Apparent Max Temperature time: {0}", item.TemperatureMaxTime);
                            fileContent.AppendLine();
                            fileContent.AppendFormat("Cloud Cover: {0}", item.CloudCover);
                            fileContent.AppendLine();
                            fileContent.AppendFormat("Pressure: {0}", item.Pressure);
                            fileContent.AppendLine();
                            fileContent.AppendFormat("Visibility: {0}", item.Visibility);
                            fileContent.AppendLine();
                            fileContent.AppendLine();
                        }
                    }


                    await Windows.Storage.FileIO.WriteTextAsync(saveFile, fileContent.ToString());
                    await new Windows.UI.Popups.MessageDialog("File Saved!").ShowAsync();
                }
            }).Catch<Exception>(async ex =>
            {
                var msg = new MessageDialog("Save failed!");
                await msg.ShowAsync();
            });
        }
    }
}
