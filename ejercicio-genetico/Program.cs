using System;

namespace ejercicio_genetico
{
    class Program
    {
        static void Main(string[] args)
        {
            Genetico obj = new Genetico(10, 0.4, 500, 0.1, 0.1);
            obj.Algoritmo();
            Console.ReadKey();
        }
    }
}
