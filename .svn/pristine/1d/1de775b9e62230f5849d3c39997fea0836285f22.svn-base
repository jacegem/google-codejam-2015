using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    class QD_Deceitful_War
    {
        internal void solve()
        {
            var folder =  @"..\..\GCJ2014\";
            var inFile = "QD-small-practice.in";
            var outFile = inFile.Replace(".in", ".out");
            var inputStream = new StreamReader(folder + inFile);
            var outputStream = new StreamWriter(folder + outFile);

            var caseCount = int.Parse(inputStream.ReadLine());
            for (var caseNumber = 1; caseNumber <= caseCount; caseNumber++)
            {
                inputStream.ReadLine();
                var myStartingBlocks = inputStream.ReadLine().Split().Select(s => double.Parse(s)).ToArray();
                var hisStartingBlocks = inputStream.ReadLine().Split().Select(s => double.Parse(s)).ToArray();

                var fairScore = PlayBestGame(myStartingBlocks, hisStartingBlocks, true);
                var unfairScore = PlayBestGame(myStartingBlocks, hisStartingBlocks, false);

                outputStream.WriteLine("Case #{0}: {1} {2}", caseNumber, unfairScore, fairScore);
            }


            inputStream.Close();
            outputStream.Close();

        }

        private int PlayBestGame(double[] myStartingBlocks, double[] hisStartingBlocks, bool fair)
        {
            var myScore = 0;
            var myBlocks = new HashSet<double>(myStartingBlocks);
            var hisBlocks = new HashSet<double>(hisStartingBlocks);

            while (myBlocks.Count > 0) {
                double? myBlock = null;
                double? myBlockValueTold = null;

                if (false == fair) 
                {
                    var hisSmallest = hisBlocks.Min();
                    var canCheat = myBlocks.Any(my => my > hisSmallest);
                    if (canCheat)
                    {
                        myBlock = myBlocks.Where(my => my > hisSmallest).Min();
                        myBlockValueTold = 1.0d;
                    }
                }

                // choose my best brick
                if (!myBlock.HasValue) 
                {
                    myBlock = myBlocks.Max();
                    myBlockValueTold = myBlock;
                }
                

                // he chooses his smallest larger than min if he has one
                // otherwise he chooses his smallest brck to lose
                double hisBlock;
                if (hisBlocks.Any(his => his > myBlockValueTold))
                {
                    hisBlock = hisBlocks.Where(his => his > myBlockValueTold).Min();
                }
                else 
                {
                    hisBlock = hisBlocks.Min();
                    myScore++;
                }

                myBlocks.Remove(myBlock.Value);
                hisBlocks.Remove(hisBlock);
                
            }
            

            return myScore;
        }
    }
}
