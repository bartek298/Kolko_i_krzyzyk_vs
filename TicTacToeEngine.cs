using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Kolko_i_krzyzyk
{
    public class TicTacToeEngine
    {
        private string[,] board;//tablica przechowujaca stan gry:
        private int size;
        private int winLength;
        public bool IsGameOver { get; private set; }
        public TicTacToeEngine(int size,int winLength)
        {
            this.size = size;
            this.winLength = winLength;
            this.board = new string[size, size];
            this.IsGameOver = false;

            for (int r = 0; r < size; r++)
                for (int c = 0; c < size; c++)
                    board[r, c] = "";
        }
        //zwraca true jesli ruch byl poprawny
        public bool PlayerMove(int row,int col,string player)
        {
            if (IsGameOver || board[row, col] != "")
                return false;

            board[row, col] = player;
            return true;
        }
        //sprawdza czy po danym ruchu ktos wygral
        public bool CheckWin(string player)
        {
            //przeszukanie calej planszy w poszukiwaniu sekwencji o dlugosci winLength
            for(int r = 0; r < size; r++)
            {
                for(int c = 0; c < size; c++)
                {
                    if (board[r, c] == player)
                    {
                        //sprawdzamy 4 kierunki:prawo,dol,ukos w dol prawo, ukos w dol lewo
                        if(CheckDirection(r,c,0,1,player)||//poziomo
                            CheckDirection(r,c,1,0,player)||//pionowo
                            CheckDirection(r,c,1,1,player)||//ukos \
                            CheckDirection(r, c, 1, -1, player))//ukos /
                        {
                            IsGameOver = true;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool CheckDirection(int startRow,int startCol,int dRow, int dCol, string player)
        {
            int count = 0;
            int r = startRow;
            int c = startCol;
            //liczymy ile znakow pod rzad pasuje do gracza w danym kierunku
            while (r>=0 && r<size && c>=0 && c<size && board[r, c] == player)
            {
                count++;
                if (count == winLength) return true;
                r += dRow;
                c += dCol;
            }
            return false;
        }
        public bool CheckDraw()
        {
            for (int r = 0; r < size; r++)
                for (int c = 0; c < size; c++)
                    if (board[r, c] == "") return false;//jest jeszcze wolne miejsce
            IsGameOver = true;
            return true;
        }
        public Point GetComputerMove()//AI
        {
            int bestScore = int.MinValue;
            Point bestMove = new Point(-1, -1);
            //maksymalna glebokosc, dla 3x3 mozemy sprawdzic cale drzewo, dla wiekszych ograniczamy
            int maxDepth = (size <= 3) ? 9 : 4;
            for(int r = 0; r < size; r++)
            {
                for(int c = 0; c < size; c++)
                {
                    if (board[r, c] == "")
                    {
                        //symulacja ruchu komputera
                        board[r, c] = "O";
                        //wywolanie minMax dla gracza(minimalizacja)
                        int score = MinMax(0, false, int.MinValue, int.MaxValue, maxDepth);
                        //cofniecie ruchu
                        board[r, c] = "";

                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = new Point(r, c);
                        }
                    }
                }
            }
            return bestMove;
        }
        //algorytm minmax z alfabeta
        private int MinMax(int depth,bool isMaximizing,int alpha,int beta,int maxDepth)
        {
            //sprawdzenie warunkow koncowych
            if (CheckWinInternal("O")) return 1000 - depth;//komputer woli wygrac szybciej
            if (CheckWinInternal("X")) return -1000 + depth;//komputer woli przegrac pozniej
            if(CheckDrawInternal()|| depth >= maxDepth)
            {
                return EvaluateBoard();//jesli koniec albo limit glebokosci, to oceniamy stan planszy heurystycznie
            }
            //maksymalizacja-ruch komputera
            if (isMaximizing)
            {
                int maxEval = int.MinValue;
                for(int r = 0; r < size; r++)
                {
                    for(int c = 0; c < size; c++)
                    {
                        if (board[r, c] == "")
                        {
                            board[r, c] = "O";
                            int eval = MinMax(depth + 1, false, alpha, beta, maxDepth);
                            board[r, c] = "";

                            maxEval = Math.Max(maxEval, eval);
                            alpha = Math.Max(alpha, eval);

                            if (beta <= alpha) break;//odcinamy alfabeta
                        }
                    }
                    if (beta <= alpha) break;
                }
                return maxEval;
            }
            //minimalizacja ruch gracza
            else
            {
                int minEval = int.MaxValue;
                for(int r = 0; r < size; r++)
                {
                    for(int c = 0; c < size; c++)
                    {
                        if (board[r, c] == "")
                        {
                            board[r, c] = "X";
                            int eval = MinMax(depth + 1, true, alpha, beta, maxDepth);
                            board[r, c] = "";

                            minEval = Math.Min(minEval, eval);
                            beta = Math.Min(beta, eval);

                            if (beta <= alpha) break;
                        }
                    }
                    if (beta <= alpha) break;
                }
                return minEval;
            }
        }
        //heurystyka klucz do oceny wyzszych wymiarow planszy
        private int EvaluateBoard()
        {
            int score = 0;
            return score;
        }
        //pomocnicze metody dzialajace na tablicy bez modyfikowania stanu IsGameOver gry
        private bool CheckWinInternal(string player)
        {
            for(int r = 0; r < size; r++)
                for(int c = 0; c < size; c++)
                    if (board[r, c] == player)
                        if (CheckDirection(r, c, 0, 1, player) || CheckDirection(r, c, 1, 0, player) ||
                            CheckDirection(r, c, 1, 1, player) || CheckDirection(r, c, 1, -1, player))
                            return true;
            return false;
                
            
        }
        private bool CheckDrawInternal()
        {
            for (int r = 0; r < size; r++)
                for (int c = 0; c < size; c++)
                    if (board[r, c] == "") return false;
            return true;
        }
    }
}
