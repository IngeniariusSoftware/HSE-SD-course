
namespace ServerSide.Processing
{
    public interface IProcess
    {
        event ProcessEventHandler StateChanged;

        bool IsActive { get; }

        void Start();

        void End();
    }
}