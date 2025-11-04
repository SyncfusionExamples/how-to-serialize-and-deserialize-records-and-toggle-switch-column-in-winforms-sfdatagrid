using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo
{

    public class OrderInfoCollection
    {
        private List<OrderInfo> _orders;

        public List<OrderInfo> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public OrderInfoCollection()
        {
            _orders = new List<OrderInfo>();
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            _orders.Add(new OrderInfo(1001, "Maria Anders", "Germany", "ALFKI", "Berlin", true, false));
            _orders.Add(new OrderInfo(1002, "Ana Trujilo", "Mexico", "ANATR", "Mexico D.F.", false, true));
            _orders.Add(new OrderInfo(1003, "Antonio Moreno", "Mexico", "ANTON", "Mexico D.F.", true, true));
            _orders.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London", false, true));
            _orders.Add(new OrderInfo(1005, "Christina Berglund", "Sweden", "BERGS", "Lula", true, true));
            _orders.Add(new OrderInfo(1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim", false, false));
            _orders.Add(new OrderInfo(1007, "Frederique Citeaux", "France", "BLONP", "Strasbourg", true, true));
            _orders.Add(new OrderInfo(1008, "Martin Sommer", "Spain", "BOLID", "Madrid", false, false));
            _orders.Add(new OrderInfo(1009, "Laurence Lebihan", "France", "BONAP", "Marseille", true, true));
        }
    }
}
