using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Demo.PrismWPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IEventAggregator EventAggregator;
        private readonly IRegionManager RegionManager;
        public MainWindowViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            //this.EventAggregator = eventAggregator;

            this.RegionManager = regionManager;

            //OpenCommand = new DelegateCommand(() =>
            //{
            //    this.EventAggregator.GetEvent<MessageEvent>()
            //    //.Subscribe(OnMessageReceived); //不使用过滤器
            //    .Subscribe(OnMessageReceived, ThreadOption.PublisherThread, false, msg =>
            //    {
            //        // 过滤器
            //        if (msg == "Hello")
            //        {
            //            return false;
            //        }
            //        return true;
            //    });
            //    //Title += "Update text \r\n";
            //});


            //SendCommand = new DelegateCommand(() =>
            //{
            //    this.EventAggregator.GetEvent<MessageEvent>().Publish("Hello");

            //    this.EventAggregator.GetEvent<MessageEvent>().Unsubscribe(OnMessageReceived);

            //});


            OpenACommand = new DelegateCommand(() =>
            {
                RegionManager.RequestNavigate("ContentRegion", "UCA");
            });

            OpenBCommand = new DelegateCommand(() =>
            {
                RegionManager.RequestNavigate("ContentRegion", "UCB");
            });
            //OpenCommand1 = new DelegateCommand(() =>
            //{
            //    Title += "Update text 1 \r\n";
            //});


            //OpenAll = new CompositeCommand();

            //OpenAll.RegisterCommand(OpenCommand);
            //OpenAll.RegisterCommand(OpenCommand1);
        }

        public void OnMessageReceived(string message)
        {
            Title += message + "\r\n";
        }

        private string _title = "Prism Application\r\n";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand OpenCommand { get; private set; }

        public DelegateCommand OpenACommand { get; private set; }

        public DelegateCommand OpenBCommand { get; private set; }

        public DelegateCommand SendCommand { get; private set; }

        //public DelegateCommand OpenCommand1 { get; private set; }

        //public CompositeCommand OpenAll { get; private set; }
    }

    public class MessageEvent : PubSubEvent<string>
    {
    }
}
