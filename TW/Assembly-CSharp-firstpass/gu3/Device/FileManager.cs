﻿// Decompiled with JetBrains decompiler
// Type: gu3.Device.FileManager
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace gu3.Device
{
  public class FileManager
  {
    private const string LIBNAME = "UnityDeviceManager";

    public static string[] GetEntries(string dirName)
    {
      int size = 0;
      IntPtr num = FileManager.FileManager_AllocDirectoryEntries(dirName, ref size);
      if (num == IntPtr.Zero)
        return (string[]) null;
      string[] entries = new string[size];
      for (int index = 0; index < size; ++index)
      {
        IntPtr ptr = Marshal.ReadIntPtr(num, index * IntPtr.Size);
        entries[index] = Marshal.PtrToStringAnsi(ptr);
      }
      FileManager.FileManager_FreeDirectoryEntries(num, size);
      return entries;
    }

    [DllImport("UnityDeviceManager")]
    private static extern IntPtr FileManager_AllocDirectoryEntries(string dirName, ref int size);

    [DllImport("UnityDeviceManager")]
    private static extern void FileManager_FreeDirectoryEntries(IntPtr p, int size);
  }
}
