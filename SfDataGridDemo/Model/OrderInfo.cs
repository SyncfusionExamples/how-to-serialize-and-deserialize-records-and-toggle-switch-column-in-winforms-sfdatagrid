using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo
{
    public class OrderInfo : INotifyPropertyChanged
    {
        private int orderID;
        private string customerId;
        private string country;
        private string customerName;
        private string shippingCity;
        private bool isActive;
        private bool isChecked;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int OrderID
        {
            get => orderID;
            set
            {
                if (orderID != value)
                {
                    orderID = value;
                    OnPropertyChanged(nameof(OrderID));
                }
            }
        }

        public string CustomerID
        {
            get => customerId;
            set
            {
                if (customerId != value)
                {
                    customerId = value;
                    OnPropertyChanged(nameof(CustomerID));
                }
            }
        }

        public string CustomerName
        {
            get => customerName;
            set
            {
                if (customerName != value)
                {
                    customerName = value;
                    OnPropertyChanged(nameof(CustomerName));
                }
            }
        }

        public string Country
        {
            get => country;
            set
            {
                if (country != value)
                {
                    country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }

        public string ShipCity
        {
            get => shippingCity;
            set
            {
                if (shippingCity != value)
                {
                    shippingCity = value;
                    OnPropertyChanged(nameof(ShipCity));
                }
            }
        }

        public bool IsActive
        {
            get => isActive;
            set
            {
                if (isActive != value)
                {
                    isActive = value;
                    OnPropertyChanged(nameof(IsActive));
                }
            }
        }

        public bool IsChecked
        {
            get => isChecked;
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }

        public OrderInfo()
        {

        }

        public OrderInfo(int orderId, string customerName, string country, string customerId, string shipCity, bool isActive, bool isChecked)
        {
            OrderID = orderId;
            CustomerName = customerName;
            Country = country;
            CustomerID = customerId;
            ShipCity = shipCity;
            IsActive = isActive;
            IsChecked = isChecked;
        }
    }
}
