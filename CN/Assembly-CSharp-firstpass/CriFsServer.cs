// Decompiled with JetBrains decompiler
// Type: CriFsServer
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class CriFsServer : MonoBehaviour
{
  private static CriFsServer _instance;
  private List<CriFsRequest> requestList;

  public static CriFsServer instance
  {
    get
    {
      CriFsServer.CreateInstance();
      return CriFsServer._instance;
    }
  }

  public int installBufferSize { get; private set; }

  public static void CreateInstance()
  {
    if (!Object.op_Equality((Object) CriFsServer._instance, (Object) null))
      return;
    CriWare.managerObject.AddComponent<CriFsServer>();
    CriFsServer._instance.installBufferSize = CriFsPlugin.installBufferSize;
  }

  public static void DestroyInstance()
  {
    if (!Object.op_Inequality((Object) CriFsServer._instance, (Object) null))
      return;
    Object.Destroy((Object) CriFsServer._instance);
  }

  private void Awake()
  {
    if (Object.op_Equality((Object) CriFsServer._instance, (Object) null))
    {
      CriFsServer._instance = this;
      this.requestList = new List<CriFsRequest>();
      this.requestList.Add(new CriFsRequest());
      this.requestList.RemoveAt(0);
    }
    else
      Object.Destroy((Object) this);
  }

  private void OnDestroy()
  {
    if (!Object.op_Equality((Object) CriFsServer._instance, (Object) this))
      return;
    foreach (CriFsRequest request in this.requestList)
      request.Dispose();
    CriFsServer._instance = (CriFsServer) null;
  }

  private void Update()
  {
    CriFsInstaller.ExecuteMain();
    for (int index = 0; index < this.requestList.Count; ++index)
      this.requestList[index].Update();
    this.requestList.RemoveAll((Predicate<CriFsRequest>) (request => request.isDone || request.isDisposed));
  }

  public void AddRequest(CriFsRequest request) => this.requestList.Add(request);

  public CriFsLoadFileRequest LoadFile(
    CriFsBinder binder,
    string path,
    CriFsRequest.DoneDelegate doneDelegate,
    int readUnitSize)
  {
    CriFsLoadFileRequest request = new CriFsLoadFileRequest(binder, path, doneDelegate, readUnitSize);
    this.AddRequest((CriFsRequest) request);
    return request;
  }

  public CriFsLoadAssetBundleRequest LoadAssetBundle(
    CriFsBinder binder,
    string path,
    int readUnitSize)
  {
    CriFsLoadAssetBundleRequest request = new CriFsLoadAssetBundleRequest(binder, path, readUnitSize);
    this.AddRequest((CriFsRequest) request);
    return request;
  }

  public CriFsInstallRequest Install(
    CriFsBinder srcBinder,
    string srcPath,
    string dstPath,
    CriFsRequest.DoneDelegate doneDelegate)
  {
    CriFsInstallRequest fsInstallRequest = new CriFsInstallRequest(srcBinder, srcPath, dstPath, doneDelegate, this.installBufferSize);
    this.requestList.Add((CriFsRequest) fsInstallRequest);
    return fsInstallRequest;
  }

  public CriFsBindRequest BindCpk(CriFsBinder targetBinder, CriFsBinder srcBinder, string path)
  {
    CriFsBindRequest request = new CriFsBindRequest(CriFsBindRequest.BindType.Cpk, targetBinder, srcBinder, path);
    this.AddRequest((CriFsRequest) request);
    return request;
  }

  public CriFsBindRequest BindDirectory(
    CriFsBinder targetBinder,
    CriFsBinder srcBinder,
    string path)
  {
    CriFsBindRequest request = new CriFsBindRequest(CriFsBindRequest.BindType.Directory, targetBinder, srcBinder, path);
    this.AddRequest((CriFsRequest) request);
    return request;
  }

  public CriFsBindRequest BindFile(CriFsBinder targetBinder, CriFsBinder srcBinder, string path)
  {
    CriFsBindRequest request = new CriFsBindRequest(CriFsBindRequest.BindType.File, targetBinder, srcBinder, path);
    this.AddRequest((CriFsRequest) request);
    return request;
  }
}
