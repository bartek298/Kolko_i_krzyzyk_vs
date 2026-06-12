namespace Kolko_i_krzyzyk
{
    public partial class Form1 : Form
    {
        private TicTacToeEngine gameEngine;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            GamePanel.Controls.Clear();//czyszczenie panelu, gdy jest nowa gra
            int n = (int)NumericSize.Value;//pobranie danych od uzytkownika
            int winLength = (int)NumericWinLength.Value;
            if (winLength > n)
            {
                MessageBox.Show("Liczba znakow do wygranej nie moze byc wieksza niz rozmiar planszy");
                return;
            }

            gameEngine = new TicTacToeEngine(n, winLength);//instancja silnika gry
            int availableWidth = GamePanel.Width;
            int availableHeight = GamePanel.Height;
            int buttonSize = Math.Min(availableWidth, availableHeight) / n;

            for (int row = 0; row < n; row++)//generowanie siatki n x n
            {
                for (int col = 0; col < n; col++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(buttonSize, buttonSize);
                    btn.Location = new Point(col * buttonSize, row * buttonSize);
                    btn.Font = new Font("Arial", buttonSize / 3, FontStyle.Bold);
                    btn.Text = "";

                    btn.Tag = new Point(row, col);//zapisanie wspolrzednych przycisku w jego wlasciwosci tag
                    btn.Click += BoardButton_Click;//akcja po kliknieciu pola na planszy
                    GamePanel.Controls.Add(btn);//dodanie przycisku do naszego panelu

                }
            }

        }
        private void BoardButton_Click(object sender, EventArgs e)
        {
            //jesli gra sie skonczyla lub silnik nie istnieje, ignorujemy kliki
            if (gameEngine == null || gameEngine.IsGameOver) return;
            Button clickedButton = (Button)sender;
            Point coordinates = (Point)clickedButton.Tag;
            int row = coordinates.X;
            int col = coordinates.Y;

            if (gameEngine.PlayerMove(row, col, "X"))
            {
                clickedButton.Text = "X";
                if (gameEngine.CheckWin("X"))
                {
                    MessageBox.Show("Wygrales, gratulacje!:)");
                    return;
                }
                if (gameEngine.CheckDraw())
                {
                    MessageBox.Show("remis");
                    return;
                }

                //ruch komputera- automatycznie po graczu
                Point compMove = gameEngine.GetComputerMove();
                if(compMove.X != -1)
                {
                    gameEngine.PlayerMove(compMove.X, compMove.Y, "O");

                    Button compButton = FindButtonByCoords(compMove.X, compMove.Y);
                    if(compButton != null)
                    {
                        compButton.Text = "O";
                    }
                    if (gameEngine.CheckWin("O"))
                    {
                        MessageBox.Show("Komputer wygral...");
                        return;
                    }
                    if (gameEngine.CheckDraw())
                    {
                        MessageBox.Show("remis");
                        return;
                    }
                }
            }
        }
        private Button FindButtonByCoords(int row,int col)
        {
            foreach(Control control in GamePanel.Controls)
            {
                if(control is Button btn && btn.Tag is Point pt && pt.X==row && pt.Y == col)
                {
                    return btn;
                }
            }
            return null;
        }
    }
}