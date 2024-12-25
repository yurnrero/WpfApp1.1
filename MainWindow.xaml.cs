using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        
        private ObservableCollection<Product> _allProducts;

        
        private ObservableCollection<Product> _filteredProducts;

        public MainWindow()
        {
            InitializeComponent();

            
            _allProducts = new ObservableCollection<Product>
            {
                new Product { ProductName = "Ноутбук ASUS", Description = "Игровой ноутбук с RTX 3060", Manufacturer = "ASUS", Price = 129999, Stock = 15, ImagePath = "Images/laptop.png" },
                new Product { ProductName = "Смартфон Samsung", Description = "Флагманский смартфон S23 Ultra", Manufacturer = "Samsung", Price = 99999, Stock = 7, ImagePath = "Images/phone.png" },
                new Product { ProductName = "Телевизор LG", Description = "Крутой телевизор 4k", Manufacturer = "LG", Price = 99999, Stock = 2, ImagePath = "Images/tv.png" },
                new Product { ProductName = "Наушники Sony", Description = "Беспроводные наушники с шумоподавлением", Manufacturer = "Sony", Price = 7999, Stock = 30, ImagePath = "Images/headphones.png" },
                new Product { ProductName = "Мышь Logitech", Description = "Игровая мышь с подсветкой", Manufacturer = "Logitech", Price = 2499, Stock = 50, ImagePath = "Images/mouse.png" },
                new Product { ProductName = "Клавиатура Corsair", Description = "Механическая клавиатура с RGB подсветкой", Manufacturer = "Corsair", Price = 7999, Stock = 20, ImagePath = "Images/keyboard.png" },
                new Product { ProductName = "Планшет Apple", Description = "Планшет iPad Pro 12.9", Manufacturer = "Apple", Price = 84999, Stock = 12, ImagePath = "Images/ipad.png" }
            };

            
            _filteredProducts = new ObservableCollection<Product>(_allProducts);
            ProductList.ItemsSource = _filteredProducts;

            
            UpdateProductCount();
        }

        
        private void UpdateProductList()
        {
            var filtered = _allProducts.AsEnumerable();

            
            var selectedManufacturer = ManufacturerFilter.SelectedItem as ComboBoxItem;
            if (selectedManufacturer != null && selectedManufacturer.Content.ToString() != "Все производители")
            {
                filtered = filtered.Where(p => p.Manufacturer == selectedManufacturer.Content.ToString());
            }

            // Поиск в названии и описании
            var searchText = SearchTextBox.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                filtered = filtered.Where(p => p.ProductName.ToLower().Contains(searchText) || p.Description.ToLower().Contains(searchText));
            }

            // Сортировка
            var selectedSort = SortOptions.SelectedItem as ComboBoxItem;
            if (selectedSort != null)
            {
                switch (selectedSort.Content.ToString())
                {
                    case "По цене":
                        filtered = filtered.OrderBy(p => p.Price);
                        break;
                    case "По имени":
                        filtered = filtered.OrderBy(p => p.ProductName);
                        break;
                    case "По наличию":
                        filtered = filtered.OrderBy(p => p.Stock);
                        break;
                }
            }

            
            _filteredProducts = new ObservableCollection<Product>(filtered);
            ProductList.ItemsSource = _filteredProducts;

            
            UpdateProductCount();
        }

        
        private void UpdateProductCount()
        {
            ProductCount.Text = $"Показано товаров: {_filteredProducts.Count}";
        }

        
        private void ManufacturerFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProductList();
        }

        
        private void SortOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProductList();
        }

        
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProductList();
        }

        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Обработчик для добавления нового товара
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product
            {
                ProductName = "Новый товар",
                Description = "Описание нового товара",
                Manufacturer = "Новый производитель",
                Price = 1000,
                Stock = 10,
                ImagePath = "Images/default.png"
            };

            _allProducts.Add(newProduct);
            UpdateProductList();
        }
    }

    // Класс для товара
    public class Product
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
    }
}
