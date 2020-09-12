namespace VinylCollection.Domain.Helper
{
    public class Enums
    {
        public enum CommunityPublishRule
        {
            EveryoneCanPost = 1,
            OnlyMembersCanPost = 2,
            OnlyAdministratorsCanPost = 3
        }

        public enum CommunityCommentRule
        {
            EveryoneCanComment = 1,
            OnlyMembersCanComment = 2,
            OnlyAdministratorsCanComment = 3
        }
    }
}
