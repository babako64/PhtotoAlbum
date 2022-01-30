﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application.RequestModel
{
    public class MemberModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public AddressModel Address { get; set; }

        public ICollection<PhotoModel> Photos { get; set; }
    }
}
