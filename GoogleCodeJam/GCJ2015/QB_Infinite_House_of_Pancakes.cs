using GoogleCodeJam.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    class QB_Infinite_House_of_Pancakes
    {
        internal static void solve()
        {
            string pathref = @"../../GCJ2015/";
            string inFile = pathref + "B-small-attempt2.in";

            /*
3
1
3
4
1 2 1 2
1
4
             
             */

            StreamUtil su = new StreamUtil(inFile);

            int caseCount = su.readInt();

            for (int caseNumber = 1; caseNumber <= caseCount; caseNumber++)
            {
                string plates = su.readLine();
                string[] non_empty = su.readLine().Split(' ');

                int[] ns = new int[non_empty.Length];
                ArrayList arr = new ArrayList();
                
                for (int i = 0; i < non_empty.Length; i++) {
                    arr.Add(Convert.ToInt32(non_empty[i]));
                }

                int min = Int32.MaxValue;
                int divideCnt = 0;

                while (true) {
                    arr.Sort();
                    arr.Reverse();
                    int max = (int)arr[0];
                    int newMin = divideCnt++ + max;

                    if (min >= newMin)
                    {
                        min = newMin;
                    }

                    if (max == 1) {
                        break;
                    }

                    // 최대값을 나누어서 저장.
                    arr.RemoveAt(0);
                    int half = max / 2;
                    arr.Add(half);
                    arr.Add(max - half);                
                }
                

                string outMsg = string.Format("Case #{0}: {1}", caseNumber, min);
                su.writeLine(outMsg);
            }
        }
    }
}
