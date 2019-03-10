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

        public SavedNotes ()
        {
            var fileNote = new  NoteFile();
         
            InitializeComponent();
            var notes = fileNote.LoadFilesToList();
            FileList.ItemsSource = fileNote.LoadFilesToList();

        }
        public SavedNotes(ref Editor toLoad, ref Entry label)
        {
            var fileNote = new NoteFile();
            this.toLoad = toLoad;
            fileName = label;
            InitializeComponent();
            var notes = fileNote.LoadFilesToList();
            FileList.ItemsSource = fileNote.LoadFilesToList();

            FileList.ItemSelected += (sender, e) =>
             {
                 var notatka = (Notes)e.SelectedItem;
                 this.fileName.Text = notatka.fileName;

                 var text = System.IO.File.ReadAllText(notatka.path);

                 this.toLoad.Text = text;

                 FileList.SelectedItem = null;

             };


        }


    }
}