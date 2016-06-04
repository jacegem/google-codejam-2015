using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    class R1A_Charging_Chaos
    {
        internal void solve()
        {
            var folder =  @"..\..\GCJ2014\";
            var inFile = "R1A-small-practice.in";
            var outFile = inFile.Replace(".in", ".out");
            var inputStream = new StreamReader(folder + inFile);
            var outputStream = new StreamWriter(folder + outFile);

            var caseCount = int.Parse(inputStream.ReadLine());
            for (var caseNumber = 1; caseNumber <= caseCount; caseNumber++)
            {
                inputStream.ReadLine();
                var flows = inputStream.ReadLine().Split().Select(s => Convert.ToInt64(s, 2)).ToArray();
                var devices = new HashSet<long>(inputStream.ReadLine().Split().Select(s => Convert.ToInt64(s, 2)));
                // why use hashSet? for use IntersectWith

                var minimumChanges = int.MaxValue;

                foreach (var flow in flows) 
                {
                    foreach (var device in devices)
                    {
                        var changes = flow ^ device;
                        var changeCount = 0;
                        var tempChanges = changes;

                        for (var i = 0; i < 64; i++) {
                            if ((tempChanges & 1) != 0)
                            {
                                changeCount++;
                            }
                            tempChanges >>= 1;
                        }

                        if (changeCount < minimumChanges) 
                        {
                            var newFlows = new HashSet<long>(flows.Select(f => f ^ changes));
                            newFlows.IntersectWith(devices);

                            if (newFlows.Count == flows.Length)
                                minimumChanges = changeCount;

                        }
                    }
                }

                if (minimumChanges != int.MaxValue)
                {
                    outputStream.WriteLine("Case #{0}: {1}", caseNumber, minimumChanges);
                }
                else {
                    outputStream.WriteLine("Case #{0}: NOT POSSIBLE", caseNumber);
                }
            }

            inputStream.Close();
            outputStream.Close();
        }
    }
}
