using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Driver
{
    static void Main(string[] args)
    {
        FileSystem fileSystem = new FileSystem();

        while (true)                                                                                                    // Loops infinitely 
        {
            Console.WriteLine("Number of files in the system: " + fileSystem.NumberFiles(fileSystem.Root) + "\n");      // Displays number of files in fileSystem
            fileSystem.PrintFileSystem(fileSystem.Root, "");

            string input = "";

            Console.Write("\n1. Add directory\n" +                                                                      // Displays options for the user
                "2. Delete directory\n" +
                "3. Add file\n" +
                "4. Delete file\n\n" +
                "Please select and option: ");
            input = Console.ReadLine();
            Option(fileSystem, input);                                                                                  // Calls Option to execute user command on fileSystem

            Console.WriteLine("\nPress Any Key to Continue");

            Console.ReadKey();
            Console.Clear();                                                                                            // Clears screen before next loop
        }
    }

    public static void Option(FileSystem fileSystem, string input)
    {
        string address;
        bool result;

        switch (input)
        {
            case "1":                                                                                                   // Add directory
                Console.Write("\n\nPlease enter a directory to be added: ");
                address = Console.ReadLine();

                if (!address.EndsWith("/") && !address.EndsWith(" "))                                                   // Validate string input
                {
                    result = fileSystem.AddDirectory(address);
                    if (result)
                        Console.WriteLine("Directory Added");
                    else
                        Console.WriteLine("Directory Already Exists or the Path is Undefined");
                }
                else
                {
                    Console.WriteLine("Invalid directory passed");
                }
                break;
            case "2":                                                                                                   // Delete directory
                Console.Write("\n\nPlease enter a directory to be removed: ");
                address = Console.ReadLine();

                result = fileSystem.RemoveDirectory(address);
                if (result)
                    Console.WriteLine("Directory Removed");
                else
                    Console.WriteLine("Path is Undefined");
                break;
            case "3":                                                                                                   // Add file
                Console.Write("\n\nPlease enter a file to be added: ");
                address = Console.ReadLine();

                if (address.Length != 0 && !address.EndsWith("/") && !address.EndsWith(" "))                            // Validate string input
                {
                    result = fileSystem.AddFile(address);

                    if (result)
                        Console.WriteLine("File Added");
                    else
                        Console.WriteLine("File Already Exists in Directory or the Path is Undefined");
                }
                else
                {
                    Console.WriteLine("Invalid directory passed");
                }
                break;
            case "4":                                                                                                   // Delete file
                Console.Write("\n\nPlease enter a file to be removed: ");
                address = Console.ReadLine();

                result = fileSystem.RemoveFile(address);
                if (result)
                    Console.WriteLine("File Removed");
                else
                    Console.WriteLine("Path is Undefined");
                break;
            default:                                                                                                    // Invalid user input
                Console.WriteLine("Error invalid selection");
                break;
        }
    }
}