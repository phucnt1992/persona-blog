namespace Persona.Domain.Entities
{


    public class Media : BaseEntity<long>
    {
        public enum MediaType
        {
            Image,
            Video,
        }
        public string Title { get; set; }
        public string Url { get; set; }
        public MediaType Type { get; set; }
    }
}
