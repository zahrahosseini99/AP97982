using System;
using System.Collections.Generic;

namespace A14
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    public class ComputeState : CalculatorState
    {
        public ComputeState(Calculator calc) : base(calc) { }

        public override IState EnterEqual()
        {
            Calc.DisplayError("Syntax Error");
            return new ErrorState(this.Calc);
        }

        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display +=$"{Calc.PendingOperator}{c.ToString()}";
          
            return new AccumulateState(this.Calc);
        }

        public override IState EnterZeroDigit()
       => EnterNonZeroDigit('0');
       

        // #5 لطفا
        public override IState EnterOperator(char c)
        {
           
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