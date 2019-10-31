using System.Collections.Generic;
using DotMailerCore.Models.Types;

namespace DotMailerCore.Models
{
	public class AddressBook
	{
		public int Id { get; set; }

        public string Name { get; set; }

        public AddressBookVisibility Visibility { get; set; }

        public int Contacts { get; set; }
    }
}
