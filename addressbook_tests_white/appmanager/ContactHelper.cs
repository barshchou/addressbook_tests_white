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
using TestStack.White.UIItems.TableItems;
using TestStack.White.AutomationElementSearch;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;

namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTWINTITTLE = "Contact Editor";

        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void AddContact(ContactData newContact)
        {
            Window dialogue = OpenContactDialogue();

            TextBox firstNametextBox = (TextBox)dialogue.Get(SearchCriteria.ByAutomationId("ueFirstNameAddressTextBox"));
            firstNametextBox.Enter(newContact.Firstname);
            TextBox lastNametextBox = (TextBox)dialogue.Get(SearchCriteria.ByAutomationId("ueLastNameAddressTextBox"));
            lastNametextBox.Enter(newContact.Lastname);

            CloseContactDialogue(dialogue);
        }

        public void RemoveContact()
        {
            Table dataGrid = manager.MainWindow.Get<Table>(SearchCriteria.ByControlType(ControlType.Table));
            dataGrid.Rows[0].Click();
            manager.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("uxDeleteAddressButton")).Click();
            Window question = manager.MainWindow.ModalWindow("Question");
            question.Get<Button>(SearchCriteria.ByControlType(ControlType.Button).AndByText("Yes")).Click();
        }

        public Window OpenContactDialogue()
        {
            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            return manager.MainWindow.ModalWindow(CONTACTWINTITTLE);
        }

        public void CloseContactDialogue(Window dialogue)
        {
            dialogue.Get<Button>(SearchCriteria.ByAutomationId("uxSaveAddressButton")).Click();
        }

        public List<TableRow> CheckNotSingleContactPresent()
        {
            Table dataGrid = manager.MainWindow.Get<Table>(SearchCriteria.ByControlType(ControlType.Table));
            List<TableRow> rows = new List<TableRow>();
            
            foreach (TableRow tableRows in dataGrid.Rows)
            {
                rows.Add(tableRows);
            }
            return rows;
        }
        
        public List<TableRow> GetContactList()
        {
            Table dataGrid = manager.MainWindow.Get<Table>(SearchCriteria.ByControlType(ControlType.Table));
            
            List<TableRow> rows = new List<TableRow>();
            
            foreach (TableRow tableRows in dataGrid.Rows)
            {
                string firstname = tableRows.Cells[0].Value.ToString();
                string lastname = tableRows.Cells[1].Value.ToString();
                rows.Add(new ContactData()
                {
                    Firstname = firstname,
                    Lastname = lastname
                });
            }
            return rows;
        }
        
        //Firstname locator - ueFirstNameAddressTextBox
        //Lastname locator - ueLastNameAddressTextBox
        //Save and close button - uxSaveAddressButton

    }
}
