using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace ASP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ValuesHolder _holder;
        public AnimalsController(ValuesHolder holder)
        {
            _holder = holder;
        }


        [HttpPost]
        public IActionResult Create([FromBody] Animal animal)
        {
            _holder.Values.Add(animal.Name);
            return Ok();
        }


        [HttpGet]
        public IActionResult Read()
        {
            return Ok(_holder.Values);
        }


        [HttpPut]
        public IActionResult Update([FromQuery] string stringsToUpdate,
            [FromQuery] string newValue)
        {
            for (int i = 0; i < _holder.Values.Count; i++)
            {
                if (_holder.Values[i] == stringsToUpdate)
                    _holder.Values[i] = newValue;
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] string stringsToDelete)
        {
            _holder.Values = _holder.Values.Where(w => w != stringsToDelete).ToList();
            return Ok();
        }
    }
}
