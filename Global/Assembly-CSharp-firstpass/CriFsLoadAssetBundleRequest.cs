// Decompiled with JetBrains decompiler
// Type: CriFsLoadAssetBundleRequest
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
public class CriFsLoadAssetBundleRequest : CriFsRequest
{
  private CriFsLoadFileRequest loadFileReq;
  private AssetBundleCreateRequest assetBundleReq;

  public CriFsLoadAssetBundleRequest(CriFsBinder binder, string path, int readUnitSize)
  {
    this.path = path;
    this.loadFileReq = CriFsUtility.LoadFile(binder, path, readUnitSize);
  }

  public string path { get; private set; }

  public AssetBundle assetBundle { get; private set; }

  public override void Update()
  {
    if (this.loadFileReq != null)
    {
      if (!this.loadFileReq.isDone)
        return;
      if (this.loadFileReq.error != null)
      {
        this.error = "Error occurred.";
        this.Done();
      }
      else
        this.assetBundleReq = AssetBundle.LoadFromMemoryAsync(this.loadFileReq.bytes);
      this.loadFileReq = (CriFsLoadFileRequest) null;
    }
    else if (this.assetBundleReq != null)
    {
      if (!((AsyncOperation) this.assetBundleReq).isDone)
        return;
      this.assetBundle = this.assetBundleReq.assetBundle;
      this.Done();
    }
    else
      this.Done();
  }

  public override void Dispose()
  {
    if (this.isDisposed)
      return;
    if (this.loadFileReq != null)
    {
      this.loadFileReq.Dispose();
      this.loadFileReq = (CriFsLoadFileRequest) null;
    }
    GC.SuppressFinalize((object) this);
    this.isDisposed = true;
  }
}
