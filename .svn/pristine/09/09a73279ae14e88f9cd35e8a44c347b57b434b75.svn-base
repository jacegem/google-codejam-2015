using GoogleCodeJam.GCJ2014;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    class QB_CookieClickerAlpha
    {
        internal void solve()
        {
            string pathref = @"../../GCJ2014/";
            string inFile = pathref + "QS-small-practice.in";

            StreamUtil su = new StreamUtil(inFile);

            int caseCount = su.readInt();

            for (var caseNumber = 1; caseNumber <= caseCount; caseNumber++)
            {
                string[] nums = new string[3];
                nums = su.readArray();
                double cc = su.parse(nums[0]);
                double ff = su.parse(nums[1]);
                double xx = su.parse(nums[2]);

                double cps = 2.0;
                double cons_time = 0;
                double secs_min = ( xx / cps ) + cons_time;

                while (true) { 
                    cons_time = cons_time + (cc / cps);
                    cps = cps + ff;
                    
                    double secs_other = ( xx / cps)  + cons_time;

                    if (secs_other < secs_min)
                    {
                        secs_min = secs_other;
                    }
                    else {
                        break;                    
                    }
                }

                // print
                string outMsg = string.Format("Case #{0}: {1:.0000000}", caseNumber, secs_min);
                su.writeLine(outMsg);
            }
        }
    }
}
