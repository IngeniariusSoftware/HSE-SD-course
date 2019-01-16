
namespace ServerSide.Logging
{
    using System;

    public interface ILog
    {
        void MakeRecord(object sender, EventArgs e);
    }
}
