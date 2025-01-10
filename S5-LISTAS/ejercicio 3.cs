using System; // Para trabajar con la consola
using System.Collections.Generic; // Para usar listas

class Program
{
    static void Main()
    {
        // Lista para almacenar las asignaturas del curso
        List<string> asignaturas = new List<string>()
        {
            "Matemáticas",
            "Física",
            "Química",
            "Historia",
            "Lengua"
        };

        // Lista para almacenar las notas de las asignaturas
        List<double> notas = new List<double>();

        // Mensaje inicial
        Console.WriteLine("Por favor, introduce las notas obtenidas en las siguientes asignaturas:\n");

        // Recorrer la lista de asignaturas y pedir al usuario la nota correspondiente
        foreach (string asignatura in asignaturas)
        {
            Console.Write($"Nota en {asignatura}: "); // Pedir la nota al usuario
            double nota; // Variable para almacenar la nota

            // Validar que el usuario introduzca un número válido
            while (!double.TryParse(Console.ReadLine(), out nota))
            {
                Console.WriteLine("Por favor, introduce un número válido.");
                Console.Write($"Nota en {asignatura}: ");
            }

            // Agregar la nota a la lista de notas
            notas.Add(nota);
        }

        // Mostrar las asignaturas junto con las notas obtenidas
        Console.WriteLine("\nResumen de calificaciones:\n");
        for (int i = 0; i < asignaturas.Count; i++)
        {
            Console.WriteLine($"En {asignaturas[i]} has sacado {notas[i]}.");
        }

        // Pausar la ejecución para que el usuario pueda ver el resultado
        Console.WriteLine("\nPresione cualquier tecla para finalizar...");
        Console.ReadKey();
    }
}
