using System;

namespace A14
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// </summary>
    public class StartState : CalculatorState
    {
        public StartState(Calculator calc) : base(calc) { }
        // وارد شدن دکمه ی مساوی این متود فراخوانی میشود
        public override IState EnterEqual() =>
            ProcessOperator(new ComputeState(this.Calc));
        //با وارد شدن دکمه صفر به این حالت در می اید و این متود فراخوانده میشود
        public override IState EnterZeroDigit()
        {
            this.Calc.Display = "0";
            return this;
        }
        //اگر دکمه ای عددی به جز صفر وارد شود این متود فراخوانده میشود و صفحه نمایش را تغییر میدهد
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }
        //این متود زمانی که یکی از اپراتور ها در صفحه کلید انتخاب شود توسط کاربر فراخوانده میشود و
        // ProcessOperator
        // نوع اپراتور را بررسی میکند و تغییرات لازم را میدهد در قسمت try
        //و متود pendingoperator 
        //اپراتور وارد شده را میدهد
        public override IState EnterOperator(char c) =>
            ProcessOperator(new ComputeState(this.Calc), c);
        //این متود زمانیکه دکمه 
        //'.'
        //وارد میشود صدا زده میشود و اگر در حالت اولیه باشد بهشکل زیر نشنم داده میشود در صفحع نمایش
        public override IState EnterPoint()
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}