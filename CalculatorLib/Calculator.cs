using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleCalculatorLibrary
{
	public class Calculator : ICalculator
	{
		private readonly List<string> _priorityOperationsList = new List<string>{"*", "/", "**", "%"};
		private readonly List<IOperation> _supportedOperationsList;

		public Calculator(List<IOperation> operationsList)
		{
			this._supportedOperationsList = operationsList;
		}

		public Result calculate(string s)
		{
			s = this._calculatePriority(s);

			Node node = this._parseNode(ref s);

			if (!node.bCompleted && this._isNumber(s))
				return new Result(int.Parse(s));

			if (!this._nodeValidation(ref node))
				return new Result(1, "invalid operand");

			IOperation operation = this._supportedOperationsList.Find(x => x.sOperator == node.sOperator);

			if (operation == null)
				return new Result(1, "incorrect operation");

			Result result = operation.apply(int.Parse(node.sLeftOperand), int.Parse(node.sRightOperand));

			if (result.iCode != 0)
				return result;

			return this.calculate(result.iValue.ToString() + s);
		}

		private	Node _parseNode(ref string s)
		{
			string[] list = Regex.Replace(s, @"([\d]+)", "'$1'").Split(new[] {'\''}, StringSplitOptions.RemoveEmptyEntries);
			
			if (list.Length < 3)
				return new Node();

			s = this._replaceFirst(s, list[0] + list[1] + list[2], "");

			return new Node(list[0], list[1], list[2]);
		}

		public string _replaceFirst(string s, string oldValue, string newValue)
		{
			int startindex = s.IndexOf(oldValue);

			if (startindex == -1)
				return s;

			return s.Remove(startindex, oldValue.Length).Insert(startindex, newValue);
		}

		private string _calculatePriority(string s)
		{
			/*
				Opening brackets.
			*/
			while (true)
			{
				string sPriority = this._getParenthesesExpression(s);
				if (sPriority == s)
					break;
				s = s.Replace("(" + sPriority + ")", this.calculate(sPriority).iValue.ToString());
			}

			/*
				Multiplication, division and other priority operations.
			*/
			while (true)
			{
				string sPriority = this._getPriorityOperation(s);
				if (sPriority == s)
					break;
				s = s.Replace(sPriority, this.calculate(sPriority).iValue.ToString());
			}
		
			return s;
		}

		private string _getParenthesesExpression(string s)
		{
			string sRes = "";

			bool bFirstLeftParenthesis = false;
			
			int iLeftParenthesesCounter = 0;
			int iRightParenthesesCounter = 0;

			for (int i = 0; i < s.Length; ++i)
			{
				if (s[i] == '(')
				{
					if (!bFirstLeftParenthesis)
						bFirstLeftParenthesis = true;
					else
						iLeftParenthesesCounter++;
				}

				if (s[i] == ')')
				{
					if (iRightParenthesesCounter == iLeftParenthesesCounter)
					{
						if (sRes[sRes.Length - 1] == ')')
							sRes = sRes.Remove(sRes.Length - 1);
						return sRes;
					}
					iRightParenthesesCounter++;
				}

				if (bFirstLeftParenthesis && i + 1 <= s.Length - 1)
					sRes += s[i + 1];
			}

			return s;
		}

		private string _getPriorityOperation(string s)
		{
			string[] list = Regex.Replace(s, @"([\d]+)", "'$1'").Split(new[] {'\''}, StringSplitOptions.RemoveEmptyEntries);
			
			for (int i = 0; i < list.Length; ++i)
				if (this._priorityOperationsList.Find(x => x == list[i]) != null)
					return list[i - 1] + list[i] + list[i + 1];

			return s;
		}

		private bool _isNumber(string s) {return int.TryParse(s, out int iOut);}
		private bool _nodeValidation(ref Node node) {return this._isNumber(node.sLeftOperand) && this._isNumber(node.sRightOperand);}
	}
}