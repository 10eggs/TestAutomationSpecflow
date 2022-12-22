using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HistoricalEngland.Specs.Helpers
{
    class ReplaceRptInfo
    {
        private static string newPath, getProjPath;

        //Code to customise report output file
        public void DeleteUnnecessaryInfo()
        {
            newPath = getProjPath + "Reports\\" + ExtReport.day_dt + "\\dashboard.html";
            var statusData = new List<string>()
            {
                {",statusGroup.infoChild"},
                {", statusGroup.fatalChild"},
                {", statusGroup.warningChild"},
                {", statusGroup.fatalParent" },
                {", statusGroup.warningParent"},
                {", statusGroup.warningGrandChild"},
                {", statusGroup.infoGrandChild"},
                {", statusGroup.fatalGrandChild"}
            };

            var statusLable = new List<string>()
            {
                { "\"Fatal\"," }, {"\"Warning\"," }, {", \"Info\""}, {"\"Info\""}
            };

            var statusColor = new List<string>()
            {
                { "\"#8b0000\"," },{ "\"#ff6347\","},{"\"#46BFBD\""}
            };
            System.IO.StreamReader objReader;
            objReader = new System.IO.StreamReader(newPath);
            string content = objReader.ReadToEnd();
            content = Regex.Replace(content, "\"#1e90ff\",", "\"#32a2db\"");
            content = Regex.Replace(content, "F7464A", "b62126"); /* red*/
            content = Regex.Replace(content, "#00af00", "#77a942");/* green*/

            for (int i = 0; i < statusData.Count; i++)
                content = Regex.Replace(content, statusData[i], "");
            for (int i = 0; i < statusLable.Count; i++)
                content = Regex.Replace(content, statusLable[i], "");
            for (int i = 0; i < statusColor.Count; i++)
                content = Regex.Replace(content, statusColor[i], "");
            objReader.Close();
            StreamWriter writer = new StreamWriter(ProjectPath.getProjectPath() + "Reports\\" + ExtReport.day_dt + "\\dashboard.html");
            writer.AutoFlush = false;
            writer.Write(content);
            writer.Flush();
            writer.Close();
        }

        //code to zip and archive reports
        public void ZipFileCreate()
        {
            getProjPath = ProjectPath.getProjectPath();
            string startPath = getProjPath + "Reports";
            string delPath = getProjPath + "Reports\\";
            string zipPath = getProjPath + "ReportsArchived\\";
            int fileCount;

            if (!Directory.Exists(zipPath))
                Directory.CreateDirectory(zipPath);

            // Will Retrieve count of all files in directry but not sub directries
            fileCount = Directory.GetFiles(zipPath, "*.*", SearchOption.TopDirectoryOnly).Length;
         
            //check if the archived file count has reached the max limit(30)
            if  (fileCount <= 30)
            {
                try
                {
                    foreach (var subDirectory in System.IO.Directory.GetDirectories(startPath))
                    {
                        var dirName = new DirectoryInfo(subDirectory).Name;
                        if (!dirName.Contains(".zip"))
                            ZipFile.CreateFromDirectory(startPath, zipPath + dirName + ".zip");
                        Directory.Delete(subDirectory, true);
                    }
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(" Folder empty or Folder already archived");
                }
            }
        }
    }
}
