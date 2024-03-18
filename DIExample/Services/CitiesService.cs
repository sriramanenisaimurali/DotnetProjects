using ServiceContracts;
namespace Services
{
    public class CitiesService : ICitiesService, IDisposable
    {
        private List<string> _cities;
        public CitiesService()
        {
            _cities = new List<string>()
            {
                "Hyderbad",
                "Banglore",
                "Chennai",
                "Delhi",
                "Mumbai"
            };
        }

        public void Dispose()
        {
            // Used to close the database connection
        }

        public List<string> GetCities()
        {
            return _cities;
        }

    }
}