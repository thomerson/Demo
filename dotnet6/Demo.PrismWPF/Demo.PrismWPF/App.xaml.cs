using Demo.PrismWPF.UC;
using Demo.PrismWPF.Views;
using Prism.Ioc;
using System.Windows;

namespace Demo.PrismWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册导航
            containerRegistry.RegisterForNavigation<UCA>();
            containerRegistry.RegisterForNavigation<UCB>();
        }
    }
}
