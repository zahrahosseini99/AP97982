namespace A14
{
    /// <summary>
    /// ماشین حساب وقتی به این حالت وارد میشود که خطایی رخ داده باشد
    /// از این حالت هر کلیدی که فشار داده شود به وضعیت اولیه باید برگردیم
    /// در این کلاس وقتی فراخوانی میشود به عنوان مثال در کلاس Computestate 
    /// همه قسمت ها
    /// null 
    /// میشوند همانطور که در زیر مشاهده میکنیم
    /// و ماشین حساب به حالت اولیه برمیگردد طبق انتظار
    /// </summary>
    public class ErrorState : CalculatorState
    {
        public ErrorState(Calculator calc) : base(calc) { }
        public override IState EnterEqual() => null;
        public override IState EnterNonZeroDigit(char c) => null;
        public override IState EnterZeroDigit() => null;
        public override IState EnterOperator(char c) => null;
        public override IState EnterPoint() => null;
    }
}