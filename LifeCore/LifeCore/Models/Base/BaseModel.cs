namespace LifeCore.Models
{
    public class BaseModel
    {
        public virtual int Id { get; set; }
        public override string ToString() => $"{Id} - {GetType().FullName}";
    }
}
