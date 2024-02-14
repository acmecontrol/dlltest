using System.Text;
using System.Text.Json;
using ACMEControl.Control;

Console.WriteLine("Hello, World!");

var control = new Control();
var input = new Input(3.14f);

string inputJson = JsonSerializer.Serialize(input);
byte[] binaryInput = Encoding.UTF8.GetBytes(inputJson);

control.Step(binaryInput);

public record Input(float x);
public record Output(float y);

