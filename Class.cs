using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordering_system
{
	public class Address
	{
		public int addressID { get; set; }
		public int customerID { get; set; }
		public string houseNumber {  get; set; }
		public string streetName { get; set; }
		public string village { get; set; }
		public string city { get; set; }
		public string postcode { get; set; }
		public string deliveryCharge { get; set; }
		string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\benny\\Documents\\CS\\NEA\\ordering system\\ordering system.accdb\";Persist Security Info=True";
	}

	//public List<Address> getAddressesForCustomer()
}
