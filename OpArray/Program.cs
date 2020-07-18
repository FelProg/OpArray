using System;

namespace OpArray
{
    class Program
    {
        static string[] Arreglo = new string[10];
        static void Main(string[] args)
        {
            try
            {
                ValidaVacio();
                Arreglo[0] = "Cero";
                ValidaVacio();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static bool ValidaVacio()
        {
            if (Arreglo[0]==null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
