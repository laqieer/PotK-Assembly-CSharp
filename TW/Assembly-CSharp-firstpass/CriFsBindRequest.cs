// Decompiled with JetBrains decompiler
// Type: CriFsBindRequest
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;

#nullable disable
public class CriFsBindRequest : CriFsRequest
{
  public CriFsBindRequest(
    CriFsBindRequest.BindType type,
    CriFsBinder targetBinder,
    CriFsBinder srcBinder,
    string path)
  {
    this.path = path;
    switch (type)
    {
      case CriFsBindRequest.BindType.Cpk:
        this.bindId = targetBinder.BindCpk(srcBinder, path);
        break;
      case CriFsBindRequest.BindType.Directory:
        this.bindId = targetBinder.BindDirectory(srcBinder, path);
        break;
      case CriFsBindRequest.BindType.File:
        this.bindId = targetBinder.BindFile(srcBinder, path);
        break;
      default:
        throw new Exception("Invalid bind type.");
    }
  }

  public string path { get; private set; }

  public uint bindId { get; private set; }

  public override void Stop()
  {
  }

  public override void Update()
  {
    if (this.isDone)
      return;
    switch (CriFsBinder.GetStatus(this.bindId))
    {
      case CriFsBinder.Status.Analyze:
        return;
      case CriFsBinder.Status.Error:
        this.error = "Error occurred.";
        break;
    }
    this.Done();
  }

  public override void Dispose()
  {
    if (this.isDisposed)
      return;
    GC.SuppressFinalize((object) this);
    this.isDisposed = true;
  }

  public enum BindType
  {
    Cpk,
    Directory,
    File,
  }
}
