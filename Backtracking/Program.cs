using System;

namespace Backtracking
{
    internal class Program
    {
        private static int _n;
        private static int _k = 1;

        private static void Main(string[] args)
        {
            NRainhas(6);
        }

        private static void NRainhas(int tamanho)
        {
            _n = tamanho;
            var tabuleiro = new int[_n, _n];

            if (NRainhasUtil(tabuleiro, 0) == false)
            {
                Console.Write("Sem solução");
            }
        }

        private static bool NRainhasUtil(int[,] tabuleiro, int coluna)
        {
            if (coluna == _n)
            {
                ToString(tabuleiro);
                return true;
            }

            bool res = false;
            for (int i = 0; i < _n; i++)
            {
                if (IsSafe(tabuleiro, i, coluna))
                {
                    tabuleiro[i, coluna] = 1;

                    res = NRainhasUtil(tabuleiro, coluna + 1) || res;

                    tabuleiro[i, coluna] = 0;
                }
            }

            return res;
        }

        private static void ToString(int[,] tabuleiro)
        {
            Console.Write($"{_k++}-\n");
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    Console.Write($" {tabuleiro[i, j]} ");
                }

                Console.Write("\n");
            }
        }

        private static bool IsSafe(int[,] tabuleiro, int linha, int coluna)
        {
            int i, j;

            for (i = 0; i < coluna; i++)
            {
                if (tabuleiro[linha, i] == 1)
                {
                    return false;
                }
            }

            for (i = linha, j = coluna; i >= 0 && j >= 0; i--, j--)
            {
                if (tabuleiro[i, j] == 1)
                {
                    return false;
                }
            }

            for (i = linha, j = coluna; j >= 0 && i < _n; i++, j--)
            {
                if (tabuleiro[i, j] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}