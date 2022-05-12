using System.Text.Json;

namespace Chat.Lib;

public record Config
{
    public string IpAddress { get; init; }
    public int Port { get; init; }

    public void Deconstruct(out string ipAddress, out int port)
    {
        ipAddress = IpAddress;
        port = Port;
    }

    public static async Task<Config?> ReadConfigAsync(string path)
    {
        Config? config = null;
        
        try
        {
            await using var file = new FileStream(path, FileMode.Open);
            config = await JsonSerializer.DeserializeAsync<Config>(file);
        }
        catch (Exception e)
        {
            // ignored
        }

        return config;
    }
}