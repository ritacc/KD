using System;
using System.Collections.Generic;
using System.Text;

namespace YZM
{
    public static class ByteUtil
    {
        /// <summary>
        /// 灰度处理
        /// </summary>
        /// <param name="buffer"></param>
        public static void GrayScale(byte[] buffer)
        {
            for (var i = 0; i < buffer.Length; i += 4)
            {
                double r = buffer[i];
                double g = buffer[i + 1];
                double b = buffer[i + 2];
                byte gray = (byte)(r * 0.3 + g * 0.59 + b * 0.11);
                buffer[i] = gray;
                buffer[i + 1] = gray;
                buffer[i + 2] = gray;
            }
        }

        /// <summary>
        /// 二值化处理 
        /// </summary>
        /// <param name="buffer">字节数组</param>
        public static void Binarization(byte[] buffer, int threshold)
        {
            for (var i = 0; i < buffer.Length; i += 4)
            {
                byte p = (byte)((buffer[i] < threshold) ? 0 : 1);
                buffer[i] = p;
                buffer[i + 1] = p;
                buffer[i + 2] = p;
            }
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <param name="rect">需要复制的矩形范围</param>
        /// <param name="stride">大步长</param>
        /// <returns>返回新的字节数组</returns>
        public static byte[] Copy(byte[] buffer, Rect rect, int stride)
        {
            byte[] result = new byte[rect.Width * rect.Height];
            for (int column = 0; column < rect.Width; column++)
            {
                for(int row = 0; row < rect.Height; row++)
                {
                    result[row * rect.Width + column] = buffer[(row + rect.Y) * stride + column + rect.X];
                }
            }
            return result;
        }

        public static byte[] Trim(byte[] buffer, int stride)
        {
            var step = buffer.Length / stride;
            var start = 0;
            var end = 0;
            var flag = false;
            for (int row = 0; row < step; row++)
            {
                if (flag)
                {
                    int sum = 0;
                    for (int column = 0; column < stride; column += 4)
                    {
                        sum += buffer[row * stride + column];
                    }
                    if (sum * 4 == stride)
                    {
                        end = row;
                        flag = !flag;
                    }
                }
                else
                {
                    for (int column = 0; column < stride; column += 4)
                    {
                        if (buffer[row * stride + column] == 0)
                        {
                            start = row;
                            flag = !flag;
                            break;
                        }
                    }
                }
            }
            Rect rect = new Rect(0, start, stride, end - start);
            return Copy(buffer, rect, stride);
        }

        public static byte[][] Split(byte[] buffer, int stride, int count)
        {
            bool flag = false;
            int step = buffer.Length / stride;
            int start = 0;
            int end = 0;
            int index = 0;
            byte[][] result = new byte[count][];

            for (int column = 0; column < stride; column += 4)
            {
                if (flag)
                {
                    int sum = 0;
                    for (int row = 0; row < step; row++)
                    {
                        sum += buffer[row * stride + column];
                    }
                    if (sum == step)
                    {
                        end = column;
                        flag = !flag;
                        Rect rect = new Rect(start, 0, end - start, step);
                        //result[index] = Copy(buffer, rect, stride);
                        result[index] = Trim(Copy(buffer, rect, stride), end - start);
                        index++;
                        if (index == count)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (var row = 0; row < step; row++)
                    {
                        if (buffer[row * stride + column] == 0)
                        {
                            start = column;
                            flag = !flag;
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
