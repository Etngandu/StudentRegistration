using ENB.Students.Registration.Blazor.RequestFeatures;

namespace ENB.Students.Registration.Blazor.Features
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; }
        public MetaData MetaData { get; set; }
    }
}
