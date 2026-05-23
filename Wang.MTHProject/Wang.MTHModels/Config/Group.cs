using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wang.MTHModels
{
    /// <summary>
    /// 通信组实体类
    /// </summary>
    public class Group
    {
        /// <summary>
        /// 通信组名称
        /// </summary>
        public string GroupName {  get; set; }

        /// <summary>
        /// 该通信组的读取起始线圈/寄存器（硬件）地址
        /// </summary>
        public ushort StartAddress {  get; set; }

        /// <summary>
        /// 读取的长度（线圈/寄存器个数）
        /// </summary>
        public ushort Length { get; set; }

        /// <summary>
        /// 存储区名称
        /// </summary>
        public string StoreArea {  get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 变量集合
        /// </summary>
        [ExcelIgnore]
        public List<Variable> VariableList { get; set; }
    }
}
