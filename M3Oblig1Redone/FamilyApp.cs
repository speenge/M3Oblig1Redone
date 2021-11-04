using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3Oblig1Redone
{
    public class FamilyApp
    {
        private static List<Person> _people;
        public string CommandPrompt;
        public string WelcomeMessage = HelpText();

        public FamilyApp(params Person[] people)
        {
            _people = new List<Person>(people);
        }

        private static string HelpText()
        {
            string Text = @"hjelp => viser en hjelpetekst som forklarer alle kommandoene
liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. 
vis <id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem)";
            return Text;
        }

        public string HandleCommand(string command)
        {
            string res = "";
            string[] input1 = command.Split(" ");
            string ainput = input1[0];
            string val = "";
            if (input1.Length > 1)
            {
                val = input1[1];
            }

            res = ainput switch
            {
                "hjelp" => HelpText(),
                "liste" => GetList(),
                "vis" => Show(val),
                _ => "ikke eksisterende komando prøv \"hjelp\""
            };

            for (int i = 0; i < input1.Length; i++)
            {
                int indexToRemove = i;
                command.Where((source, index) => index != indexToRemove).ToArray();
            }

            return res;
        }
        private static string GetList(){
        var t = _people;
        string res = "";
            foreach (var val in t)
            {
            res += val.GetDescription() + "\n";
            }

            return res;
        }
        // vis 4 - viser person med id 4 og barnene hvis unger eksisterer.

        private static string Show(string val)
        {
            bool valid = false;
            var t = _people;
            string res = "";
            foreach (char c in val)
            {
                valid = char.IsDigit(c);
            }

            if (valid)
            {
                var p = t.FirstOrDefault(item => item.Id == Convert.ToInt32(val));
                res = p != null ? $"{p.GetDescription()}{GetChild(p.Id)}" : "denne personen eksisterer ikke enda prøv \"vis\"";
            }
            else res = "Please enter a digit";

            return res;
        }

        private static string GetChild(int id)
        {
            var str = "";
            var person = _people.Find(item => item.Id == id);
            List<Person> f,m, ChildrenList = new();
            f = _people.FindAll(item => item.Father != null && item.Father.Id == person.Id);
            m = _people.FindAll(item => item.Mother != null && item.Mother.Id == person.Id);
            ChildrenList = m.Concat(f).ToList();
            if (ChildrenList.Count != 0) str += $"\n  Barn:\n";
            if (ChildrenList.Count != 0) foreach (var a in ChildrenList) str += $"    {a.FirstName} (Id={a.Id}) Født: {a.BirthYear}\n";
            ChildrenList.Clear();
        

            return str;
        }


    }
}
