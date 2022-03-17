using App1.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Employee : ContentPage
    {
        private string name_property;
        public string emri_property
        {
            get { return name_property; }
            set
            {
                name_property = value;
                OnPropertyChanged(nameof(emri_property));
            }
        }

        private string position_property;
        public string pozicioni_property
        {
            get { return position_property; }
            set
            {
                position_property = value;
                OnPropertyChanged(nameof(pozicioni_property));
            }
        }

        private string hours_property;
        public string oret_property
        {
            get { return hours_property; }
            set
            {
                hours_property = value;
                OnPropertyChanged(nameof(oret_property));
            }
        }

        private string wage_per_hour_property;
        public string paga_per_ore_property
        {
            get { return wage_per_hour_property; }
            set
            {
                wage_per_hour_property = value;
                OnPropertyChanged(nameof(paga_per_ore_property));
            }
        }

        private string total_wage_property;
        public string paga_totale_property
        {
            get { return total_wage_property; }
            set
            {
                total_wage_property = value;
                OnPropertyChanged(nameof(paga_totale_property));
            }
        }

        public Employee()
        {
            InitializeComponent();

            BindingContext = this;
            emri_property = Login_Info.emri + " " + Login_Info.mbiemri;
            pozicioni_property = Login_Info.pozicioni;
            paga_per_ore_property = "Hourly Wage: $" + Login_Info.paga_ore.ToString();

            calculate_working_hours();
        }

        public void calculate_working_hours()
        {
            int paga_finale = 0;
            TimeSpan oret_e_punes;

            try
            {
                string login_querry = "SELECT  Sec_To_Time( SUM( Time_To_Sec( `Dita_Punes` ) ) ) AS timeSum " +
                    "FROM Orari WHERE MONTH(Data) = MONTH(CURRENT_DATE())and Punonjes_ID = " + Login_Info.id;
                
                MySqlConnection conn = new MySqlConnection(MySql.connection_string);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(login_querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr.HasRows)
                    {  
                        if(dr[0].ToString() == "")
                        {
                            oret_e_punes = TimeSpan.Parse("00:00:00");
                            paga_finale = 0;
                        }
                        else
                        {
                            oret_e_punes = TimeSpan.Parse((dr[0].ToString()));
                            paga_finale = oret_e_punes.Hours * Login_Info.paga_ore;
                        }                        

                        BindingContext = this;
                        oret_property = "Working Hours: " + oret_e_punes.ToString();
                        paga_totale_property = "Salary: $" + paga_finale.ToString();
                    }
                    else
                    {
                        
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                DisplayAlert("Finger Tracker", ex.ToString(), "Try Again!");                
            }
        }
    }
}