using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace GoogleCodeJam
{
    class R1B_Full_Binary_Tree
    {
        internal void solve()
        {
            var folder = @"..\..\GCJ2014\";
            var inFile = "R1B-small-practice.in";
            var outFile = inFile.Replace(".in", ".out");
            var sr = new StreamReader(folder + inFile);
            var sw = new StreamWriter(folder + outFile);

            var caseCount = int.Parse(sr.ReadLine());
            for (var caseNumber = 1; caseNumber <= caseCount; caseNumber++)
            {

                List<int[]> edges = new List<int[]>();
                int N = int.Parse(sr.ReadLine());

                for (int j = 0; j < N - 1; j++) {
                    int[] splitted = sr.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
                    splitted[0] -= 1;
                    splitted[1] -= 1;
                    edges.Add(splitted);    
                }

                int res = solve(N, edges);
                sw.WriteLine(string.Format("Case #{0}: {1}", caseNumber, res));

            }//for            


            sr.Close();
            sw.Close();
        }

        private int solve(int N, List<int[]> edges)
        {
            int res = 0;

            Dictionary<int, List<int>> incindence = new Dictionary<int, List<int>>();

            for (int i = 0; i < N; i++)
            {
                incindence[i] = new List<int>();
            }

            foreach (var ee in edges)
            {
                incindence[ee[0]].Add(ee[1]);
                incindence[ee[1]].Add(ee[0]);
            }

            for (int root = 0; root < N; root++)
            {
                int cur = findBiggestSubtree(root, -1, incindence);
                res = Math.Max(res, cur);
            }

            return N - res;
        }

        private int findBiggestSubtree(int root, int parent, Dictionary<int, List<int>> incindence)
        {
            var inc = incindence[root].Where(j => j != parent).ToArray();
            if (inc.Length <= 1)
                return 1;

            int[] sr = new int[inc.Length];

            for (int i = 0; i < inc.Length; i++)
            {
                int subroot = inc[i];
                sr[i] = findBiggestSubtree(subroot, root, incindence);
            }

            Array.Sort(sr);
            return 1 + sr[inc.Length - 1] + sr[inc.Length - 2];
        }
    }
}
