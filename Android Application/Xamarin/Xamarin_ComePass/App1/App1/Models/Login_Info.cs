using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class Login_Info
    {
        static int ID;
        public static int id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        static string Name;
        public static string emri
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        static string Lastname;
        public static string mbiemri
        {
            get
            {
                return Lastname;
            }
            set
            {
                Lastname = value;
            }
        }

        static string Position;
        public static string pozicioni
        {
            get
            {
                return Position;
            }
            set
            {
                Position = value;
            }
        }

        static int Wage_Hour;
        public static int paga_ore
        {
            get
            {
                return Wage_Hour;
            }
            set
            {
                Wage_Hour = value;
            }
        }
    }
}
