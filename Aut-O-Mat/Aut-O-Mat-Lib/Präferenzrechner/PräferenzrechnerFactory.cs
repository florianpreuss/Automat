namespace Aut_O_Mat_Lib.Präferenzrechner;

public class PräferenzrechnerFactory
{
    public PräferenzrechnerFactory()
    {
        new PräferenzrechnerFactory();
    }

    public IPräferenzrechner GetPräferenzrechner()
    {
        throw new InvalidOperationException();
    }
}
