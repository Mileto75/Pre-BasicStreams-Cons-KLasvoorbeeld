// See https://aka.ms/new-console-template for more information
using Pre.BasicStreams.Cons;
using System.IO;

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
    try
    {
        Directory.CreateDirectory(pathToDesktopPre);
    }
    catch(IOException ioException)
    {
        Console.WriteLine(ioException.Message);
    }
    
}
//check if file exists  
if(!File.Exists(pathToFile))
{
    try
    {
        File.Create(pathToFile);
    }
    catch (IOException ioException)
    {
        Console.WriteLine(ioException.Message);
    }
}
//file uitlezen met Filestream
try
{
    using (FileStream fileStream = new FileStream(pathToFile, FileMode.Open))
    {
        var characterByte = fileStream.ReadByte();
        while (characterByte != -1)
        {
            Console.Write((char)characterByte);
            characterByte = fileStream.ReadByte();
        }
    }
}
catch(FileNotFoundException fileNotFoundException)
{
    Console.WriteLine(fileNotFoundException.Message);
}
//StreamReader om hetzelfde te doen
using (var streamReader = new StreamReader(pathToFile))
{
    Console.WriteLine(streamReader.ReadToEnd());
}
//write to a file using streamWriter
try
{
    var pathToPre = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    , "Pre", "Streams","test.csv");

    using (StreamWriter streamWriter = new StreamWriter(pathToPre, true))
    {
        streamWriter.WriteLine("Intonatie van namen is zeer belangrijk!");
    }
}
catch(IOException iOException)
{
    Console.WriteLine(iOException.Message);
}
using (var streamReader = new StreamReader(pathToFile))
{
    Console.WriteLine(streamReader.ReadToEnd());
}
//read the personen.txt
//create a new file in assets => personen.csv
//C:\Users\Mileto\source\repos\Pre.BasicStreams.Cons\Pre.BasicStreams.Cons
//fixed absolute path
//var pathToProject = @"C:\Users\Mileto\source\repos\Pre.BasicStreams.Cons\Pre.BasicStreams.Cons";
var pathToProject = 
    Path
    .Combine(Directory.GetParent( Directory.GetCurrentDirectory()).Parent.Parent.FullName,"Assets");
//pathToFile
if(!Directory.Exists(pathToProject))
{
    Directory.CreateDirectory(pathToProject);
}
var pathToCsv = Path.Combine(pathToProject, "personen.csv");
//create the file using streamwriter
try
{
    //create pathToPersonenTxt
    var pathToPersonenTxt = Path.Combine(pathToDesktopPre, "Personen.txt");
    //read from personen.txt
    var persons = new List<Person>();
    using (var streamReaderPersonenTxt = new StreamReader(pathToPersonenTxt))
    {
        //read from personen.txt
        //read each line into a person
        //add to list of persons
        //use split
        var line = streamReaderPersonenTxt
            .ReadLine();
        while (line != null)
        {
            //split into string[]
            var personString =
                line.Split("|");
            //add to persons as Person object
            persons.Add(new Person
            {
                Firstname = personString[0],
                Lastname = personString[1],
                City = personString[2],
                Country = personString[3],
                Gender = personString[4],
                Age = int.Parse(personString[5]),
            });
            //read the next line
            line = streamReaderPersonenTxt.ReadLine();
        }
    }
    using (var streamWriterCsv = new StreamWriter(pathToCsv))
    {
        //write to the file from the persons list
        //write the gender F 
        var females = persons.Where(f => f.Gender.Equals("F"));
        streamWriterCsv.WriteLine("Firstname,Lastname,City,Country,Gender,Age");
        foreach(var person in females)
        {
            streamWriterCsv.WriteLine($"{person.Firstname}," +
                $"{person.Lastname}," +
                $"{person.City}," +
                $"{person.Country}," +
                $"{person.Gender}," +
                $"{person.Age}");
        }
    }
}
catch(IOException ioException)
{
    Console.WriteLine(ioException.Message);
}


