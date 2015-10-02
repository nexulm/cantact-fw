
using System;
using System.Collections.Generic;

namespace CANtact
{
	public enum CanFrameType
	{
		CAN_RTR_DATA,
		CAN_RTR_REMOTE,
		CAN_RTR_UNKNOWN
	}

	public enum CanIdType
	{
		CAN_ID_STD,
		CAN_ID_EXT,
		CAN_ID_UNKNOWN
	}

	public class CANPackage
	{
		public CanFrameType FrameType = CanFrameType.CAN_RTR_UNKNOWN;
		public CanIdType IdType = CanIdType.CAN_ID_UNKNOWN;
		public UInt32 ID;
		public UInt16 DLC;
		public byte[] Data = new byte[8];
		public UInt32 Delay { get; set; }
		public UInt32 Count { get; set; }
		public bool Use { get; set; }

		public CANPackage()
		{
		}

		public string[] ToStrings()
		{
			return ToStrings(0);
		}

		public string[] ToStrings(int count)
		{
			List<string> strings = new List<string>(15);
			strings.Add("RX");
			strings.Add("0x" + ID.ToString("X4"));
			strings.Add(FrameType == CanFrameType.CAN_RTR_DATA ? "DATA" : "REM");
			strings.Add(DLC.ToString());
			for(int idx = 0; idx < Data.Length; idx++)
			{
				if (idx < DLC)
					strings.Add("0x" + Data[idx].ToString("X2"));
				else
					strings.Add(string.Empty);
			}
			strings.Add(count.ToString());
			return strings.ToArray();
		}
	}
}
