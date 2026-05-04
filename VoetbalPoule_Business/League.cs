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
                foreach (Game item in _game)
                {
                    if (item.HomeTeam == home && item.AwayTeam == away)
                    {
                        matchAllreadyExists = true;
                    }
                }
                if (matchAllreadyExists)
                {
                    throw new Exception($"Match between '{homeTeamName}' and '{awayTeamName}' already exists.");
                }

            }
            _game.Add(new Game(home, away));
        }

        public void RegisterResult(string homeTeamName, string awayTeamName, int homeScore, int awayScore)
        {
            //search for first match between both teams already played, if not found throw exception
            bool matchFound = false;
            Game? game = null;
            foreach (Game item in _game)
            {
                if (item.HomeTeam.Name == homeTeamName && item.AwayTeam.Name == awayTeamName)
                {
                    matchFound = true;
                    game = item;
                    break;
                }
            }
            if (!matchFound)
            {
                throw new Exception($"Match between '{homeTeamName}' and '{awayTeamName}' not found or already played.");
            }
            game.RegisterResult(homeScore, awayScore);
        }
        //standings 
        public List<Team> GetStanding()
        {
            return _teams
           .OrderByDescending(t => t.Points)
           .ThenByDescending(t => t.GoalDifference)
           .ThenByDescending(t => t.GoalsFor)
           .ToList();
        }

        //helper
        private Team? GetTeamBYName(string name)
        {
            bool found = false;
            Team? team = null;
            foreach (Team item in _teams)
            {
                if (item.Name == name)
                {
                    team = item;
                    found = true; 
                    break;
                }
            }if(!found)
                throw new Exception($"Team '{name}' not found in the league.");
            return team;
        }






    }
}
