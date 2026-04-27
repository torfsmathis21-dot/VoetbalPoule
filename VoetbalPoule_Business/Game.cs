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

        }
        

    }
}
