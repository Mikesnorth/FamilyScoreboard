﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyScoreboard.Models {
    public class Chore {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointValue { get; set; }
    }
}
