namespace CalculatorApp.Operations
{
    internal class DivideOperation : IOperation
    {
        public double Execute(double operand1, double operand2)
        {
            if (operand2 == 0)
            {
                throw new DivideByZeroException("Can't devide by zero!");
            }

            return operand1 / operand2;
        }
    }
}
