
public class Party
{
    public string Name { get; }
    public List<Character> Characters { get; }

    public Party(List<Character> characters, string name)
    {
        Characters = characters;
        Name = name;
    }

    public void RemoveCharacter(Character character) { Characters.Remove(character); }
}
