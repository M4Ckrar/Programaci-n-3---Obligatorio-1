using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Usuario
    {

        public string Cedula { get; set; }
        public string Password { get; set; }
        public bool Rol { get; set; }

        public bool ValidarUsuario()
        {
            if (Password.Length >= 6 && Password.Length <= 20 && Cedula.Length == 8 || Cedula.Length == 9) {
                bool containsCapitalLetter = false;
                bool containsLowerCase = false;
                bool containsDigit = false;
                bool validPassword = false;
                for (int i = 0; i < Password.Length; i++)
                {
                    int asciiValue = (int)Password[i];

                    if (!containsCapitalLetter && asciiValue >= 65 && asciiValue <= 90)
                        containsCapitalLetter = true;
                    else if (!containsLowerCase && asciiValue >= 97 && asciiValue <= 127)
                        containsLowerCase = true;
                    else if (!containsDigit && asciiValue >= 48 && asciiValue <= 57)
                        containsDigit = true;

                    if (containsCapitalLetter && containsLowerCase && containsDigit)
                    {
                        validPassword = true;
                        break;
                    }                                               
                }

                if (validPassword)
                    return true;
                else
                    return false;

            } else {
                return false;
            }                
        }

    }

}
