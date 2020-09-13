namespace VinylCollection.Domain.Transversal
{
    public class AppPrincipal : IAppPrincipal
    {
        public AppPrincipal(int id = 0, string userName = "Unknown")
        {
            Id = id;
            UserName = userName;
        }

        public int Id { get; }
        public string UserName { get; }
    }
}
