using NotatnikMobile.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMobile
{
  
    public partial class DeleteNotes : ContentPage
	{

        Editor toLoad;
        Entry fileName;
        DeleteNotes reference;
        public DeleteNotes()
        {
            var fileNote = new  NoteFile();
         
            InitializeComponent();
            var notes = fileNote.LoadFilesToList();
            FileList.ItemsSource = fileNote.LoadFilesToList();

        }
        public DeleteNotes(ref Editor toLoad, ref Entry label)
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

                     File.Delete(notatka.path);            
                     FileList.SelectedItem = null;
                     FileList.ItemsSource = fileNote.LoadFilesToList();

                 }
                 //    
             };


        }


    }
}