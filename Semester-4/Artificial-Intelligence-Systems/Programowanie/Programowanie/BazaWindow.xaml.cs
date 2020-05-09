namespace Programowanie
{

    public partial class BazaWindow : System.Windows.Window
    {
        private System.Collections.Generic.List<Name> namesToDataGrid = new System.Collections.Generic.List<Name>();
        private System.Collections.Generic.List<string> names;



        public BazaWindow()
        {
            InitializeComponent();
        }

        private void LoadBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
            openFileDialog1.Filter = "DataBase File|*.accdb";
            if (openFileDialog1.ShowDialog() == true)
            {
                names = Baza.ReadOrderData(openFileDialog1.FileName);
                UpdateDataDrid();
                BaseDataGrid.ItemsSource = namesToDataGrid;

                if (names.Count == 0)
                {
                    System.Windows.MessageBox.Show("Brak prawidłowych danych do wczytania!", "Brak danych");
                    return;
                }
            }
        }
        private void UpdateDataDrid()
        {
            namesToDataGrid.Clear();
            for (int i = 0; i < names.Count; i++)
                namesToDataGrid.Add(new Name { name = names[i] });
            BaseDataGrid.ItemsSource = null;
            BaseDataGrid.ItemsSource = namesToDataGrid;
        }
    }

}
