// Decompiled with JetBrains decompiler
// Type: CriFsInstallRequest
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;

#nullable disable
public class CriFsInstallRequest : CriFsRequest
{
  private CriFsInstaller installer;

  public CriFsInstallRequest(
    CriFsBinder srcBinder,
    string srcPath,
    string dstPath,
    CriFsRequest.DoneDelegate doneDelegate,
    int installBufferSize)
  {
    this.sourcePath = srcPath;
    this.destinationPath = dstPath;
    this.doneDelegate = doneDelegate;
    this.progress = 0.0f;
    this.installer = new CriFsInstaller();
    this.installer.Copy(srcBinder, srcPath, dstPath, installBufferSize);
  }

  public string sourcePath { get; private set; }

  public string destinationPath { get; private set; }

  public float progress { get; private set; }

  public override void Stop()
  {
    if (this.installer == null)
      return;
    this.installer.Stop();
  }

  public override void Update()
  {
    if (this.installer == null)
      return;
    this.progress = this.installer.GetProgress();
    switch (this.installer.GetStatus())
    {
      case CriFsInstaller.Status.Busy:
        return;
      case CriFsInstaller.Status.Error:
        this.progress = -1f;
        this.error = "Error occurred.";
        break;
    }
    this.installer.Dispose();
    this.installer = (CriFsInstaller) null;
    this.Done();
  }

  public override void Dispose()
  {
    if (this.isDisposed)
      return;
    if (this.installer != null)
    {
      this.installer.Dispose();
      this.installer = (CriFsInstaller) null;
    }
    GC.SuppressFinalize((object) this);
    this.isDisposed = true;
  }
}
