using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CS_TicTacToeGame
{
    class Program
    {
        static void Main(String[] args)
        {
            int gameState = 0;
            int currentPlayer = -1;
            char[] marks = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            do
            {
                Console.Clear();
                currentPlayer = nextPlayer(currentPlayer);
                displayGreeting(currentPlayer);
                drawTheGameBoard(marks);
                gameRoot(marks, currentPlayer);
                gameState = checkWinner(marks);
            } while (gameState.Equals(0));
            Console.Clear();
            displayGreeting(currentPlayer);
            drawTheGameBoard(marks);
            string name;
            if (currentPlayer == 1)
                name = "HEMO";
            else
                name = "SMASM";
            if (gameState == 1)
                Console.WriteLine($"Player {name} is the winner, Congratulations <-->");
            else if (gameState == 2)
                Console.WriteLine($"the game is draw, no winner");
        }

        static int checkWinner(char[] marks)
        {
            if (isWinner(marks))
            {
                return 1;
            }

            if (isGameDraw(marks))
            {
                return 2;
            }

            return 0;
        }
        static bool isGameDraw(char[] marks)
        {
            return marks[0] != '1' && marks[1] != '2' && marks[2] != '3' && marks[3] != '4' && marks[4] != '5' && marks[5] != '6' && marks[6] != '7' && marks[7] != '8' && marks[8] != '9';
        }
        static bool isWinner(char[] marks)
        {
            if (isSame(marks, 0, 1, 2)) return true;
            else if (isSame(marks, 3, 4, 5)) return true;
            else if (isSame(marks, 6, 7, 8)) return true;
            else if (isSame(marks, 0, 4, 8)) return true;
            else if (isSame(marks, 2, 4, 6)) return true;
            else if (isSame(marks, 0, 3, 6)) return true;
            else if (isSame(marks, 2, 5, 8)) return true;
            else if (isSame(marks, 1, 4, 7)) return true;
            else return false;
        }

        static bool isSame(char[] testMarks,int pos1,int pos2,int pos3)
        {
            return testMarks[pos1].Equals(testMarks[pos2]) && testMarks[pos2].Equals(testMarks[pos3]);
        }
        static void gameRoot(char[] marks,int currentPlayer)
        {
            bool wrongMove = true;
            do
            {
                string input=Console.ReadLine();
                if( !string.IsNullOrEmpty(input) && ( input.Equals("1") || input.Equals("2") || input.Equals("3")
                 ||  input.Equals("4") || input.Equals("5") || input.Equals("6") || input.Equals("7") || input.Equals("8") || input.Equals("9") )
                    )
                {
                    int.TryParse(input, out var gamePlacementMarker);
                    char currentMarker = marks[gamePlacementMarker - 1];
                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Place has already a marker please select anotyher placement.");
                    }
                    else
                    {
                        marks[gamePlacementMarker - 1] = playerMark(currentPlayer);

                        wrongMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong value please select another place.");
                }

            }while(wrongMove);
        }
        static char playerMark(int player)
        {
            if (player % 2 == 0)
                return 'O';
            else
                return 'X';

        }
        static void displayGreeting(int player)
        {
            Console.WriteLine("       *********************************************************");
            Console.WriteLine("                          Hello everyone                                ");
            Console.WriteLine("       *********************************************************");
            Console.WriteLine();
            Console.WriteLine("                  Welcome to the Tic Tac Toe game                       ");
            Console.WriteLine("             *****************************************");
            Console.WriteLine();
            Console.WriteLine("  HEMO: X");
            Console.WriteLine("  SMASM: O");
            Console.WriteLine();
            string name;
            if (player == 1)
                name = "HEMO";
            else
                name = "SMASM";
            Console.WriteLine($"  Player {name} to move, select 1 thorugh 9 from the game board.");
            Console.WriteLine();
        }
        static void drawTheGameBoard(char [] marks)
        {
            Console.WriteLine($"  {marks[0]} | {marks[1]} | {marks[2]} ");
            Console.WriteLine(" ---+---+---");
            Console.WriteLine($"  {marks[3]} | {marks[4]} | {marks[5]} ");
            Console.WriteLine(" ---+---+---");
            Console.WriteLine($"  {marks[6]} | {marks[7]} | {marks[8]} ");
        }
        static int nextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }

            return 1;
        }
    }
    
}
