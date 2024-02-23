namespace ExpenseNavigator.Models.Dbo
{
    public class Notification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public bool IsActive { get; set; }
    }
}
