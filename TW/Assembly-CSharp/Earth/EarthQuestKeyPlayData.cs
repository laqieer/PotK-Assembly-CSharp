// Decompiled with JetBrains decompiler
// Type: Earth.EarthQuestKeyPlayData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;

#nullable disable
namespace Earth
{
  [Serializable]
  public class EarthQuestKeyPlayData : BL.ModelBase
  {
    private int mKeyID;
    private bool mIsOpen;
    private int mPlayCount;
    private static readonly string serverDataFormat = "{{\"keyID\":{0},\"isOpen\":{1},\"playCount\":{2}}}";

    public int ID
    {
      get => this.mKeyID;
      set => this.mKeyID = value;
    }

    public bool Open
    {
      get => this.mIsOpen;
      set => this.mIsOpen = value;
    }

    public int PlayCount
    {
      get => this.mPlayCount;
      set => this.mPlayCount = value;
    }

    public string GetSeverString()
    {
      return string.Format(EarthQuestKeyPlayData.serverDataFormat, (object) this.mKeyID, (object) (!this.mIsOpen ? 0 : 1), (object) this.mPlayCount);
    }

    public static EarthQuestKeyPlayData JsonLoad(Dictionary<string, object> json)
    {
      return new EarthQuestKeyPlayData()
      {
        mKeyID = (int) (long) json["keyID"],
        mIsOpen = (int) (long) json["isOpen"] != 0,
        mPlayCount = (int) (long) json["playCount"]
      };
    }
  }
}
