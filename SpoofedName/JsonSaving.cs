using System.Text.Json;
using LabApi.Features.Console;
using LabApi.Features.Wrappers;

namespace SpoofedName;

public class JsonSaving
{
    private readonly string _filePath;
    private Dictionary<string, string> _storage = new();

    public JsonSaving(string filePath)
    {
        Directory.CreateDirectory(filePath);
        _filePath = Path.Combine(filePath, "SpoofedNames.json");
        Load();
    }

    public void Save(Player player, string spoofName)
    {
        _storage[player.UserId] = spoofName;
        WriteToFile();
    }

    public bool TryGet(string userID, out string? spoofName)
    {
        return _storage.TryGetValue(userID, out spoofName);
    }

    public bool Delete(string userID)
    {
        return _storage.Remove(userID);
    }

    private void WriteToFile()
    {
        try
        {
            var json = JsonSerializer.Serialize(_storage, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            Logger.Error($"Error writing to {_filePath}: {ex.Message}");
        }
    }
    
    private void Load()
    {
        try
        {
            if (!File.Exists(_filePath)) return;
            var json = File.ReadAllText(_filePath);
            _storage = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
        }
        catch (Exception ex)
        {
            Logger.Error($"Error Loading to {_filePath}: {ex.Message}");
        }
    }
}