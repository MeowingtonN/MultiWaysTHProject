using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wang.ModbusTCPLib
{
    /// <summary>
    /// 自实现字节数组工具类，用于报文拼接
    /// </summary>
    internal sealed class ByteArray
    {
        #region 私有字段
        /// <summary>
        /// 私有list集合字段
        /// </summary>
        private List<byte> list = new List<byte>();
        #endregion

        #region 属性
        /// <summary>
        /// 以List集合形式返回数组数据
        /// </summary>
        public List<byte> List
        {
            get
            {
                return list;
            }
        }

        /// <summary>
        /// 以字节数组形式返回数组数据
        /// </summary>
        public byte[] Array
        {
            get
            {
                if (list == null)
                    return null;
                return list.ToArray();
            }
        }

        /// <summary>
        /// 数组的长度
        /// </summary>
        public int Length
        {
            get
            {
                if (list == null)
                    return -1;
                return list.Count;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 在本数组尾部添加一个字节
        /// </summary>
        /// <param name="item">要添加的字节</param>
        public void Add(byte item)
        {
            list.Add(item);
        }

        /// <summary>
        /// 在本数组尾部添加一个字节数组的数据。字节数组为null则直接返回。
        /// </summary>
        /// <param name="array">要添加的字节数组</param>
        public void Add(byte[] array)
        {
            if (array == null) return;
            list.AddRange(array);
        }

        /// <summary>
        /// 在本数组尾部添加一个List集合的数据。List集合为null则直接返回。
        /// </summary>
        /// <param name="list">要添加的List集合</param>
        public void Add(List<byte> list)
        {
            if (list == null) return;
            list.AddRange(list);
        }

        /// <summary>
        /// 连续在本数组尾部添加两个字节
        /// </summary>
        /// <param name="item1">添加的第一个字节</param>
        /// <param name="item2">添加的第二个字节</param>
        public void Add(byte item1, byte item2)
        {
            Add(new byte[] { item1, item2 });
        }

        /// <summary>
        /// 连续在本数组尾部添加三个字节
        /// </summary>
        /// <param name="item1">添加的第一个字节</param>
        /// <param name="item2">添加的第二个字节</param>
        /// <param name="item3">添加的第三个字节</param>
        public void Add(byte item1, byte item2,
                        byte item3)
        {
            Add(new byte[] { item1, item2, item3 });
        }

        /// <summary>
        /// 连续在本数组尾部添加四个字节
        /// </summary>
        /// <param name="item1">添加的第一个字节</param>
        /// <param name="item2">添加的第二个字节</param>
        /// <param name="item3">添加的第三个字节</param>
        /// <param name="item4">添加的第四个字节</param>
        public void Add(byte item1, byte item2,
                        byte item3, byte item4)
        {
            Add(new byte[] { item1, item2, item3, item4 });
        }

        /// <summary>
        /// 连续在本数组尾部添加五个字节
        /// </summary>
        /// <param name="item1">添加的第一个字节</param>
        /// <param name="item2">添加的第二个字节</param>
        /// <param name="item3">添加的第三个字节</param>
        /// <param name="item4">添加的第四个字节</param>
        /// <param name="item5">添加的第五个字节</param>
        public void Add(byte item1, byte item2, byte item3,
                        byte item4, byte item5)
        {
            Add(new byte[] { item1, item2, item3, item4, item5 });
        }

        /// <summary>
        /// 在本数组尾部添加一个ByteArray对象所指向的数据。ByteArray对象为null则直接返回。
        /// </summary>
        /// <param name="byteArray">ByteArray对象</param>
        public void Add(ByteArray byteArray)
        {
            if (byteArray == null) return;
            Add(byteArray.Array);
        }

        /// <summary>
        /// 在本数组尾部添加一个short类型的数据。高字节先添加，低字节后添加。
        /// </summary>
        /// <param name="value">要添加的short类型数据</param>
        public void Add(short value)
        {
            Add((byte)(value >> 8));
            Add((byte)value);
        }

        /// <summary>
        /// 在本数组尾部添加一个ushort类型的数据。高字节先添加，低字节后添加。
        /// </summary>
        /// <param name="value">要添加的ushort类型数据</param>
        public void Add(ushort value)
        {
            Add((byte)(value >> 8));
            Add((byte)value);
        }

        /// <summary>
        /// 清空本数组的内容
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }
        #endregion
    }
}
