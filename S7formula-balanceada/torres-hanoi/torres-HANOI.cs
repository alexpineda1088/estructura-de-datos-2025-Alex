using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    // Función recursiva para resolver el problema de las Torres de Hanoi
    static void ResolverTorres(int n, char origen, char destino, char auxiliar)
    {
        // Caso base: si solo hay un disco, simplemente moverlo de la torre origen a la torre destino
        if (n == 1)
        {
            Console.WriteLine($"Mover disco 1 de {origen} a {destino}");
            return;
        }
        
        // Mover n-1 discos de la torre origen a la torre auxiliar, usando la torre destino como auxiliar
        ResolverTorres(n - 1, origen, auxiliar, destino);
        
        // Mover el disco restante (el más grande) de la torre origen a la torre destino
        Console.WriteLine($"Mover disco {n} de {origen} a {destino}");
        
        // Mover los n-1 discos de la torre auxiliar a la torre destino, usando la torre origen como auxiliar
        ResolverTorres(n - 1, auxiliar, destino, origen);
    }

    static void Main(string[] args)
    {
        // Definimos el número de discos
        int numeroDeDiscos = 3;

        // Llamamos a la función para resolver las Torres de Hanoi, con las torres A, B, C como origen, destino y auxiliar
        Console.WriteLine("Solución para las Torres de Hanoi:");
        ResolverTorres(numeroDeDiscos, 'A', 'C', 'B');
    }
}
