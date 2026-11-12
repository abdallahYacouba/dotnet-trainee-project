

using System.Text;

string path = @"test.txt";

StringBuilder sb = new StringBuilder();
sb.AppendLine("[Unit]");
sb.AppendLine("Description=.NET Employee Web Service");
sb.AppendLine("After=network.target");
sb.AppendLine("");
sb.AppendLine("[Service]");
sb.AppendLine("WorkingDirectory=/var/www/html");
sb.AppendLine("ExecStart=/usr/bin/dotnet /var/www/html/EmployeeApi");
sb.AppendLine("Restart=always");
sb.AppendLine("RestartSec=10");
sb.AppendLine("KillSignal=SIGINT");
sb.AppendLine("SyslogIdentifier=employeeapi");
sb.AppendLine("User=www-data");
sb.AppendLine("Environment=ASPNETCORE_ENVIRONMENT=Production");
sb.AppendLine("");
sb.AppendLine("[Install]");
sb.AppendLine("WantedBy=multi-user.target");

string fileContent = sb.ToString();
try
{
	File.WriteAllText(path, fileContent);
    Console.WriteLine($"Successfully wrote content to {path}");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
Console.ReadLine();

