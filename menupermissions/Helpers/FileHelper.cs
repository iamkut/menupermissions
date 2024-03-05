using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace menupermissions.Helpers
{
    public static class FileHelper
    {
        public static void ProcessFiles(string userFileName, string menuFileName)
        {
            string currentDirectory = Environment.CurrentDirectory;
            var userFilePath = Path.Combine(currentDirectory, userFileName);
            var menuFilePath = Path.Combine(currentDirectory, menuFileName);

            try
            {
                if (!File.Exists(userFilePath))
                {
                    throw new FileNotFoundException($"File {userFileName} was not found.");
                }
                if (!File.Exists(menuFilePath))
                {
                    throw new FileNotFoundException($"File {menuFileName} was not found.");
                }

                var menuItems = LoadMenus(menuFilePath);
                var users = LoadUsers(userFilePath, menuItems);

                var outputFileName = "output.json";
                var outputFilePath = Path.Combine(currentDirectory, outputFileName);

                Console.WriteLine("Writing to file...");
                var jsonValue = JsonConvert.SerializeObject(users, Formatting.Indented);

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine(jsonValue);
                }
                Console.WriteLine($"{outputFileName} updated successfully.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File {ex.FileName} can not be found. Ensure all required files are in the project folder.");
            }
            catch (IOException)
            {
                Console.WriteLine("File is in use, close any applications that may have it in use and try again.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Unauthorized access to the file or folder. Run the application from a location the user has Read and Write permissions in.");
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"An error has occured. Please contact support@demo.co.za and attach the following message: {Environment.NewLine}" + ex.Message);
            }
        }
        
        private static Dictionary<int, string> LoadMenus(string menuFilePath)
        {
            var menuItems = new Dictionary<int, string>();
            try
            {
                foreach (var line in File.ReadAllLines(menuFilePath))
                {
                    var parts = line.Split(new[] { ", " }, StringSplitOptions.None);
                    menuItems.Add(int.Parse(parts[0]), parts[1]);
                }
            }
            catch(FileNotFoundException)
            {
                throw;
            }
            
            return menuItems;
        }

        private static List<object> LoadUsers(string userFilePath, Dictionary<int, string> menuItems)
        {
            var users = new List<object>();
            foreach (var line in File.ReadAllLines(userFilePath))
            {
                var parts = line.Split(' ');
                var userName = parts[0];
                var accessList = new List<string>();

                for (int i = 1; i <= 2; i++)
                {
                    for (int j = 0; j < parts[i].Length; j++)
                    {
                        if (parts[i][j] == 'Y')
                        {
                            int menuNumber = j + 1 + (i - 1) * 5;
                            if (menuItems.ContainsKey(menuNumber))
                            {
                                accessList.Add(menuItems[menuNumber]);
                            }
                        }
                    }
                }

                users.Add(new
                {
                    userName,
                    menuItems = accessList
                });
            }

            return users;
        }   
    }
}
