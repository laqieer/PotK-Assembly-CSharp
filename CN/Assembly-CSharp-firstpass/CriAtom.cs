// Decompiled with JetBrains decompiler
// Type: CriAtom
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
[AddComponentMenu("CRIWARE/CRI Atom")]
public class CriAtom : MonoBehaviour
{
  public string acfFile = string.Empty;
  public CriAtomCueSheet[] cueSheets = new CriAtomCueSheet[0];
  public string dspBusSetting = string.Empty;
  public bool dontDestroyOnLoad;
  private static CriAtomExSequencer.EventCbFunc eventUserCbFunc = (CriAtomExSequencer.EventCbFunc) null;
  private static Queue<string> eventQueue = new Queue<string>();
  public bool dontRemoveExistsCueSheet;

  private static CriAtom instance { get; set; }

  public static void AttachDspBusSetting(string settingName)
  {
    CriAtom.instance.dspBusSetting = settingName;
    if (!string.IsNullOrEmpty(settingName))
      CriAtomEx.AttachDspBusSetting(settingName);
    else
      CriAtomEx.DetachDspBusSetting();
  }

  public static void DetachDspBusSetting()
  {
    CriAtom.instance.dspBusSetting = string.Empty;
    CriAtomEx.DetachDspBusSetting();
  }

  public static CriAtomCueSheet GetCueSheet(string name)
  {
    return CriAtom.instance.GetCueSheetInternal(name);
  }

  public static CriAtomCueSheet AddCueSheet(
    string name,
    string acbFile,
    string awbFile,
    CriFsBinder binder = null)
  {
    CriAtomCueSheet criAtomCueSheet = CriAtom.instance.AddCueSheetInternal(name, acbFile, awbFile, binder);
    if (Application.isPlaying)
      criAtomCueSheet.acb = CriAtom.instance.LoadAcbFile(binder, acbFile, awbFile);
    return criAtomCueSheet;
  }

  public static CriAtomCueSheet AddCueSheet(
    string name,
    byte[] acbData,
    string awbFile,
    CriFsBinder awbBinder = null)
  {
    CriAtomCueSheet criAtomCueSheet = CriAtom.instance.AddCueSheetInternal(name, string.Empty, awbFile, awbBinder);
    if (Application.isPlaying)
      criAtomCueSheet.acb = CriAtom.instance.LoadAcbData(acbData, awbBinder, awbFile);
    return criAtomCueSheet;
  }

  public static void RemoveCueSheet(string name) => CriAtom.instance.RemoveCueSheetInternal(name);

  public static CriAtomExAcb GetAcb(string cueSheetName)
  {
    foreach (CriAtomCueSheet cueSheet in CriAtom.instance.cueSheets)
    {
      if (cueSheetName == cueSheet.name)
        return cueSheet.acb;
    }
    Debug.LogWarning((object) (cueSheetName + " is not loaded."));
    return (CriAtomExAcb) null;
  }

  public static void SetCategoryVolume(string name, float volume)
  {
    CriAtomExCategory.SetVolume(name, volume);
  }

  public static void SetCategoryVolume(int id, float volume)
  {
    CriAtomExCategory.SetVolume(id, volume);
  }

  public static float GetCategoryVolume(string name) => CriAtomExCategory.GetVolume(name);

  public static float GetCategoryVolume(int id) => CriAtomExCategory.GetVolume(id);

  public static void SetBusAnalyzer(bool sw)
  {
    if (sw)
      CriAtomExAsr.AttachBusAnalyzer(50, 1000);
    else
      CriAtomExAsr.DetachBusAnalyzer();
  }

  public static CriAtomExAsr.BusAnalyzerInfo GetBusAnalyzerInfo(int bus)
  {
    CriAtomExAsr.BusAnalyzerInfo info;
    CriAtomExAsr.GetBusAnalyzerInfo(bus, out info);
    return info;
  }

  private void Setup()
  {
    CriAtom.instance = this;
    CriAtomPlugin.InitializeLibrary();
    if (!string.IsNullOrEmpty(this.acfFile))
      CriAtomEx.RegisterAcf((CriFsBinder) null, Path.Combine(CriWare.streamingAssetsPath, this.acfFile));
    if (!string.IsNullOrEmpty(this.dspBusSetting))
      CriAtom.AttachDspBusSetting(this.dspBusSetting);
    foreach (CriAtomCueSheet cueSheet in this.cueSheets)
      cueSheet.acb = this.LoadAcbFile((CriFsBinder) null, cueSheet.acbFile, cueSheet.awbFile);
    if (!this.dontDestroyOnLoad)
      return;
    Object.DontDestroyOnLoad((Object) ((Component) this).gameObject);
  }

  private void Shutdown()
  {
    foreach (CriAtomCueSheet cueSheet in this.cueSheets)
    {
      if (cueSheet.acb != null)
      {
        cueSheet.acb.Dispose();
        cueSheet.acb = (CriAtomExAcb) null;
      }
    }
    CriAtomPlugin.FinalizeLibrary();
    CriAtom.instance = (CriAtom) null;
  }

  private void Awake()
  {
    if (!Object.op_Inequality((Object) CriAtom.instance, (Object) null))
      return;
    if (CriAtom.instance.acfFile != this.acfFile)
    {
      GameObject gameObject = ((Component) CriAtom.instance).gameObject;
      CriAtom.instance.Shutdown();
      CriAtomEx.UnregisterAcf();
      Object.Destroy((Object) gameObject);
    }
    else
    {
      if (CriAtom.instance.dspBusSetting != this.dspBusSetting)
        CriAtom.AttachDspBusSetting(this.dspBusSetting);
      CriAtom.instance.MargeCueSheet(this.cueSheets, this.dontRemoveExistsCueSheet);
      Object.Destroy((Object) ((Component) this).gameObject);
    }
  }

