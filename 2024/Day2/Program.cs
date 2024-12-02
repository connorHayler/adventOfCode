namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int safeReports = 0;
            foreach (var line in File.ReadLines("day2input.txt")){
                string[] split =  line.Split(" ");
                bool safe = true;
                bool increasing = true;
                bool damper = true;
                for(int i  = 1; i < split.Length; i++)
                {
                    var difference = Math.Abs(Int32.Parse(split[i]) - Int32.Parse(split[i - 1]));
                    if(i >= 2)
                    {
                        if((Int32.Parse(split[i]) < Int32.Parse(split[i - 1]) && increasing))
                        {
                            if (damper)
                            {
                                damper = false;
                            }
                            else
                            {
                                safe = false;
                                break;
                            }
                        }
                        else if((Int32.Parse(split[i]) > Int32.Parse(split[i - 1]) && !increasing))
                        {
                            if (damper)
                            {
                                damper = false;
                            }
                            else
                            {
                                safe = false;
                                break;
                            }
                        }
                    }
                    if(Int32.Parse(split[i]) < Int32.Parse(split[i - 1]))
                    {
                        increasing = false;
                    }
                    if (difference is <= 0 or > 3)
                    {
                        if (damper)
                        {
                            damper = false;
                        }
                        else
                        {
                            safe = false;
                            break;
                        }
                    }
                }
                if (safe)
                {
                    safeReports++;
                }
            }
            Console.WriteLine(safeReports);
        }
    }
}
