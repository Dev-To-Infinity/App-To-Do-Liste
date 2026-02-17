class WriteAllLines
{
    public void ExampleAsync()
    {
        string[] lines =
        {
            "First line", "Second line", "Third line" 
        };
        File.WriteAllLines(@"C:\Users\jakow\Documents\WriteLines.txt", lines);
    }
}