using System;
using System.ComponentModel;
using System.Linq;
using PropertyChanged;
using TradeViewer.Commands;
using TradeViewer.Core;

namespace TradeViewer.ViewModels
{
    [ImplementPropertyChanged]
    public class AddTradeViewModel : IDataErrorInfo
    {
        private readonly Trade trade;
        public AddTradeViewModel(Trade trade)
        {
            this.trade = trade;

            SaveCommand = new RelayCommand<object>(x => SaveTrade(), x => CanSave);
        }
        public Trade Trade { get { return trade; } }

        public string Security
        {
            get { return trade.Security; }
            set { trade.Security = value; }
        }
        public decimal Quantity
        {
            get { return trade.Quantity; }
            set { trade.Quantity = value; }
        }

        public RelayCommand<object> SaveCommand { get; private set; }

        public bool? DialogResult { get; set; }

        private bool CanSave
        {
            get
            {
                return TypeDescriptor.GetProperties(trade.GetType())
                    .Cast<PropertyDescriptor>()
                    .All(x => string.IsNullOrEmpty(this[x.Name]));
            }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Security":
                        {
                            if (string.IsNullOrWhiteSpace(Security))
                                return "Security Name cannot be empty";
                            break;
                        }
                    case "Quantity":
                        {
                            if (Quantity <= 0)
                                return "Quantity should be greater than zero";
                            break;
                        }
                }
                return string.Empty;
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public void SaveTrade()
        {
            if (CanSave)
            {
                DialogResult = true;
            }
        }
    }
}
