using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    internal class Calculator
    {
        private Dictionary<string, IOperation> _operations = new Dictionary<string, IOperation>();

        public void RegisterOperation(string symbol, IOperation operation)
        {
            _operations[symbol] = operation;
        }

        public bool CheckIfOperationSymbolRegistered(string symbol)=> _operations.ContainsKey(symbol);

        public List<string> GetRegisteredOperatorsSymbols() => [.. _operations.Keys];


        public double ExecuteOperation(double operand1, double operand2, string symbol)
        {
            if (!CheckIfOperationSymbolRegistered(symbol))
            {
                throw new NotImplementedException($"Operation with symbol {symbol} not registered!");
            }

            return _operations[symbol].Execute(operand1, operand2);
        }
    }
}
