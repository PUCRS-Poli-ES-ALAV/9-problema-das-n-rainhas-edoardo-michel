using System;
using System.Collections.Generic;

namespace Backtracking
{
    internal class Program
    {
        private static int n;
        private static int k = 1;

        private static void Main(string[] args)
        {
            NQueens(6);
        }

        private static void NQueens(int size)
        {
            n = size;
            var board = new int[n, n];

            if (NQueensUtil(board, 0) == false)
            {
                Console.Write("Solution does not exist");
            }
        }

        private static bool NQueensUtil(int[,] board, int col)
        {
            if (col == n)
            {
                PrintSolution(board);
                return true;
            }

            bool res = false;
            for (int i = 0; i < n; i++)
            {
                if (IsSafe(board, i, col))
                {
                    board[i, col] = 1;

                    res = NQueensUtil(board, col + 1) || res;

                    board[i, col] = 0; // BACKTRACK 
                }
            }

            return res;
        }

        private static void PrintSolution(int[,] board)
        {
            Console.Write($"{k++}-\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($" {board[i, j]} ");
                }

                Console.Write("\n");
            }
        }

        private static bool IsSafe(int[,] board, int row, int col)
        {
            int i, j;

            for (i = 0; i < col; i++)
            {
                if (board[row, i] == 1)
                {
                    return false;
                }
            }

            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            for (i = row, j = col; j >= 0 && i < n; i++, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}