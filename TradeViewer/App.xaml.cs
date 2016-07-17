using System;
using System.Windows;
using TradeViewer.Infrastructure.Data;
using TradeViewer.Services;
using TradeViewer.ViewModels;
using TradeViewer.Views;

namespace TradeViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var viewModel = new MainViewModel(
                new PriceSource(new RandomPriceGenerator()),
                new TradeModifyService(),
                new TradeRepository());

            MainWindow= new MainWindow(viewModel);
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
