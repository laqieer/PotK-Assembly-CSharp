// Decompiled with JetBrains decompiler
// Type: CriFsLoadFileRequest
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;

#nullable disable
public class CriFsLoadFileRequest : CriFsRequest
{
  private CriFsLoadFileRequest.Phase phase;
  private CriFsBinder refBinder;
  private CriFsBinder newBinder;
  private uint bindId;
  private CriFsLoader loader;
  private int readUnitSize;
  private long fileSize;

  public CriFsLoadFileRequest(
    CriFsBinder srcBinder,
    string path,
    CriFsRequest.DoneDelegate doneDelegate,
    int readUnitSize)
  {
    this.path = path;
    this.doneDelegate = doneDelegate;
    this.readUnitSize = readUnitSize;
    if (srcBinder == null)
    {
      this.newBinder = new CriFsBinder();
      this.refBinder = this.newBinder;
      this.bindId = this.newBinder.BindFile(srcBinder, path);
      this.phase = CriFsLoadFileRequest.Phase.Bind;
    }
    else
    {
      this.newBinder = (CriFsBinder) null;
      this.refBinder = srcBinder;
      this.fileSize = srcBinder.GetFileSize(path);
      if (this.fileSize < 0L)
        this.phase = CriFsLoadFileRequest.Phase.Error;
      else
        this.phase = CriFsLoadFileRequest.Phase.Load;
    }
  }

  public string path { get; private set; }

  public byte[] bytes { get; private set; }

  public override void Dispose()
  {
    if (this.isDisposed)
      return;
    if (this.loader != null)
    {
      this.loader.Dispose();
      this.loader = (CriFsLoader) null;
    }
    if (this.newBinder != null)
    {
      this.newBinder.Dispose();
      this.newBinder = (CriFsBinder) null;
    }
    this.bytes = (byte[]) null;
    GC.SuppressFinalize((object) this);
    this.isDisposed = true;
  }

  public override void Stop()
  {
    if (this.phase != CriFsLoadFileRequest.Phase.Load || this.loader == null)
      return;
    this.loader.Stop();
  }

  public override void Update()
  {
    if (this.phase == CriFsLoadFileRequest.Phase.Bind)
      this.UpdateBinder();
    if (this.phase == CriFsLoadFileRequest.Phase.Load)
      this.UpdateLoader();
    if (this.phase != CriFsLoadFileRequest.Phase.Error)
      return;
    this.OnError();
  }

  private void UpdateBinder()
  {
    switch (CriFsBinder.GetStatus(this.bindId))
    {
      case CriFsBinder.Status.Analyze:
        return;
      case CriFsBinder.Status.Complete:
        this.fileSize = this.refBinder.GetFileSize(this.path);
        break;
      default:
        this.fileSize = -1L;
        break;
    }
    if (this.fileSize < 0L)
      this.phase = CriFsLoadFileRequest.Phase.Error;
    else
      this.phase = CriFsLoadFileRequest.Phase.Load;
  }

  private void UpdateLoader()
  {
    if (this.loader == null)
    {
      this.loader = new CriFsLoader();
      this.loader.SetReadUnitSize(this.readUnitSize);
      this.bytes = new byte[this.fileSize];
      this.loader.Load(this.refBinder, this.path, 0L, this.fileSize, this.bytes);
    }
    CriFsLoader.Status status = this.loader.GetStatus();
    if (status == CriFsLoader.Status.Loading)
      return;
    switch (status)
    {
      case CriFsLoader.Status.Stop:
        this.bytes = (byte[]) null;
        break;
      case CriFsLoader.Status.Error:
        this.phase = CriFsLoadFileRequest.Phase.Error;
        return;
    }
    this.phase = CriFsLoadFileRequest.Phase.Done;
    this.loader.Dispose();
    this.loader = (CriFsLoader) null;
    if (this.newBinder != null)
    {
      this.newBinder.Dispose();
      this.newBinder = (CriFsBinder) null;
    }
    this.Done();
  }

  private void OnError()
  {
    this.bytes = (byte[]) null;
    this.error = "Error occurred.";
    this.refBinder = (CriFsBinder) null;
    if (this.newBinder != null)
    {
      this.newBinder.Dispose();
      this.newBinder = (CriFsBinder) null;
    }
    if (this.loader != null)
    {
      this.loader.Dispose();
      this.loader = (CriFsLoader) null;
    }
    this.phase = CriFsLoadFileRequest.Phase.Done;
    this.Done();
  }

  private enum Phase
  {
    Stop,
    Bind,
    Load,
    Done,
    Error,
  }
}
