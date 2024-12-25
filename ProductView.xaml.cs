using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();
        }

        public string ProductName
        {
            get { return (string)GetValue(ProductNameProperty); }
            set { SetValue(ProductNameProperty, value); }
        }
        public static readonly DependencyProperty ProductNameProperty =
            DependencyProperty.Register(nameof(ProductName), typeof(string), typeof(ProductView), new PropertyMetadata(string.Empty));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register(nameof(Description), typeof(string), typeof(ProductView), new PropertyMetadata(string.Empty));

        public string Manufacturer
        {
            get { return (string)GetValue(ManufacturerProperty); }
            set { SetValue(ManufacturerProperty, value); }
        }
        public static readonly DependencyProperty ManufacturerProperty =
            DependencyProperty.Register(nameof(Manufacturer), typeof(string), typeof(ProductView), new PropertyMetadata(string.Empty));

        public decimal Price
        {
            get { return (decimal)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register(nameof(Price), typeof(decimal), typeof(ProductView), new PropertyMetadata(0m));

        public int Stock
        {
            get { return (int)GetValue(StockProperty); }
            set { SetValue(StockProperty, value); }
        }
        public static readonly DependencyProperty StockProperty =
            DependencyProperty.Register(nameof(Stock), typeof(int), typeof(ProductView), new PropertyMetadata(0));

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }
        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register(nameof(ImagePath), typeof(string), typeof(ProductView), new PropertyMetadata(string.Empty));
    }
}
