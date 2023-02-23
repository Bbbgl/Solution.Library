using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library
{
    public class Menu: IMenu
    {
        IMenu menu;

        public Menu (IMenu menu)
        {
            this.menu = menu;
        }

        public void Show()
        {
            this.menu.Show();
        }
    }
}
