﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
