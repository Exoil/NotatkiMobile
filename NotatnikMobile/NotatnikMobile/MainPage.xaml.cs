using NotatnikMobile.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotatnikMobile
{
    public partial class MainPage : ContentPage
    {
        OptionMenu list;
        NoteFile checkDir;

        private bool isListShowed;
        public MainPage()
        {
            checkDir = new NoteFile();

            if(checkDir.ChecSourceDirectory() == false)
            {
                checkDir.CreateSourceDirectory();
            }


            list = new OptionMenu();
            InitializeComponent();
            MainMenu.Children.Add(list);
    
            list.toReplace = Edytor;
            list.title = Title;
            
        }

        private void ShowOptions(object sender, EventArgs e)
        {
            if(list.IsVisible == false)
            {
                list.IsVisible = true;
                Edytor.IsEnabled = false;
            }
            else
            {
                list.IsVisible = false;
                Edytor.IsEnabled = true;
            }
        }
    }


  
}
