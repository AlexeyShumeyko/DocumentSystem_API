namespace DocumentSystem.Core.Model
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PreviousTaskID { get; set; }
    }
}
