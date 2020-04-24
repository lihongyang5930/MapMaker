using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrPipe.Diagnosis.Models;
using MindOne.DrPipe.Dpf.Models;

namespace DrPipe.Diagnosis
{
    public static class LinqExtensions
    {
        public static IEnumerable<PipeGroup> GroupByZone(this IEnumerable<DBM_PIPE> source)
        {
            var zones  = source
                            .Where(x => !string.IsNullOrWhiteSpace(x.ZONE))
                            .Select(x => x.ZONE)
                            .Distinct()
                            .OrderBy(x => x)
                            .ToArray();
            var groups = new List<PipeGroup>();
            foreach (var zone in zones)
            {
                var minPressure   = source.Where(x => x.ZONE == zone).Where(x => x.PRESSURE_MIN.HasValue).Select(x => x.PRESSURE_MIN.Value).Min();
                var maxPressure   = source.Where(x => x.ZONE == zone).Where(x => x.PRESSURE_MAX.HasValue).Select(x => x.PRESSURE_MAX.Value).Max();
                var avgPressure   = source.Where(x => x.ZONE == zone).Where(x => x.PRESSURE_AVG.HasValue).Select(x => x.PRESSURE_AVG.Value).Average();
                var rangePressure = maxPressure - minPressure;

                var minVelocity   = source.Where(x => x.ZONE == zone).Where(x => x.VELOCITY_MIN.HasValue).Select(x => x.VELOCITY_MIN.Value).Min();
                var maxVelocity   = source.Where(x => x.ZONE == zone).Where(x => x.VELOCITY_MAX.HasValue).Select(x => x.VELOCITY_MAX.Value).Max();
                var avgVelocity   = source.Where(x => x.ZONE == zone).Where(x => x.VELOCITY_AVG.HasValue).Select(x => x.VELOCITY_AVG.Value).Average();
                var rangeVelocity = maxVelocity - minVelocity;


                var group = new PipeGroup();
                var pipes = source.Where(x => x.ZONE == zone).Select(ToPipe).ToArray();
                group.Zone = zone;

                group.MinPressure   = minPressure;
                group.MaxPressure   = maxPressure;
                group.AvgPressure   = avgPressure;
                group.StDevPressure = rangePressure;

                group.MinVelocity   = minVelocity;
                group.MaxVelocity   = maxVelocity;
                group.AvgVelocity   = avgVelocity;
                group.StDevVelocity = rangeVelocity;

                group.Pipes         = pipes;
                groups.Add(group);
            }
            return groups;
        }

        public static Pipe ToPipe(this DBM_PIPE model)
        {
            return new Pipe { 
                ID               = model.ID             ,
                MGR_ID           = model.MGR_ID         ,
                PP_TYPE          = model.PP_TYPE        ,
                PP_CIR           = model.PP_CIR         ,
                PP_LEN           = model.PP_LEN         ,
                NYEAR            = model.NYEAR          ,
                LEAK_BASE        = model.LEAK_BASE      ,
                LEAK_BREAK       = model.LEAK_BREAK     ,
                LEAK_SUM         = model.LEAK_SUM       ,
                LEAK2            = model.LEAK2          ,
                PRESSURE_MIN     = model.PRESSURE_MIN   ,
                PRESSURE_MAX     = model.PRESSURE_MAX   ,
                PRESSURE_AVG     = model.PRESSURE_AVG   ,
                PRESSURE_STDDEV  = model.PRESSURE_STDDEV,
                VELOCITY_MIN     = model.VELOCITY_MIN   ,
                VELOCITY_MAX     = model.VELOCITY_MAX   ,
                VELOCITY_AVG     = model.VELOCITY_AVG   ,
                VELOCITY_STDDEV  = model.VELOCITY_STDDEV,
            };
        }
    }
}
