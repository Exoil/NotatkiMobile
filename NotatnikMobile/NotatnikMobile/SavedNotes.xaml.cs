using NotatnikMobile.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMobile
{
  
    public partial class SavedNotes : ContentPage
	{

        Editor toLoad;
        Entry fileName;
        SavedNotes reference;
        public SavedNotes ()
        {
            var fileNote = new  NoteFile();
         
            InitializeComponent();
            var notes = fileNote.LoadFilesToList();
            FileList.ItemsSource = fileNote.LoadFilesToList();

        }
        public SavedNotes(ref Editor toLoad, ref Entry label)
        {

            reference = this;
            var fileNote = new NoteFile();
            this.toLoad = toLoad;
            fileName = label;
            InitializeComponent();
            var notes = fileNote.LoadFilesToList();
            FileList.ItemsSource = fileNote.LoadFilesToList();

            FileList.ItemSelected += (sender, e) =>
             {
                 var notatka = (Notes)e.SelectedItem;
                 if (notatka != null)
                 {
                     if (notatka.fileName == null)
                     {
                         fileName.Text = " ";

                     }
                     else
                     {
                         this.fileName.Text = notatka.fileName;
                     }


                     var text = System.IO.File.ReadAllText(notatka.path);

                     if (text == null)
                     {
                         this.toLoad.Text = "";
                     }
                     else
                     {
                         this.toLoad.Text = text;
                     }


                     FileList.SelectedItem = null;
                     Navigation.RemovePage(reference);

                 }
                 //    
             };


        }


    }
}