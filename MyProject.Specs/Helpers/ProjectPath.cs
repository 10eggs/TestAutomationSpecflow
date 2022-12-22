using System;

namespace HistoricalEngland.Specs.Helpers
{
    public class ProjectPath
    {
        private static string getPath, actualPath, projectPath;
        public static string getProjectPath()
        {
            getPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            actualPath = getPath.Substring(0, getPath.LastIndexOf("bin"));
            projectPath = new Uri(actualPath).LocalPath;
            return projectPath;
        }
    }
}
