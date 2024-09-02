// Decompiled with JetBrains decompiler
// Type: MissionData.DailyIMissionReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;

namespace MissionData
{
  internal class DailyIMissionReward : IMissionReward
  {
    private DailyMissionReward data_;

    public bool isDaily => true;

    public bool isGuild => false;

    public object original => (object) this.data_;

    public int reward_quantity => this.data_.reward_quantity;

    public string reward_message => this.data_.reward_message;

    public int reward_type_id => this.data_.reward_type_id;

    public int reward_id => this.data_.reward_id;

    public DailyIMissionReward(DailyMissionReward dat) => this.data_ = dat;
  }
}
