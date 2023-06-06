using Discord;
using Discord.WebSocket;
using DiscordBotApplication.Services;

namespace DiscordBotApplication;

class Program
{
    private DiscordSocketClient _client;

    public static Task Main(string[] args) => new Program().MainAsync();

    private async Task MainAsync()
    {
        _client = new DiscordSocketClient();

        var token = await File.ReadAllTextAsync(@"C:\Users\Zaw Nay Lin\Desktop\DiscordBotCred.txt");

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(-1);
    }
    
}