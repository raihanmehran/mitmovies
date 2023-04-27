namespace Domain.v1.Entities
{
    public class Credit
    {
        public List<Cast> Cast { get; set; }
        public List<Crew> Crew { get; set; }
        public int MovieId { get; set; }
    }
}