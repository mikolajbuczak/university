namespace Football_Team
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Controls;
    using System.Globalization;
    using System.ComponentModel;
    using System.Collections.Generic;
    public partial class MainWindow : Window
    {
        private List<Player> team = new List<Player>();
        private readonly int minAge = 15;
        private readonly int maxAge = 55;
        private readonly string defaultName = "Podaj imię";
        private readonly string defaultLastName = "Podaj nazwisko";

        private readonly string teamDataFile = Path.Combine(Environment.CurrentDirectory, @"team.txt");

        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBox();
            CheckSaveFile();
            LoadTeam();
        }

        #region onLoad
        private void InitializeComboBox()
        {
            for (int i = minAge; i <= maxAge; i++)
                Age_cb.Items.Add(i);
        }

        private void CheckSaveFile()
        {
            if (!File.Exists(teamDataFile))
            {
                FileStream fs = File.Create(teamDataFile);
                fs.Close();
            }
        }

        private void LoadTeam()
        {
            string[] playersData = File.ReadAllLines(teamDataFile);
            if (playersData.Length < 4)
                AddDefaultTeam();
            else
                LoadTeamFromData(ref playersData);
            UpdateTeam();
        }

        private void AddDefaultTeam()
        {
            team.Add(new Player("Adrian", "Kapczyński", 44, 80.0));
            team.Add(new Player("Jarosław", "Karcewicz", 44, 75.5));
            team.Add(new Player("Zbigniew", "Marszałek", 55, 92.3));
        }

        private void LoadTeamFromData(ref string[] data)
        {
            for (int i = 0; i < data.Length; i += 4)
            {
                string name = data[i];
                string lastName = data[i + 1];
                bool isAgeCorrect = Int32.TryParse(data[i + 2], out int age);
                bool isWeightCorrect = Double.TryParse(data[i + 3], out double weight);
                if (name != String.Empty && lastName != String.Empty && isAgeCorrect && isWeightCorrect)
                    team.Add(new Player(name, lastName, age, weight));
            }
        }
        #endregion

        #region TextBox
        #region NameTextBox
        private void Name_tb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == defaultName)
                ClearTextBox(ref tb);
        }

        private void Name_tb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == String.Empty)
                ResetTextBox(ref tb, defaultName);
        }
        #endregion

        #region LastNameTextBox
        private void LastName_tb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == defaultLastName)
                ClearTextBox(ref tb);
        }

        private void LastName_tb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == String.Empty)
                ResetTextBox(ref tb, defaultLastName);
        }
        #endregion

        private void ClearTextBox(ref TextBox textBox)
        {
            textBox.Text = String.Empty;
            textBox.Foreground = Brushes.Black;
        }

        private void ResetTextBox(ref TextBox textBox, string defaultValue)
        {
            textBox.Text = defaultValue;
            textBox.Foreground = Brushes.Gray;
        }

        private void SetTextBox(ref TextBox textBox, string text)
        {
            textBox.Text = text;
            textBox.Foreground = Brushes.Black;
        }
        #endregion

        #region Slider
        private void Weight_s_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Weight_s.IsLoaded)
                Weight_l.Content = e.NewValue.ToString("0.0", CultureInfo.GetCultureInfo("pl-PL")) + " kg";
        }

        private void ResetSlider(ref Slider slider)
        {
            slider.Value = slider.Minimum;
        }

        private void SetSlider(ref Slider slider, double value)
        {
            if (slider.Minimum > value || value > slider.Maximum) return;
            slider.Value = value;
        }
        #endregion

        #region ComboBox
        private void ResetComboBox(ref ComboBox comboBox)
        {
            comboBox.SelectedIndex = 0;
        }

        private void SetComboBox(ref ComboBox comboBox, int index)
        {
            if (index < 0 || index > comboBox.Items.Count) return;
            comboBox.SelectedIndex = index;
        }
        #endregion

        #region Button
        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Name_tb.Text == String.Empty || Name_tb.Text == defaultName)
            {
                Name_tb.BorderThickness = new Thickness(3, 3, 3, 3);
                Name_tb.BorderBrush = Brushes.Red;
                Name_tb.ToolTip = "Wprowadź imię!";
                return;
            }
            if (LastName_tb.Text == String.Empty || LastName_tb.Text == defaultLastName)
            {
                LastName_tb.BorderThickness = new Thickness(3, 3, 3, 3);
                LastName_tb.BorderBrush = Brushes.Red;
                LastName_tb.ToolTip = "Wprowadź nazwisko!";
                return;
            }
            AddNewPlayer(Name_tb.Text, LastName_tb.Text, Age_cb.SelectedIndex + minAge, Weight_s.Value);
            UpdateTeam();
            ResetControls();
        }

        private void Modify_btn_Click(object sender, RoutedEventArgs e)
        {
            team[Team_lb.SelectedIndex].Update(Name_tb.Text, LastName_tb.Text, minAge + Age_cb.SelectedIndex, Weight_s.Value);
            Modify_btn.IsEnabled = false;
            UpdateTeam();
            ResetControls();
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            DeletePlayer(Team_lb.SelectedIndex);
            UpdateTeam();
            ResetControls();
        }
        #endregion

        #region ButtonsLogic
        private void AddNewPlayer(string name, string lastName, int age, double weight)
        {
            team.Add(new Player(name, lastName, age, weight));
        }

        private void SetPlayerInfoToControls(Player player)
        {
            SetTextBox(ref Name_tb, player.Name);
            SetTextBox(ref LastName_tb, player.LastName);
            SetComboBox(ref Age_cb, player.Age - minAge);
            SetSlider(ref Weight_s, player.Weight);
        }

        private void DeletePlayer(int index)
        {
            team.RemoveAt(index);
            for (int i = index + 1; i < team.Count; i++)
            {
                team[i - 1] = team[i];
            }
        }
        #endregion

        private void UpdateTeam()
        {
            Team_lb.ItemsSource = null;
            Team_lb.ItemsSource = team;
        }

        private void ResetControls()
        {
            ResetTextBox(ref Name_tb, defaultName);
            ResetTextBox(ref LastName_tb, defaultLastName);
            ResetSlider(ref Weight_s);
            ResetComboBox(ref Age_cb);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            using (StreamWriter file = new StreamWriter(teamDataFile))
            {
                foreach (Player player in team)
                {
                    file.WriteLine(player.Name);
                    file.WriteLine(player.LastName);
                    file.WriteLine(player.Age);
                    file.WriteLine(player.Weight);
                }
            }
        }

        private void ListBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int index = Team_lb.SelectedIndex;
            if (index == -1) return;
            SetPlayerInfoToControls(team[index]);
            Modify_btn.IsEnabled = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BorderThickness = new Thickness(1, 1, 1, 1);
            tb.BorderBrush = Brushes.Black;
            tb.ToolTip = null;
        }
    }
}
