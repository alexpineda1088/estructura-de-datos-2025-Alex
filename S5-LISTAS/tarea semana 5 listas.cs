using System;
using System.Collections.Generic; // Se utiliza para listas

class Program
{
    static void Main()
    {
        // Crear una lista para almacenar las asignaturas del curso
        List<string> asignaturas = new List<string>()
        {
            "Matemáticas",  // Primera asignatura
            "Física",       // Segunda asignatura
            "Química",      // Tercera asignatura
            "Historia",     // Cuarta asignatura
            "Lengua"        // Quinta asignatura
        };

        // Mostrar un mensaje inicial
        Console.WriteLine("Las asignaturas del curso son:");

        // Recorrer la lista y mostrar cada asignatura
        foreach (string asignatura in asignaturas)
        {
            Console.WriteLine("- " + asignatura); // Imprime cada asignatura precedida por un guion
        }

        // Finalizar el programa con un mensaje
        Console.WriteLine("\nFin del programa. Presione cualquier tecla para salir...");
        Console.ReadKey(); // Pausa el programa hasta que el usuario presione una tecla
    }
}

