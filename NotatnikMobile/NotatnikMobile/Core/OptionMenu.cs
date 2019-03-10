using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NotatnikMobile.Core
{
    public class OptionMenu : StackLayout
    {
        Button load, save, back;

        public Editor toReplace;
        public Entry title;

        public OptionMenu()
        {

            save = new Button();
            save.Text = "Save";
            save.Clicked += SaveFile;
            load = new Button();
            load.Text = "load";
            load.Clicked += LoadFile;
            back = new Button();
            back.Text = "Back";
            back.Clicked += BackEdit;



            Grid.SetRow(this, 0);
            Grid.SetRowSpan(this, 3);
            Grid.SetColumn(this, 0);
            Grid.SetColumnSpan(this, 2);

            this.Children.Add(save);
            this.Children.Add(load);
            this.Children.Add(back);
            this.BackgroundColor = Color.White;
            IsVisible = false;



        }

        public async void LoadFile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SavedNotes(ref toReplace, ref title));
        }

        public void SaveFile(object sender, EventArgs e)
        {
            var fileName = this.title.Text.ToString(); ;
            var resource = this.toReplace.Text.ToString();
            var fileDir = new NoteFile();
            var path = fileDir.DirectoryPath() + "/" + fileName + ".txt";
            fileDir.SaveNote(path, resource);  
            IsVisible = false;
            toReplace.IsEnabled = true;
        }

        public void BackEdit(object sender, EventArgs e)
        {
            IsVisible = false;
            toReplace.IsEnabled = true;
        }

    }
}
