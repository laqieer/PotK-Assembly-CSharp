// Decompiled with JetBrains decompiler
// Type: gu3.File.FileManager
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

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
