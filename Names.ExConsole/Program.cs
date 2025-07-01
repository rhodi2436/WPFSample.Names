// See https://aka.ms/new-console-template for more information
using Names.ExConsole;

var man = new Man(Task.Delay(500));
man.IncreaseCommand.Execute(2);
Console.WriteLine("Hello, World!");
