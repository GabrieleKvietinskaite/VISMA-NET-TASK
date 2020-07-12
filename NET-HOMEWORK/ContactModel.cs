using System;
using System.Collections.Generic;
using System.Text;

namespace NET_HOMEWORK
{
    public class ContactModel
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public List<long> PhoneNumbers { set; get; }
        public string Address { set; get; }
    }
}
