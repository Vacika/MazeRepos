using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    [Serializable]
    public class Game : ISerializable
    {
        public int hits { get; set; }
        public Snake snake { get; set; }
        public TimeSpan ts { get; set; } 
        public StringBuilder eventlog { get; set; }
        public Game()
        {
            hits = 0;
            snake = new Snake();
            ts = new TimeSpan(0,0,0);
            eventlog = new StringBuilder();
        }
        public TimeSpan getTimespan(Stopwatch stopwatch)
        {
            return ts + stopwatch.Elapsed;
        }
        public Game(SerializationInfo info, StreamingContext context)
        {
            hits = (int)info.GetValue("hits", typeof(int));
            snake = (Snake)info.GetValue("snake", typeof(Snake));
            ts = (TimeSpan)info.GetValue("ts",typeof(TimeSpan));
            eventlog = (StringBuilder)info.GetValue("eventlog", typeof(StringBuilder));
           
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ts", ts);
            info.AddValue("hits", hits);
            info.AddValue("snake", snake);
            info.AddValue("eventlog", eventlog);
        }

        public void addEvent(string poraka)
        {
            eventlog.Append(poraka + "\n");
        }
    }
}
