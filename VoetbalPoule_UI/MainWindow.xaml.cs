using System;
using System.Collections.Generic;
using System.Drawing.Text;
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
    /// Interaction logic for Mainwindow2.xaml
    /// </summary>
    public partial class Mainwindow : Window
    {
        private Controller _controller;

        public Mainwindow()
        {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void FillListOfTeams()
        {
            List<string> teamnames = _controller.GetTeamsName();

            LstTeams.ItemsSource = teamnames;

            CmbHome.ItemsSource = null;
            CmbHome.ItemsSource = teamnames;

            CmbAway.ItemsSource = null;
            CmbAway.ItemsSource = teamnames;
    
            dgrStandings.ItemsSource = _controller.GetStandings();
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

            try
            {
                _controller.RegisterResult(
                    CmbHome.SelectedItem.ToString(),
                    CmbAway.SelectedItem.ToString(),
                    homeScore,
                    awayScore
                );

                FillListOfTeams();
                CmbHome.SelectedItem = null;
                CmbAway.SelectedItem = null;
                TxtHomeScore.Clear();
                TxtAwayScore.Clear();
                TxtHomeScore.IsEnabled = false;
                TxtAwayScore.IsEnabled = false;
                btnRegisterResult.IsEnabled = false;

                MessageBox.Show("Successfully registered");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Plan game
        private void Button_Click_ScheduleMatch(object sender, RoutedEventArgs e)
        {
            if (CmbHome.SelectedItem == null || CmbAway.SelectedItem == null)
            {
                MessageBox.Show("Please select both home and away teams.");
                return;
            }

            if (CmbHome.SelectedItem.ToString() == CmbAway.SelectedItem.ToString())
            {
                MessageBox.Show("Please select two different teams.");
                return;
            }

            try
            {
                _controller.ScheduleGame(
                    CmbHome.SelectedItem.ToString(),
                    CmbAway.SelectedItem.ToString()
                );

                MessageBox.Show("Match scheduled successfully.");

                btnRegisterResult.IsEnabled = true;
                TxtHomeScore.IsEnabled = true;
                TxtAwayScore.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error scheduling match: {ex.Message}");
            }
        }
    }
}

    

    

