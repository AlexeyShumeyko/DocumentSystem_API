namespace DocumentSystem.Core.Model
{
    public class DocumentEntity
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public TaskEntity ActiveTask { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }
}
