namespace DocumentSystem.Core.Model
{
    public class TaskEntity
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string PreviousTaskID { get; set; }
    }
}
