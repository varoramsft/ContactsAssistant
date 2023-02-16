namespace ContactManagementAssistant.ChatGptClient
{
    public interface IChatGptClient
    {
        public Task<string> Create(string prompt);
    }
}
