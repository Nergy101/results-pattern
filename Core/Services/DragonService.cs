using Core;

namespace FluentResultsTrial;

public class DragonService
{
    private readonly Dictionary<string, Dragon> _dragons = new Dictionary<string, Dragon>();

    // Create a new Dragon
    public void CreateDragon(Dragon dragon)
    {
        if (dragon == null)
        {
            throw new ArgumentNullException(nameof(dragon), "Dragon cannot be null");
        }

        if (!_dragons.TryAdd(dragon.Name, dragon))
        {
            throw new ArgumentException($"Dragon with name {dragon.Name} already exists");
        }
    }

    // Read a Dragon by name
    public Dragon GetDragon(string name)
    {
        if (_dragons.TryGetValue(name, out var dragon))
        {
            return dragon;
        }

        throw new NotFoundException($"Dragon with name {name} not found");
    }

    // Update an existing Dragon
    public void UpdateDragon(Dragon dragon)
    {
        if (dragon == null)
        {
            throw new ArgumentNullException(nameof(dragon), "Dragon cannot be null");
        }

        if (!_dragons.ContainsKey(dragon.Name))
        {
            throw new NotFoundException($"Dragon with name {dragon.Name} not found");
        }

        _dragons[dragon.Name] = dragon;
    }

    // Delete a Dragon by name
    public void DeleteDragon(string name)
    {
        if (!_dragons.Remove(name))
        {
            throw new NotFoundException($"Dragon with name {name} not found");
        }
    }

    // List all Dragons
    public IEnumerable<Dragon> GetAllDragons()
    {
        return _dragons.Values;
    }
}