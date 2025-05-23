namespace ShortLink.Domain.Repository
{
    public interface IUnityOfWork
    {
        public Task Commit();
    }
}
