namespace Domain.v1.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        public int Cast_Id { get; set; }
        public string Character { get; set; }
        public string Credit_Id { get; set; }
        public int Gender { get; set; }
        public int Order { get; set; }
        public string ProfilePath { get; set; }
    }
}