namespace Domain.v1.Entities
{
    public class Credit
    {
        public int MovieId { get; set; }
        public List<Cast> Cast { get; set; }
        public List<Crew> Crew { get; set; }
    }
}