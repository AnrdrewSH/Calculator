namespace SimpleCalculatorLibrary
{
	public struct Node
	{
		public string sLeftOperand;
		public string sOperator;
		public string sRightOperand;

		public bool bCompleted;

		public Node(string sLeftOperand, string sOperator,  string sRightOperand)
		{
			this.sLeftOperand = sLeftOperand;
			this.sOperator = sOperator;
			this.sRightOperand = sRightOperand;

			this.bCompleted = true;
		}
	}
}