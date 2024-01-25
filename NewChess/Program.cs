
using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;


List<DrawCHessBoardRequestModel> request = new List<DrawCHessBoardRequestModel>();
do
{
    request.Add(InputFiveCoordinates.Input(request));
}
while (request.Count < 5);

DrawBoardWithFivePiece.Drawer(request);




public class DrawCHessBoardRequestModel
{
    public char letter = '0';
    public int num = 0;
    public string figure;
    public string color;
}


public class InputFiveCoordinates
{
    public static DrawCHessBoardRequestModel Input(List<DrawCHessBoardRequestModel> request)
    {

        bool[,] chessBoard = new bool[8, 8];
        for (int i = 0; i <= request.Count(); i++)
        {
            Console.WriteLine("Enter a chess figure (two black R, Black King K, Queen Q, and White King ` W" +
                "");
            string figure = Console.ReadLine();
            switch (figure.ToUpper())
            {
                case "R":
                case "K":
                case "Q":
                case "W":

                    Console.WriteLine("Enter the coordinates(e.g., A1):");
                    string input = Console.ReadLine();


                    char letter = input[0];
                    if (int.TryParse(input.Substring(1), out int num))
                    {
                        switch (char.ToUpper(letter))
                        {
                            case 'A':
                            case 'B':
                            case 'C':
                            case 'D':
                            case 'E':
                            case 'F':
                            case 'G':
                            case 'H':
                                if (request.Count() == 0)
                                {
                                    return (new DrawCHessBoardRequestModel
                                    {
                                        letter = letter,
                                        num = num,
                                        figure = figure,
                                        color = "Black"

                                    });
                                }
                                if (num >= 1 && num <= 8)
                                {
                                    if (request[i].letter == letter && request[i].num == num)
                                    {
                                        Console.WriteLine("The coordinate is already contain figure");
                                        Thread.Sleep(3000);
                                        Console.Clear();
                                        Input(request);
                                    }

                                    Console.WriteLine($"{figure} input coordinate is: {letter}{num}");
                                    if (figure == "W")
                                    {
                                        List<DrawCHessBoardRequestModel> listOfRook = request.Where(x => x.figure == "R").ToList();
                                        foreach (var req in listOfRook)
                                        {
                                            if (req.letter == letter || req.num == num)
                                            {
                                                Console.WriteLine("You can't input here White King");
                                                Thread.Sleep(3000);
                                                Console.Clear();
                                                Input(request);
                                            }
                                        }
                                        List<DrawCHessBoardRequestModel> listOfKing = request.Where(x => x.figure == "K").ToList();
                                        foreach (var req in listOfKing)
                                        {
                                            if ((req.letter == letter - 1 && req.num == num) ||
                                                (req.letter == letter - 1 && req.num == num - 1) ||
                                                (req.letter == letter - 1 && req.num == num + 1) ||
                                                (req.letter == letter + 1 && req.num == num + 1) ||
                                                (req.letter == letter + 1 && req.num == num) ||
                                                (req.letter == letter + 1 && req.num == num - 1) ||
                                                (req.letter == letter && req.num == num + 1) ||
                                                (req.letter == letter && req.num == num - 1))
                                            {
                                                Console.WriteLine("You can't input here White King");
                                                Thread.Sleep(3000);
                                                Console.Clear();
                                                Input(request);
                                            }
                                        }
                                        return (new DrawCHessBoardRequestModel
                                        {
                                            letter = letter,
                                            num = num,
                                            figure = figure,
                                            color = "White"

                                        });
                                    }
                                    else
                                    {
                                        return (new DrawCHessBoardRequestModel
                                        {
                                            letter = letter,
                                            num = num,
                                            figure = figure,
                                            color = "Black"

                                        });
                                    }

                                    //if (request.Count == )
                                    //{
                                    //    DrawBoardWithFivePiece.Drawer(request);
                                    //}
                                }
                                else
                                {
                                    Console.WriteLine("Invalid rank.Please enter a rank between 1 and 8");
                                    Console.Clear();
                                    Console.WriteLine("Please Enter coordinates again");
                                    Input(request);
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid file.Please Enter a file between A and H.");
                                Console.Clear();
                                Console.WriteLine("Please Enter coordinates again");
                                Input(request);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input format. Please enter coordinates in the format A1.");
                        Console.Clear();
                        Console.WriteLine("Please Enter coordinates again");
                        Input(request);
                    }

                    break;
                default:
                    Console.WriteLine("You entered wrong piece, please input R,K or Q");
                    Thread.Sleep(3000);
                    Console.Clear();
                    Input(request);
                    break;
            }
        }
        return default;
    }

}



public class DrawBoardWithFivePiece
{
    public static void Drawer(List<DrawCHessBoardRequestModel> request)
    {
        Console.WriteLine("   A B C D E F G H");
        for (int row = 8; row >= 1; row--)
        {
            Console.Write(row + "|");

            for (char col = 'A'; col <= 'H'; col++)

            {
                bool mustPrint = false;
                string figure = "";
                string color = "";
                for (int i = 0; i < request.Count; i++)
                {
                    if (row == request[i].num && col == char.ToUpper(request[i].letter))
                    {
                        mustPrint = true;
                        figure = request[i].figure;
                        color = request[i].color;
                    };
                }
                if (mustPrint)
                {
                    if ((row + col) % 2 == 0)
                    {
                        if (color == "Black")
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" " + figure);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" " + figure);
                            Console.ResetColor();
                        }

                    }
                    else
                    {
                        if (color == "Black")
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" " + figure);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" " + figure);
                            Console.ResetColor();
                        }
                    }
                }
                else
                {
                    if ((row + col) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    Console.Write("  ");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("|" + row);

        }
        Console.WriteLine("  " +
            " A B C D E F G H");
    }
}



