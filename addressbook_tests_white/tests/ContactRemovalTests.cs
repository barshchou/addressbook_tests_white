using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactDeleteTest()
        {
            ContactData contact = new ContactData()
            {
                Firstname = "Test_firstname",
                Lastname = "Test_lastname"
            };

            
            if (app.Contacts.CheckNotSingleContactPresent().Count() == 0)
            {
                //app.Groups.CloseGroupDialogue();
                app.Contacts.AddContact(contact);
            }
            
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];

            //Actions
            app.Contacts.RemoveContact();

            //Comparing lists before and after removal
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            
        }
    }
}
