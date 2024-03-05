using Microsoft.VisualStudio.TestTools.UnitTesting;
using menupermissions.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menupermissions.Helpers.Tests
{
    [TestClass()]
    public class FileHelperTests
    {
        private readonly string userFilePath = "users.txt";
        private readonly string menuFilePath = "menus.txt";
      

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ProcessFiles_UserFileNotFound_ThrowsFileNotFoundException()
        {
            FileHelper.ProcessFiles("file-not-here.txt", menuFilePath);
        }
        
        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ProcessFiles_MenuFileNotFound_ThrowsFileNotFoundException()
        {
            FileHelper.ProcessFiles(userFilePath, "file-not-here.txt");
        }
    }
}