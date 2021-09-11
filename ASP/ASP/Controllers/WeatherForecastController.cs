using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace ASP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ValuesHolder _holder; // Поле для хранения данных о пагоде
        //Констурктор класса
        public WeatherForecastController(ValuesHolder holder)
        {
            _holder = holder;
        }


        //Метод добавляет полученные данные в список
        [HttpPost]
        public IActionResult Create([FromBody] WeatherForecast weatherForecast)
        {
            _holder.Values.Add(new WeatherForecast() {TemperatureC = weatherForecast.TemperatureC, Date = weatherForecast.Date });
            return Ok();
        }


        //Метод возврашает данные из списка
        [HttpGet]
        public IActionResult Read()
        {
            return Ok(_holder);
        }


        //Метод обновляет конкретные данные
        [HttpPut]
        public IActionResult Update([FromQuery] double doubleToUpdate, [FromQuery] double newDoubleValue,
            [FromQuery] DateTime dateToUpdate, [FromQuery] DateTime newDateToUpdate)
        {
            for (int i = 0; i < _holder.Values.Count; i++)
            {
                foreach (var w in _holder.Values)
                {
                    if (w.TemperatureC == doubleToUpdate && w.Date == dateToUpdate)
                    {
                        w.TemperatureC = newDoubleValue;
                        w.Date = newDateToUpdate;
                    }
                }
            }
            return Ok();
        }


        //Метод удаляет конкретные значения температуры
        [HttpDelete]
        public IActionResult Delete([FromQuery] double doubleToDelete, DateTime dateToDelete)
        {
            _holder.Values = _holder.Values.Where(w => w.TemperatureC != doubleToDelete).Where(w => w.Date != dateToDelete).ToList();
            return Ok();
        }
    }
}
