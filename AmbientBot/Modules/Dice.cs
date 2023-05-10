﻿using Discord;
using Discord.Commands;

namespace RpgUltimateBot.Modules;

public class Dice : ModuleBase<SocketCommandContext>
{
    [Command("Dice")]
    public async Task DiceAsync(string message)
    {
        string input = message;

        string[] components = input.Split(new char[] { 'd', '+', '-' });

        if (components.Length < 2 || components.Length > 3 ||
            components.Any(c => !int.TryParse(c, out _)) ||
            (components.Length == 3 && components[2][0] != '+' && components[2][0] != '-'))
        {
            message = "Formato Inválido. Por favor, use o formato 'XdY+Z' ou 'XdY-Z', onde X, Y, e Z são números inteiros positivos.";
        }
        else
        {

            int numDice = components.Length > 1 ? int.Parse(components[0]) : 1;
            int numFaces = components.Length > 1 ? int.Parse(components[1]) : int.Parse(components[0]);

            int modifier = 0;
            if (components.Length > 2)
            {
                char modifierSign = input.First(c => c == '+' || c == '-');
                int modifierValue = int.Parse(components.Last());
                modifier = modifierSign == '+' ? modifierValue : -modifierValue;
            }

            int roll = RollDice(numDice, numFaces) + modifier;

            message = $"You rolled {roll} ({numDice}d{numFaces}{(modifier >= 0 ? "+" + modifier : modifier.ToString())})";

        }

        await Context.Channel.SendMessageAsync(message);
    }

    [Command("DiceHidden")]
    public async Task DiceHiddenAsync(string message)
    {

        string input = message;

        string[] components = input.Split(new char[] { 'd', '+', '-' });

        if (components.Length < 2 || components.Length > 3 ||
        components.Any(c => !int.TryParse(c, out _)) ||
        (components.Length == 3 && components[2][0] != '+' && components[2][0] != '-'))
        {
            message = "Formato Inválido. Por favor, use o formato 'XdY+Z' ou 'XdY-Z', onde X, Y, e Z são números inteiros positivos.";
        }
        else
        {
            int numDice = components.Length > 1 ? int.Parse(components[0]) : 1;
            int numFaces = components.Length > 1 ? int.Parse(components[1]) : int.Parse(components[0]);

            int modifier = 0;
            if (components.Length > 2)
            {
                char modifierSign = input.First(c => c == '+' || c == '-');
                int modifierValue = int.Parse(components.Last());
                modifier = modifierSign == '+' ? modifierValue : -modifierValue;
            }

            int roll = RollDice(numDice, numFaces) + modifier;

            message = $"You rolled {roll} ({numDice}d{numFaces}{(modifier >= 0 ? "+" + modifier : modifier.ToString())})";

        }

        var user = Context.User;

        var dmChannel = await user.CreateDMChannelAsync();

        await dmChannel.SendMessageAsync(message);

        await Context.Channel.SendMessageAsync(message);

    }

    static Random random = new Random();

    static int RollDice(int numDice, int numFaces)
    {
        int sum = 0;
        for (int i = 0; i < numDice; i++)
        {
            sum += random.Next(1, numFaces + 1);
        }
        return sum;
    }

}
