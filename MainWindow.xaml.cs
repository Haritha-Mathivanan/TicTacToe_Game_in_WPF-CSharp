using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tic_Tac_Toe_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
           
        }
        public enum PlayerType
        {
         ONE,
         TWO
        }
       

        private void Oneplayer_Click(object sender, RoutedEventArgs e)
        {
            GameBoard gameBoard = new GameBoard(PlayerType.ONE);
            gameBoard.Show();
            this.Close();
        }

        private void Twoplayer_Click(object sender, RoutedEventArgs e)
        {
            GameBoard gameBoard = new GameBoard(PlayerType.TWO);
            gameBoard.Show();
            this.Close();
        }

        private void Quit_Game_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }
    }
}
