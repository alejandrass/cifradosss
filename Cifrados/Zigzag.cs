using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace cifradoss.Cifrados
{
    public class Zigzag
    {
        public string Convert2(string s, int numRows)
        {
            if (numRows <= 1) return s;
            var strbuilder = new StringBuilder[numRows];
            for (var i = 0; i < numRows; i++)
            {
                strbuilder[i] = new StringBuilder();
            }

            var step = 1;
            var index = 0;
            foreach (char ch in s)
            {
                strbuilder[index].Append(ch);
                if (index == 0) step = 1;
                if (index == numRows - 1) step = -1;

                index += step;
            }

            var res = new StringBuilder();
            for (var i = 0; i < numRows; i++)
            {
                res.Append(strbuilder[i]);
            }

            return res.ToString();
        }
    }
}
