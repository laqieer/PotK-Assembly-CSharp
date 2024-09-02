// Decompiled with JetBrains decompiler
// Type: Earth.EarthQuestKeyPlayData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;

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

    public string GetSeverString() => string.Format(EarthQuestKeyPlayData.serverDataFormat, (object) this.mKeyID, (object) (this.mIsOpen ? 1 : 0), (object) this.mPlayCount);

    public static EarthQuestKeyPlayData JsonLoad(
      Dictionary<string, object> json)
    {
      return new EarthQuestKeyPlayData()
      {
        mKeyID = (int) (long) json["keyID"],
        mIsOpen = (uint) (int) (long) json["isOpen"] > 0U,
        mPlayCount = (int) (long) json["playCount"]
      };
    }
  }
}
