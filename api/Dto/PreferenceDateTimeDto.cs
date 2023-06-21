namespace api.Dto
{
    public class PreferenceDateTimeDto
    {
        public DateOnly Date { get; set; } 
        public List<TimeOnly> Times { get; set; }
    }
}