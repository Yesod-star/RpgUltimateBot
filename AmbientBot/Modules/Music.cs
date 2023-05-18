using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Lavalink;

namespace RpgUltimateBot.Modules;

public class Music : BaseCommandModule
{
    [Command]
    public async Task Play(CommandContext ctx, [RemainingText] string search)
    {
        if (ctx.Member.VoiceState == null || ctx.Member.VoiceState.Channel == null)
        {
            await ctx.RespondAsync("You are not in a voice channel.");
            return;
        }

        var lava = ctx.Client.GetLavalink();
        var node = lava.ConnectedNodes.Values.First();
        var conn = node.GetGuildConnection(ctx.Member.VoiceState.Guild);

        if (conn == null)
        {
            await ctx.RespondAsync("Lavalink is not connected.");
            return;
        }

        var loadResult = await node.Rest.GetTracksAsync(search);

        if (loadResult.LoadResultType == LavalinkLoadResultType.LoadFailed
            || loadResult.LoadResultType == LavalinkLoadResultType.NoMatches)
        {
            await ctx.RespondAsync($"Track search failed for {search}.");
            return;
        }

        var track = loadResult.Tracks.First();

        await conn.PlayAsync(track);

        await ctx.RespondAsync($"Now playing {track.Title}!");
    }

    [Command]
    public async Task Pause(CommandContext ctx)
    {
        if (ctx.Member.VoiceState == null || ctx.Member.VoiceState.Channel == null)
        {
            await ctx.RespondAsync("You are not in a voice channel.");
            return;
        }

        var lava = ctx.Client.GetLavalink();
        var node = lava.ConnectedNodes.Values.First();
        var conn = node.GetGuildConnection(ctx.Member.VoiceState.Guild);

        if (conn == null)
        {
            await ctx.RespondAsync("Lavalink is not connected.");
            return;
        }

        if (conn.CurrentState.CurrentTrack == null)
        {
            await ctx.RespondAsync("There are no tracks loaded.");
            return;
        }

        await conn.PauseAsync();
    }

    [Command]
    public async Task Resume(CommandContext ctx)
    {
        if (ctx.Member.VoiceState == null || ctx.Member.VoiceState.Channel == null)
        {
            await ctx.RespondAsync("You are not in a voice channel.");
            return;
        }

        var lava = ctx.Client.GetLavalink();
        var node = lava.ConnectedNodes.Values.First();
        var conn = node.GetGuildConnection(ctx.Member.VoiceState.Guild);

        if (conn == null)
        {
            await ctx.RespondAsync("Lavalink is not connected.");
            return;
        }

        if (conn.CurrentState.CurrentTrack == null)
        {
            await ctx.RespondAsync("There are no tracks loaded.");
            return;
        }

        await conn.ResumeAsync();
    }

    [Command]
    public async Task Volume(CommandContext ctx, [RemainingText] string search)
    {
        if (ctx.Member.VoiceState == null || ctx.Member.VoiceState.Channel == null)
        {
            await ctx.RespondAsync("You are not in a voice channel.");
            return;
        }

        var lava = ctx.Client.GetLavalink();
        var node = lava.ConnectedNodes.Values.First();
        var conn = node.GetGuildConnection(ctx.Member.VoiceState.Guild);

        if (conn == null)
        {
            await ctx.RespondAsync("Lavalink is not connected.");
            return;
        }

        if (conn.CurrentState.CurrentTrack == null)
        {
            await ctx.RespondAsync("There are no tracks loaded.");
            return;
        }

        if (!TryConvertToInt(search, out int convertedValue))
        {
            await ctx.RespondAsync("Provide a number to show the volume.");
            return;
        }

        await conn.SetVolumeAsync(convertedValue);
    }

    public static bool TryConvertToInt(string value, out int result)
    {
        return int.TryParse(value, out result);
    }


}
