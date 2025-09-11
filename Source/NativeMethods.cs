// Decompiled with JetBrains decompiler
// Type: NativeMethods
// Assembly: Launcher, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BE2EDF30-BDA3-4FE0-9EFC-B0A1BE215D80
// Assembly location: D:\SteamLibrary\steamapps\common\Call of Duty Black Ops\bin\Launcher.exe

using System;
using System.Runtime.InteropServices;

namespace Launcher
{
  internal class NativeMethods
  {
    public const int HWND_BROADCAST = 65535;
    public static readonly int WM_SHOWME = NativeMethods.RegisterWindowMessage(nameof (WM_SHOWME));

    [DllImport("user32", CharSet = CharSet.Unicode)]
    public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

    [DllImport("user32", CharSet = CharSet.Unicode)]
    public static extern int RegisterWindowMessage(string message);
  }
}
