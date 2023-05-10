using Discord.Commands;

namespace RpgUltimateBot.Modules;

public class Stats : ModuleBase<SocketCommandContext>
{

    [Command("Sheet")]
    public async Task SheetAsync()
    {
        var user = Context.User;

        var dmChannel = await user.CreateDMChannelAsync();

        await dmChannel.SendMessageAsync($"Hello {user.Mention}!");

        await Context.Channel.SendMessageAsync($"Hello {user.Mention}!");
    }

    [Command("Health")]
    public async Task HealthAsync()
    {
        var user = Context.User;

        var dmChannel = await user.CreateDMChannelAsync();

        await dmChannel.SendMessageAsync($"Hello {user.Mention}!");

        await Context.Channel.SendMessageAsync($"Hello {user.Mention}!");
    }

    [Command("Gold")]
    public async Task GoldAsync()
    {
        var user = Context.User;

        var dmChannel = await user.CreateDMChannelAsync();

        await dmChannel.SendMessageAsync($"Hello {user.Mention}!");

        await Context.Channel.SendMessageAsync($"Hello {user.Mention}!");
    }

    [Command("Inventory")]
    public async Task InventoryAsync()
    {
        var user = Context.User;

        var dmChannel = await user.CreateDMChannelAsync();

        await dmChannel.SendMessageAsync($"Hello {user.Mention}!");

        await Context.Channel.SendMessageAsync($"Hello {user.Mention}!");
    }

    [Command("Spell")]
    public async Task SpellAsync()
    {
        var user = Context.User;

        var dmChannel = await user.CreateDMChannelAsync();

        await dmChannel.SendMessageAsync($"Hello {user.Mention}!");

        await Context.Channel.SendMessageAsync($"Hello {user.Mention}!");
    }

    [Command("SpellList")]
    public async Task SpellListAsync()
    {
        var user = Context.User;

        var dmChannel = await user.CreateDMChannelAsync();

        await dmChannel.SendMessageAsync($"Hello {user.Mention}!");

        await Context.Channel.SendMessageAsync($"Hello {user.Mention}!");
    }

}
