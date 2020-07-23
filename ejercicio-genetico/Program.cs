using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_genetico
{
    class Program
    {
        static void Main(string[] args)
        {
            Genetico obj = new Genetico(20, 3, 10, 0.1, 0.1);
            obj.Algoritmo();
            Console.ReadKey();
        }
    }
}
