﻿# ITLDG.BitConverterExtend

BitConverter 的大端模式扩展,额外增加了一些常用方法

## 结果对照

| 类型           | 值        | BitConverter            | ITLDG.BitConverterExtend | 还原方法              |
| -------------- | --------- | ----------------------- | ------------------------ | --------------------- |
| Char           | a         | 61-00                   | 00-61                    | `ToCharByBigEndian`   |
| Double         | 2.5       | 00-00-00-00-00-00-04-40 | 40-04-00-00-00-00-00-00  | `ToDoubleByBigEndian` |
| Int16(short)   | 99        | 63-00                   | 00-63                    | `ToInt16ByBigEndian`  |
| Int32(int)     | 9999      | 0F-27-00-00             | 00-00-27-0F              | `ToInt32ByBigEndian`  |
| Int64(long)    | 999999999 | FF-C9-9A-3B-00-00-00-00 | 00-00-00-00-3B-9A-C9-FF  | `ToInt64ByBigEndian`  |
| Single(float)  | 2.5       | 00-00-20-40             | 40-20-00-00              | `ToSingleByBigEndian` |
| UInt16(ushort) | 99        | 63-00                   | 00-63                    | `ToUInt16ByBigEndian` |
| UInt32(uint)   | 9999      | 0F-27-00-00             | 00-00-27-0F              | `ToUInt32ByBigEndian` |
| UInt64(ulong)  | 999999999 | FF-C9-9A-3B-00-00-00-00 | 00-00-00-00-3B-9A-C9-FF  | `ToUInt64ByBigEndian` |

## 扩展方法

演示字节数组为:E4 BD A0 E5 A5 BD

| 方法           | 结果                                             | 备注                                                  |
| -------------- | ------------------------------------------------ | ----------------------------------------------------- |
| GetString_BIN  | 111001001011110110100000111001011010010110111101 | 字节数组转二进制字符串                                |
| GetString_HEX  | E4 BD A0 E5 A5 BD                                | 字节数组转十六进制字符串,对应`GetBytes_HEX`           |
| GetString_UTF8 | 你好                                             | 字节数组使用`UTF-8`编码解码字符串,对应`GetBytes_UTF8` |

## 更多方法

更多的方法和参数未一一列出,等待大家发现和 `Pr`
