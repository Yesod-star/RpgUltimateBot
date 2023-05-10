using Discord.Commands;

namespace RpgUltimateBot.Modules;

public class Checks : ModuleBase<SocketCommandContext>
{
    [Command("Check")]
    public async Task CheckAsync()
    {
        await ReplyAsync("Pong!");
    }

    [Command("Initiative")]
    public async Task DiceHiddenAsync()
    {
        var user = Context.User;

        var dmChannel = await user.CreateDMChannelAsync();

        await dmChannel.SendMessageAsync($"Hello {user.Mention}!");

        await Context.Channel.SendMessageAsync($"Hello {user.Mention}!");
    }

}

