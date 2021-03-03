using KinectXEFTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Extractor
{
    interface IXEFDataWriter
    {
        string FilePath { get; }

        long EventCount { get; }

        TimeSpan StartTime { get; }

        TimeSpan EndTime { get; }

        TimeSpan Duration { get; }

        void ProcessEvent(XEFEvent xefEvent);

        void Close();
    }
}
