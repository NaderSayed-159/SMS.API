namespace SMS.Infrastructure.Model
{
    public abstract class ModelEntityBase<T>
    {
        public virtual T Id { get; set; }
    }
}
