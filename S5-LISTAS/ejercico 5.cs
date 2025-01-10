using System; // Para trabajar con la consola
using System.Collections.Generic; // Para manejar listas

class Program
{
    static void Main()
    {
        // Crear una lista para almacenar los números del 1 al 10
        List<int> numeros = new List<int>();

        // Llenar la lista con los números del 1 al 10
        for (int i = 1; i <= 10; i++)
        {
            numeros.Add(i); // Agregar cada número a la lista
        }

        // Invertir el orden de los números en la lista
        numeros.Reverse(); // Método integrado para invertir una lista

        // Mostrar los números en orden inverso, separados por comas
        Console.WriteLine("Números en orden inverso:");
        Console.WriteLine(string.Join(", ", numeros)); // Convierte la lista en una cadena separada por comas

        // Pausar la ejecución para que el usuario pueda ver el resultado
        Console.WriteLine("\nPresione cualquier tecla para finalizar...");
        Console.ReadKey(); // Espera a que el usuario presione una tecla
    }
}
