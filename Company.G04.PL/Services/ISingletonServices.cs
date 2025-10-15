namespace Company.G04.PL.Services
{
    public interface ISingletonServices
    {
        public Guid Guid { get; set; }
        string GetGuid();
    }
}
