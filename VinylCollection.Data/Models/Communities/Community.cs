using VinylCollection.Data.Models.Base;
using VinylCollection.Data.Models.Security;
using static VinylCollection.Domain.Helper.Enums;

namespace VinylCollection.Data.Models.Communities
{
    public class Community : BaseEntity
    {
        public int Id_User { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }
        public string Background { get; set; }

        public CommunityPublishRule PublishRule { get; set; }
        public CommunityCommentRule CommentRule { get; set; }

        public bool NSFW { get; set; }

        public User User { get; set; }
    }
}
