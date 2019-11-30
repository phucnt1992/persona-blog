namespace Persona.Domain.Entities
{


    public class Media : BaseEntity
    {
        public enum MediaType
        {
            Image,
            Video,
        }
        public long Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public MediaType Type { get; set; }
    }
}
