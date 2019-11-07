using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.ProgramaDeEstagio.TesteCadastroDeCargo
{
    public class Uteis
    {
         public Random random = new Random();
         public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                                .Select(s => s[random.Next(s.Length)]).ToArray());
            
        }
         
    }
}
