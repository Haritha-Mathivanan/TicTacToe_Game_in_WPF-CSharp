using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tic_Tac_Toe_Game
{
    /// <summary>
    /// Interaction logic for GameBoard.xaml
    /// </summary>
    public partial class GameBoard : Window
    {
        //public GameBoard()
        //{
        //    InitializeComponent();
        //    Game_Restart();
        //}
        public GameBoard(MainWindow.PlayerType pt)
        {
            player = pt;
            InitializeComponent();
            Game_Restart();
            if (MainWindow.PlayerType.ONE == player)
            {
                player1 = "Player Wins  ";
                player2 = "AI Wins  ";
            }
            else 
            { 
                player1 = "Player One Wins  ";
                player2 = "Player Two Wins  ";
            }
        }
        private enum Player
        {
            X, O
        }
        Player currentplayer;
        Random random = new Random();
        int Player_1_Count = 0;
        int Player_2_Count = 0;
        List<Button> buttons;
        Boolean isplayerwin;
        string player1 = "";
        string player2 = "";
        MainWindow.PlayerType player;
        int count = 0;





        private void Restart_Game_Click(object sender, RoutedEventArgs e)
        {

            Game_Restart();
        }
        private void Player_Btn_Click(object sender, RoutedEventArgs e)
        {
            count++;                     
            Button btn = (Button)sender;
            if (MainWindow.PlayerType.ONE == player)
            {
                PlayerOneTurn(btn);      
                if (!isplayerwin) { AITurn(); }
            }
            else
            {
                if (count % 2 != 0)
                {
                    PlayerOneTurn(btn);
                }
                else
                {
                    PlayerTwoTurn(btn);
                }
            }

        }
        private void PlayerOneTurn(Button btn1)
        {
            currentplayer = Player.X;
            btn1.Content = currentplayer.ToString();
            btn1.IsEnabled = false;
            btn1.Foreground = Brushes.Violet;
            buttons.Remove(btn1);
            CheckGame();

        }
        


        private void Game_Restart()
        {
            buttons = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button button in buttons)
            {
                button.IsEnabled = true;
                button.Content = " ";
                button.Background = Brushes.White;
            }
            isplayerwin = false;
            count=0;

        }
        private void PlayerTwoTurn(Button btn2)
        {
          //  Button btn1 = (Button)sender;
            currentplayer = Player.O;
            btn2.Content = currentplayer.ToString();
            btn2.IsEnabled = false;
            btn2.Foreground = Brushes.DarkGoldenrod;
            buttons.Remove(btn2);
            CheckGame();
            
        }
        private void AITurn()
        {
            int index = 0;
            if (buttons.Count > 0)
            {
                index = random.Next(buttons.Count);
                currentplayer = Player.O;
                buttons[index].IsEnabled = false;
                buttons[index].Content = currentplayer.ToString();
                buttons[index].Background = Brushes.BurlyWood;
                buttons[index].Foreground = Brushes.DarkGoldenrod;
                buttons.RemoveAt(index);
                CheckGame();

            }
        }

        private void CheckGame()
        {

            if ((button1.Content.ToString() == "X" && button2.Content.ToString() == "X" && button3.Content.ToString() == "X")
                || (button4.Content.ToString() == "X" && button5.Content.ToString() == "X" && button6.Content.ToString() == "X")
                || (button7.Content.ToString() == "X" && button8.Content.ToString() == "X" && button9.Content.ToString() == "X")
                || (button1.Content.ToString() == "X" && button5.Content.ToString() == "X" && button9.Content.ToString() == "X")
                || (button1.Content.ToString() == "X" && button4.Content.ToString() == "X" && button7.Content.ToString() == "X")
                || (button2.Content.ToString() == "X" && button5.Content.ToString() == "X" && button8.Content.ToString() == "X")
                || (button3.Content.ToString() == "X" && button6.Content.ToString() == "X" && button9.Content.ToString() == "X")
                || (button3.Content.ToString() == "X" && button5.Content.ToString() == "X" && button7.Content.ToString() == "X"))
            {
                MessageBox.Show(player1);
                Player_1_Count++;
                Player_Wins.Content = player1 + Player_1_Count;
                AI_Wins.Content=player2 + Player_2_Count;
                isplayerwin = true;
                // Game_Restart();
            }
            else if ((button1.Content.ToString() == "O" && button2.Content.ToString() == "O" && button3.Content.ToString() == "O")
               || (button4.Content.ToString() == "O" && button5.Content.ToString() == "O" && button6.Content.ToString() == "O")
               || (button7.Content.ToString() == "O" && button8.Content.ToString() == "O" && button9.Content.ToString() == "O")
               || (button1.Content.ToString() == "O" && button5.Content.ToString() == "O" && button9.Content.ToString() == "O")
               || (button1.Content.ToString() == "O" && button4.Content.ToString() == "O" && button7.Content.ToString() == "O")
               || (button2.Content.ToString() == "O" && button5.Content.ToString() == "O" && button8.Content.ToString() == "O")
               || (button3.Content.ToString() == "O" && button6.Content.ToString() == "O" && button9.Content.ToString() == "O")
               || (button3.Content.ToString() == "O" && button5.Content.ToString() == "O" && button7.Content.ToString() == "O"))
            {
                MessageBox.Show(player2);
                Player_2_Count++;
                Player_Wins.Content = player1 + Player_1_Count;
                AI_Wins.Content = player2 + Player_2_Count;
                //  Game_Restart();
            }


        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ms = new MainWindow();
            ms.Show();
            this.Close();           
        }


    }
}
