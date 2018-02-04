using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]

    public class GroupRemovalTests : TestBase
    {
        [Test]

        public void GroupRemoveTest()
        {
            GroupData group = new GroupData()
            {
                Name = "Test"
            };
            
            if (app.Groups.CheckNotSingleGroupPresent().Count() < 2)
            {
                //app.Groups.CloseGroupDialogue();
                app.Groups.AddGroup(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[1];
            //Actions
            app.Groups.RemoveGroup(toBeRemoved);

            //Comparing lists before and after removal
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(1);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
