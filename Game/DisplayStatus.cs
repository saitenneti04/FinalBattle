using System;

public static class DisplayStatus
{
    public static void DisplayGameStatus(Party currParty, Character currCharacter, Party enemyParty)
    {
        Console.WriteLine();
        Console.WriteLine("===================================Battle==================================");

        GetCharacterHealth(currParty, currCharacter);
        Console.WriteLine("-------------------------------------VS------------------------------------");
        GetCharacterHealth(enemyParty, currCharacter);
        Console.WriteLine("===========================================================================");
        Console.WriteLine();
    }

    private static void GetCharacterHealth(Party currParty, Character currCharacter)
    {
        foreach (Character character in currParty.Characters)
        {
            ConsoleColor curr = Console.ForegroundColor;
            if (character == currCharacter)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"{character.Name}     ({character.CurrHP}/{character.MaxHP})");
            Console.ForegroundColor = curr;
        }
    }
}
