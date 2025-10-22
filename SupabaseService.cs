using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace MemoryGame_Supabase
{
    public partial class SupabaseService
    {
        private readonly HttpClient _client = new HttpClient();
        private const string SUPABASE_URL = "https://wohhwcvrvwogmfnqrxwy.supabase.co";
        private const string SUPABASE_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6IndvaGh3Y3ZydndvZ21mbnFyeHd5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjA5NzQzMDcsImV4cCI6MjA3NjU1MDMwN30.d-X1cA3PXaqAS5VnPWsTOLZEO16ajBIsrN_aggr9nQs";


        public async Task GuardarResultado(string jugador, int intentos, string tiempo)
        {
            var Data = new
            {
                jugador = jugador,
                intentos = intentos,
                tiempo = tiempo
            };

            var content = new StringContent(JsonSerializer.Serialize(Data), Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("apikey", SUPABASE_KEY);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {SUPABASE_KEY}");

            var response = await _client.PostAsync($"{SUPABASE_URL}/rest/v1/resultados", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
