using System;
using System.Collections.Generic;
using System.Text;

namespace YZM
{
    public static class EMS
    {
        /// <summary>
        /// 验证码模板
        /// </summary>
        static string[][] Maps =
        {
            new string[] {"0", "111000111100000001100111001001111100001111100001111100001111100001111100001111100001111100100111001100000001111000111"},
            new string[] {"1", "11000111000001110000011111100111111001111110011111100111111001111110011111100111111001110000000000000000"},
            new string[] {"2", "10000011000000010111110011111100111111001111100111110011111001111100111110011111001111110000000000000000"},
            new string[] {"3", "10000011000000000111110011111100111110011000001110000001111110001111110011111100011110000000000110000011"},
            new string[] {"4", "111110011111100011111100011111000011110010011110010011100110011100110011000000000000000000111110011111110011111110011"},
            new string[] {"5", "00000000000000000011111100111111001111110000011100000001111110001111110011111100011110000000000110000011"},            
            new string[] {"6", "111000011110000001100111101100111111001111111001000011000000001000111000001111100001111100100111000100000001111000011"},
            new string[] {"7", "00000000000000001111110011111101111110011111001111110111111001111110111111001111110011111001111110011111"},            
            new string[] {"8", "110000011100000001100111001100111001100011011110000011110000011100110001001111100001111100000111000100000001110000011"},
            new string[] {"9", "110000111100000001000111001001111100001111100000111000100000000110000100111111100111111001101111001100000011110000111"}
        };

        /// <summary>
        /// 验证码个数
        /// </summary>
        static int COUNT = 6;

        /// <summary>
        /// 二值化阈值
        /// </summary>
        static int THRESHOLD = 125;

        /// <summary>
        /// 默认字符
        /// </summary>
        static string DEFAULT = "-";

        /// <summary>
        /// 相似百分比
        /// </summary>
        static int SIMILAR_PERCENTAGES = 90;

        public static string Get(byte[] buffer, int stride)
        {
            ByteUtil.GrayScale(buffer); // 灰度处理
            ByteUtil.Binarization(buffer, THRESHOLD); // 二值化
            byte[][] group = ByteUtil.Split(buffer, stride, COUNT); // 分割字符

            for (int j = 0; j < buffer.Length / stride; j++)
            {
                for (int i = 0; i < stride; i += 4)
                {
                    Console.Write(buffer[j * stride + i]);
                }
                Console.WriteLine();
            }

            string[] letters = new string[COUNT];
            for (int i = 0; i < 6; i++)
            {
                byte[] item = group[i];
                letters[i] = DEFAULT;
                for (int j = 0; j < Maps.Length; j++)
                {
                    string map = Maps[j][1];
                    if (item.Length == map.Length * 4)
                    {
                        int flag = 0;
                        for (int k = 0; k < map.Length; k++)
                        {
                            if (map[k].ToString() == item[k * 4].ToString())
                            {
                                flag++;
                            }
                        }

                        if (flag * 100 / map.Length > 90)
                        {
                            letters[i] = Maps[j][0];
                            break;
                        }
                    }
                }
            }
            return string.Join("", letters);
        }
    }
}
