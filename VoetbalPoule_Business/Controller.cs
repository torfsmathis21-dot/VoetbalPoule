namespace VoetbalPoule_Business
{
    public class Controller
    {
       private League _league;
        public Controller()
        {
            _league = new League();
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
       


    }
}
