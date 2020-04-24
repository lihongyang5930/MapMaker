namespace DrPipe.Diagnosis.Models
{
    public class Pipe
    {
        public int     ID      { get; set; }
        public string  MGR_ID  { get; set; }
        public string  PP_TYPE { get; set; }
        public double? PP_CIR  { get; set; }
        public double? PP_LEN  { get; set; }
        public decimal? NYEAR   { get; set; }
        public double? LEAK_BASE  { get; set; }
        public double? LEAK_BREAK { get; set; }
        public double? LEAK_SUM   { get; set; }
        public double? LEAK2      { get; set; }
        public double? PRESSURE_MIN { get; set; }
        public double? PRESSURE_MAX { get; set; }
        public double? PRESSURE_AVG { get; set; }
        public double? PRESSURE_STDDEV { get; set; }
        public double? VELOCITY_MIN { get; set; }
        public double? VELOCITY_MAX { get; set; }
        public double? VELOCITY_AVG { get; set; }
        public double? VELOCITY_STDDEV { get; set; }

        /// <summary>급수관연장</summary>
        public double Col1 { get; set; }
        /// <summary>급수전수</summary>
        public double Col2 { get; set; }

        public Pipe Copy()
        {
            return new Pipe {
                ID                = ID              ,
                MGR_ID            = MGR_ID          ,
                PP_TYPE           = PP_TYPE         ,
                PP_CIR            = PP_CIR          ,
                PP_LEN            = PP_LEN          ,
                 NYEAR            =  NYEAR          ,
                LEAK_BASE         = LEAK_BASE       ,
                LEAK_BREAK        = LEAK_BREAK      ,
                LEAK_SUM          = LEAK_SUM        ,
                LEAK2             = LEAK2           ,
                PRESSURE_MIN      = PRESSURE_MIN    ,
                PRESSURE_MAX      = PRESSURE_MAX    ,
                PRESSURE_AVG      = PRESSURE_AVG    ,
                PRESSURE_STDDEV   = PRESSURE_STDDEV ,
                VELOCITY_MIN      = VELOCITY_MIN    ,
                VELOCITY_MAX      = VELOCITY_MAX    ,
                VELOCITY_AVG      = VELOCITY_AVG    ,
                VELOCITY_STDDEV   = VELOCITY_STDDEV ,
                Col1              = Col1            ,
                Col2              = Col2            ,
            };
        }
    }
}
