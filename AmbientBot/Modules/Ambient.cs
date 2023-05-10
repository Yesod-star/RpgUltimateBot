using Discord.Commands;

namespace RpgUltimateBot.Modules;

public class Ambient : ModuleBase<SocketCommandContext>
{

    [Command("Ambient")]
    public async Task AmbientAsync()
    {
        var user = Context.User;

        var dmChannel = await user.CreateDMChannelAsync();

        await dmChannel.SendMessageAsync($"Hello {user.Mention}!");

        await Context.Channel.SendMessageAsync($"Hello {user.Mention}!");
    }
}

