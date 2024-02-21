using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// SETUP 
const string myPersonalID = "c205b98b832782cc70a8b178b224a6419cd30a782b297c818aae923f74141018";
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/";
const string taskEndpoint = "task/";

HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n");
string taskID = "aAaa23";

//#### FIRST TASK 
Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Console.WriteLine(task1Response);
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);

double temperatureInFahrenheit = double.Parse(task1.parameters);
double temperatureInCelsius = (temperatureInFahrenheit - 32) / 1.8;
string answer = temperatureInCelsius.ToString("0.00");

Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer);
Console.WriteLine($"Fahrenheit:{task1.parameters}; Celsius:{answer}");
Console.WriteLine($"Answer: {Colors.Green}{task1AnswerResponse}{ANSICodes.Reset}");


taskID = "psu31_4";

Console.WriteLine("\n-----------------------------------\n");

class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}