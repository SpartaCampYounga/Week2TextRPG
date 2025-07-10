using System.Text;

namespace Week2TextRPG_Younga.Utility
{
    public static class FormatUtility
    {
        public static int GetStringWidth(string str)
        {
            int width = 0;
            foreach (char c in str)
            {
                width += c >= 0xAC00 && c <= 0xD7A3 ? 2 : 1;  //한글 전각 문자 범위
            }

            return width;
        }
        public static string AlignWithPadding(string str, int width)
        {
            //int pad = width - Encoding.Default.GetBytes(str).Length; //바이트로 구할 경우 몬가.. 이상하게 됨ㅠㅠ
            int padding = width - GetStringWidth(str);
            padding = Math.Max(0, padding);

            return str + new string(' ', padding);
        }
    }

}
