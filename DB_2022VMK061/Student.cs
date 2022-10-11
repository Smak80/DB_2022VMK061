using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DB_2022VMK061
{
    /*public class Student : INotifyPropertyChanged
    {
        private int id;
        private string firstName;
        private string lastName;
        private string group;
        private double rating;
        private DateTime birth;
        private bool gender;

        [DisplayName("Номер п/п")]
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Имя")]
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Фамилия")]
        public string LastName
        {
            get => lastName;
            set {
                lastName = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Номер группы")]
        public string Group { get => group;
            set
            {
                group = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Средний балл")]
        public double Rating
        {
            get => rating;
            set
            {
                rating = value; 
                OnPropertyChanged();
            }
        }

        [DisplayName("Дата рождения")]
        public DateTime Birth { get => birth;
            set
            {
                birth = value; 
                OnPropertyChanged();
            }
        }
        [DisplayName("Муж.")]
        public bool Gender { get => gender;
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }
        public Student(
            int id,
            string firstName,
            string lastName,
            string group,
            double rating,
            DateTime birth,
            bool gender
            )
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.group = group;
            this.rating = rating;
            this.birth = birth;
            this.gender = gender;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }*/
    public class Student : INotifyPropertyChanged
    {
        private int id;
        private string firstName;
        private string lastName;
        private string group;
        private double rating;
        private DateTime birth;
        private bool gender;

        [DisplayName("Номер п/п")]
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Имя")]
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Фамилия")]
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Номер группы")]
        public string Group
        {
            get => group;
            set
            {
                group = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Средний балл")]
        public double Rating
        {
            get => rating;
            set
            {
                rating = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Дата рождения")]
        public DateTime Birth
        {
            get => birth;
            set
            {
                birth = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Муж.")]
        public bool Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }
        public Student(
            int id,
            string firstName,
            string lastName,
            string group,
            double rating,
            DateTime birth,
            bool gender
            )
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.group = group;
            this.rating = rating;
            this.birth = birth;
            this.gender = gender;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
