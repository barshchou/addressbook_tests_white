﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace addressbook_tests_white
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITTLE = "Free Address Book";
        

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
        }
    }
}