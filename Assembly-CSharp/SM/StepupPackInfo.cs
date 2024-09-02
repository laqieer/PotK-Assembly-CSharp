// Decompiled with JetBrains decompiler
// Type: SM.StepupPackInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class StepupPackInfo : KeyCompare
  {
    public StepupPackInfoPack_steps[] pack_steps;
    public PlayerStepupPack player_pack;
    public StepupPack pack;

    public StepupPackInfo()
    {
    }

    public StepupPackInfo(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<StepupPackInfoPack_steps> packInfoPackStepsList = new List<StepupPackInfoPack_steps>();
      foreach (object obj in (List<object>) json[nameof (pack_steps)])
        packInfoPackStepsList.Add(obj == null ? (StepupPackInfoPack_steps) null : new StepupPackInfoPack_steps((Dictionary<string, object>) obj));
      this.pack_steps = packInfoPackStepsList.ToArray();
      this.player_pack = json[nameof (player_pack)] == null ? (PlayerStepupPack) null : new PlayerStepupPack((Dictionary<string, object>) json[nameof (player_pack)]);
      this.pack = json[nameof (pack)] == null ? (StepupPack) null : new StepupPack((Dictionary<string, object>) json[nameof (pack)]);
    }
  }
}
