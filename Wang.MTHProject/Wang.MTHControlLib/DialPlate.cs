using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wang.MTHControlLib
{
    public partial class DialPlate : UserControl
    {
        public DialPlate()
        {
            InitializeComponent();

            // 刻度值水平居中显示
            stringFormat.Alignment = StringAlignment.Center;
            // 刻度值垂直居中显示
            stringFormat.LineAlignment = StringAlignment.Center;

            // 减少控件闪烁
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);  // 让控件忽略特定窗口消息以减少闪烁
            this.SetStyle(ControlStyles.DoubleBuffer, true);  // 双缓冲防止因重绘控件而引起的闪烁
            // 设置控件样式
            this.SetStyle(ControlStyles.ResizeRedraw, true);  // 在调整窗口大小时重绘控件
            this.SetStyle(ControlStyles.Selectable, true);    // 设置控件可选
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);  // 设置控件支持模拟透明度
        }

        // 用于绘制文字时指定文字在矩形中显示的对齐方式
        private StringFormat stringFormat = new StringFormat();

        #region 外环设计
        /// <summary>
        /// 外环报警显示颜色
        /// </summary>
        private Color alarmColor = Color.FromArgb(36, 184, 196);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置外环报警显示颜色")]
        public Color AlarmColor
        {
            get { return alarmColor; }
            set 
            { 
                alarmColor = value; 
                this.Invalidate();
            }
        }

        /// <summary>
        /// 外环颜色
        /// </summary>
        private Color outerRingColor = Color.FromArgb(187, 187, 187);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置外环整体颜色")]
        public Color OuterRingColor
        {
            get { return outerRingColor; }
            set
            {
                outerRingColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 报警角度
        /// </summary>
        private float alarmAngle = 120.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置报警角度")]
        public float AlarmAngle
        {
            get { return alarmAngle; }
            set
            {
                alarmAngle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 外环宽度
        /// </summary>
        private int outerThickness = 8;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置外环宽度")]
        public int OuterThickness
        {
            get { return outerThickness; }
            set
            {
                outerThickness = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 内环设计
        /// <summary>
        /// 内环（温度环）的比例，用于与this.Width相乘，设置温度环的位置和半径
        /// </summary>
        private float tempScale = 0.65f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置内环（温度环）的比例，默认低于1.0，用于与this.Width相乘，设置温度环的位置和半径")]
        public float TempScale
        {
            get { return tempScale; }
            set
            {
                if (value > 1.0f || value < 0.0f) return;
                tempScale = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 内环（温度环）的颜色
        /// </summary>
        private Color tempColor = Color.FromArgb(36, 184, 196);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置内环（温度环）的颜色")]
        public Color TempColor
        {
            get { return tempColor; }
            set
            {
                tempColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 内环（湿度环）的比例，用于与this.Width相乘，设置湿度环的位置和半径
        /// </summary>
        private float humidityScale = 0.35f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置内环（湿度环）的比例，默认低于1.0，用于与this.Width相乘，设置湿度环的位置和半径")]
        public float HumidityScale
        {
            get { return humidityScale; }
            set
            {
                if (value > 1.0f || value < 0.0f) return;
                humidityScale = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 内环（湿度环）的颜色
        /// </summary>
        private Color humidityColor = Color.FromArgb(36, 184, 196);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置内环（湿度环）的颜色")]
        public Color HumidityColor
        {
            get { return humidityColor; }
            set
            {
                humidityColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 内环宽度
        /// </summary>
        private int innerThickness = 16;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置内环宽度")]
        public int InnerThickness
        {
            get { return innerThickness; }
            set
            {
                innerThickness = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 刻度环设计
        /// <summary>
        /// 设置刻度环上显示的刻度值的距离比例，默认低于1.0，用于与this.Width*0.5f相乘，设置绘制刻度值时使用的半径值
        /// </summary>
        private float textScale = 0.85f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置刻度环上显示的刻度值的距离比例，默认低于1.0，用于与this.Width*0.5f相乘，设置绘制刻度值时使用的半径值")]
        public float TextScale
        {
            get { return textScale; }
            set
            {
                if (value > 1.0f || value < 0.0f) return;
                textScale = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 刻度环量程的低限
        /// </summary>
        private float rangeMin = 0.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置刻度环量程的低限")]
        public float RangeMin
        {
            get { return rangeMin; }
            set
            {
                if(value > rangeMax) return;
                rangeMin = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 刻度环量程的高限
        /// </summary>
        private float rangeMax = 90.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置刻度环量程的高限")]
        public float RangeMax
        {
            get { return rangeMax; }
            set
            {
                if(value < rangeMin) return;
                rangeMax = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 温湿度实时显示
        /// <summary>
        /// 当前仪表盘应显示的温度值
        /// </summary>
        private float temperature = 10.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置当前仪表盘应显示的温度值")]
        public float Temperature
        {
            get { return temperature; }
            set
            {
                if (value < rangeMin)
                {
                    value = rangeMin;
                }
                else if (value > rangeMax)
                {
                    value = rangeMax;
                }
                temperature = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 当前仪表盘应显示的湿度值
        /// </summary>
        private float humidity = 10.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置当前仪表盘应显示的湿度值")]
        public float Humidity
        {
            get { return humidity; }
            set
            {
                if (value < rangeMin)
                {
                    value = rangeMin;
                }
                else if (value > rangeMax)
                {
                    value = rangeMax;
                }
                humidity = value;
                this.Invalidate();
            }
        }
        #endregion

        // 要绘制控件时触发执行该方法
        protected override void OnPaint(PaintEventArgs e)    // GDI绘制控件
        {
            base.OnPaint(e);  // 先执行基类的OnPaint方法

            // 获取画布（GDI绘图图面）并设置相关参数
            Graphics graphics = e.Graphics;
            // 消除锯齿
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // 设置文本呈现模式为最高质量
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // 绘制前，要求本自定义控件的宽度和高度均需大于20
            if (this.Width <= 20 || this.Height <= 20) return;

            // 绘制前，要求本自定义控件的高度要大于等于宽度的一半，宽度要大于等于高度的一半
            if (this.Height < this.Width / 2 || this.Width < this.Height / 2) return;

            // 准备画笔（初始化颜色为外环报警颜色，初始化笔粗为外环宽度）
            Pen pen = new Pen(alarmColor, outerThickness);
            // 1. 画外环（外环的报警角度部分），水平向右（x轴正方向）为0度，顺时针计量，从180度开始，画alarmAngle度。
            graphics.DrawArc(pen, new RectangleF(10, 10, this.Width-20, this.Width-20), 180, alarmAngle);

            // 准备画笔（初始化颜色为外环颜色，初始化笔粗为外环宽度）
            pen = new Pen(outerRingColor, outerThickness);
            // 2. 画外环（外环去除报警角度的部分），水平向右（x轴正方向）为0度，顺时针计量，从(180+alarmAngle)度开始，画(180-alarmAngle)度。
            // 这个椭圆由正方形RectangleF(10, 10, this.Width - 20, this.Width - 20)指定，故实际是一个圆。
            graphics.DrawArc(pen, new RectangleF(10, 10, this.Width - 20, this.Width - 20), 180+alarmAngle, 180-alarmAngle);

            // 转移坐标系（修改坐标系原点为正方形RectangleF(10, 10, this.Width - 20, this.Width - 20)的中心）
            graphics.TranslateTransform(this.Width * 0.5f, this.Width * 0.5f);

            // 旋转坐标系（逆时针旋转90度后，x轴正方向垂直向上，y轴正方向水平向右）
            graphics.RotateTransform(-90);

            SolidBrush solidBrush = null;
            // 3. 在外环上绘制7个刻度小矩形，相邻刻度之间相差30度
            for (int i = 0; i < 7; i++)
            {
                // 相邻刻度之间相差30度，据此判断刻度小矩形是否超过报警角度。
                if(30 * i <= alarmAngle)
                {
                    // 若没有超过，则刻度小矩形的颜色是外环报警显示颜色
                    solidBrush = new SolidBrush(alarmColor);
                }
                else
                {
                    // 若超过，则刻度小矩形的颜色是外环颜色
                    solidBrush = new SolidBrush(outerRingColor);
                }

                // 确定要绘制的小矩形的x坐标、宽、高和y坐标。
                float x = -3.0f;
                float width = 6.0f;
                float height = outerThickness + 4;
                float y = (this.Width * 0.5f - 10 + height * 0.5f) * (-1.0f);
                // 填充刻度小矩形（依据设置的小矩形起点x坐标和y坐标以及小矩形的宽和高进行绘制；在这里solidBrush指定了颜色信息）
                graphics.FillRectangle(solidBrush, new RectangleF(x, y, width, height));
                // 顺时针旋转坐标系30度以接下去绘制呈现角度的小矩形（重要技巧！）
                graphics.RotateTransform(30);
            }

            // 绘制刻度小矩形完毕后，将坐标系旋转回最初的角度（x轴正方向为水平向右，y轴正方向为垂直向下）
            graphics.RotateTransform(-210);
            graphics.RotateTransform(90);

            // 4. 绘制刻度值
            // 计算相邻两个刻度之间相隔多少值（若不能被6整除，则保留一位小数）
            float rangeAvg = (rangeMax - rangeMin) % 6 == 0 ? Convert.ToSingle((rangeMax - rangeMin) / 6)
                                                            : Convert.ToSingle(((rangeMax - rangeMin) / 6).ToString("f1"));
            // 绘制7个刻度值
            for(int i = 0; i < 7; i++)
            {
                // 刻度对应的角度（水平向右（x轴正方向）为0度）
                float angle = -180.0f + i * 30.0f;

                // 绘制文字和绘制矩形类似，要先找绘制“原点”/“起点”！
                //（若坐标系是x轴正方向为水平向右，y轴正方向为垂直向下，则“原点”/“起点”是矩形的左上角。）
                // this.Width * textScale * 0.5f 是绘制刻度值时使用的半径的值。
                float pointX = Convert.ToSingle(this.Width * textScale * 0.5f * Math.Cos(angle * Math.PI / 180.0f));
                float pointY = Convert.ToSingle(this.Width * textScale * 0.5f * Math.Sin(angle * Math.PI / 180.0f));

                // 获取要绘制的文字
                string text = (rangeMin + rangeAvg * i).ToString();

                // 获取要绘制的文字尺寸
                SizeF size = graphics.MeasureString(text, this.Font);

                // 绘制文字时的“原点”是(pointX - size.Width * 0.5f, pointY)。
                RectangleF rectangle = new RectangleF(pointX - size.Width * 0.5f, pointY, size.Width, size.Height);

                // 绘制文字
                graphics.DrawString(text, this.Font, new SolidBrush(this.ForeColor), rectangle, stringFormat);
            }

            // 5. 绘制实际温度湿度环
            // 先画温度环
            pen = new Pen(tempColor, innerThickness);
            // 计算温度环所占的角度
            float sweepAngle = (temperature - rangeMin) / (rangeMax - rangeMin) * 180.0f;
            // 确定矩形的原点（在该坐标系中是左上角的点；矩形用于确定椭圆的位置和大小，而环是椭圆的一部分）
            float pointXX = this.Width * tempScale * 0.5f * (-1.0f);
            float pointYY = this.Width * tempScale * 0.5f * (-1.0f);
            // 绘制温度环
            graphics.DrawArc(pen, new RectangleF(pointXX, pointYY, this.Width * tempScale, this.Width * tempScale), 180.0f, sweepAngle);
            // 再画湿度环
            pen = new Pen(humidityColor, innerThickness);
            // 计算湿度环所占的角度
            sweepAngle = (humidity - rangeMin) / (rangeMax - rangeMin) * 180.0f;
            // 确定矩形的原点（在该坐标系中是左上角的点；矩形用于确定椭圆的位置和大小，而环是椭圆的一部分）
            pointXX = this.Width * humidityScale * 0.5f * (-1.0f);
            pointYY = this.Width * humidityScale * 0.5f * (-1.0f);
            // 绘制湿度环
            graphics.DrawArc(pen, new RectangleF(pointXX, pointYY, this.Width * humidityScale, this.Width * humidityScale), 180.0f, sweepAngle);
        }
    }
}
