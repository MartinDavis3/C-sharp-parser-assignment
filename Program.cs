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
    static void Main(string[] args)
    {
      bool endRequested = false;
      string filename = "";
      string inputOption = "";
      string stringToReplace = "";
      OutputInstructions();
      while ( !endRequested ) {
        Console.WriteLine("Input an option:");
        inputOption = Console.ReadLine();
        switch ( inputOption ) {
          case "1":
            filename=Console.ReadLine();
            break;
          case "2":
            stringToReplace = Console.ReadLine();
            if (File.Exists(filename)) {
              string readText = File.ReadAllText(filename);
              string[] splitText = readText.Split(stringToReplace);
              string writeText ="";
              foreach ( string part in splitText ) {
                writeText = writeText + " " + part;
              }
              File.WriteAllText( filename, writeText );
            } else {
              Console.WriteLine( "No such file, please use option 1 to enter a valid file name" );
            }
            break;
          case "3":
            endRequested = true;
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
