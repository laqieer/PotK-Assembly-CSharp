// Decompiled with JetBrains decompiler
// Type: CriWareErrorHandler
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
[AddComponentMenu("CRIWARE/Error Handler")]
public class CriWareErrorHandler : MonoBehaviour
{
  public bool enableDebugPrintOnTerminal;
  public bool enableForceCrashOnError;
  public bool dontDestroyOnLoad = true;
  private static int initializationCount;

  public static string errorMessage { get; set; }

  private void Awake()
  {
    ++CriWareErrorHandler.initializationCount;
    if (CriWareErrorHandler.initializationCount != 1)
    {
      Object.Destroy((Object) this);
    }
    else
    {
      CriWareErrorHandler.criWareUnity_Initialize();
      CriWareErrorHandler.criWareUnity_SetForceCrashFlagOnError(this.enableForceCrashOnError);
      CriWareErrorHandler.criWareUnity_ControlLogOutput(this.enableDebugPrintOnTerminal);
      if (!this.dontDestroyOnLoad)
        return;
      Object.DontDestroyOnLoad((Object) ((Component) ((Component) this).transform).gameObject);
    }
  }

  private void OnEnable()
  {
  }

  private void Start()
  {
  }

  private void Update()
  {
    if (this.enableDebugPrintOnTerminal)
      return;
    CriWareErrorHandler.OutputErrorMessage();
  }

  private void OnDestroy()
  {
    --CriWareErrorHandler.initializationCount;
    if (CriWareErrorHandler.initializationCount != 0)
      return;
    CriWareErrorHandler.criWareUnity_Finalize();
  }

  private static void OutputErrorMessage()
  {
    IntPtr firstError = CriWareErrorHandler.criWareUnity_GetFirstError();
    if (firstError == IntPtr.Zero)
      return;
    string stringAnsi = Marshal.PtrToStringAnsi(firstError);
    if (stringAnsi != string.Empty)
    {
      CriWareErrorHandler.OutputLog(stringAnsi);
      CriWareErrorHandler.criWareUnity_ResetError();
    }
    if (CriWareErrorHandler.errorMessage != null)
      return;
    CriWareErrorHandler.errorMessage = stringAnsi.Substring(0);
  }

  private static void OutputLog(string errmsg)
  {
    if (errmsg == null)
      return;
    if (errmsg.StartsWith("E"))
      Debug.LogError((object) ("[CRIWARE] Error:" + errmsg));
    else if (errmsg.StartsWith("W"))
      Debug.LogWarning((object) ("[CRIWARE] Warning:" + errmsg));
    else
      Debug.Log((object) ("[CRIWARE]" + errmsg));
  }

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criWareUnity_Initialize();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criWareUnity_Finalize();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern IntPtr criWareUnity_GetFirstError();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criWareUnity_ResetError();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criWareUnity_ControlLogOutput(bool sw);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criWareUnity_SetForceCrashFlagOnError(bool sw);
}
