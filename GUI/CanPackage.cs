
using System;
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

	public class CanPackage
	{
		public CanFrameType FrameType = CanFrameType.CAN_RTR_UNKNOWN;
		public CanIdType IdType = CanIdType.CAN_ID_UNKNOWN;
		public UInt32 ID;
		public UInt16 DLC;
		public byte[] Data = new byte[8];

		public CanPackage()
		{
		}
	}
}
