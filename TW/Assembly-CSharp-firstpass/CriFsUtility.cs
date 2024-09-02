// Decompiled with JetBrains decompiler
// Type: CriFsUtility
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System.Runtime.InteropServices;

#nullable disable
public static class CriFsUtility
{
  public const int DefaultReadUnitSize = 1048576;

  public static CriFsLoadFileRequest LoadFile(string path, int readUnitSize = 1048576)
  {
    return CriFsServer.instance.LoadFile((CriFsBinder) null, path, (CriFsRequest.DoneDelegate) null, readUnitSize);
  }

  public static CriFsLoadFileRequest LoadFile(
    string path,
    CriFsRequest.DoneDelegate doneDelegate,
    int readUnitSize = 1048576)
  {
    return CriFsServer.instance.LoadFile((CriFsBinder) null, path, doneDelegate, readUnitSize);
  }

  public static CriFsLoadFileRequest LoadFile(CriFsBinder binder, string path, int readUnitSize = 1048576)
  {
    return CriFsServer.instance.LoadFile(binder, path, (CriFsRequest.DoneDelegate) null, readUnitSize);
  }

  public static CriFsLoadAssetBundleRequest LoadAssetBundle(string path, int readUnitSize = 1048576)
  {
    return CriFsUtility.LoadAssetBundle((CriFsBinder) null, path, readUnitSize);
  }

  public static CriFsLoadAssetBundleRequest LoadAssetBundle(
    CriFsBinder binder,
    string path,
    int readUnitSize = 1048576)
  {
    return CriFsServer.instance.LoadAssetBundle(binder, path, readUnitSize);
  }

  public static CriFsInstallRequest Install(string srcPath, string dstPath)
  {
    return CriFsUtility.Install((CriFsBinder) null, srcPath, dstPath, (CriFsRequest.DoneDelegate) null);
  }

  public static CriFsInstallRequest Install(
    string srcPath,
    string dstPath,
    CriFsRequest.DoneDelegate doneDeleagate)
  {
    return CriFsUtility.Install((CriFsBinder) null, srcPath, dstPath, doneDeleagate);
  }

  public static CriFsInstallRequest Install(CriFsBinder srcBinder, string srcPath, string dstPath)
  {
    return CriFsServer.instance.Install(srcBinder, srcPath, dstPath, (CriFsRequest.DoneDelegate) null);
  }

  public static CriFsInstallRequest Install(
    CriFsBinder srcBinder,
    string srcPath,
    string dstPath,
    CriFsRequest.DoneDelegate doneDeleagate)
  {
    return CriFsServer.instance.Install(srcBinder, srcPath, dstPath, doneDeleagate);
  }

  public static CriFsBindRequest BindCpk(CriFsBinder targetBinder, string srcPath)
  {
    return CriFsUtility.BindCpk(targetBinder, (CriFsBinder) null, srcPath);
  }

  public static CriFsBindRequest BindCpk(
    CriFsBinder targetBinder,
    CriFsBinder srcBinder,
    string srcPath)
  {
    return CriFsServer.instance.BindCpk(targetBinder, srcBinder, srcPath);
  }

  public static CriFsBindRequest BindDirectory(CriFsBinder targetBinder, string srcPath)
  {
    return CriFsServer.instance.BindDirectory(targetBinder, (CriFsBinder) null, srcPath);
  }

  public static CriFsBindRequest BindDirectory(
    CriFsBinder targetBinder,
    CriFsBinder srcBinder,
    string srcPath)
  {
    return CriFsServer.instance.BindDirectory(targetBinder, srcBinder, srcPath);
  }

  public static CriFsBindRequest BindFile(CriFsBinder targetBinder, string srcPath)
  {
    return CriFsServer.instance.BindFile(targetBinder, (CriFsBinder) null, srcPath);
  }

  public static CriFsBindRequest BindFile(
    CriFsBinder targetBinder,
    CriFsBinder srcBinder,
    string srcPath)
  {
    return CriFsServer.instance.BindFile(targetBinder, srcBinder, srcPath);
  }

  public static void SetUserAgentString(string userAgentString)
  {
    CriFsPlugin.InitializeLibrary();
    CriFsUtility.criFsUnity_SetUserAgentString(userAgentString);
  }

  public static void SetProxyServer(string proxyPath, ushort proxyPort)
  {
    CriFsPlugin.InitializeLibrary();
    CriFsUtility.criFsUnity_SetProxyServer(proxyPath, proxyPort);
  }

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criFsUnity_SetUserAgentString(string userAgentString);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criFsUnity_SetProxyServer(string proxyPath, ushort proxyPort);
}
