using System.Text.Json.Serialization;

namespace Desafio.Infrastructure.CommandBus
{
    public sealed class CommandResult
    {
        public CommandResult(object data, bool success = true)
        {
            Data = data;
            Success = success;
        }

        public CommandResult(long id, bool success = true)
        {
            Id = id;
            Success = success;
        }

        public long? Id { get; set; }

        public object? Data { get; init; }

        [JsonIgnore]
        public bool Success { get; init; }

        public static CommandResult CompletedSuccess()
        {
            return new CommandResult(Guid.Empty, true);
        }

        public static CommandResult CompletedError(long id)
        {
            return new CommandResult(id, false);
        }
    }
}
