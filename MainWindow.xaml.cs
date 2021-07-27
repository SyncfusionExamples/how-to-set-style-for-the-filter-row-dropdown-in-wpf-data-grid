using Syncfusion.Data.Extensions;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.RowFilter;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace SfDataGrid_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.dataGrid.RowGenerator = new CustomRowGenerator(this.dataGrid);
        }
    }

    public class GridFilterRowCellExt : GridFilterRowCell
    {

        public GridFilterRowCellExt()
            : base()
        { }

        /// <summary>
        /// Opens the FilterOptionPopup with the FilterOptionList.
        /// </summary>

        public override void OpenFilterOptionPopup()
        {
            base.OpenFilterOptionPopup();

            var styleListBox = new Style(typeof(ListBox));

            styleListBox.Setters.Add(new Setter
            {
                Property = BackgroundProperty,
                Value = Brushes.Black
            });

            styleListBox.Setters.Add(new Setter
            {
                Property = ForegroundProperty,
                Value = Brushes.White
            });

            this.FilterOptionsList.Style = styleListBox;
            
        }
    }

    public class CustomRowGenerator : RowGenerator
    {
        public CustomRowGenerator(SfDataGrid dataGrid)
            : base(dataGrid)
        {
        }

        /// <summary>
        /// Return the Custom FilterRowCell
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>GridCell</returns>

        protected override GridCell GetGridCell<T>()
        {

            //If the Cell is FilterRowCell return custom FilterRowCell

            if (typeof(T) == typeof(GridFilterRowCell))
                return new GridFilterRowCellExt();
            return base.GetGridCell<GridCell>();
        }
    }
}
