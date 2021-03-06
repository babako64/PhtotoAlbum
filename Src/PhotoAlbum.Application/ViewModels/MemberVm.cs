using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application.ViewModels
{
    public class MemberVm
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public AddressVm Address { get; set; }

        public ICollection<PhotoVm> Photos { get; set; }

    }
}
