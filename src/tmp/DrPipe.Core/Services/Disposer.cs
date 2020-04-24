using System;

namespace DrPipe.Core.Services
{
    public class Disposer : IDisposable
    {
        Action _a;

        public Disposer(Action a)
        {
            _a = a;
        }
        public void Dispose()
        {
            _a.Invoke();
        }
    }
}
