using GoogleCodeJam.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    class QD_Ominous_Omino
    {

        internal static void solve()
        {
            string pathref = @"../../GCJ2015/";
            string inFile = pathref + "D-small-attempt2.in";

            StreamUtil su = new StreamUtil(inFile);

            int caseCount = su.readInt();
            string wg = "GABRIEL";
            string wr = "RICHARD";
            

            for (int caseNumber = 1; caseNumber <= caseCount; caseNumber++)
            {
                string[] arr = su.readLine().Split(' ');
                int x = Convert.ToInt32(arr[0]);
                int r = Convert.ToInt32(arr[1]);
                int c = Convert.ToInt32(arr[2]);
                string winner = "";

                if (((x % 2) == 1) ^ (((r * c) % 2) == 1))
                {
                    //GABRAEL
                    winner = wr;
                }
                else if (x >= 7){
                    winner = wr;
                }
                else if (r < (x /2) || c < (x /2))
                {
                    winner = wr;
                }
                else {
                    winner = wg;
                }


                string outMsg = string.Format("Case #{0}: {1}", caseNumber, winner);
                su.writeLine(outMsg);

            }
        }
    }
}
