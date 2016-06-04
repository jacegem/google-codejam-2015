using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GoogleCodeJam.GCJ2014;

namespace GoogleCodeJam
{
    /*
    Bad magician!
    Case #3: Volunteer cheated!
     */

    class QA_MagicTrick
    {
        
          
        internal void solve()
        {
            int iGot;
            string theNumber = "";
            string pathref = @"../../GCJ2014/";
            string inFile = pathref + "QA-small-practice.in";
            string badMagician = "Bad magician!";
            string volunteerChated = "Volunteer cheated!";

            
            StreamUtil su = new StreamUtil(inFile);
            Dictionary<string, string> result = new Dictionary<string, string>();

            int caseCount = su.readInt();

            for (var caseNumber = 1; caseNumber <= caseCount; caseNumber++)
            {
                iGot = 0;
                result.Clear();

                int firstAnswer = su.readInt();
                
                for (int rowIdx = 1; rowIdx <= 4; rowIdx++) {
                    string row = su.readLine();
                    if (firstAnswer == rowIdx){
                        string[] arr = row.Split(' ');
                        foreach(string s in arr){
                            result.Add(s,s);
                        }
                    }
                }

                int secondAnswer = su.readInt();

                for (int rowIdx = 1; rowIdx <= 4; rowIdx++)
                {
                    string row = su.readLine();
                    if (secondAnswer == rowIdx)
                    {
                        string[] arr = row.Split(' ');
                        foreach (string s in arr)
                        {
                            if (result.ContainsKey(s)) {
                                iGot++;
                                theNumber = s;
                            }
                        }
                    }
                }

                string msg;
                if (iGot == 0) {
                    msg = volunteerChated;
                }
                else if (iGot == 1)
                {
                    msg = theNumber;
                }
                else {
                    msg = badMagician;
                }

                string outMsg = string.Format("Case #{0}: {1}", caseNumber, msg);

                su.writeLine(outMsg);
            }

        }

        
    }
}
