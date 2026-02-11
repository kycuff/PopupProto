using Microsoft.Extensions.DependencyInjection;
using PopupProto;

namespace PopupProto
{
    public partial class App : Application
    {
        readonly IServiceProvider _serviceProvider;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
        }

        protected override Window CreateWindow(IActivationState? activationState) => new(new NavigationPage(_serviceProvider.GetRequiredService<MainPage>()));
    }
}