using System.Collections.Generic;
using System.Linq;
using MindOne.DrPipe.Dpf.Models;

namespace DrPipe.Diagnosis.Models
{
    public class PipeGroup
    {
        public PipeGroup()
        {
             Pipes = Enumerable.Empty<Pipe>();
        }

        public IEnumerable<Pipe> Pipes { get; set; }

        /// <summary>진단구역</summary>
        public string Zone { get; set; }

        /// <summary>평균표고</summary>
        public double AvgElevation { get; set; }
        /// <summary>평균수압-누수량분석 입력 해야됨</summary>
        public double InputAvgPressure { get; set; }
        /// <summary>유입유량</summary>
        public double InFlow { get; set; }
        /// <summary>사용량</summary>
        public double Usage { get; set; }
        /// <summary>무수수량</summary>
        public double AnhydrouAmount { get; set; }
        /// <summary>배경누수량-배수관</summary>
        public double Col6 { get; set; }
        /// <summary>배경누수량-급수시설</summary>
        public double Col7 { get; set; }
        /// <summary>배경누수량-옥내</summary>
        public double Col8 { get; set; }
        /// <summary>배경누수량</summary>
        public double Col9 { get; set; }
        /// <summary>파열누수량</summary>
        public double RuptureLeakage { get; set; }
        /// <summary>누수량</summary>
        public double Leakage { get; set; }
        /// <summary>최수수압</summary>
        public double MinPressure { get; set; }
        /// <summary>최대수압</summary>
        public double MaxPressure { get; set; }
        /// <summary>평균수압</summary>
        public double AvgPressure { get; set; }
        /// <summary>수압표준편차</summary>
        public double StDevPressure { get; set; }
        /// <summary>최소유속</summary>
        public double MinVelocity { get; set; }
        /// <summary>최대유속</summary>
        public double MaxVelocity { get; set; }
        /// <summary>평균유속</summary>
        public double AvgVelocity { get; set; }
        /// <summary>유속표준편차</summary>
        public double StDevVelocity { get; set; }

        public PipeGroup Copy()
        {
            return new PipeGroup {
                Pipes            = Pipes?.Select(x => x.Copy()).ToArray(),
                Zone             = Zone            ,
                AvgElevation     = AvgElevation    ,
                InputAvgPressure = InputAvgPressure,
                InFlow           = InFlow          ,
                Usage            = Usage           ,
                AnhydrouAmount   = AnhydrouAmount  ,
                Col6             = Col6            ,
                Col7             = Col7            ,
                Col8             = Col8            ,
                Col9             = Col9            ,
                RuptureLeakage   = RuptureLeakage  ,
                Leakage          = Leakage         ,
                MinPressure      = MinPressure     ,
                MaxPressure      = MaxPressure     ,
                AvgPressure      = AvgPressure     ,
                StDevPressure    = StDevPressure   ,
                MinVelocity      = MinVelocity     ,
                MaxVelocity      = MaxVelocity     ,
                AvgVelocity      = AvgVelocity     ,
                StDevVelocity    = StDevVelocity   ,
            };
        }
    }
}
