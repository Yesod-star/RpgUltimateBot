using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Lavalink;

namespace RpgUltimateBot.Modules;

public class Channel : BaseCommandModule
{
    [Command("join")]
    public async Task Join(CommandContext ctx)
    {
        var lava = ctx.Client.GetLavalink();
        if (!lava.ConnectedNodes.Any())
        {
            await ctx.RespondAsync("The Lavalink connection is not established");
            return;
        }

        var node = lava.ConnectedNodes.Values.First();

        if (ctx.Channel.Type != ChannelType.Voice)
        {
            await ctx.RespondAsync("Not a valid voice channel.");
            return;
        }

        await node.ConnectAsync(ctx.Channel);
        await ctx.RespondAsync($"Joined {ctx.Channel.Name}!");
    }

    [Command("leave")]
    public async Task Leave(CommandContext ctx)
    {
        var lava = ctx.Client.GetLavalink();
        if (!lava.ConnectedNodes.Any())
        {
            await ctx.RespondAsync("The Lavalink connection is not established");
            return;
        }

        var node = lava.ConnectedNodes.Values.First();

        if (ctx.Channel.Type != ChannelType.Voice)
        {
            await ctx.RespondAsync("Not a valid voice channel.");
            return;
        }

        var conn = node.GetGuildConnection(ctx.Channel.Guild);

        if (conn == null)
        {
            await ctx.RespondAsync("Lavalink is not connected.");
            return;
        }

        await conn.DisconnectAsync();
        await ctx.RespondAsync($"Left {ctx.Channel.Name}!");
    }

}
