using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Buoi5_WinForms
{
    //[Serializable] // Cần có để đọc ghi binary ở bản 6.0 
    public class Student
    {
        private string _ID;
        private string _Name;
        private DateTime _Birthday;
        private bool _Gender;
        private string _Adress;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public DateTime Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        public bool Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        public string Adress
        {
            get { return _Adress; }
            set { _Adress = value; }
        }

        public Student()
        {
            _ID = "";
            _Name = "";
            _Birthday = DateTime.Now;
            _Gender = false;
            _Adress = "";
        }

        public Student(string ID, string Name, DateTime Birthday, bool Gender, string Adress) { 
            _ID = ID;
            _Name = Name;
            _Birthday = Birthday;
            _Gender = Gender;
            _Adress = Adress;
        }
    }
}
