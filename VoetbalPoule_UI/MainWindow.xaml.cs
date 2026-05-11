using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VoetbalPoule_Business;

namespace VoetbalPoule_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller _controller;
        public MainWindow()
        {
            //velden
            InitializeComponent();
            _controller = new Controller();
            FillListOfTeams();

            

        }

        private void btnAddTeam_Click(object sender, RoutedEventArgs e)
        {
            string name = TxtTeamName?.Text?.Trim();
            string city = TxtTeamCity?.Text?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a team name.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                _controller.AddTeam(name, city);


                var names = _controller.GetTeamsName();

                LstTeams.ItemsSource = null;
                LstTeams.ItemsSource = names;

                CmbHome.ItemsSource = null;
                CmbHome.ItemsSource = names;

                CmbAway.ItemsSource = null;
                CmbAway.ItemsSource = names;

                TxtTeamName.Clear();
                TxtTeamCity.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add team: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            {
                string home = CmbHome?.SelectedItem as string;
                string away = CmbAway?.SelectedItem as string;
            }
        }

        private void FillListOfTeams()
        {
            List<string>teamnames = _controller.GetTeamsName();
            
            LstTeams.ItemsSource = teamnames;
            LstTeams.Items.Refresh();
            LstTeams.ItemsSource = teamnames;
            LstTeams.Items.Refresh();
            CmbHome.ItemsSource = teamnames;
            LstTeams.Items.Refresh();
            dgrStandings.ItemsSource = _controller.GetStandings();
            dgrStandings.Items.Refresh();   
        }
    }
}