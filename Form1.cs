using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12_aralıködev
{
    public partial class Form1 : Form
    {
        private readonly string _connectionString = @"Data Source=DESKTOP-AQ2MBA7\SQLEXPRESS;Initial Catalog=ogu.bs;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
             
        

            string username = textBox1.Text;
            string password = textBox2.Text;

            string role = await GetUserRoleAsync(username, password);

            if (!string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Giriş başarılı! Rol: " + role, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Rolüne göre uygun paneli aç
                OpenRoleBasedForm(role);
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kullanıcı adı ve şifreye göre rolü asenkron olarak veritabanından alır
        private async Task<string> GetUserRoleAsync(string username, string password)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT Rol FROM Kullanici WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@KullaniciAdi", username);
                        command.Parameters.AddWithValue("@Sifre", password);

                        var result = await command.ExecuteScalarAsync();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        // Kullanıcı rolüne göre uygun formu açar
        private void OpenRoleBasedForm(string role)
        {
            Form formToOpen;

            if (role == "Ogrenci")
            {
                formToOpen = new OgrenciPanel(); // OgrenciPanel formunu oluşturmalısınız
            }
            else if (role == "Ogretmen")
            {
                formToOpen = new OgretmenPanel(); // OgretmenPanel formunu oluşturmalısınız
            }
            else if (role == "Yonetici")
            {
                formToOpen = new Ogrenci_isleri_ders(); // YoneticiPanel formunu oluşturmalısınız
            }
            else
            {
                MessageBox.Show("Geçersiz rol!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            formToOpen.Show();
            this.Hide(); // Mevcut formu gizle
        }

        

    }
}
        
       