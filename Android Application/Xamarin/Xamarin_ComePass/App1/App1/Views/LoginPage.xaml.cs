using App1.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySql.Data;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MySqlConnector;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            Device.SetFlags(new[] { "Brush_Experimental" });
            InitializeComponent();
            init();
        }

        void init()
        {
            BackgroundColor = Constants.backgroundColor;
            //label_username.TextColor = Constants.mainTextColor;
            //label_password.TextColor = Constants.mainTextColor;
            activitySpinner.IsVisible = false;
            logoIcon.HeightRequest = Constants.loginIconHeigh;

            entry_username.Completed += (s, e) => entry_password.Focus();
            entry_password.Completed += (s, e) => button_signin.Focus();

        }

        void SingInProcedure(object sender, EventArgs e)
        {
            login(entry_username.Text, entry_password.Text);
        }

        private async void login(string username, string pass)
        {
            try
            {
                string login_querry = "SELECT * FROM Punonjesit WHERE E_Mail = '" + username + "' AND Kodi = '" + pass + "';";

                MySqlConnection conn = new MySqlConnection(MySql.connection_string);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(login_querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    Login_Info.id = int.Parse(dr[0].ToString());
                    Login_Info.emri = (dr[1].ToString());
                    Login_Info.mbiemri = (dr[2].ToString());
                    Login_Info.pozicioni = (dr[3].ToString());
                    Login_Info.paga_ore = int.Parse(dr[4].ToString());

                    await DisplayAlert("Login Success", "Welcome Back " + Login_Info.emri, "Next!");
                    Navigation.PushAsync(new Employee());
                }
                else
                {
                    await DisplayAlert("Login Failed", "Please Check Your Credentials", "Try Again!");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Unexpected Error", ex.ToString(), "Try Again!");
                //conn.Close();
            }
        }
    }
}