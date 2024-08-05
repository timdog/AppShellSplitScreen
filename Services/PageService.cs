namespace AppShellSplitScreen.Services
{
    public class PageService : IPageService
    {
        private string _staticMessage = "DEFAULT STATIC CONTENT MESSAGE";

        public event EventHandler<string> StaticMessageUpdated;

        public void UpdateStaticMessage(string message)
        {
            StaticMessageUpdated?.Invoke(this, message);
        }

        public string GetStaticMessage()
        {
            return _staticMessage;
        }
    }
}
