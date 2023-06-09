﻿using System.Collections.Generic;

namespace ContactRegister.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string PersonalPhone { get; set; }
        public string CommercialPhone { get; set; }
        public List<Email> Emails { get; set; } = new List<Email>();
    }
}
