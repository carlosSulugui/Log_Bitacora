namespace projectUMG.Data
{
    public class DbContext
    {
        public string? Value { get; set; }
        public DbContext(string? value) => Value = value;
        
    }
}



