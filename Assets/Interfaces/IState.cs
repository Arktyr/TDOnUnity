namespace Interfaces
{
    public interface IState <out TInitializer>
    {
        TInitializer Initializer { get; }
    }
}