using System;
using System.Collections.Generic;
using System.Text;

namespace VoetbalPoule_Business
{
    public class Team
    {
        //velden
        private string _city;
        private int _drawn;
        private int _goaldifference;
        private int _goalsagainst;
        private int _goalsfor;
        private int _lost;
        private string _name;
        private int _points;
        private int _won;

        //eigenschappen
        public string City
        {
            get { return _city; }

        }
        public int Drawn
        {
            get { return _drawn; }
            set { _drawn = value; }
        }
        public int Goaldifference
        {
            get { return _goaldifference; }

        }
        public int GoalsAgainst
        {
            get { return _goalsagainst; }
            set { _goalsagainst = value; }
        }
        public int GoalsFor
        {
            get { return _goalsfor; }
            set { _goalsfor = value; }
        }
        public int Lost
        {
            get { return _lost; }
            set { _lost = value; }
        }
        public string Name
        {
            get { return _name; }

        }
        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }
        public int Won
        {
            get { return _won; }
            set { _won = value; }
        }
        //methodes
        public Team(string name, string city)
        {
            _name = name;
            _city = city;
        }
        public int GoalDifference => GoalsFor - GoalsAgainst;

        public void UpdateStats(int goalsFor, int goalsagainst)
        {

            GoalsFor += goalsFor;
            GoalsAgainst += goalsagainst;
            // Bereken of je wint of je verliest of je gelijk speelt
            if (goalsFor > goalsagainst)
            {
                Won++;
                Points += 3;
            }
            else if (goalsFor == goalsagainst)
            {
                Drawn++;
                Points += 1;
            }
            else
            {
                Lost++;

            }

        }
    }
}
