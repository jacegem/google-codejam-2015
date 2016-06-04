using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam.GCJ2014
{
    class R2A_The_Repeater
    {

        static int m_minChangeCnt = int.MaxValue; 

        internal void solve()
        {
            var folder = @"..\..\GCJ2014\";
            var inFile = "R2A-sample.in";
            var outFile = inFile.Replace(".in", ".out");
            var sr = new StreamReader(folder + inFile);
            var sw = new StreamWriter(folder + outFile);

            
            var caseCount = int.Parse(sr.ReadLine());
            for (var caseNumber = 1; caseNumber <= caseCount; caseNumber++)
            {
                m_minChangeCnt = int.MaxValue; 

                var strCount = int.Parse(sr.ReadLine());
                string[] strings = new string[strCount];

                for (int i = 0; i < strCount; i++) {
                    strings[i] = sr.ReadLine();
                }

                bool bFeglaWon = isFeglaWon(strings);
                if (bFeglaWon) 
                {
                    sw.WriteLine(string.Format("Case #{0}: Felga Won", caseNumber));
                    sw.Flush();
                    continue;
                }

                // let's find the minimum hints
                string longest = strings.OrderByDescending(ss => ss.Length).First();
                int minHints = getMin(strings, longest);
                Console.WriteLine(string.Format("{0}",minHints));
                sw.WriteLine(string.Format("Case #{0}: {1}", caseNumber, minHints));
                sw.Flush();
            }
        }

        

        private int getMin(string[] strings, string goal)
        {
            int changeCnt = 0;
            // goal 과 나머지를 모두 비교
            char? lastChar = null;
            foreach (string s in strings) {
                string cmpStr = s;

                for (int i = 0; i < goal.Length; i++) {
                    if (goal.Length > cmpStr.Length)
                    {
                        cmpStr += " ";
                    }
                    if (goal[i] != cmpStr[i])
                    {  // 다르면
                        changeCnt++;
                        // 복사 또는 삭제
                        if (goal[i] == lastChar)
                        {
                            cmpStr = cmpStr.Insert(i, lastChar.ToString());
                        }
                        else {
                            cmpStr = cmpStr.Remove(i, 1);
                        }
                    }

                    lastChar = goal[i];
                }
            }

            m_minChangeCnt = Math.Min(m_minChangeCnt, changeCnt);

            // 중복되어 있는 문자열이 있는가?
            lastChar = null;
            string org = goal;
            for (int i = 0; i < goal.Length; i++)
            {
                if (lastChar == goal[i])
                {
                    lastChar = goal[i];
                    goal = goal.Remove(i, 1);
                    getMin(strings, goal);
                }
                else {
                    lastChar = goal[i];
                }

                goal = org;
            }

            return 0;
        }


        private bool isFeglaWon(string[] strs)
        {
            string firstChars = removeDuplicates(strs[0]);

            //is same with others
            for (int i = 1; i < strs.Length; i++) {

                string other = removeDuplicates(strs[i]);
                if (firstChars.CompareTo(other) != 0)   // 0 is same
                {
                    return true;
                }
            }

            return false;
        }

        private string removeDuplicates(string str)
        {
            string resultString = "";
            char? lastChar = null;

            for (int i = 0; i < str.Length; i++) {
                char c = str[i];

                if (lastChar != c)
                {
                    resultString += c;
                    lastChar = c;
                }
            }

            return resultString;
        }
    }
}


/*
 * Problem A. The Repeater

문제

페글라와 오마르는 날마다 게임 즐기기를 좋아한다. 그러나 현재 그들은 모든 게임에 질려버렸다. 이제 새로운 게임을 즐기고 싶어한다. 그래서 그들은 "The Repeater" 라는 게임을 만들기로 결심한다. 

Fegla and Omar like to play games every day. But now they are bored of all games, and they would like to play a new game. So they decided to invent their own game called "The Repeater".

그들은 2명이 할수 있는 게임을 만들었다. 페글라는 N개의 문자열을 적는다. 오마르의 일은 아래 두가지 액션을 최소로 하면서 가능하면 모든 문자열을 똑같이 만들어 내는 것이다. 
 
They invented a 2 player game. Fegla writes down N strings. Omar's task is to make all the strings identical, if possible, using the minimum number of actions (possibly 0 actions) of the following two types:

	* Select any character in any of the strings and repeat it (add another instance of this character exactly after it). For example, in a single move Omar can change "abc" to "abbc" (by repeating the character 'b').
	* Select any two adjacent and identical characters in any of the strings, and delete one of them. For example, in a single move Omar can change "abbc" to "abc" (delete one of the 'b' characters), but can't convert it to "bbc".

The 2 actions are independent; it's not necessary that an action of the first type should be followed by an action of the second type (or vice versa).
Help Omar to win this game by writing a program to find if it is possible to make the given strings identical, and to find the minimum number of moves if it is possible.
InputThe first line of the input gives the number of test cases, T. T test cases follow. Each test case starts with a line containing an integer N which is the number of strings. Followed by N lines, each line contains a non-empty string (each string will consist of lower case English characters only, from 'a' to 'z').
OutputFor each test case, output one line containing "Case #x: y", where x is the test case number (starting from 1) and y is the minimum number of moves to make the strings identical. If there is no possible way to make all strings identical, print "Fegla Won" (quotes for clarity).
Limits1 ≤ T ≤ 100.
1 ≤ length of each string ≤ 100.
Small datasetN = 2.
Large dataset2 ≤ N ≤ 100.
Sample

Input 
 
Output 
 
5
2
mmaw
maw
2
gcj
cj
3
aaabbb
ab
aabb
2
abc
abc
3
aabc
abbc
abcc


Case #1: 1
Case #2: Fegla Won
Case #3: 4
Case #4: 0
Case #5: 3



*/