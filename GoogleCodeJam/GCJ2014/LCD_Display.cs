using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    class LCD_Display
    {
        // '-' , '|'
        readonly string HOR_BAR = "-";
        readonly string VER_BAR = "|";
        readonly string BLANK = " ";

        // 출력 문자열 저장
        List<string> listPrint = new List<string>();
        
        // 비교값
        Dictionary<int, Dictionary<string, Boolean>> map = new Dictionary<int, Dictionary<string, bool>>();

        readonly string HEADER = "header";
        readonly string HEAD_LEFT = "head_left";
        readonly string HEAD_RIGHT = "head_right";
        readonly string MIDDLE = "middle";
        readonly string BOTT_LEFT = "bott_left";
        readonly string BOTT_RIGHT = "bott_right";
        readonly string BOTTOM = "bottom";

        readonly string DISPLAY_FLAG = "1";

        public LCD_Display() {
            
            addToMap(1, "0010010");
            addToMap(2, "1011101");
            addToMap(3, "1011011");
            addToMap(4, "0111010");
            addToMap(5, "1101011");
            addToMap(6, "1101111");
            addToMap(7, "1010010");
            addToMap(8, "1111111");
            addToMap(9, "1111011");
            addToMap(0, "1110111");           
            
        }

        private void addToMap(int targetNum, string value)
        {
            Dictionary<string, Boolean> numMap = new Dictionary<string, bool>();

            int idx = 0;
            numMap.Add(HEADER, isTrue(value, idx++));
            numMap.Add(HEAD_LEFT, isTrue(value, idx++));
            numMap.Add(HEAD_RIGHT, isTrue(value, idx++));
            numMap.Add(MIDDLE, isTrue(value, idx++));
            numMap.Add(BOTT_LEFT, isTrue(value, idx++));
            numMap.Add(BOTT_RIGHT, isTrue(value, idx++));
            numMap.Add(BOTTOM, isTrue(value, idx++));

            map.Add(targetNum, numMap);
        }

        private bool isTrue(string value, int idx)
        {
            return value.Substring(idx, 1) == DISPLAY_FLAG;
        }

        internal void solve()
        {
            display("2", "12345");
            listPrint.Add("");
            display("3", "67890");

            foreach(string s in listPrint){
                Console.WriteLine(s);
            }


        }

        private void display(string pSize, string pNum)
        {
            int size = Convert.ToInt32(pSize);

            string oneLine = "";

            // head line
            for (int i = 0; i < pNum.Length; i++)
            {                 
                int num = Convert.ToInt32(pNum.Substring(i, 1));
                oneLine += getHorLine(num, size, HEADER);
                oneLine += BLANK;
            }

            listPrint.Add(oneLine);


            
            for (int j = 0; j < size; j++) {
                oneLine = "";

                for (int i = 0; i < pNum.Length; i++)
                {
                    int num = Convert.ToInt32(pNum.Substring(i, 1));
                    oneLine += getVerLine(num, size, HEAD_LEFT, HEAD_RIGHT);
                    oneLine += BLANK;
                }

                listPrint.Add(oneLine);
            }

            // middle line
            oneLine = "";

            for (int i = 0; i < pNum.Length; i++)
            {
                int num = Convert.ToInt32(pNum.Substring(i, 1));
                oneLine += getHorLine(num, size, MIDDLE);
                oneLine += BLANK;
            }

            listPrint.Add(oneLine);
            
            // bottom line
            for (int j = 0; j < size; j++)
            {
                oneLine = "";

                for (int i = 0; i < pNum.Length; i++)
                {
                    int num = Convert.ToInt32(pNum.Substring(i, 1));
                    oneLine += getVerLine(num, size, BOTT_LEFT, BOTT_RIGHT);
                    oneLine += BLANK;
                }

                listPrint.Add(oneLine);
            }

            oneLine = "";

            for (int i = 0; i < pNum.Length; i++)
            {
                int num = Convert.ToInt32(pNum.Substring(i, 1));
                oneLine += getHorLine(num, size, BOTTOM);
                oneLine += BLANK;
            }

            listPrint.Add(oneLine);
        }

        private string getVerLine(int num, int size, string keyLeft, string keyRight)
        {
            string rst = "";

            if (map[num][keyLeft] == true)
            {
                rst += VER_BAR;
            }
            else
            {
                rst += BLANK;
            }

            for (int i = 0; i < size; i++)
            {
                rst += BLANK;
            }

            if (map[num][keyRight] == true)
            {
                rst += VER_BAR;
            }
            else
            {
                rst += BLANK;
            }

            return rst;
        }

        private string getHorLine(int num, int size, string key)
        {
            string rst = "";

            for (int i = 0; i < size; i++)
            {
                if (map[num][key] == true)
                {
                    rst += HOR_BAR;
                }
                else
                {
                    rst += BLANK;
                }
            }

            return BLANK + rst + BLANK;
        }

            

    }
}
