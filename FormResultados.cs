using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame_Supabase
{
    public partial class FormResultados : Form
    {
        private const string SUPABASE_URL = "https://wohhwcvrvwogmfnqrxwy.supabase.co";
        private const string SUPABASE_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6IndvaGh3Y3ZydndvZ21mbnFyeHd5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjA5NzQzMDcsImV4cCI6MjA3NjU1MDMwN30.d-X1cA3PXaqAS5VnPWsTOLZEO16ajBIsrN_aggr9nQs";

        public FormResultados()
        {
            InitializeComponent();
        }
    }
}
