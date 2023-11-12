using WebApplication2.School_dbModels;

namespace WebApplication2.Models
{
    public class StudentsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class ViewModel
    {
        public List<Person> Items { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }

    public class SearchResultModel
    {
        public string SearchTerm { get; set; }
        public List<Person> Items { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
