using App.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Feature.MyName.Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyNameView : ContentView
    {
        public MyNameView()
        {
            InitializeComponent();

            BindingContext = ServiceProviderContainer.GetService<MyNameViewModel>();
        }
    }
}