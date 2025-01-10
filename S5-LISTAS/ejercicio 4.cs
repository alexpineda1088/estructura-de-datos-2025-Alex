using System; // Para trabajar con la consola
using System.Collections.Generic; // Para manejar listas
using System.Linq; // Para usar funciones como OrderBy

class Program
{
    static void Main()
    {
        // Lista para almacenar los números ganadores
        List<int> numerosGanadores = new List<int>();

        // Mensaje inicial
        Console.WriteLine("Introduce los números ganadores de la lotería primitiva.\n");

        // Pedir al usuario que ingrese 6 números
        for (int i = 1; i <= 6; i++) // El usuario introduce 6 números en total
        {
            Console.Write($"Número {i}: "); // Solicitar cada número
            int numero; // Variable para almacenar el número introducido

            // Validar que el usuario introduzca un número entero válido
            while (!int.TryParse(Console.ReadLine(), out numero) || numero < 1 || numero > 49)
            {
                Console.WriteLine("Por favor, introduce un número entero entre 1 y 49.");
                Console.Write($"Número {i}: ");
            }

            // Agregar el número a la lista
            numerosGanadores.Add(numero);
        }

        // Ordenar los números en orden ascendente
        numerosGanadores.Sort(); // Función integrada para ordenar listas

        // Mostrar los números ordenados
        Console.WriteLine("\nNúmeros ganadores ordenados de menor a mayor:");
        foreach (int numero in numerosGanadores)
        {
            Console.WriteLine(numero); // Mostrar cada número
        }

        // Pausar la ejecución para que el usuario pueda ver el resultado
        Console.WriteLine("\nPresione cualquier tecla para finalizar...");
        Console.ReadKey();
    }
}
