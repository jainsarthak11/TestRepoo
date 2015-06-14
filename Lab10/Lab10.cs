
using System;
using System.IO;
using System.Threading.Tasks;

class Lab10
{
    static async void SearchInFolder(string searchString)
    {
        string path = "../../";
        string[] files = Directory.GetFiles(path,"*.txt");
        foreach (string file in files)
        {
            Task<string> task = ReadFile(file, searchString);

            string isPresent = await task;

            Console.WriteLine(isPresent);
        }
        }

    static async void SearchString(string searchString)
    {
     
   Task<string> task = ReadFile("C:\\Users\\SJ\\Documents\\Visual Studio 2013\\Projects\\Lab10\\Lab10\\new1.txt",searchString);
        string isPresent = await task;
        Console.WriteLine(isPresent);
    }

    
    static async Task<string> ReadFile(string file,string searchStr)
    {
        string isPresent = "";
        string fileData = "";
        using (StreamReader reader = File.OpenText(file))
        {
            fileData = await reader.ReadToEndAsync();
        }
        if(fileData.Contains(searchStr))
        {
            string filename = Path.GetFileName(file);
            isPresent = searchStr + " Present in " + filename;
        }
        else
        {
            isPresent = "String Not Present";
        }
        
        return isPresent;
    }
    static void Main()
    {

        //string searchThis = "await acts as a callback";
        string searchThis = Console.ReadLine();
        Task task = new Task(() => SearchString(searchThis));
        task.Start();
        task.Wait();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Search In Folders");
        Console.WriteLine("--------------------------------");
        Task task2 = new Task(() => SearchInFolder(searchThis));
        task2.Start();
        Console.ReadLine();
    }

} 