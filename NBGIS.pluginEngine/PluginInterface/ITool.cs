using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ITool接口混合了AO中ICommand接口和ITool接口
    /// </summary>
    public interface ITool : IPlugin
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
        /// <summary>
        /// 鼠标在地图上的样式
        /// </summary>
        int Cursor { get;}
        /// <summary>
        /// Tool的激活状态设置
        /// </summary>
        /// <returns></returns>
        bool Deactivate();
        /// <summary>
        /// 鼠标双击地图时触发的事件
        /// </summary>
        void OnDblClick();
        /// <summary>
        /// 鼠标点击右键弹出快捷菜单时触发的事件
        /// </summary>
        /// <param name="x">菜单的x坐标</param>
        /// <param name="y">菜单的y坐标</param>
        /// <returns></returns>
        bool OnContextMenu(int x, int y);
        /// <summary>
        /// 鼠标在地图上移动时触发的事件
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x">x轴坐标</param>
        /// <param name="y">y轴坐标</param>
        void OnMouseMove(int button, int shift, int x, int y);
        /// <summary>
        /// 鼠标点击地图时触发的事件
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseDown(int button, int shift, int x, int y);
        /// <summary>
        /// 鼠标在地图上弹起时触发的事件
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseUp(int button, int shift, int x, int y);
        /// <summary>
        /// 地图刷新时触发的事件
        /// </summary>
        /// <param name="hDC"></param>
        void Refresh(int hDC);
        /// <summary>
        /// 键盘某个按键点击时触发的事件
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="shift"></param>
        void OnKeyDown(int keyCode,int shift);
        /// <summary>
        /// 键盘某个按键点击后弹起触发的事件
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="shift"></param>
        void OnKeyUp(int keyCode, int shift);
    }
}
