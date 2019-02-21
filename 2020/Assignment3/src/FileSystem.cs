using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Node
{
    public string Directory { get; set; }                                                               // Read/write property
    public List<string> File { get; set; }                                                              // Read/write property
    public Node LeftMostChild { get; set; }                                                             // Read/write property
    public Node RightSibling { get; set; }                                                              // Read/write property

    // Constructor
    public Node(string name)                                                            
    {
        Directory = name;                                                                               // Sets directory name to input
        File = new List<string>();                                                                      // Creates empty list of files
        LeftMostChild = null;                                                                           // LeftMostChild is set to null
        RightSibling = null;                                                                            // RightSibling is set to null
    }
}

public class FileSystem
{
    private Node root;
    public Node Root { get { return root; } }                                                           // Read property to access root outside of class

    // Creates a file system with a root directory
    public FileSystem()
    {
        root = new Node("");
    }

    // Adds a file at the given address
    // Returns false if the file already exists or the path is undefined; true otherwise
    public bool AddFile(string address)
    {
        Node current = root;
        String[] folder = address.Split('/');
        if (folder.Length == 2)                                                                         //Checks if file is being stored at root
            if (!(root.File.Contains(folder[folder.Length - 1])))                                       //Checks if file already exists in root directory
            {
                root.File.Add(folder[folder.Length - 1]);                                               //Adds file to directory if it does not exist
                return true;
            }
            else
                return false;
        //Traverses file system until the address is found or path leads to null
        for (int i = 1; i < folder.Length; i++)
        {
            bool found = false;
            if (i < folder.Length - 1)                                                                  //Move next level down unless at last directory in address
                current = current.LeftMostChild;
            while (!found)                                                                              //Repeats loop until folder is found or is broken from within
            {
                if (i == folder.Length - 1)                                                             //Checks if looking at the file name
                {
                    if (!(current.File.Contains(folder[folder.Length - 1])))                            //Checks if file already exists in the directory, adds it to the directory if it does not
                    {
                        current.File.Add(folder[folder.Length - 1]);
                        return true;
                    }
                    else
                        return false;
                }
                if (current == null)                                                                    //Checks if currect directory exists, returns false if it does not
                    return false;
                if (current.Directory == folder[i])                                                     //Checks if current directory is the one in the address
                    found = true;
                else                                                                                    //Directory is either a sibling or does not exist
                {
                    do
                    {
                        current = current.RightSibling;
                    } while (current != null && current.Directory != folder[i]);                        //Loops while sibling directory exists or until directory is found
                }
            }
        }
        return false;
    }

    // Removes the file at the given address
    // Returns false if the file is not found or the path is undefined; true otherwise
    public bool RemoveFile(string address)
    {
        Node current = root;

        string[] folder = address.Split('/');
        if (folder.Length == 2)                                                                         //Checks if file is being stored at root
        {
            if (root.File.Contains(folder[folder.Length - 1]))                                          //Checks if file already exists in root directory, deletes it from List if found
            {
                root.File.Remove(folder[folder.Length - 1]);
                return true;
            }
            else
                return false;
        }

        for (int i = 1; i < folder.Length; i++)                                                         //For loop for files not stored at root, runs through address
        {
            bool found = false;
            if (i < folder.Length - 1)                                                                  //Move next level down unless at last directory in address
                current = current.LeftMostChild;
            while (!found)                                                                              //Repeats loop until folder is found or is broken from within
            {
                if (i == folder.Length - 1)                                                             //Checks if looking at the file name
                {
                    if (current.File.Contains(folder[i]))                                               //Checks if file exists in directory, delets it from the List if found
                    {
                        current.File.Remove(folder[i]);
                        return true;
                    }
                    else
                        return false;
                }
                if (current == null)                                                                    //Checks if current directory exists, returns false if it does not
                    return false;
                if (current.Directory == folder[i])                                                     //Checks if current directory is the one in the address
                    found = true;
                else                                                                                    //Directory is either a sibling or does not exist
                {
                    do
                    {
                        current = current.RightSibling;
                    } while (current != null && current.Directory != folder[i]);                        //Loops while sibling directory exists or until directory is found
                }
            }
        }
        return false;
    }

