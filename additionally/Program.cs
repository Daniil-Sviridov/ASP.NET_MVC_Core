/*

using System.Text;

static async Task<string> ReadTextAsync(string filename)
{
    using var sourceStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);

    var sb = new StringBuilder();

    byte[] buffer = new byte[0x1000];
    int numRead;
    while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
    {
        string text = Encoding.UTF8.GetString(buffer);
        sb.Append(text);
    }

    return sb.ToString();
}

string name = Environment.GetCommandLineArgs()[0];

Console.WriteLine(Environment.GetCommandLineArgs().Length);

string curret_directory = Directory.GetCurrentDirectory();

string[] files = Directory.GetFiles(curret_directory + "\\FilesrRead\\", "*.txt");



foreach (string file in files)
{
    Console.WriteLine(file);
    Console.WriteLine(await ReadTextAsync(file));
}


*/

