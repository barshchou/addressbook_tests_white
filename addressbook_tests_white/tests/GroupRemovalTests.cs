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
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData group = new GroupData()
            {
                Name = "Test"
            };
            
            if (app.Groups.CheckNotSingleGroupPresent().Count() < 2)
            {
                //app.Groups.CloseGroupDialogue();
                app.Groups.AddGroup(group);
            }

            //Actions
            app.Groups.RemoveGroup();

            //Comparing lists before and after removal
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
