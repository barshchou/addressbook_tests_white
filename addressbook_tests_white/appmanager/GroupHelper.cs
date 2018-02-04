using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITTLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];

            foreach(TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
            CloseGroupDialogue(dialogue);
            return list;
        }

        public void AddGroup(GroupData newGroup) 
        {
            Window dialogue = OpenGroupDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            CloseGroupDialogue(dialogue);
        }

        public void CloseGroupDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        public void CloseGroupDialogue()
        {
            manager.MainWindow.ModalWindow(GROUPWINTITTLE).Get<Button>("uxCloseAddressButton").Click(); 
            
        }

        public Window OpenGroupDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITTLE);
        }

        public void RemoveGroup(GroupData group)
        {
            Window dialogue = OpenGroupDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            List<TreeNode> nodes = new List<TreeNode>();

            foreach (TreeNode treeItem in root.Nodes)
            {
                if (treeItem.Name == group.Name)
                {
                    treeItem.Click();
                }
            }
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            dialogue.Get<Button>("uxOKAddressButton").Click();

            CloseGroupDialogue(dialogue);
        }

        public List<TreeNode> CheckNotSingleGroupPresent()
        {
            Window dialogue = OpenGroupDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];

            List<TreeNode> nodes = new List<TreeNode>();

            foreach (TreeNode treeItem in root.Nodes)
            {
                nodes.Add(treeItem);
            }
            
            CloseGroupDialogue(dialogue);
            return nodes;
        }
    }
}