using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace DiscordBotApplication.Services;

public class LoggingServices
{
    public LoggingServices(DiscordSocketClient client, CommandService commandService)
    {
        client.Log += LogAsync;
        commandService.Log += LogAsync;
    }

    private Task LogAsync(LogMessage message)
    {
        if (message.Exception is CommandException commandException)
        {
            Console.WriteLine(
                $"[Command/{message.Severity}] {commandException.Command.Aliases[0]} failed to execute in {commandException.Context.Channel}.");
            Console.WriteLine(commandException);
        }
        else
        {
            Console.WriteLine($"[General/{message.Severity}] {message}");
        }

        return Task.CompletedTask;
    }
}