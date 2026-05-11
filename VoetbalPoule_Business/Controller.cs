using System.Net;

namespace VoetbalPoule_Business
{
    public class Controller
    {
       private League _league;
        public Controller()
        {
            _league = new League();
            //om te testen voeg hier al wat teams toe
             //_league.AddTeam("Ajax", "Amsterdam");
             //_league.AddTeam("PSV", "Eindhoven");
             //_league.AddTeam("Feyenoord", "Rotterdam");
             //_league.AddTeam("AZ", "Alkmaar")
        }
        public void AddTeam(string name, string city)
        {
            try
            {
                _league.AddTeam(name, city);
            }
            catch(Exception e) 
            { 
                throw e;
            }
        }
        public IReadOnlyList<Team> GetTeams()
        {
            return _league.GetTeams();
        }
        public void ScheduleGame(string homeTeamName, string awayTeamName)
        {
            _league.ScheduleGame(homeTeamName, awayTeamName);
        }   

        public IEnumerable<object> GetStandings()
        {
            List<object> standings = new List<object>();
            int positie = 0;
            foreach(Team t in _league.GetStanding())
            {
                standings.Add(new
                {
                    Position = positie,
                    t.Name,
                    t.City,
                    t.Drawn,
                    t.GoalDifference,
                    t.GoalsAgainst,
                    t.GoalsFor,
                    t.Lost,
                    t.Points,
                });
                positie++;
            }
            return standings;

        }   
        public List<string> GetTeamsName()
        {
            List <string> teamNames = new List<string>();
            foreach(Team item in _league.GetTeams())
            {
                teamNames.Add(item.Name);
            }
            return teamNames;
        }
        public void RegisterResult(string homeTeam, string awayTeam, int homeScore, int awayScore)
        {
            try
            {
                _league.RegisterResult(homeTeam, awayTeam, homeScore, awayScore);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void SchedulMatch(string homeTeam, string awayTeam)
        {
            try
            {
                _league.ScheduleGame(homeTeam, awayTeam);
            }
            catch (Exception ex)
            {
                throw ex;
            }


         }
    }

}
