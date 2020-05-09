namespace Programowanie
{
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DaneBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DaneWindow daneWindow = new DaneWindow();
            daneWindow.Closing += ChildWindowClosing;
            daneWindow.Show();
            this.Hide();
        }

        private void GrafikaBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GrafikaWindow grafikaWindow = new GrafikaWindow();
            grafikaWindow.Closing += ChildWindowClosing;
            grafikaWindow.Show();
            this.Hide();
        }

        private void BazaBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BazaWindow bazaWindow = new BazaWindow();
            bazaWindow.Closing += ChildWindowClosing;
            bazaWindow.Show();
            this.Hide();
        }

        private void ChildWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Show();
        }
    }
}
