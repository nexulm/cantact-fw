using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CANtact
{
	public class TraceRow
	{
		public string RxTx { get; set; }
		public string ID { get; set; }
		public string RTR { get; set; }
		public int DLC { get; set; }
		public TraceRow()
		{
		}
	}
}
