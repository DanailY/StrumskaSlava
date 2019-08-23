namespace StrumskaSlava.Services.Data
{
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;

    public class PlayerPositionServiceModel : IMapFrom<PlayerPosition>, IMapTo<PlayerPosition>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
