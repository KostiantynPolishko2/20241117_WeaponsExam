namespace AdminPageServer.PL.Infrastructures
{
    public class WeaponsException : Exception
    {
        public string property { get; } = null!;
        public WeaponsException(string message, string property) : base(message) {
            this.property = property;
        }
    }
}
