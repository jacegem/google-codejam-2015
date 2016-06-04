using GoogleCodeJam.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    class QA_Standing_Ovation
    {
        internal static void solve()
        {
            int iGot;
            string theNumber = "";
            string pathref = @"../../GCJ2015/";
            string inFile = pathref + "A-large.in";

            /*
             * 
             *  4
                4 11111
                1 09
                5 110011
                0 1
             * 
             */
            StreamUtil su = new StreamUtil(inFile);

            int caseCount = su.readInt();

            for (var caseNumber = 1; caseNumber <= caseCount; caseNumber++)
            {
                string row = su.readLine();
                string[] arr = row.Split(' ');

                int max = Convert.ToInt32(arr[0]);
                char[] s = arr[1].ToCharArray();

                int sum = 0;
                int over = 0;
                for (int i = 0; i < s.Length; i++) {
                    int n = Convert.ToInt32(s[i].ToString());

                    if (n == 0) {
                        continue;
                    }

                    if (sum < i)
                    {
                        over += i - sum;
                        sum += over;
                    }


                    sum += n;

                                       
                }

                string outMsg = string.Format("Case #{0}: {1}", caseNumber, over);
                su.writeLine(outMsg);
            }
        }
    }
}
