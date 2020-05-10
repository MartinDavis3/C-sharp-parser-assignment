using System;
using System.Linq;
using System.IO;

namespace C__parser_assignment
{
  class Program
  {
    static void OutputInstructions()
    {
      Console.WriteLine("Input an option from 1 to 3:");
      Console.WriteLine("1 to enter a filename.");
      Console.WriteLine("2 to enter a string to be removed in the file.");
      Console.WriteLine("3 to exit.");
    }
    static void OutputFileErrorMessage()
    {
      Console.WriteLine( "No file found, please use option 1 to enter the name of an existing file." );
    }
    static void Main(string[] args)
    {
      bool endRequested = false;
      string filename = "";
      string inputOption = "";
      OutputInstructions();
      while ( !endRequested ) {
        Console.WriteLine("Input an option:");
        inputOption = Console.ReadLine();
        switch ( inputOption ) {
          case "1":
            Console.WriteLine("Please enter the filename:");
            filename=Console.ReadLine();
            if ( !File.Exists( filename ) ) {
              OutputFileErrorMessage();
            }
            break;
          case "2":
            Console.WriteLine("Please enter the string to remove in the file:");
            string stringToReplace = Console.ReadLine();
            if (File.Exists(filename)) {
              string readText = File.ReadAllText(filename);
              string[] splitText = readText.Split(stringToReplace);
              string writeText ="";
              foreach ( string part in splitText ) {
                writeText = writeText + part + " " ;
              }
              File.WriteAllText( filename, writeText );
            } else {
              OutputFileErrorMessage();
            }
            break;
          case "3":
            endRequested = true;
            Console.WriteLine("Exit requested: Goodbye!");
            break;
          default:
            Console.WriteLine("Invalid option.");
            OutputInstructions();
            break;
        }
      }
    }
  }
}
