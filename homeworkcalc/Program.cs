/* Доработайте программу калькулятор реализовав выбор действий
 * и вывод результатов на экран в цикле так чтобы калькулятор
 * мог работать до тех пор пока пользователь не нажмет отмена
 * или введёт пустую строку. */

using homeworkcalc;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

var calc = new Calculate();
calc.MyEventHandler += Calculate_MyEventHandler;
calc.MyEventHandler += Congrat_MyEventHandler; ;


Console.WriteLine("Введите первое число");
calc.result = Convert.ToDouble(Console.ReadLine());

while (true)
{

    Console.WriteLine("Введите действие: '+', '-', '*', '/', 'Отмена действия', 'Выход'");
    var sight = Console.ReadLine();
    int secondNumber = 0;

    if (sight != "Отмена" && sight != "Выход")
    {
        Console.WriteLine("Введите второе число");
        secondNumber = Convert.ToInt32(Console.ReadLine());
    }

    switch (sight)
    {
        case "+":
            calc.Sum(secondNumber);
            break;
        case "-":
            calc.Sub(secondNumber);
            break;
        case "/":
            calc.Divide(secondNumber);
            break;
        case "*":
            calc.Multy(secondNumber);
            break;
        case "Отмена":
            calc.CancelLast();
            break;
        case "Выход":
            Environment.Exit(0);
            break;
    }

}

static void Calculate_MyEventHandler(object? sender, EventArgs e)
{
    if (sender is Calculate)
    {
        Console.WriteLine(String.Empty);
        Console.WriteLine("Результат:");
        Console.WriteLine(((Calculate)sender).result);
    }

}

static void Congrat_MyEventHandler(object? sender, EventArgs e)
{
    Console.WriteLine("-----------------------------");
}

Console.WriteLine(String.Empty);