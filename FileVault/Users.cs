﻿using System;
using System.Collections.Generic;

namespace FileVault
{
    public partial class Users
    {
        public Users()
        {
            UploadFiles = new HashSet<UploadFiles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UploadFiles> UploadFiles { get; set; }
    }
}
