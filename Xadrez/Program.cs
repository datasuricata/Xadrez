using System;
using Tabuleiro;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao P;
            P = new Posicao(3, 4);
            Console.Write("Posição: " + P);
            Console.Read();
        }
    }
}
