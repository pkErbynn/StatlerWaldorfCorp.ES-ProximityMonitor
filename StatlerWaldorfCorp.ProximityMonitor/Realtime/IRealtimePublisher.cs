using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatlerWaldorfCorp.ES_CQRS_ProximityMonitor.Realtime
{
    public interface IRealtimePublisher
    {
        void Publish(string channelName, string message);
        void Validate();
    }
}