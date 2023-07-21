using System;

namespace Exercicio1
{
    class Program
    {

        static void PrintBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }

        }

        static int checkValidationsEntries(string inputvalue)
        {
            int intValue;
            while (string.IsNullOrWhiteSpace(inputvalue) || !int.TryParse(inputvalue, out intValue) || intValue <= 0 || intValue > 4)
            {
                if (string.IsNullOrWhiteSpace(inputvalue))
                {
                    Console.WriteLine("Entrada inválida. Não pode conter espaço vazio ou nulo.");
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, preencher apenas com número entre 1 e 3.");
                }

                inputvalue = Console.ReadLine();
            }
            int validInput = int.Parse(inputvalue);
            return validInput;

        }

        static void Player1Play(char[,] board, int line, int column)
        {
            while (board[line - 1, column - 1] != '-')
            {
                Console.WriteLine("Tente novamente! Essa posição já está ocupada");
                Console.WriteLine("Escolha um número entre 1 e 3 para a linha:");
                line = checkValidationsEntries(Console.ReadLine());
                Console.WriteLine("Escolha um número entre 1 e 3 para a coluna:");
                column = checkValidationsEntries(Console.ReadLine());
            }

            board[line - 1, column - 1] = 'X';
        }

        static void Player2Play(char[,] board, int line, int column)
        {
            while (board[line - 1, column - 1] != '-')
            {
                Console.WriteLine("Tente novamente! Essa posição já está ocupada");
                Console.WriteLine("Escolha um número entre 1 e 3 para a linha:");
                line = checkValidationsEntries(Console.ReadLine());
                Console.WriteLine("Escolha um número entre 1 e 3 para a coluna:");
                column = checkValidationsEntries(Console.ReadLine());
            }

            board[line - 1, column - 1] = 'O';
        }


        static bool VictoryCheck(char[,] board, char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||
                    (board[0, i] == player && board[1, i] == player && board[2, i] == player))
                {
                    return true;
                }
            }

            if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
                (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
            {
                return true;
            }

            return false;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Olá! Vamos jogar o jogo da velha? ");

            char[,] board = new char[3, 3];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = '-';
                }
            }
            PrintBoard(board);

            for (int turn = 0; turn < 9; turn++)
            {
                Console.WriteLine($"Faça uma jogada: (Turno {turn + 1})");
                Console.WriteLine("Escolha um número entre 1 e 3 para a linha:");
                int inputLine = checkValidationsEntries(Console.ReadLine());
                Console.WriteLine("Escolha um número entre 1 e 3 para a coluna:");
                int inputColumn = checkValidationsEntries(Console.ReadLine());

                if (turn % 2 == 0)
                {
                    Player1Play(board, inputLine, inputColumn);
                    PrintBoard(board);
                    if (VictoryCheck(board, 'X'))
                    {
                        Console.WriteLine("Jogador 1 é o Vencedor");
                        break;
                    }
                }
                else
                {
                    Player2Play(board, inputLine, inputColumn);
                    PrintBoard(board);
                    if (VictoryCheck(board, 'O'))
                    {
                        Console.WriteLine("Jogador 2 é o Vencedor");
                        break;
                    }
                }
            }
            Console.WriteLine("O jogo terminou!");
        }
    }
}
