using VinylCollection.Domain.ViewModels.Base;
using VinylCollection.Domain.ViewModels.Security;
using static VinylCollection.Domain.Helper.Enums;

namespace VinylCollection.Domain.ViewModels.Communities
{
    public class CommunityViewModel : BaseViewModel
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

        public UserViewModel User { get; set; }
    }
}
