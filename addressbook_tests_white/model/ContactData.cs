using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_white
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
          public String Firstname { get; set; }

          public String Lastname { get; set; }

          public int CompareTo(ContactData other)
          {
                if (Object.ReferenceEquals(other, null))
                {
                    return 1;
                }

                if (Lastname.CompareTo(other.Lastname) == 0)
                {
                    return Firstname.CompareTo(other.Firstname);
                }
                else
                return Lastname.CompareTo(other.Lastname);

            //return this.Firstname.CompareTo(other.Firstname);
          }

          public bool Equals(ContactData other)
          {
                if (Object.ReferenceEquals(other, null))
                {
                    return false;
                }
                if (Object.ReferenceEquals(this, other))
                {
                    return true;
                }
                return Firstname == other.Firstname && Lastname == other.Lastname;

            //return this.Firstname.Equals(other.Firstname);
          }
    }
}
