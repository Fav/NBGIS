using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ICommand接口类似AO库中的ICommand接口
    /// </summary>
    public interface ICommand : IPlugin
    {
        /// <summary>
        /// 命令按钮的图标
        /// </summary>
        Bitmap Bitmap { get;}
        /// <summary>
        /// 命令按钮的文字
        /// </summary>
        string Caption { get;}
        /// <summary>
        /// 命令按钮所属的类别
        /// </summary>
        string Category { get;}
        /// <summary>
        /// 命令按钮是否被选择
        /// </summary>
        bool Checked { get;}
        /// <summary>
        /// 命令按钮是否可用
        /// </summary>
        bool Enabled { get;}
        /// <summary>
        /// 快速帮助ID
        /// </summary>
        int HelpContextId { get;}
        /// <summary>
        /// 帮助文件路径
        /// </summary>
        string HelpFile { get;}
        /// <summary>
        /// 鼠标移到按钮上时状态栏出现的文字
        /// </summary>
        string Message { get;}
        /// <summary>
        /// 按钮名称
        /// </summary>
        string Name { get;}
        /// <summary>
        /// 按钮点击时触发的方法
        /// </summary>
        void OnClick();
        /// <summary>
        /// 按钮产生是触发的方法
        /// </summary>
        /// <param name="hook">框架的宿主对象</param>
        void OnCreate(IApplication hook);
        /// <summary>
        /// 鼠标移到按钮上弹出的文字
        /// </summary>
        string Tooltip { get;}
    }
}
