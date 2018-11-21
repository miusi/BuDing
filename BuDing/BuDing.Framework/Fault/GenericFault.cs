using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BuDing.Framework.Fault
{
	[DataContract]
	public class GenericFault
	{
		[DataMember]
		public String ErrorMessage { get; set; }

		[DataMember]
		public String ErrorDetails { get; set; }
	}
}
