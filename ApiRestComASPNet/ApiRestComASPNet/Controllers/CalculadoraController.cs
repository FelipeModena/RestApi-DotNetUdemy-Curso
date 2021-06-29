using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestComASPNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (isNumeric(secondNumber) && isNumeric(firstNumber))
            {
                var avgr = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(avgr);

            }
            else
            {
                return BadRequest("faio");
            }
        }

        [HttpGet("avgr/{firstNumber}/{secondNumber}")]
        public IActionResult Avgr(string firstNumber, string secondNumber)
        {
            if (isNumeric(secondNumber) && isNumeric(firstNumber))
            {
                var avgr = (ConvertToDecimal(firstNumber) +ConvertToDecimal(secondNumber))/ 2;
            return Ok(avgr);

            }
            else
            {
                return BadRequest("faio");
            }
        }

        [HttpGet("sqr/{firstNumber}")]
        public IActionResult Sqr(string firstNumber)
        {
            if ( isNumeric(firstNumber))
            {
                var sum = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(sum.ToString());

            }
            return BadRequest("Invalid input");
        }


        [HttpGet ("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (isNumeric(secondNumber) && isNumeric(firstNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());

            }
            return BadRequest("Invalid input");
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (isNumeric(secondNumber) && isNumeric(firstNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());

            }
            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            else
            {
                return 0;
            }
        }

        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
    }
}
