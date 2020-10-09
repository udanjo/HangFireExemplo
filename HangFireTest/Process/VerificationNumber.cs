using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireTest.Process
{
    public class VerificationNumber
    {
        public void GerandoValorNumerico()
        {
            var number1 = new Random().Next(0, 10);
            var number2 = new Random().Next(0, 10);

            var result = number1 == number2 ? "Valores são iguais!" : number1 > number2 ? "Valor 1 Maior!" : "Valor 2 Maior!";
        }
    }
}
