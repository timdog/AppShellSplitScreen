namespace AppShellSplitScreen.Services
{
    public interface IPageService
    {
        event EventHandler<string> StaticMessageUpdated;
        void UpdateStaticMessage(string message);
        string GetStaticMessage();
    }
}
