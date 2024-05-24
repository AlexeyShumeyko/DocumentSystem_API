namespace DocumentSystem.Core.Model
{
    public class DocumentEntity
    {
        public required string Id { get; set; }
        public required string Status { get; set; }

        public TaskEntity ActiveTask { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }
}
