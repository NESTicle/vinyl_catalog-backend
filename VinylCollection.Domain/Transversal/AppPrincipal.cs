namespace VinylCollection.Domain.Transversal
{
    public class AppPrincipal : IAppPrincipal
    {
        public AppPrincipal(int id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
