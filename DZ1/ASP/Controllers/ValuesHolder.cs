using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Controllers
{
    public class ValuesHolder
    {
        //Создаем и инициализируем список класса WeatherForecast
        public List<WeatherForecast> Values { get; set; } = new List<WeatherForecast>();
    }
}
