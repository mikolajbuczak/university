namespace Programowanie
{
    public partial class DaneWindow : System.Windows.Window
    {
        private System.Collections.Generic.List<Number> numbersToDataGrid = new System.Collections.Generic.List<Number>();
        private System.Collections.Generic.List<double> numbers;

        public DaneWindow()
        {
            InitializeComponent();
        }

        private void OpenBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Text File|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                numbers = Dane.POBIERZ(openFileDialog.FileName);
                UpdateDataDrid();
                DataGrid.ItemsSource = numbersToDataGrid;
                if(numbers.Count == 0)
                {
                    System.Windows.MessageBox.Show("Brak prawidłowych danych do wczytania!", "Brak danych");
                    return;
                }

                SaveBtn.IsEnabled = true;
                MethodsList.IsEnabled = true;
                MethodsList.SelectedIndex = 0;
                DataGrid.IsEnabled = true;
                SetBtn.IsEnabled = true;
            }           
        }

        private void SaveBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Text File|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                string textToSave = "";

                foreach(double n in numbers)
                {
                    textToSave += n.ToString() + '\n';
                }

                System.IO.File.WriteAllText(saveFileDialog.FileName, textToSave);
            }              
        }

        private void SetBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (MethodsList.SelectedIndex)
            {
                case 0:
                    Dane.TASUJ(ref numbers);
                    UpdateDataDrid();
                    break;
                case 1:
                    Dane.MINMAX(ref numbers);
                    UpdateDataDrid();
                    break;
                case 2:
                    Dane.MEAN(ref numbers);
                    UpdateDataDrid();
                    break;
                case 3:
                    Dane.STANDARD(ref numbers);
                    UpdateDataDrid();
                    break;
            }
        }

        private void UpdateDataDrid()
        {
            numbersToDataGrid.Clear();
            for (int i = 0; i < numbers.Count; i++)
                numbersToDataGrid.Add( new Number { number = numbers[i] } );
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = numbersToDataGrid;
        }
    }
}
