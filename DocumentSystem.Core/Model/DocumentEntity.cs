namespace DocumentSystem.Core.Model
{
    public class DocumentEntity
    {
        public required string Id { get; set; }
        public required string Status { get; set; }

        public required TaskEntity ActiveTask { get; set; }
        public required List<TaskEntity> Tasks { get; set; }
    }
}
