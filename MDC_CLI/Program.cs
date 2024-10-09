// See https://aka.ms/new-console-template for more information

using System;
using System.CommandLine;
using System.IO;
using System.Threading.Tasks;

internal class Program
{
    private static async Task<int> Main(string[] args)

    {
        var fileOption = new Option<FileInfo>(
            name: "--file",
            description: "Scegli il file da testare",
            getDefaultValue: () => new FileInfo("file.txt")
            );

        var optionTest = new Option<string>(
            name: "--test",
            description: "Opzione di test",
            getDefaultValue: () => "Testo di prova"
            );


        var rootCommand = new RootCommand("Applicazione per fare i test");
        //rootCommand.AddOption(fileOption);

        var testCommand = new Command("test", "Testa il dispositivo")
        {
            optionTest
        };

        rootCommand.AddCommand(testCommand);

        testCommand.SetHandler((test) =>
        {
            TryTest(test);
        }, optionTest);
        return await rootCommand.InvokeAsync(args);
    }

    private static void TryTest(string test)
    {
        Console.WriteLine(test);
    }
}