  private void OnEnable()
  {
    if (Object.op_Inequality((Object) CriAtom.instance, (Object) null))
      return;
    this.Setup();
  }

  private void OnDestroy()
  {
    if (Object.op_Inequality((Object) this, (Object) CriAtom.instance))
      return;
    this.Shutdown();
  }

  private void Update()
  {
    if (CriAtom.eventUserCbFunc == null)
      return;
    int count = CriAtom.eventQueue.Count;
    for (int index = 0; index < count; ++index)
    {
      string eventParamsString;
      lock (((ICollection) CriAtom.eventQueue).SyncRoot)
        eventParamsString = CriAtom.eventQueue.Dequeue();
      CriAtom.eventUserCbFunc(eventParamsString);
    }
  }

  public CriAtomCueSheet GetCueSheetInternal(string name)
  {
    for (int index = 0; index < this.cueSheets.Length; ++index)
    {
      CriAtomCueSheet cueSheet = this.cueSheets[index];
      if (cueSheet.name == name)
        return cueSheet;
    }
    return (CriAtomCueSheet) null;
  }

  public CriAtomCueSheet AddCueSheetInternal(
    string name,
    string acbFile,
    string awbFile,
    CriFsBinder binder)
  {
    CriAtomCueSheet[] criAtomCueSheetArray = new CriAtomCueSheet[this.cueSheets.Length + 1];
    this.cueSheets.CopyTo((Array) criAtomCueSheetArray, 0);
    this.cueSheets = criAtomCueSheetArray;
    CriAtomCueSheet criAtomCueSheet = new CriAtomCueSheet();
    this.cueSheets[this.cueSheets.Length - 1] = criAtomCueSheet;
    criAtomCueSheet.name = !string.IsNullOrEmpty(name) ? name : Path.GetFileNameWithoutExtension(acbFile);
    criAtomCueSheet.acbFile = acbFile;
    criAtomCueSheet.awbFile = awbFile;
    return criAtomCueSheet;
  }

  public void RemoveCueSheetInternal(string name)
  {
    int index1 = -1;
    for (int index2 = 0; index2 < this.cueSheets.Length; ++index2)
    {
      if (name == this.cueSheets[index2].name)
        index1 = index2;
    }
    if (index1 < 0)
      return;
    CriAtomCueSheet cueSheet = this.cueSheets[index1];
    if (cueSheet.acb != null)
      cueSheet.acb.Dispose();
    CriAtomCueSheet[] destinationArray = new CriAtomCueSheet[this.cueSheets.Length - 1];
    Array.Copy((Array) this.cueSheets, 0, (Array) destinationArray, 0, index1);
    Array.Copy((Array) this.cueSheets, index1 + 1, (Array) destinationArray, index1, this.cueSheets.Length - index1 - 1);
    this.cueSheets = destinationArray;
  }

  private void MargeCueSheet(CriAtomCueSheet[] newCueSheets, bool newDontRemoveExistsCueSheet)
  {
    if (!newDontRemoveExistsCueSheet)
    {
      int i = 0;
      while (i < this.cueSheets.Length)
      {
        if (Array.FindIndex<CriAtomCueSheet>(newCueSheets, (Predicate<CriAtomCueSheet>) (sheet => sheet.name == this.cueSheets[i].name)) < 0)
          CriAtom.RemoveCueSheet(this.cueSheets[i].name);
        else
          ++i;
      }
    }
    foreach (CriAtomCueSheet newCueSheet in newCueSheets)
    {
      if (this.GetCueSheetInternal(newCueSheet.name) == null)
        CriAtom.AddCueSheet((string) null, newCueSheet.acbFile, newCueSheet.awbFile);
    }
  }

  private CriAtomExAcb LoadAcbFile(CriFsBinder binder, string acbFile, string awbFile)
  {
    if (string.IsNullOrEmpty(acbFile))
      return (CriAtomExAcb) null;
    string str1 = acbFile;
    if (binder == null && CriWare.IsStreamingAssetsPath(str1))
      str1 = Path.Combine(CriWare.streamingAssetsPath, str1);
    string str2 = awbFile;
    if (!string.IsNullOrEmpty(str2) && binder == null && CriWare.IsStreamingAssetsPath(str2))
      str2 = Path.Combine(CriWare.streamingAssetsPath, str2);
    return CriAtomExAcb.LoadAcbFile(binder, str1, str2);
  }

  private CriAtomExAcb LoadAcbData(byte[] acbData, CriFsBinder binder, string awbFile)
  {
    if (acbData == null)
      return (CriAtomExAcb) null;
    string str = awbFile;
    if (!string.IsNullOrEmpty(str) && binder == null && CriWare.IsStreamingAssetsPath(str))
      str = Path.Combine(CriWare.streamingAssetsPath, str);
    return CriAtomExAcb.LoadAcbData(acbData, binder, str);
  }

  public void EventCallbackFromNative(string eventString)
  {
    if (CriAtom.eventUserCbFunc == null)
      return;
    lock (((ICollection) CriAtom.eventQueue).SyncRoot)
      CriAtom.eventQueue.Enqueue(eventString);
  }

  public static void SetEventCallback(CriAtomExSequencer.EventCbFunc func, string separator)
  {
    IntPtr zero = IntPtr.Zero;
    CriAtom.eventUserCbFunc = func;
    if (func == null)
      return;
    CriAtomPlugin.criAtomUnitySeqencer_SetEventCallback(Marshal.GetFunctionPointerForDelegate((Delegate) new CriAtomExSequencer.EventCbFunc(CriAtom.instance.EventCallbackFromNative)), ((Object) ((Component) CriAtom.instance).gameObject).name, "EventCallbackFromNative", separator);
  }
}
