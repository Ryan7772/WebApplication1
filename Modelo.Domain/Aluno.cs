using System.Text.Json.Serialization;

namespace Modelo.Domain
{
    public class Aluno
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}