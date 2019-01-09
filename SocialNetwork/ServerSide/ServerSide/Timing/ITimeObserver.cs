
namespace ServerSide.Timing
{
    using ServerSide.Interfaces;

    internal interface ITimeObserver : IProcess
    {
        event TimeEventHandler ChangeState;
    }
}
