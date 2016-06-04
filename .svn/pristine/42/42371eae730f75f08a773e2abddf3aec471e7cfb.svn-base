using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    class R1C_Proper_Shuffle
    {
        internal void solve()
        {
            var folder = @"..\..\GCJ2014\";
            var inFile = "R1C-small-practice.in";
            var outFile = inFile.Replace(".in", ".out");
            var sr = new StreamReader(folder + inFile);
            var sw = new StreamWriter(folder + outFile);

            
            var caseCount = int.Parse(sr.ReadLine());
            for (var caseNumber = 1; caseNumber <= caseCount; caseNumber++)
            {
                int N = int.Parse(sr.ReadLine());
                int[] nums = new int[N];

                for (int i = 0; i < N; i++)
                {
                    nums[i] = i;
                }

                int[] pens = sr.ReadLine().Split().Select(s => Convert.ToInt32(s)).ToArray();

                string outmsg ="";
                
                int zeroPosition = getIndex(pens, 0);
                
                while (zeroPosition != 0)
                {  
                     int idx = getIndex(pens, zeroPosition);

                    //swap 
                    //pens[zeroPosition], pens[idx]

                    int temp = pens[zeroPosition];
                    pens[zeroPosition] = pens[idx];
                    pens[idx] = temp;
                    zeroPosition = idx;
                }

                for (int i = 0; i < N; i++) {
                    if (pens[i] != i) {
                        outmsg = "BAD";
                        break;
                    }
                }

                    if (string.IsNullOrEmpty(outmsg))
                    {
                        outmsg = "GOOD";
                    }

                sw.WriteLine(string.Format("Case #{0}: {1}", caseNumber, outmsg));
                sw.Flush();
            }
        }

        private int getIndex(int[] pens, int find)
        {
            for (int i = 0; i < pens.Length; i++) {
                if (pens[i] == find) {
                    return i;
                }
            }

            return 0;
        }
    }
}
