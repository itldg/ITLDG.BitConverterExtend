using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace ITLDG
{
    /// <summary>
    /// 对BitConverter进行方法扩展
    /// </summary>
    public static class BitConverterExtend
    {
        #region 辅助函数
        /// <summary>
        /// 字节数组拷贝并反转
        /// </summary>
        /// <param name="value">要拷贝的数组</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="len">拷贝长度</param>
        /// <returns>反转后的字节数组</returns>
        static byte[] CopyAndReverse(byte[] value, int startIndex, int len)
        {
            byte[] bs = new byte[len];
            for (int i = 0; i < len; i++)
            {
                bs[len - 1 - i] = value[startIndex + i];
            }
            return bs;
        }
        #endregion

        #region 将指定的数据转换为字节数组。

        /// <summary>
        /// 以网络字节序（大端模式）的字节数组形式返回指定的 Unicode 字符值。
        /// </summary>
        /// <param name="value">要转换的数字。</param>
        /// <returns>长度为 2 的字节数组。</returns>
        public static byte[] GetBytesBigEndian(this char value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray();
        }

        /// <summary>
        /// 以网络字节序（大端模式）的字节数组形式返回指定的双精度浮点值。
        /// </summary>
        /// <param name="num">要转换的数字。</param>
        /// <returns>长度为 8 的字节数组。</returns>
        public static byte[] GetBytesBigEndian(this double num)
        {
            return BitConverter.GetBytes(num).Reverse().ToArray();
        }

        /// <summary>
        /// 以网络字节序（大端模式）的字节数组形式返回指定的 16 位有符号整数值。
        /// </summary>
        /// <param name="num">要转换的数字。</param>
        /// <returns>长度为 2 的字节数组。</returns>
        public static byte[] GetBytesBigEndian(this short num)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(num));
        }

        /// <summary>
        /// 以网络字节序（大端模式）的字节数组形式返回指定 32 位有符号整数值。
        /// </summary>
        /// <param name="num">要转换的数字。</param>
        /// <returns>长度为 4 的字节数组。</returns>
        public static byte[] GetBytesBigEndian(this int num)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(num));
        }

        /// <summary>
        /// 以网络字节序（大端模式）的字节数组形式返回指定 64 位带符号整数值。
        /// </summary>
        /// <param name="num">要转换的数字。</param>
        /// <returns>长度为 8 的字节数组。</returns>
        public static byte[] GetBytesBigEndian(this long num)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(num));
        }

        /// <summary>
        /// 以网络字节序（大端模式）的字节数组形式返回指定的单精度浮点值。
        /// </summary>
        /// <param name="num">要转换的数字。</param>
        /// <returns>长度为 4 的字节数组。</returns>
        public static byte[] GetBytesBigEndian(this float num)
        {
            return BitConverter.GetBytes(num).Reverse().ToArray();
        }

        /// <summary>
        /// 以网络字节序（大端模式）的字节数组形式返回指定的 16 位无符号整数值。
        /// </summary>
        /// <param name="num">要转换的数字。</param>
        /// <returns>长度为 2 的字节数组。</returns>
        public static byte[] GetBytesBigEndian(this ushort num)
        {
            return ((short)num).GetBytesBigEndian();
        }

        /// <summary>
        /// 以网络字节序（大端模式）的字节数组形式返回指定的 32 位无符号整数值。
        /// </summary>
        /// <param name="num">要转换的数字。</param>
        /// <returns>长度为 4 的字节数组。</returns>
        public static byte[] GetBytesBigEndian(this uint num)
        {
            return ((int)num).GetBytesBigEndian();
        }

        /// <summary>
        /// 以网络字节序（大端模式）的字节数组形式返回指定的 64 位无符号整数值。
        /// </summary>
        /// <param name="num">要转换的数字。</param>
        /// <returns>长度为 8 的字节数组。</returns>
        public static byte[] GetBytesBigEndian(this ulong num)
        {
            return ((long)num).GetBytesBigEndian();
        }
        #endregion

        #region 将字节数组转换为指定的数据格式
        /// <summary>
        /// 返回由字节数组中指定位置的两个字节转换来的 Unicode 字符。
        /// </summary>
        /// <param name="value">包含要转换的两个字节的数组。</param>
        /// <param name="startIndex"><see cref="value"/> 内的起始位置。</param>
        /// <returns>以两个字节开头 <see cref="startIndex"/> 的字符。</returns>
        public static char ToCharByBigEndian(this byte[] value, int startIndex = 0)
        {
            return BitConverter.ToChar(CopyAndReverse(value, startIndex, 2), 0);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的八个字节转换来的双精度浮点数。
        /// </summary>
        /// <param name="value">包含要转换的八个字节的字节数组。</param>
        /// <param name="startIndex"><see cref="value"/> 内的起始位置。</param>
        /// <returns>以八个字节开头 <see cref="startIndex"/> 的字符。</returns>
        public static double ToDoubleByBigEndian(this byte[] value, int startIndex = 0)
        {
            return BitConverter.ToDouble(CopyAndReverse(value, startIndex, 8), 0);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的两个字节转换来的 16 位有符号整数。
        /// </summary>
        /// <param name="value">包含要转换的两个字节的字节数组。</param>
        /// <param name="startIndex"><see cref="value"/> 内的起始位置。</param>
        /// <returns>由两个字节构成、从 <see cref="startIndex"/> 开始的 16 位有符号整数。</returns>
        public static short ToInt16ByBigEndian(this byte[] value, int startIndex = 0)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(value, startIndex));
        }

        /// <summary>
        /// 返回由字节数组中指定位置的四个字节转换来的 32 位有符号整数。
        /// </summary>
        /// <param name="value">包含要转换的四个字节的字节数组。</param>
        /// <param name="startIndex"><see cref="value"/> 内的起始位置。</param>
        /// <returns>由四个字节构成、从 <see cref="startIndex"/> 开始的 32 位有符号整数。</returns>
        public static int ToInt32ByBigEndian(this byte[] value, int startIndex = 0)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt32(value, startIndex));
        }

        /// <summary>
        /// 返回由字节数组中指定位置的八个字节转换来的 64 位有符号整数。
        /// </summary>
        /// <param name="value">包含要转换的八个字节的字节数组。</param>
        /// <param name="startIndex"><see cref="value"/> 内的起始位置。</param>
        /// <returns>由八个字节构成、从 <see cref="startIndex"/> 开始的 64 位有符号整数。</returns>
        public static long ToInt64ByBigEndian(this byte[] value, int startIndex = 0)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt64(value, startIndex));
        }

        /// <summary>
        /// 返回由字节数组中指定位置的四个字节转换来的单精度浮点数。
        /// </summary>
        /// <param name="value">包含要转换的四个字节的字节数组。</param>
        /// <param name="startIndex"><see cref="value"/> 内的起始位置。</param>
        /// <returns>由四个字节构成、从 <see cref="startIndex"/> 开始的单精度浮点数。</returns>
        public static float ToSingleByBigEndian(this byte[] value, int startIndex = 0)
        {
            return BitConverter.ToSingle(CopyAndReverse(value, startIndex, 4), 0);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的两个字节转换来的 16 位无符号整数。
        /// </summary>
        /// <param name="value">包含要转换的两个字节的字节数组。</param>
        /// <param name="startIndex"><see cref="value"/> 内的起始位置。</param>
        /// <returns>由两个字节构成、从 <see cref="startIndex"/> 开始的 16 位无符号整数。</returns>
        public static ushort ToUInt16ByBigEndian(this byte[] value, int startIndex = 0)
        {
            return (ushort)((value[startIndex++] << 8) | value[startIndex]);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的四个字节转换来的 32 位无符号整数。
        /// </summary>
        /// <param name="value">包含要转换的四个字节的字节数组。</param>
        /// <param name="startIndex"><see cref="value"/> 内的起始位置。</param>
        /// <returns>由四个字节构成、从 <see cref="startIndex"/> 开始的 32 位无符号整数。</returns>
        public static uint ToUInt32ByBigEndian(this byte[] value, int startIndex = 0)
        {
            return (uint)((value[startIndex++] << 24) | (value[startIndex++] << 16)
                | (value[startIndex++] << 8) | value[startIndex]);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的八个字节转换来的 64 位无符号整数。
        /// </summary>
        /// <param name="value">包含要转换的八个字节的字节数组。</param>
        /// <param name="startIndex"><see cref="value"/> 内的起始位置。</param>
        /// <returns>由八个字节构成、从 <see cref="startIndex"/> 开始的 64 位无符号整数。</returns>
        public static ulong ToUInt64ByBigEndian(this byte[] value, int startIndex = 0)
        {
            return (ulong)((value[startIndex++] << 56) | (value[startIndex++] << 48)
                | (value[startIndex++] << 40) | (value[startIndex++] << 32)
                | (value[startIndex++] << 24) | (value[startIndex++] << 16)
                | (value[startIndex++] << 8) | value[startIndex]);
        }
        /// <summary>
        /// 返回由字节数组转换的整数。
        /// </summary>
        /// <param name="value">字节数组。</param>
        /// <returns>根据字节长度,返回合适的整数类型</returns>
        public static object ToIntByBigEndian(this byte[] value)
        {
            if (value.Length == 1)
            {
                return (short)value[0];
            }
            else if(value.Length <= 2)
            {
                return value.ToInt16ByBigEndian();
            }
            else if (value.Length <= 4)
            {
                return value.ToInt32ByBigEndian();
            }
            else if (value.Length <= 8)
            {
                return value.ToInt64ByBigEndian();
            }
            else
            {
                throw new Exception("字节数组长度超出范围");
            }
        }
        /// <summary>
        /// 返回由字节数组转换的无符号整数。
        /// </summary>
        /// <param name="value">字节数组。</param>
        /// <returns>根据字节长度,返回合适的无符号整数类型</returns>
        public static object ToUIntByBigEndian(this byte[] value)
        {
            if (value.Length == 1)
            {
                return (ushort)value[0];
            }
            else if (value.Length <= 2)
            {
                
                return value.ToUInt16ByBigEndian();
            }
            else if (value.Length <= 4)
            {
                return value.ToUInt32ByBigEndian();
            }
            else if (value.Length <= 8)
            {
                return value.ToUInt64ByBigEndian();
            }
            else
            {
                throw new Exception("字节数组长度超出范围");
            }
        }
        #endregion

        #region 字节数组与字符串转换
        /// <summary>
        /// 将指定的字节数组的每个元素的数值转换为它的等效十六进制字符串表示形式。
        /// </summary>
        /// <param name="value">字节数组。</param>
        /// <param name="separator"></param>
        /// <returns>由以 <see cref="separator"/> 分隔的十六进制对构成的字符串，其中每一对表示 <see cref="value"/> 中对应的元素；例如“7F 2C 4A”。</returns>
        public static string GetString_HEX(this byte[] value, string separator = " ")
        {
            if (value == null || value.Length == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                byte b = value[i];
                sb.Append(b.ToString("X2"));
                if (i != value.Length - 1)
                {
                    sb.Append(separator);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将指定字节数组中的所有字节解码为一个字符串。
        /// </summary>
        /// <param name="value">要解码的字节序列的字节数组。</param>
        /// <returns>字节序列解码结果的字符串。</returns>
        public static string GetString_UTF8(this byte[] value)
        {
            return Encoding.UTF8.GetString(value);
        }

        /// <summary>
        /// 将指定字节数组中的所有字节解码为一个字符串。
        /// </summary>
        /// <param name="value">包含要解码的字节序列的字节数组。</param>
        /// <param name="index">要解码的第一个字节的索引。</param>
        /// <param name="count">要解码的字节数。</param>
        /// <returns>包含对指定字节序列进行解码的结果的字符串。</returns>
        public static string GetString_UTF8(this byte[] value, int index, int count)
        {
            return Encoding.UTF8.GetString(value, index, count);
        }

        /// <summary>
        /// 将指定字节数组中的所有字节转换为二进制字符串(高位在前)。
        /// </summary>
        /// <param name="bytes">要转换的字节数组。</param>
        /// <returns>二进制字符串,例如 0x56 转换为“01010110”</returns>
        public static string GetString_BIN(this byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    byte b = bytes[i];
                    sb.Append((b & 0x80) == 0 ? '0' : '1');
                    sb.Append((b & 0x40) == 0 ? '0' : '1');
                    sb.Append((b & 0x20) == 0 ? '0' : '1');
                    sb.Append((b & 0x10) == 0 ? '0' : '1');
                    sb.Append((b & 0x08) == 0 ? '0' : '1');
                    sb.Append((b & 0x04) == 0 ? '0' : '1');
                    sb.Append((b & 0x02) == 0 ? '0' : '1');
                    sb.Append((b & 0x01) == 0 ? '0' : '1');
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 将HEX字符串转换为ASCII码的HEX字符串。
        /// </summary>
        /// <param name="value">HEX字符串</param>
        /// <param name="separator">转换后分隔符</param>
        /// <returns>转换为ASCII码的HEX字符串</returns>
        /// <example>GetString_HEX2ASCII("01 02")//30 31 30 32</example>
        public static string GetString_HEX2ASCII(this string value, string separator = " ")
        {
            return Encoding.Default.GetBytes(value).GetString_HEX(separator);
        }
        /// <summary>
        /// 将ASCII码的HEX字符串转换为HEX字符串。
        /// </summary>
        /// <param name="value">ASCII码的HEX字符串</param>
        /// <param name="separator">转换后分隔符</param>
        /// <returns>HEX字符串</returns>
        /// <example>GetString_HEX2ASCII("30 31 30 32")//01 02</example>
        public static string GetString_ASCII2HEX(this string value)
        {
            return Encoding.Default.GetString(GetBytes_HEX(value));
        }

        /// <summary>
        /// 字节转换为二进制字符串(高位在前)。
        /// </summary>
        /// <param name="byte">要转换的字节</param>
        /// <returns>二进制字符串,例如 0x56 转换为“01010110”</returns>
        public static string GetByte_BIN(this byte byteData)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append((byteData & 0x80) == 0 ? '0' : '1');
            sb.Append((byteData & 0x40) == 0 ? '0' : '1');
            sb.Append((byteData & 0x20) == 0 ? '0' : '1');
            sb.Append((byteData & 0x10) == 0 ? '0' : '1');
            sb.Append((byteData & 0x08) == 0 ? '0' : '1');
            sb.Append((byteData & 0x04) == 0 ? '0' : '1');
            sb.Append((byteData & 0x02) == 0 ? '0' : '1');
            sb.Append((byteData & 0x01) == 0 ? '0' : '1');
            return sb.ToString();
        }

        /// <summary>
        /// 将指定字符串使用UTF-8编码,编码为字节数组
        /// </summary>
        /// <param name="value">要编码的字符串</param>
        /// <returns>以字节数组的形式返回UTF-8编码后的字符串</returns>
        public static byte[] GetBytes_UTF8(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        /// <summary>
        /// 将指定的十六进制字符串转换为它的字节等效表示形式数组。
        /// </summary>
        /// <param name="value">要转换的十六进制字符串(支持的连接符号:" ","\t","-")</param>
        /// <returns>以字节数组的形式返回指定的十六进制字符串。</returns>
        public static byte[] GetBytes_HEX(this string value)
        {
            value = RemoveHexSpace(value);
            if (value.Length % 2 != 0)
            {
                value = "0" + value;
            }
            int len = value.Length / 2;
            byte[] bytes = new byte[len];
            StringBuilder sb = new StringBuilder(value);
            for (int i = 0; i < len; i++)
            {
                bytes[i] = byte.Parse(sb.ToString(i * 2, 2), NumberStyles.HexNumber);
            }
            return bytes;
        }
        /// <summary>
        /// 移除HEX字符串中的空格、制表符、连接符
        /// </summary>
        /// <param name="value">HEX字符串</param>
        /// <returns>移除后的结果</returns>
        public static string RemoveHexSpace(string value)
        {
            return value.Replace(" ", "").Replace("\t", "").Replace("-", "");
        }
        #endregion
    }
}
