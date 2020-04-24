using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MindOne.Geographics.Controls
{
    public partial class Legend : UserControl
    {
        public Legend()
        {
            InitializeComponent();
        }
        public void SetLegend(string title, string unit, Color[] colors, string[] names)
        {
            titleLabel.Content = title;
            unitLabel .Content = unit;

            colorsGrid.Children.Clear();

            colorsGrid.ColumnDefinitions.Clear();
            colorsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(10) });
            colorsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

            colorsGrid.RowDefinitions.Clear();
            for (int i = 0; i < colors.Length; i++)
            {
                colorsGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20) });

                var color     = colors[i];
                var rectangle = new Rectangle { Fill = new SolidColorBrush(color) };
                Grid.SetColumn(rectangle, 0);
                Grid.SetRow   (rectangle, i);
                colorsGrid.Children.Add(rectangle);
            }
            for (int i = 0; i < names.Length; i++)
            {
                var name      = names[i];
                var label     = new Label { Content = name };
                Grid.SetColumn(label, 1);
                Grid.SetRow   (label, i);
                colorsGrid.Children.Add(label);
            }
        }
    }
}
