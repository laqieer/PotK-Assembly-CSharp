// Decompiled with JetBrains decompiler
// Type: Quest00214DetailDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Quest00214DetailDisplay : MonoBehaviour
{
  public UILabel Txt_Stagename;
  public UILabel Txt_Ap;
  public UILabel Txt_SubCondition;
  public UILabel Txt_Condition;
  public Transform StageNumbersParent;
  public UILabel[] Txt_StageNumbers;

  public void InitDetailDisplay(QuestSConverter StageData, int num)
  {
    this.Txt_Stagename.SetTextLocalize(StageData.name);
    this.Txt_Ap.SetTextLocalize(StageData.lost_ap);
    this.Txt_SubCondition.SetTextLocalize(StageData.stage.victory_condition.sub_name);
    this.Txt_Condition.SetTextLocalize(StageData.stage.victory_condition.name);
    foreach (UILabel txtStageNumber in this.Txt_StageNumbers)
      txtStageNumber.text = num.ToString();
  }

  public void StartTween(bool order)
  {
    foreach (UITweener component in ((Component) this).GetComponents<UITweener>())
    {
      if (component.tweenGroup == 1)
        component.Play(order);
    }
  }
}
