namespace Application.Models.Common
{
    public class BaseModel<T>
    {
        public T Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
