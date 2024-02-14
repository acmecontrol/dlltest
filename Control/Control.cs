namespace ACMEControl.Control;

using System.Buffers.Text;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


public class Control : ACMEControl.Definitions.IControl
{
    readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    public byte[] Step(byte[] binaryInput)
    {
        Input? input;
        try
        {
            string jsonInput = Encoding.UTF8.GetString(binaryInput);
            input = JsonSerializer.Deserialize<Input>(jsonInput, _jsonOptions);
        }
        catch (JsonException e)
        {
            ACMEControl.Middleware.Middleware.SendTelemetry(e.Message);
            return [];
        }
        if (input != null)
        {
            ACMEControl.Middleware.Middleware.SendTelemetry("x: " + input.X + ", y: " + input.X * 2);
        }
        else
        {
            return [];
        }

        return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new Output(Y: 2 * input.X)));
    }
}

record Input(float X);
record Output(float Y);
