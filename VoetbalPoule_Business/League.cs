using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace VoetbalPoule_Business
{
    internal class League
    {
        //velden
        private List<Game> _game;
        private List<Team> _teams;

        //constructor
        public League()
        {
            _teams = new List<Team>();
            _game = new List<Game>();
        }

        //methodes
        public void AddTeam(string name, string city)
        {
            bool teamAlreadyExists = false;
            foreach (Team item in _teams)
            {
                if (item.Name == name)
                { teamAlreadyExists = true; }
            }
            if (teamAlreadyExists)
            {
                throw new Exception($"Team '{name}' already exists in the league.");
            }
            _teams.Add(new Team(name, city));
        }

        public IReadOnlyList<Team> GetTeams()
        {
            return _teams.AsReadOnly();
        }
        //matches
        public void ScheduleGame(string homeTeamName, string awayTeamName)
        {
            Team home = _teams.Find(t => t.Name == homeTeamName);
            Team away = _teams.Find(t => t.Name == awayTeamName);
            if (home != null || away != null)
            {
                bool matchAllreadyExists = false;
                foreach(Game item in _game)
                {
                   if (item.HomeTeam == home && item.AwayTeam==away)
                    {
                        matchAllreadyExists = true;
                    }
                }
                if(matchAllreadyExists)
                {
                    throw new Exception($"Match between '{homeTeamName}' and '{awayTeamName}' already exists.");
                }

            }
            _game.Add(new Game(home, away));
        }

        public void RegisterResult(string homeTeamName, string awayTeamName, int homeScore, int awayScore)
        {
            Game game = _game.Find(g => g.HomeTeam.Name == homeTeamName && g.AwayTeam.Name == awayTeamName);
            if (game == null)
            {
                throw new Exception("The specified game does not exist.");
            }
            game.RegisterResult(homeScore, awayScore);
        }
        //standings 
        public List<Team> GetStanding()
        {
            return new List<Team>();
        }






    }
}
