using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace simplerbot.Commands;

public class Moderation : BaseCommandModule
{
    [Command("warn")]
    [RequirePermissions(Permissions.KickMembers)]
    public async Task Warn(CommandContext ctx, DiscordMember member, string reason = "<no reason provided>")
    {
        await ctx.RespondAsync($"User {member.Mention} has been successfully warned!\nReason: {reason}");
    }
    
    [Command("kick")]
    [RequirePermissions(Permissions.KickMembers)]
    public async Task Kick(CommandContext ctx, DiscordMember member, string reason = "<no reason provided>")
    {
        await member.RemoveAsync(reason);
        await ctx.RespondAsync($"User {member.Mention} has been successfully kicked!\nReason: {reason}");
    }
    
    [Command("ban")]
    [RequirePermissions(Permissions.BanMembers)]
    public async Task Ban(CommandContext ctx, DiscordMember member, string reason = "<no reason provided>")
    {
        await member.BanAsync(0, reason);
        await ctx.RespondAsync($"User {member.Mention} has been successfully banned!\nReason: {reason}");
    }
}