using API.Extension;
using System;
using System.Collections.Generic;

namespace API.Models
{
    public class InsumoOutput
    {
        public InsumoOutput() { }
        public InsumoOutput(InsumoInput insumo)
        {
            if (insumo != null)
            {
                Type = insumo.Location?.State?.Region();
                Gender = insumo.Gender?.UpperFirst();
                Name = insumo.Name;
                Location = insumo.Location;
                Email = insumo.Email;
                Birthday = insumo.Dob?.Date ?? DateTime.MinValue;
                Registered = insumo.Registered?.Date ?? DateTime.MinValue;
                TelephoneNumbers = new List<string>() { insumo.Phone.E164() };
                MobileNumbers = new List<string>() { insumo.Cell.E164() };
                Picture = insumo.Picture;
            }
        }

        public string Type { get; set; }
        public string Gender { get; set; }
        public Name Name { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Registered { get; set; }
        public IEnumerable<string> TelephoneNumbers { get; set; }
        public IEnumerable<string> MobileNumbers { get; set; }
        public Picture Picture { get; set; }
        public string Nationality => "BR";
    }
}