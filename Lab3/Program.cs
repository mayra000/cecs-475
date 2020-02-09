/*
Mayra Sanchez
CECS 475
Phuong Nguyen
Lab 3
/


/*
 * Read the following lecture note from the week 2.

Delegates and Events
Code example 

and implement the following:

Delegate event without passing data - done
Delegate event with passing data - done
Rewrite item a using .NET EventHandler - tbd
Rewrite item b using .NET EventHandler - tbd
Grading

Demonstrate the result to the instructor in the class
Return a printed copy of the answers to the following questions: Briefly describe how you convert part a to c by showing the code that is modified for using .NET event handler.
Briefly describe how you convert part a to c by showing the code that is modified for using .NET event handler.
*/

/*
* 1 - Define Delegate
* 2 - Define Event based off that delegate
* 3 - Raise the even
* */

namespace CECS475_Lab3_A
{
    class Program
    {
        static void Main(string[] args)
        {
            //PART A
            //output without passing data
            Number myNumber = new Number(100000);
            myNumber.PrintMoney();
            myNumber.PrintNumber();

            //PART B
            //output with passing data
            NumberPass myNumberPass = new NumberPass(100000);
            myNumberPass.PrintMoneyPass();
            myNumberPass.PrintNumberPass();
        }
    }
}

//given code from delegateevent pdf w/ modifications
class Number
{
    private PrintHelper _printHelper;

    public Number(int val)
    {
        _value = val;

        _printHelper = new PrintHelper();
        //subscribe to beforePrintEvent event
        _printHelper.beforePrintEvent += printHelper_beforePrintEvent;
    }
    //beforePrintevent handler
    void printHelper_beforePrintEvent()
    {
        Console.WriteLine("BeforPrintEventHandler: PrintHelper is going to print a value");
    }

    private int _value;

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public void PrintMoney()
    {
        _printHelper.PrintMoney(_value);
    }

    public void PrintNumber()
    {
        _printHelper.PrintNumber(_value);
    }
}

public class PrintHelper
{
    // declare delegate 
    public delegate void BeforePrint();

    //declare event of type delegate
    public event BeforePrint beforePrintEvent;

    //why is this left blank? 
    public PrintHelper()
    {

    }

    public void PrintNumber(int num)
    {
        //call delegate method before going to print
        if (beforePrintEvent != null)
            beforePrintEvent();

        Console.WriteLine("Number: {0,-12:N0}", num);
    }

    public void PrintDecimal(int dec)
    {
        if (beforePrintEvent != null)
            beforePrintEvent();

        Console.WriteLine("Decimal: {0:G}", dec);
    }


    public void PrintMoney(int money)
    {
        if (beforePrintEvent != null)
            beforePrintEvent();

        Console.WriteLine("Money: {0:C}", money);
    }

    public void PrintTemperature(int num)
    {
        if (beforePrintEvent != null)
            beforePrintEvent();

        Console.WriteLine("Temperature: {0,4:N1} F", num);
    }
    public void PrintHexadecimal(int dec)
    {
        if (beforePrintEvent != null)
            beforePrintEvent();

        Console.WriteLine("Hexadecimal: {0:X}", dec);
    }

}

//*******************PART B*****************************************//


// Delegate event with passing data only done for MONEY
public class PrintHelperPass
{
    //name should correspond with class name for consistency
    public delegate void BeforePrintPass(string message);
    public event BeforePrintPass beforePrintEventPass;

    public void PrintNumberPass(int num)
    {
        if (beforePrintEventPass != null)
            beforePrintEventPass("PrintNumber");
        Console.WriteLine("Number: {0,-12:N0}", num);
    }

    public void PrintMoneyPass(int money)
    {
        if (beforePrintEventPass != null)
            beforePrintEventPass("PrintMoney");
        Console.WriteLine("Money: {0:C}", money);
    }

}

//NEW
class NumberPass
{
    private PrintHelperPass _printHelperPass;
    public NumberPass(int val)
    {
        _valuePass = val;

        _printHelperPass = new PrintHelperPass();
        //subscribe to beforePrintEvent event
        _printHelperPass.beforePrintEventPass += printHelperPass_beforePrintEventPass;
    }
    //beforePrintevent handler
    void printHelperPass_beforePrintEventPass(string message)
    {
        Console.WriteLine("BeforePrintEvent fires from {0}", message);
    }
    private int _valuePass;
    public int ValuePass
    {
        get { return _valuePass; }
        set { _valuePass = value; }
    }
    public void PrintMoneyPass()
    {
        _printHelperPass.PrintMoneyPass(_valuePass);
    }
    public void PrintNumberPass()
    {
        _printHelperPass.PrintNumberPass(_valuePass);
    }
}

