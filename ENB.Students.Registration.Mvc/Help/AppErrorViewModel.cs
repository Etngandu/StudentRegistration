namespace ENB.Students.Registration.Mvc
{
    public class AppErrorViewModel
    {
        public string? Title { get; set; }

        public string? Path { get; set;}

        public string? Message { get; set; }

        public IReadOnlyDictionary<string, string[]>? ErrorMessages { get; set; }
    }
}
