// Decompiled with JetBrains decompiler
// Type: gu3.File.FileManager
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System.Runtime.InteropServices;

#nullable disable
namespace gu3.File
{
  public static class FileManager
  {
    [DllImport("__Internal")]
    private static extern bool _DoNotBackup(string uri);

    public static bool SetDoNotBackup(string uri, bool flag) => FileManager._DoNotBackup(uri);
  }
}
