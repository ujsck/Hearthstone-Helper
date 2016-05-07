using System.Collections.Generic;
using MahApps.Metro.Controls;

namespace Hearthstone_Helper
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private List<Card> cardDb = new List<Card>();
        public MainWindow()
        {
            InitializeComponent();
            LoadCardList();
        }

        public void LoadCardList()
        {
            foreach (var card in HearthDb.Cards.All.Values)
            {
                cardDb.Add(new Card(card));
                ListViewDB.Items.Add(new Card(card));
            }
        }
    }
}
