namespace ACMEControl.Definitions;

public interface IControl
{
    byte[] Step(byte[] input);
}
