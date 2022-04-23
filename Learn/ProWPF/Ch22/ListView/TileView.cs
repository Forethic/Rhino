using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProWPF.Ch22
{
    public class TileView : ViewBase
    {
        private DataTemplate _itemTemplate;
        public DataTemplate ItemTemplate
        {
            get => _itemTemplate;
            set => _itemTemplate = value;
        }

        private Brush _selectedBackground = Brushes.Transparent;
        public Brush SelectedBackground
        {
            get => _selectedBackground;
            set => _selectedBackground = value;
        }

        private Brush _selectedBorderBrush = Brushes.Black;
        public Brush SelectedBorderBrush
        {
            get => _selectedBorderBrush;
            set => _selectedBorderBrush = value;
        }

        protected override object DefaultStyleKey => new ComponentResourceKey(GetType(), "TileView");
        protected override object ItemContainerDefaultStyleKey => new ComponentResourceKey(GetType(), "TileViewItem");
    }
}
