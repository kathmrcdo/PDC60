using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace PDC60_REST_API
{
    public class Post
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string userpassword { get; set; }
        public string email { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        private const string url = "http://172.16.20.7/pdc60/api_r.php";
        private const string url_create = "http://172.16.20.7/PDC60/api_create.php";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Post> _post;
        public MainPage()
        {
            InitializeComponent();
        }
        //Retrive Records
        protected override async void OnAppearing()
        {
            var content = await _Client.GetStringAsync(url);

            var post = JsonConvert.DeserializeObject<List<Post>>(content);
            _post = new ObservableCollection<Post>(post);
            Post_List.ItemsSource = _post;
            base.OnAppearing();
        }

        private async void OnAdd(object sender, System.EventArgs e)
        {
            Post post = new Post { username = xName.Text, email = xEmail.Text };
            var content = JsonConvert.SerializeObject(post);
            await _Client.PostAsync(url_create, new StringContent(content, Encoding.UTF8, "application/json"));
            _post.Insert(0, post);
        }
    }
}
