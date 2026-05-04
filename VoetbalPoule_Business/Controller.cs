namespace VoetbalPoule_Business
{
    public class Controller
    {
        //velden
        private League _league = new League();

        // Methodes
        public void AddTeam(string name, string city)
        {
            _league.AddTeam(name, city);
        }

        
    }
}
