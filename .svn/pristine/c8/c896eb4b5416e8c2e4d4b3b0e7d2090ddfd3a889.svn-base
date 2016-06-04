using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GoogleCodeJam.GCJ2014
{
    class StreamUtil
    {
        private bool mIsDebug = true;
        private System.IO.StreamReader mReader;
        private System.IO.StreamWriter mWriter;
        private string mInputFile;
        private string mOutputFile;

        public StreamUtil(System.IO.StreamReader reader, System.IO.StreamWriter writer)
        {
            this.mReader = reader;
            this.mWriter = writer;
        }

        public StreamUtil(string inFile, string outFile)
        {
            mInputFile = inFile;
            mOutputFile = outFile;

            mReader = new StreamReader(mInputFile);
            mWriter = new StreamWriter(mOutputFile);
        }

        ~StreamUtil() {
            mReader.Close();
        }

        public StreamUtil(string inFile)
            :this(inFile, inFile.Replace(".in", ".out"))
        {
        }

        internal int readInt()
        {
            return int.Parse(readLine());
        }

        internal string readLine()
        {
            string line = mReader.ReadLine();
            if (mIsDebug) {
                Console.WriteLine("[READ]:"+ line);
            } 

            return line;
        }

        internal string[] readArray()
        {
            return readLine().Split(' ');
        }

        internal void writeLine(string outMsg)
        {
            if (mIsDebug) {
                Console.WriteLine("[WRITE]:" + outMsg);
            }
            mWriter.WriteLine(outMsg);
            mWriter.Flush();
        }

        internal double parse(string p)
        {
            return double.Parse(p);
        }
    }
}
