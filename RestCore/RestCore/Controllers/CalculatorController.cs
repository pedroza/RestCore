using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestCore.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        // GET api/values/5/5
        [HttpGet("{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                    return Ok(sum.ToString());
            }

            return BadRequest("value");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal numDecimal;

            if (decimal.TryParse(number, out numDecimal))
                return numDecimal;

            return 0;
        }

        private bool isNumeric(string firstNum)
        {
            double num;

            bool isNum = double.TryParse(firstNum, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out num);
            return isNum;

        }
    }
}
