// See https://aka.ms/new-console-template for more information
Console.WriteLine("Basic streams");
//paden
var pathToD = Path.Combine("D:", "Pre", "Streams");
Console.WriteLine(pathToD);
//pathTo desktop
var pathToDesktopPre = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    ,"Pre","Streams");
Console.WriteLine(pathToDesktopPre);
//Create a file
var pathToFile = Path.Combine(pathToDesktopPre, "test.txt");
Console.WriteLine(pathToFile);
//use File static
//check if directory exists
//Directory static
if (!Directory.Exists(pathToDesktopPre))
{
    Directory.CreateDirectory(pathToDesktopPre);
}
File.Create(pathToFile);
