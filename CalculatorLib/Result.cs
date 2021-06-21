namespace SimpleCalculatorLibrary
{
	public struct Result
	{
		public int iValue;
		public int iCode;

		public string sMessage;

		public Result(int iValue)
		{
			this.iValue = iValue;
			this.iCode = 0;
			this.sMessage = "OK";
		}

		public Result(int iCode, string sMessage)
		{
			this.iValue = 0;
			this.iCode = iCode;
			this.sMessage = sMessage;
		}
	}
}