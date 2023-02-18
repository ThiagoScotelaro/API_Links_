namespace Aula3.Entities
{
    public class ShortLink
    {
        public ShortLink(string title, string destinationlink)
        {
            var code = title.Split("  ")[0];
            Title = title;           
            DestinationLink= destinationlink;
            ShortenedLink = $"localhost:3000/{Title.Split("  ")[0]}";
            Code= code;
            CreatedAt = DateTime.Now.ToShortDateString();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortenedLink { get; set; }
        public string DestinationLink { get; set; }
        public string Code { get; set;}
        public string CreatedAt{ get; set; }

        public void Update( string title, string destinationLink)
        {
            Title= title;
            DestinationLink= destinationLink;
        }

    }
}
