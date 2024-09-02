// Decompiled with JetBrains decompiler
// Type: gu3.Download.IDownloadHandler
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

#nullable disable
namespace gu3.Download
{
  public interface IDownloadHandler
  {
    void didFinishDownloading(string path, string location);

    void didWriteData(string path, long writtenBytes, long totalBytes);
  }
}
