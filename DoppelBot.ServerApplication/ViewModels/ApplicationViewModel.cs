using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoppelBot.ServerApplication.ViewModels
{
    public class ApplicationViewModel
    {
        public Dictionary<string, UserControl> Pages { get; }

        public UserControl CurrentPage { get; set; }

        public ApplicationViewModel()
        {
            
        }
    }
}