    // Adds a directory at the given address
    // Returns false if the directory already exists or the path is undefined; true otherwise
    public bool AddDirectory(string address)
    {
        Node traverse = root;
        string[] folder = address.Split('/');

        if (address == root.Directory)
        {                                                                                               //Checks if address is of root directory
            return false;
        }

        //Traverses file system until the address is found or path leads to null
        for (int i = 1; i < folder.Length; i++)
        {
            if (traverse.LeftMostChild == null && i == folder.Length - 1)                               //Path is correct, directory is added
            {
                traverse.LeftMostChild = new Node(folder[i]);
                return true;
            }
            else if (traverse.LeftMostChild == null && i != folder.Length - 1)                          //Path is false
            {
                return false;
            }
            else if (traverse.LeftMostChild.Directory == folder[i] && i == folder.Length - 1)           //Checks if directory already exists in file system
                return false;
            else if (traverse.LeftMostChild.Directory == folder[i])                                     //Directory is next level down					
                traverse = traverse.LeftMostChild;
            else                                                                                        //Directory is either a sibling or does not exist
            {
                traverse = traverse.LeftMostChild;
                do
                {
                    if (traverse.RightSibling == null && i == folder.Length - 1)                        //Path is correct, directory is added
                    {
                        traverse.RightSibling = new Node(folder[i]);
                        return true;
                    }
                    traverse = traverse.RightSibling;
                } while (traverse!=null && traverse.Directory != folder[i]);                            //Loops while sibling directory exists or until directory is found
            }
        }

        return false;
    }

    // Removes the directory (and its subdirectories) at the given address
    // Returns false if the directory is not found or the path is undefined; true otherwise
    public bool RemoveDirectory(string address)
    {
        Node current = root;                                                                            // Placeholder node
        Node prev = root;                                                                               // Previous node

        string[] folder = address.Split('/');
        if (address == root.Directory)
        {                                                                                               // Checks if address is of root directory
            return false;
        }

        for (int i = 1; i < folder.Length; i++)                                                         // For every directory being parsed
        {
            if (current.LeftMostChild == null)                                                          // If left child is null return false
            {
                return false;
            }
            else if (current.LeftMostChild.Directory == folder[i])                                      // If leftmost directory is looking at directory
            {
                prev = current;                                                                         // Move nodes left
                current = current.LeftMostChild;

                if (i == folder.Length - 1)                                                             // If last loc in folder
                {
                    prev.LeftMostChild = current.RightSibling;                                          // Remove left sibling
                    return true;
                }
            }
            else if (current.LeftMostChild.RightSibling == null)                                        // Make sure right is not null
            {
                return false;
            }
            else if (current.LeftMostChild.RightSibling.Directory == folder[i])                         // If right is looking at directory
            {
                prev = current;                                                                         // Move node right
                current = current.LeftMostChild.RightSibling;

                if (i == folder.Length - 1)                                                             // If last loc in folder
                {
                    prev.LeftMostChild.RightSibling = current.RightSibling;                             // Remove right sibling
                    return true;
                }
            }
        }
        return false;
    }

    // Returns the number of files in the file system
    public int NumberFiles(Node current, int numFiles = 0)
    {
        if (current != null)                                                                            // If current node is not null
        {
            while (current != null)                                                                     // While current node is not null
            {                                                                                           // Add number of files in the current directory to the total
                numFiles += current.File.Count;
                numFiles = NumberFiles(current.RightSibling, numFiles);                                 // Recursively call function, move to the sibling directory
                current = current.LeftMostChild;                                                        // Move to the directory next level down, go to top of loop
            }
        }
        return numFiles;
    }

    // Prints the directories in a pre-order fashion along with their files
    public void PrintFileSystem(Node current, String indent)
    {
        if (current != null)                                                                            // If current node is not null
        {
            while (current != null)                                                                     // While right sibling is not null
            {
                Console.WriteLine(indent + "├─┐/" + current.Directory);                                 // Write layer and directory
                foreach (string file in current.File)
                {                                                                                       //For each file
                    Console.WriteLine(indent + "│ ├ " + file);                                          // Print layer and then file name
                }
                PrintFileSystem(current.LeftMostChild, indent + "│ ");                                  // Recursively call function, Move to left child and add layer
                current = current.RightSibling;                                                         // Move to right sibling and go to top of loop
            }
        }
    }
}
