using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3Oblig1Redone
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private int _id;
        private int _birthYear;
        private int _deathYear;

        public string FirstName;
        public string LastName;
        public int Id;
        public int BirthYear;
        public int DeathYear;
        public Person Father;
        public Person Mother;

        public string GetDescription()
        {
            if (FirstName != null && LastName != null && Id != 0 && BirthYear != 0 && DeathYear != 0 &&
                Father != null && Mother != null)
            {
                return $"{FirstName} {LastName} (Id={Id}) Født: {BirthYear} Død: {DeathYear} Far: {Father.ToString()} Mor: {Mother.ToString()}";
            }
            var str = GetNullString(FirstName, LastName, Id, BirthYear, DeathYear);
            if (Father != null) str += $"Far: {Father.ToString()}";
            if (Mother != null) str += $"Mor: {Mother.ToString()}";

            return str.TrimEnd();

        }

        private string GetNullString(string firstName = null, string lastName = null, int? id = null, int? birthYear = null, int? deathYear = null)
        {
            _firstName = firstName ?? _firstName;
            _lastName = lastName ?? _lastName;
            _id = id ?? _id;
            _birthYear = birthYear ?? _birthYear;
            _deathYear = deathYear ?? _deathYear;
            var str = GetCorrectOutput(_firstName, _lastName, _id, _birthYear, _deathYear);
            return str;
        }

        private string GetCorrectOutput(string firstName, string lastName, int id, int birthYear, int deathYear)
        {
            var str = "";
            str += firstName == null ? "" : firstName + " ";
            str += lastName == null ? "" : lastName + " ";
            str += id == 0 ? "" : "(Id=" + Convert.ToString(id) + ") ";
            str += birthYear == 0 ? "" : "Født: " + Convert.ToString(birthYear) + " ";
            str += deathYear == 0 ? "" : "Død: " + Convert.ToString(deathYear) + " ";
            return str;
        }
        public override string ToString()
        {
            return $"{FirstName} (Id={Id})";
        }
    }
}
