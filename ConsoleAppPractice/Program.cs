
using ConsoleAppPractice.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extentions;
using System.Net.Security;

Menues();

LibraryController libraryController = new();

while (true)
{
    Operation: string operationStr = Console.ReadLine();
    int operation;

    bool isCorrectOperation = int.TryParse(operationStr, out operation);

    if (isCorrectOperation)
    {
        switch (operation)
        {
            case (int)Operations.GreateLibrary:
                libraryController.Greate();
                break;
            case (int)Operations.DeleteLibrary :
                libraryController.Delete();
                break;
            case 3:
                Console.WriteLine("Library edit :");
                break;
            case (int)Operations.GetAllLibraries:
                libraryController.GetAll();
                break;
            case (int)Operations.GetById:
                libraryController.GetById();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Please write correct option :");
                goto Operation;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Please write correct option format ");
        goto Operation;
    }
}


static void Menues()
{
    ConsoleColor.DarkBlue.WriteConsole("Choose one options for working with application :" +
    "Library operations : 1- Greate , 2- Delete ,3- Edit , 4-GetAll , 5- GetById");

}



