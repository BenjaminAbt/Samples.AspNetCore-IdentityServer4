namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApiSdk.ApiModels
{
    public class TaskApiModel
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }

        public TaskApiModel(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
