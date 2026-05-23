using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wang.MTHModels
{
    /// <summary>
    /// 变量实体类
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// 变量名称
        /// </summary>
        public string VarName { get; set; }

        /// <summary>
        /// 寄存器情况下表示组内变量起始字索引；
        /// 线圈情况下表示组内变量起始字节索引。
        /// </summary>
        public ushort Start {  get; set; }

        /// <summary>
        /// 数据类型（通过数据类型可以得知长度信息）
        /// </summary>
        public string DataType {  get; set; }

        /// <summary>
        /// 数据类型是布尔：表示字节内位偏移；
        /// 数据类型是字符串或字节数组：表示长度。
        /// </summary>
        public int OffsetOrLength {  get; set; }

        /// <summary>
        /// 所属通信组名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否上升沿报警
        /// </summary>
        public bool PosAlarm {  get; set; }

        /// <summary>
        /// 是否下降沿报警
        /// </summary>
        public bool NegAlarm {  get; set; }
        
        /// <summary>
        /// 转换系数（用于线性转换）
        /// </summary>
        public float Scale {  get; set; } = 1.0f;

        /// <summary>
        /// 偏移值（用于线性转换）
        /// </summary>
        public float Offset { get; set; } = 0.0f;

        /// <summary>
        /// 变量的值
        /// </summary>
        [ExcelIgnore]
        public object VarValue {  get; set; }

        /// <summary>
        /// 上升沿报警检测的缓存值
        /// </summary>
        [ExcelIgnore]
        public bool PosCacheValue { get; set; } = false;

        /// <summary>
        /// 下降沿报警检测的缓存值
        /// </summary>
        [ExcelIgnore]
        public bool NegCacheValue { get; set; } = true;
    }
}
