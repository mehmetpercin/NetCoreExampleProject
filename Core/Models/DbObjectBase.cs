namespace Core.Models
{
    public abstract class DbObjectBase<T> : ITable
    {
        public T Id { get; set; }
    }
}
