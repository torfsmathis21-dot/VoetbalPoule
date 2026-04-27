using System;
using System.Collections.Generic;
using System.Text;

namespace VoetbalPoule_Business
{
    internal class Game
    {
        //velden
        private int _awayscore;
        private Team _awayteam;
        private int _homescore;
        private Team _hometeam;
        private bool _isplayed;

        //eigenschappen
        public int AwayScore
        {
            get { return _awayscore; }
            set { _awayscore = value; }
        }
        public Team AwayTeam
        {
            get { return _awayteam; }
        }
        public int HomeScore
        {
            get { return _homescore; }
            set { _homescore = value; }
        }
        public bool IsPlayed
        {
            get { return _isplayed; }
            set { _isplayed = value; }
        }
        public Team HomeTeam
        {
            get { return _hometeam; }
        }
        
        //methodes
        internal Game (Team homeTeam, Team awayTeam)
        {
            _hometeam = homeTeam;
            _awayteam = awayTeam;
            _isplayed = false;
        }
        internal void RegisterResult(int homeScore, int awayScore)
        {
            if(IsPlayed)
            {
                throw new InvalidOperationException("This game has already been played.");
            }
            _homescore = homeScore;
            _awayscore = awayScore;
            _isplayed = true;

            HomeTeam.UpdateStats(homeScore, awayScore);
            AwayTeam.UpdateStats(awayScore, homeScore);
        }



    }
}
