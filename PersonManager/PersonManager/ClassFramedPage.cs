using PersonManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PersonManager
{
    public class ClassFramedPage : Page
    {
        public ClassFramedPage(ClassViewModel? viewModel)
        {
            ClassViewModel = viewModel;
        }

        public ClassViewModel? ClassViewModel { get;}
        public Frame? Frame { get; set;}
    }
}
