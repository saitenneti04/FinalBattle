
public class Party
{
    public string Name { get; }
    public List<Character> Characters { get; } 
    public List<Item> Items { get; }

    public Party(List<Character> characters, string name, List<Item> items)
    {
        Characters = characters;
        Name = name;
        Items = items;
    }

    public void RemoveCharacter(Character character) { Characters.Remove(character); }

    public bool CheckItemsAvailable()
    {
        return (this.Items.Count > 0);
    }
}
