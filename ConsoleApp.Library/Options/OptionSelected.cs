
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library
{
    public class OptionSelected : IOptionSelected
    {
        IOptionSelected optionSelected;

        public User User { get; set; }
        

        public OptionSelected(IOptionSelected optionSelected)
        {
            this.optionSelected = optionSelected;
            //this.User = user;
            //this.LibraryBusinessLogic = lbl;
           

        }

        public void Doing()
        {
            this.optionSelected.Doing();
        }
    }
}
