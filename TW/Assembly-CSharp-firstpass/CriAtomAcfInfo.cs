// Decompiled with JetBrains decompiler
// Type: CriAtomAcfInfo
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using System.IO;
using UnityEngine;

#nullable disable
public class CriAtomAcfInfo
{
  public static CriAtomAcfInfo.AcfInfo acfInfo;

  public static bool GetCueInfo(bool forceReload, string searchPath)
  {
    if (CriAtomAcfInfo.acfInfo == null || forceReload)
    {
      foreach (string file in Directory.GetFiles(searchPath))
      {
        if (Path.GetExtension(file.Replace("\\", "/")) == ".acf")
        {
          CriAtomAcfInfo.acfInfo = new CriAtomAcfInfo.AcfInfo(Path.GetFileNameWithoutExtension(file), 0, string.Empty, Path.GetFileName(file), string.Empty, string.Empty);
          CriAtomAcfInfo.acfInfo.acfFilePath = file;
          break;
        }
      }
      if (CriAtomAcfInfo.acfInfo == null)
        Debug.Log((object) ("CriAtomAcfInfo.acfInfo is null. \"" + searchPath + "\""));
    }
    return CriAtomAcfInfo.acfInfo != null;
  }

  public class InfoBase
  {
    public string name = "dummyCueSheet";
    public int id;
    public string comment = string.Empty;
  }

  public class AcfInfo : CriAtomAcfInfo.InfoBase
  {
    public string acfPath = "dummyCueSheet.acf";
    public List<CriAtomAcfInfo.AcbInfo> acbInfoList = new List<CriAtomAcfInfo.AcbInfo>();
    private List<CriAtomAcfInfo.AcbInfo> tmpAcbInfoList = new List<CriAtomAcfInfo.AcbInfo>();
    public string atomGuid = string.Empty;
    public string dspBusSetting = "DspBusSetting_0";
    public List<string> aisacControlNameList = new List<string>();
    public string acfFilePath = string.Empty;

    public AcfInfo(
      string n,
      int inId,
      string com,
      string inAcfPath,
      string _guid,
      string _dspBusSetting)
    {
      this.name = n;
      this.id = inId;
      this.comment = com;
      this.acfPath = inAcfPath;
      this.atomGuid = _guid;
      this.dspBusSetting = _dspBusSetting;
    }
  }

  public class AcbInfo : CriAtomAcfInfo.InfoBase
  {
    public string acbPath = "dummyCueSheet.acb";
    public string awbPath = "dummyCueSheet_streamfiles.awb";
    public string atomGuid = string.Empty;
    public Dictionary<int, CriAtomAcfInfo.CueInfo> cueInfoList = new Dictionary<int, CriAtomAcfInfo.CueInfo>();

    public AcbInfo(
      string n,
      int inId,
      string com,
      string inAcbPath,
      string inAwbPath,
      string _guid)
    {
      this.name = n;
      this.id = inId;
      this.comment = com;
      this.acbPath = inAcbPath;
      this.awbPath = inAwbPath;
      this.atomGuid = _guid;
    }
  }

  public class CueInfo : CriAtomAcfInfo.InfoBase
  {
    public CueInfo(string n, int inId, string com)
    {
      this.name = n;
      this.id = inId;
      this.comment = com;
    }
  }
}
