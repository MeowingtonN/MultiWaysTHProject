using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wang.MTHModels
{
    /// <summary>
    /// 通信设备实体类
    /// </summary>
    public class Device
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress {  get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 该设备相关的通信组集合
        /// </summary>
        public List<Group> GroupList { get; set; }

        /// <summary>
        /// 通信状态标志位。在连接断开的情况下重连成功会将IsConnected赋值true，在连接情况下想要重连会将IsConnected赋值false，故
        /// 无需担心IsConnected赋值时的多线程竞争问题。
        /// </summary>
        public bool IsConnected { get; set; } = false;

        /// <summary>
        /// 重连时间（间隔多长时间后再尝试连接）
        /// </summary>
        public int ReConnectTime { get; set; } = 2000;

        /// <summary>
        /// 重连标志位，为true表示要重连。
        /// </summary>
        public bool ReConnectSign { get; set; } = false;

        /// <summary>
        /// 所有变量的键值对，键使用变量的名称，值是变量的实际值
        /// </summary>
        public Dictionary<string, object> CurrentValue = new Dictionary<string, object>();

        /// <summary>
        /// 当前设备应用的配方名
        /// </summary>
        public string CurrentRecipeName {  get; set; }

        /// <summary>
        /// 报警触发/消除事件。
        /// bool为true表示报警触发，bool为false表示报警消除。
        /// </summary>
        public event Action<bool, Variable> AlarmTrigEvent;

        /// <summary>
        /// 更新变量字典中的相应变量的值，若没有对应变量则添加到字典中；
        /// 同时进行报警检测。
        /// </summary>
        /// <param name="variable"></param>
        public void UpdateVariable(Variable variable)
        {
            if (CurrentValue.ContainsKey(variable.VarName))
            {
                CurrentValue[variable.VarName] = variable.VarValue;
            }
            else
            {
                CurrentValue.Add(variable.VarName, variable.VarValue);
            }

            // 报警检测
            CheckAlarm(variable);
        }

        /// <summary>
        /// 报警检测
        /// </summary>
        /// <param name="variable"></param>
        private void CheckAlarm(Variable variable)
        {
            // 上升沿报警（之前为false，现在为true）检测
            if (variable.PosAlarm)  // 如果该变量需要上升沿报警
            {
                // 获取该变量当前的值（该变量应要为布尔类型）
                bool currentValue = variable.VarValue.ToString() == "True";

                if (variable.PosCacheValue == false && currentValue == true)
                {
                    // 检测到报警触发，执行绑定的处理方法
                    AlarmTrigEvent?.Invoke(true, variable);
                }
                else if(variable.PosCacheValue == true && currentValue == false) 
                {
                    // 检测到报警消除，执行绑定的处理方法
                    AlarmTrigEvent?.Invoke(false, variable);
                }

                // 更新上升沿报警检测缓存值
                variable.PosCacheValue = currentValue;
            }

            // 下降沿报警检测
            if(variable.NegAlarm)
            {
                bool currentValue = variable.VarValue.ToString() == "True";

                if (variable.NegCacheValue == true && currentValue == false)
                {
                    // 检测到报警触发
                    AlarmTrigEvent?.Invoke(true, variable);
                }
                else if (variable.NegCacheValue == false && currentValue == true)
                {
                    // 检测到报警消除
                    AlarmTrigEvent?.Invoke(false, variable);
                }

                // 更新下降沿报警检测缓存值
                variable.NegCacheValue = currentValue;
            }
        }

        /// <summary>
        /// 索引器，使用Device对象加方括号，
        /// 可在设备的变量键值对缓存中根据变量名称获取变量值。
        /// 相关控件会根据设备的变量键值对缓存，使用该索引器获取数据以展示。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                if(CurrentValue.ContainsKey(key))
                {
                    return CurrentValue[key];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
