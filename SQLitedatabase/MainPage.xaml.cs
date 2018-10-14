using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLitedatabase.Entity;
using SQLitedatabase.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SQLitedatabase
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Song> listSong;
        internal ObservableCollection<Song> ListSong { get => listSong; set => listSong = value; }
        SongModel songModel = new SongModel();
        public MainPage()
        {

            this.InitializeComponent();
            this.ListSong = new ObservableCollection<Song>();

            List<Song> songList = SongModel.GetSongList();
            foreach (var music in songList)
            {
                this.listSong.Add(music);
            }





        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                Song song = new Song()
                {
                    Name = this.txt_name.Text,
                    Thumbnail = this.txt_thumbnail.Text
                };
                SongModel.AddData(song);
                Debug.WriteLine("Sucesss");
                this.txt_name.Text = String.Empty;
                this.txt_thumbnail.Text = String.Empty;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            this.txt_name.Text = String.Empty;
            this.txt_thumbnail.Text = String.Empty;
        }
    }
}
