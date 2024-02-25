using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Engine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameSession _gameSession;
        public MainWindow()
        {
            InitializeComponent();
            _gameSession = new GameSession();
            DataContext = _gameSession;
        }
        private void OnClick_MoveNorth(object sender, EventArgs e)
        {
            _gameSession.MoveNorth();
        }
        private void OnClick_MoveWest(object sender, EventArgs e)
        {
            _gameSession.MoveWest();
        }
        private void OnClick_MoveEast(object sender, EventArgs e)
        {
            _gameSession.MoveEast();
        }
        private void OnClick_MoveSouth(object sender, EventArgs e)
        {
            _gameSession.MoveSouth();
        }

    }
}
