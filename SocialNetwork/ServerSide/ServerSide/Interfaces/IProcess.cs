
namespace ServerSide.Interfaces
{
    public interface IProcess
    {
        bool IsActive { get; }

        void Start();

        void End();
    }
}
