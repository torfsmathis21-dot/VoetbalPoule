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
            btnRegisterResult.IsEnabled = false;
            TxtHomeScore.IsEnabled = false;
            TxtAwayScore.IsEnabled = false;



        }

        private void btnAddTeam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _controller.AddTeam(TxtTeamName.Text, TxtTeamCity.Text);

                TxtTeamName.Clear();
                TxtTeamCity.Clear();

                FillListOfTeams();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            CmbAway.ItemsSource = teamnames;
            LstTeams.Items.Refresh();
            dgrStandings.ItemsSource = _controller.GetStandings();
            dgrStandings.Items.Refresh();   
        }

        private void btnRegisterResult_Click(object sender, RoutedEventArgs e)
        {
            if (CmbHome.SelectedItem == null || CmbAway.SelectedItem == null)
            {
                MessageBox.Show("Please select both home and away teams.");
                return;
            }

            if (CmbHome.SelectedItem.ToString() == CmbAway.SelectedItem.ToString())
            {
                MessageBox.Show("Same team selected. Please select two different teams.");
                return;
            }

            try
            {
                if (!int.TryParse(TxtHomeScore.Text, out int homeScore) ||
                !int.TryParse(TxtAwayScore.Text, out int awayScore))
                {
                    MessageBox.Show("Please enter valid numbers for the scores.");
                    return;
                }

                if (homeScore > 150 || awayScore > 150)
                {
                    MessageBox.Show("The maximum score is 150.");
                    return;
                }

                _controller.RegisterResult(
                    CmbHome.SelectedItem.ToString(),
                    CmbAway.SelectedItem.ToString(),
                    homeScore,
                    awayScore
                );

                dgrStandings.ItemsSource = _controller.GetStandings();

                CmbHome.SelectedItem = null;
                CmbAway.SelectedItem = null;
                TxtHomeScore.Clear();
                TxtAwayScore.Clear();

                
                TxtHomeScore.IsEnabled = false;
                TxtAwayScore.IsEnabled = false;

                MessageBox.Show("Successfully registered");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for the scores.");
            }
            catch (OverflowException)
            {
                MessageBox.Show("The scores are too large.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}