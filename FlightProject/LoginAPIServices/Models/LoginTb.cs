﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LoginAPIServices.Models
{
    public partial class LoginTb
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
