using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.ViewModels
{
    public class UsernameViewModel
    {
        public string Userame { get; set; }

        public UsernameViewModel(string userame)
        {
            this.Userame = userame;
        }   
    }
}
