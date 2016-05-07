using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HearthDb;
using HearthDb.Enums;
using MahApps.Metro;

namespace Hearthstone_Helper
{
    class Card
    {
        public HearthDb.Card Data = null;

        public int Count { get; set; } = 1;
        public int Cost { get; set; }
        public string LocalizedName { get; set; }
        public Card(string cardId)
        {
            HearthDb.Card dbCard;
            if (Cards.All.TryGetValue(cardId, out dbCard))
                Data = dbCard;
            Debug.WriteLine("Could not find card with ID=" + cardId);
        }
        public Card(HearthDb.Card card)
        {
            Data = card;
            Cost = card.Cost;
            LocalizedName = card.GetLocName(Language.zhCN);
        }
        public ImageBrush Background
        {
            get
            {
                if (Data.Id == null || Data.Name == null)
                    return new ImageBrush();
                try
                {
                    var group = new DrawingGroup();
                    var barImagePath = Path.Combine("Images/Bars", Data.Id + ".png");
                    var frameImagePath = Path.Combine("Images/Bars", "frame.png");
                    if (File.Exists(barImagePath))
                    {
                        group.Children.Add(new ImageDrawing(new BitmapImage(new Uri(barImagePath, UriKind.Relative)), new Rect(83, 0, 134, 34)));
                    }
                    group.Children.Add(new ImageDrawing(new BitmapImage(new Uri(frameImagePath, UriKind.Relative)), new Rect(0, 0, 217, 34)));
                    return new ImageBrush { ImageSource = new DrawingImage(group) };
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Image builder failed: {ex.Message}");
                    return new ImageBrush();
                }
            }
        }
    }
}
