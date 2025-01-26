using System;
using System.Collections.Generic;

class FormulaBalanceada
{
    // Función principal para verificar si una fórmula está balanceada
    static bool EstaBalanceada(string formula)
    {
        // Declaración de la pila para almacenar los caracteres de apertura
        Stack<char> pila = new Stack<char>();

        // Iterar sobre cada caracter en la fórmula
        foreach (char caracter in formula)
        {
            // Si es un caracter de apertura, se agrega a la pila
            if (caracter == '{' || caracter == '[' || caracter == '(')
            {
                pila.Push(caracter);
            }
            // Si es un caracter de cierre
            else if (caracter == '}' || caracter == ']' || caracter == ')')
            {
                // Si la pila está vacía, la fórmula no está balanceada
                if (pila.Count == 0) return false;

                // Obtener el tope de la pila y verificar si hace pareja con el caracter actual
                char tope = pila.Pop();
                if (!EsPareja(tope, caracter)) return false;
            }
        }

        // Si la pila está vacía al final, la fórmula está balanceada
        return pila.Count == 0;
    }

    // Función auxiliar para verificar si un caracter de apertura y cierre son pareja
    static bool EsPareja(char apertura, char cierre)
    {
        return (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']') ||
               (apertura == '(' && cierre == ')');
    }

    // Punto de entrada del programa
    static void Main(string[] args)
    {
        // Ejemplo de fórmula a verificar
        string formula = "{7+(8*5)-[(9-7)+(4+1)]}";

        // Mostrar resultado en consola
        Console.WriteLine(EstaBalanceada(formula) ? "Fórmula balanceada" : "Fórmula no balanceada");
    }
}
