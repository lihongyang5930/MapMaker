using System;

namespace MindOne.Epanet.Models
{
    public interface IEapnetValue
    {
        TimeSpan TimeStep { get; }
    }
}
