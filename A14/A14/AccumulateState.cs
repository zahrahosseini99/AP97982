using System;
using System.Collections.Generic;
using static System.Console;

namespace A14
{
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }


        public override IState EnterEqual()
        {

            string newDisplay = Calc.Display.Split(Calc.PendingOperator.Value)[1];
            Calc.Display = newDisplay;

            return ProcessOperator(new ComputeState(this.Calc), '=');
        }
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display += c.ToString();
            return new AccumulateState(this.Calc);
        }


        public override IState EnterOperator(char c)
        {
            if (Calc.PendingOperator != null)
            {
                Calc.Display = Calc.Display.Split('+', '-', '*', '^')[1];
            }

            return ProcessOperator(new ComputeState(this.Calc), c);
        }


        public override IState EnterPoint()
        {
            if (!this.Calc.Display.Contains("."))
                this.Calc.Display += ".";
            return new PointState(this.Calc);
        }
    }
}