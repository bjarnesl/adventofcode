using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace day4
{
    class Program
    {

        static void Main(string[] args)
        {

            RunPart1();
            RunPart2();
        }

        private static void RunPart1()
        {
            var validPassportCounter = 0;
            var input = InputFetcher.GetInputAsString(InputFetcher.day4p1);
            var passports = input.Split(new string[] { "\r\n\r\n" },
                               StringSplitOptions.RemoveEmptyEntries);
            foreach (var passport in passports)
            {
                var pass = new Passport(passport);
                if (pass.ContainsRequiredFields())
                {
                    validPassportCounter++;
                }
            }
            Console.WriteLine($"Part 1: Number of valid passports: {validPassportCounter}");

        }

        private static void RunPart2()
        {
            var validPassportCounter = 0;
            var input = InputFetcher.GetInputAsString(InputFetcher.day4p1);
            var passports = input.Split(new string[] { "\r\n\r\n" },
                               StringSplitOptions.RemoveEmptyEntries);
            foreach (var passport in passports)
            {
                var pass = new Passport(passport);
                if (pass.IsValid())
                {
                    validPassportCounter++;
                }
            }
            Console.WriteLine($"PArt 2: Number of valid passports: {validPassportCounter}");

        }


        internal class Passport
        {
            readonly Dictionary<string,bool> requiredFields = new  Dictionary<string, bool>{ 
                { "byr", false },
                {"iyr", false },
                {"eyr", false },
                {"hgt", false },
                {"hcl",  false },
                {"ecl",  false },
                {"pid" , false }};

            bool byr;
            bool iyr;
            bool eyr;
            bool hgt;
            bool hcl;
            bool ecl;
            bool pid;

          

            private readonly string[] fields;

            public Passport(string passpoertserializer)
            {
                fields = passpoertserializer.Replace("\r\n"," ").Split(' ');
                byr = int.TryParse(FindFieldValue("byr"), out int candidateBirthYear) && candidateBirthYear >= 1920 && candidateBirthYear <= 2002;
                iyr = int.TryParse(FindFieldValue("iyr"), out int candidateIssuedYear) && candidateIssuedYear >= 2010 && candidateIssuedYear <= 2020;
                eyr = int.TryParse(FindFieldValue( "eyr"), out int candidateExpireYear) && candidateExpireYear >= 2020 && candidateExpireYear <= 2030;
                hgt = IsvalidHeight(FindFieldValue("hgt"));
                hcl = Regex.Match(FindFieldValue( "hcl"), "^#(([[a-f0-9]){6})$").Success;
                ecl = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(FindFieldValue("ecl"));
                pid = Regex.Match(FindFieldValue("pid"), "^\\d{9}$").Success;
            }

            public bool IsValid()
            {
                return fields != null && ContainsRequiredFields() && byr && iyr && eyr && hgt && hcl && ecl && pid;
            }
            private string FindFieldValue(string fieldname)
            {
                return fields.Where(e => e.Split(':')[0] == fieldname).Select(e => e.Split(':')[1]).SingleOrDefault() ?? "";
            }
            public bool ContainsRequiredFields()
            {
                foreach (var field in fields)
                {
                    var fieldIdentifiactor = field.Split(':');
                    requiredFields[fieldIdentifiactor[0]] = true;
                }
                return requiredFields.All(d => d.Value == true);
            }

            internal bool IsvalidHeight(string inputheight)
            {
                if (inputheight.EndsWith("cm"))
                {
                    int candidateHeigt;
                    int.TryParse(inputheight.Substring(0, inputheight.Length - 2), out candidateHeigt);
                    return candidateHeigt >=150 && candidateHeigt <= 193;
                }
                if (inputheight.EndsWith("in"))
                {
                    int candidateHeigt;
                    int.TryParse(inputheight.Substring(0, inputheight.Length - 2), out candidateHeigt);
                    return candidateHeigt >= 59 && candidateHeigt <= 76;
                }

                return false;
            }
        }
      
       
       
       
    }
}
