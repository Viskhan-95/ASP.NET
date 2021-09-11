using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP
{
    //Создаем класс для хранения температуры и даты
    public class WeatherForecast
    {
        public DateTime Date { get; set; } // Поле для хранеия даты изменения погоды
        public double TemperatureC { get; set; } //Поле для хранения температуры
    }
}
