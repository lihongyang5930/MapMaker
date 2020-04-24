namespace DrPipe.Core.Models
{
    public class MonthRange
    {
        public int Year1 { get; set; }
        public int Month1 { get; set; }

        public int Year2 { get; set; }
        public int Month2 { get; set; }

        public override string ToString()
        {
            return $"{GetMonthString(Year1, Month1)} ~ {GetMonthString(Year2, Month2)}";
        }
        private string GetMonthString(int year, int month)
        {
            return $"{year.ToString("D4")}-{month.ToString("D2")}";
        }
    }
}
