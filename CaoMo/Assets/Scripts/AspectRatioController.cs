using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using AOT;
using Unity.Mathematics;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

/// <summary>
/// 在窗口模式下拖动改变窗口大小时，强制窗口保持 16:9
/// windows reference: https://blog.csdn.net/u014661152/article/details/113737625
/// mac os reference: https://forum.unity.com/threads/solved-enforce-aspect-ratio-of-game-window-standalone-for-mac-osx.458347/
/// </summary>
public class AspectRatioController : MonoBehaviour
{
//    // 全屏模式下的分辨率
//#if UNITY_IOS || UNITY_ANDROID
//    private int maxFullScreenWidth = 1280;
//    private int maxFullScreenHeight = 720;
//#else
//    private int maxFullScreenWidth = 1920;
//    private int maxFullScreenHeight = 1080;
//#endif
   

//    // 窗口的宽度和高度。不包括边框和窗口标题栏
//    // 当调整窗口大小时，就会设置这些值
//    private int width = -1;
//    private int height = -1;

//    // 当前锁定长宽比。
//    private static float aspect = 16f / 9;

//    // 最小宽高
//    private static int minWidth = 1024;
//    private static int minHeight = 576;

//    // 最后一帧全屏状态。
//    private bool wasFullscreenLastFrame;

//#if UNITY_STANDALONE_WIN
//    // 是否初始化了AspectRatioController
//    // 一旦注册了WindowProc回调函数，就将其设置为true
//    private bool started;

//    //一旦用户请求终止applaction，则将其设置为true
//    private bool quitStarted;

//    // WinAPI相关定义

//    #region WINAPI

//    // 当窗口调整时,WM_SIZING消息通过WindowProc回调发送到窗口
//    private const int WM_SIZING = 0x214;

//    // WM大小调整消息的参数
//    private const int WMSZ_LEFT = 1;
//    private const int WMSZ_RIGHT = 2;
//    private const int WMSZ_TOP = 3;
//    private const int WMSZ_BOTTOM = 6;

//    // 获取指向WindowProc函数的指针
//    private const int GWLP_WNDPROC = -4;

//    // 委托设置为新的WindowProc回调函数
//    private delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

//    private WndProcDelegate wndProcDelegate;

//    // 检索调用线程的线程标识符
//    [DllImport("kernel32.dll")]
//    private static extern uint GetCurrentThreadId();

//    // 检索指定窗口所属类的名称
//    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//    private static extern int GetClassName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

//    // 通过将句柄传递给每个窗口，依次传递给应用程序定义的回调函数，枚举与线程关联的所有非子窗口
//    [DllImport("user32.dll")]
//    private static extern bool EnumThreadWindows(uint dwThreadId, EnumWindowsProc lpEnumFunc, IntPtr lParam);

//    private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

//    [MonoPInvokeCallback(typeof(EnumWindowsProc))]
//    static bool OnEnumWindow(IntPtr hWnd, IntPtr lParam)
//    {
//        var classText = new StringBuilder(UNITY_WND_CLASSNAME.Length + 1);
//        GetClassName(hWnd, classText, classText.Capacity);

//        if (classText.ToString() == UNITY_WND_CLASSNAME)
//        {
//            unityHWnd = hWnd;
//            return false;
//        }

//        return true;
//    }
    

//    // 将消息信息传递给指定的窗口过程
//    [DllImport("user32.dll")]
//    private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam,
//        IntPtr lParam);

//    // 检索指定窗口的边框的尺寸
//    // 尺寸是在屏幕坐标中给出的，它是相对于屏幕左上角的
//    [DllImport("user32.dll", SetLastError = true)]
//    private static extern bool GetWindowRect(IntPtr hwnd, ref RECT lpRect);

//    //检索窗口客户区域的坐标。客户端坐标指定左上角
//    //以及客户区的右下角。因为客户机坐标是相对于左上角的
//    //在窗口的客户区域的角落，左上角的坐标是(0,0)
//    [DllImport("user32.dll")]
//    private static extern bool GetClientRect(IntPtr hWnd, ref RECT lpRect);

//    // 更改指定窗口的属性。该函数还将指定偏移量的32位(长)值设置到额外的窗口内存中
//    [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
//    private static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

//    //更改指定窗口的属性。该函数还在额外的窗口内存中指定的偏移量处设置一个值
//    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
//    private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

//    // 获取窗口属性
//    [DllImport("user32.dll")]
//    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

//    //用于查找窗口句柄的Unity窗口类的名称
//    private const string UNITY_WND_CLASSNAME = "UnityWndClass";

//    // Unity窗口的窗口句柄
//    private static IntPtr unityHWnd;

//    // 指向旧WindowProc回调函数的指针
//    private static IntPtr oldWndProcPtr;

//    // 指向我们自己的窗口回调函数的指针
//    private IntPtr newWndProcPtr;

//    private const int GWL_STYLE = -16;
//    private const int WS_MAXIMIZEBOX = 0x10000;

//    /// <summary>
//    /// WinAPI矩形定义。
//    /// </summary>
//    [StructLayout(LayoutKind.Sequential)]
//    public struct RECT
//    {
//        public int Left;
//        public int Top;
//        public int Right;
//        public int Bottom;
//    }

//    #endregion

//    /// <summary>
//    /// WindowProc回调。应用程序定义的函数，用来处理发送到窗口的消息 
//    /// </summary>
//    /// <param name="msg">用于标识事件的消息</param>
//    /// <param name="wParam">额外的信息信息。该参数的内容取决于uMsg参数的值 </param>
//    /// <param name="lParam">其他消息的信息。该参数的内容取决于uMsg参数的值 </param>
//    /// <returns></returns>
//    [MonoPInvokeCallback(typeof(WndProcDelegate))]
//    private static IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
//    {
//        // 检查消息类型
//        // resize事件
//        if (msg == WM_SIZING)
//        {
//            // 获取窗口大小结构体
//            RECT rc = (RECT) Marshal.PtrToStructure(lParam, typeof(RECT));

//            // 计算窗口边框的宽度和高度
//            RECT windowRect = new RECT();
//            GetWindowRect(unityHWnd, ref windowRect);

//            RECT clientRect = new RECT();
//            GetClientRect(unityHWnd, ref clientRect);

//            int borderWidth = windowRect.Right - windowRect.Left - (clientRect.Right - clientRect.Left);
//            int borderHeight = windowRect.Bottom - windowRect.Top - (clientRect.Bottom - clientRect.Top);

//            // 在应用宽高比之前删除边框(包括窗口标题栏)
//            rc.Right -= borderWidth;
//            rc.Bottom -= borderHeight;

//            // 限制窗口大小
//            int newWidth = Mathf.Max(rc.Right - rc.Left, minWidth);
//            int newHeight = Mathf.Max(rc.Bottom - rc.Top, minHeight);

//            // 根据纵横比和方向调整大小
//            switch (wParam.ToInt32())
//            {
//                case WMSZ_LEFT:
//                    rc.Left = rc.Right - newWidth;
//                    rc.Bottom = rc.Top + Mathf.RoundToInt(newWidth / aspect);
//                    break;
//                case WMSZ_RIGHT:
//                    rc.Right = rc.Left + newWidth;
//                    rc.Bottom = rc.Top + Mathf.RoundToInt(newWidth / aspect);
//                    break;
//                case WMSZ_TOP:
//                    rc.Top = rc.Bottom - newHeight;
//                    rc.Right = rc.Left + Mathf.RoundToInt(newHeight * aspect);
//                    break;
//                case WMSZ_BOTTOM:
//                    rc.Bottom = rc.Top + newHeight;
//                    rc.Right = rc.Left + Mathf.RoundToInt(newHeight * aspect);
//                    break;
//                case WMSZ_RIGHT + WMSZ_BOTTOM:
//                    rc.Right = rc.Left + newWidth;
//                    rc.Bottom = rc.Top + Mathf.RoundToInt(newWidth / aspect);
//                    break;
//                case WMSZ_RIGHT + WMSZ_TOP:
//                    rc.Right = rc.Left + newWidth;
//                    rc.Top = rc.Bottom - Mathf.RoundToInt(newWidth / aspect);
//                    break;
//                case WMSZ_LEFT + WMSZ_BOTTOM:
//                    rc.Left = rc.Right - newWidth;
//                    rc.Bottom = rc.Top + Mathf.RoundToInt(newWidth / aspect);
//                    break;
//                case WMSZ_LEFT + WMSZ_TOP:
//                    rc.Left = rc.Right - newWidth;
//                    rc.Top = rc.Bottom - Mathf.RoundToInt(newWidth / aspect);
//                    break;
//            }

//            // // 保存实际分辨率,不包括边界
//            // setWidth = rc.Right - rc.Left;
//            // setHeight = rc.Bottom - rc.Top;

//            // 添加边界
//            rc.Right += borderWidth;
//            rc.Bottom += borderHeight;

//            // 回写更改的窗口参数
//            Marshal.StructureToPtr(rc, lParam, true);
//        }

//        // 调用原始的WindowProc函数
//        return CallWindowProc(oldWndProcPtr, hWnd, msg, wParam, lParam);
//    }

//    /// <summary>
//    /// 调用SetWindowLong32或SetWindowLongPtr64，取决于可执行文件是32位还是64位。
//    /// 这样，我们就可以同时构建32位和64位的可执行文件而不会遇到问题。
//    /// </summary>
//    /// <param name="hWnd">The window handle.</param>
//    /// <param name="nIndex">要设置的值的从零开始的偏移量</param>
//    /// <param name="dwNewLong">The replacement value.</param>
//    /// <returns>返回值是指定偏移量的前一个值。否则零.</returns>
//    private static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
//    {
//        //32位系统
//        if (IntPtr.Size == 4)
//        {
//            return SetWindowLong32(hWnd, nIndex, dwNewLong);
//        }

//        return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
//    }

//    /// <summary>
//    /// 退出时调用。 返回false将中止并使应用程序保持活动。True会让它退出。
//    /// </summary>
//    /// <returns></returns>
//    private bool ApplicationWantsToQuit()
//    {
//        //仅允许在应用程序初始化后退出。
//        if (!started)
//            return false;

//        //延迟退出，clear up
//        if (!quitStarted)
//        {
//            StartCoroutine("DelayedQuit");
//            return false;
//        }

//        return true;
//    }

//    /// <summary>
//    /// 恢复旧的WindowProc回调，然后退出。
//    /// </summary>
//    IEnumerator DelayedQuit()
//    {
//        // 重新设置旧的WindowProc回调,如果检测到WM_CLOSE,这将在新的回调本身中完成, 64位没问题，32位可能会造成闪退

//        SetWindowLong(unityHWnd, GWLP_WNDPROC, oldWndProcPtr);

//        yield return new WaitForEndOfFrame();

//        quitStarted = true;
//        Application.Quit();
//    }

//#endif

//#if UNITY_STANDALONE_OSX
//    // API import
//    [DllImport("MacOSWindowPlugin", CallingConvention = CallingConvention.Cdecl)]
//    private static extern void setwindow();
//#endif

//    void Start()
//    {
//#if UNITY_EDITOR
//        return;
//#endif
        
//#if UNITY_STANDALONE_WIN
//        // 不要在Unity编辑器中注册WindowProc回调函数，它会指向Unity编辑器窗口，而不是Game视图

//        //注册回调，然后应用程序想要退出
//        Application.wantsToQuit += ApplicationWantsToQuit;

//        // 找到主Unity窗口的窗口句柄
//        EnumThreadWindows(GetCurrentThreadId(), OnEnumWindow, IntPtr.Zero);

//        // 保存当前的全屏状态
//        wasFullscreenLastFrame = Screen.fullScreen;

//        // Register (replace) WindowProc callback。每当一个窗口事件被触发时，这个函数都会被调用
//        //例如调整大小或移动窗口
//        //保存旧的WindowProc回调函数，因为必须从新回调函数中调用它
//        wndProcDelegate = WndProc;
//        newWndProcPtr = Marshal.GetFunctionPointerForDelegate(wndProcDelegate);
//        oldWndProcPtr = SetWindowLong(unityHWnd, GWLP_WNDPROC, newWndProcPtr);

//        // 初始化完成
//        started = true;
//#endif

//#if UNITY_STANDALONE_OSX
//        setwindow();
//#endif

//#if UNITY_IOS || UNITY_ANDROID
//        // 移动平台设置
//        var (w, h) = GetFullScreenSize();
//        Screen.SetResolution(w, h, true);
//#endif
//    }

//#if UNITY_STANDALONE
    
//    private bool maxbuttonSet = false;

//    void Update()
//    {
//        if (Screen.fullScreen && !wasFullscreenLastFrame)
//        {
//            //切换到全屏检测, 设置为全屏分辨率
//            var (w, h) = GetFullScreenSize();
//            Screen.SetResolution(w, h, true);
//        }
//        else if (!Screen.fullScreen && wasFullscreenLastFrame)
//        {
//            // 从全屏切换到检测到的窗口。设置上一个窗口的分辨率。
//            Screen.SetResolution(width, height, false);
//        }
//        else if (!Screen.fullScreen && (Screen.width != width || Screen.height != height))
//        {
//            // 记录窗口模式大小，在从全屏切回窗口的时候用到
//            width = Screen.width;
//            height = Screen.height;
//        }

//#if UNITY_STANDALONE_WIN
//        // window平台窗口模式下，禁用最大化按钮
//        if (Screen.fullScreen && !wasFullscreenLastFrame)
//        {
//            maxbuttonSet = false;
//        }
//        else
//        {
//            // if (!maxbuttonSet)
//            // {
//            // https://stackoverflow.com/questions/2470685/how-do-you-disable-aero-snap-in-an-application
//            var windowStyle = GetWindowLong(unityHWnd, GWL_STYLE);
//            // if ((windowStyle & WS_MAXIMIZEBOX) == 0)
//            // {
//            windowStyle = windowStyle & ~WS_MAXIMIZEBOX;
//            SetWindowLong(unityHWnd, GWL_STYLE, (IntPtr) windowStyle);
//            maxbuttonSet = true;
//            // }
//            // }
//        }
//#endif

//        //保存下一帧的全屏状态
//        wasFullscreenLastFrame = Screen.fullScreen;
//    }
//#endif

    
//    /// <summary>
//    /// get full screen resolution
//    /// </summary>
//    /// <returns></returns>
//    (int w, int h) GetFullScreenSize()
//    {
//#if UNITY_ANDROID || UNITY_IOS
//        int width = Screen.width;
//        int height = Screen.height;
//        float screenRatio = (float)width / height;
//        if (screenRatio > aspect)
//        {
//            height = Math.Min(height, maxFullScreenHeight);
//            width = Mathf.RoundToInt(height * screenRatio);
//        }
//        else if(screenRatio < aspect)
//        {
//            width = Math.Min(width, maxFullScreenWidth);
//            height = Mathf.RoundToInt(width / screenRatio);
//        }
//        else
//        {
//            width = maxFullScreenWidth;
//            height = maxFullScreenHeight;
//        }

//        return (width, height);

//#elif UNITY_STANDALONE
//        int width, height;
//        var screenResolution = Screen.resolutions[Screen.resolutions.Length - 1];
//        if (screenResolution.width >= maxFullScreenWidth && screenResolution.height >= maxFullScreenHeight)
//        {
//            // 1080p maximum
//            width = maxFullScreenWidth;
//            height = maxFullScreenHeight;
//        }
//        else
//        {
//            width = screenResolution.width;
//            height = screenResolution.height;
//            float screenRatio = (float)screenResolution.width / screenResolution.height;
//            if (screenRatio > aspect)
//            {
//                width = Mathf.RoundToInt(screenResolution.height * aspect);
//            }
//            else if(screenRatio < aspect)
//            {
//                height = Mathf.RoundToInt(screenResolution.width / aspect);
//            }
//        }
//        return (width, height);
//#endif
//    }
}