// Decompiled with JetBrains decompiler
// Type: Quest0022DetailDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0022DetailDisplay : MonoBehaviour
{
  [SerializeField]
  private UILabel Txt_Stagename;
  [SerializeField]
  private UILabel Txt_SubCondition;
  [SerializeField]
  private UILabel Txt_Condition;
  [SerializeField]
  private UILabel Txt_Wave_Condition;
  [SerializeField]
  private UILabel Txt_Wave_Number;
  [SerializeField]
  private UI2DSprite StageNumber;
  [SerializeField]
  protected GameObject SlcHiScroeBase;
  [SerializeField]
  protected UILabel TxtHiScroe;
  [SerializeField]
  protected UILabel TxtRest;

  public void InitDetailDisplay(
    QuestConverterData stageData,
    int num,
    QuestScoreCampaignProgress qscp)
  {
    this.Txt_Stagename.SetTextLocalize(stageData.title_S);
    if (stageData.wave != null)
    {
      ((Component) this.Txt_Wave_Condition).gameObject.SetActive(true);
      ((Component) this.Txt_Wave_Number).gameObject.SetActive(true);
      this.Txt_Wave_Condition.SetTextLocalize(stageData.wave.victory_description);
      this.Txt_Wave_Number.SetTextLocalize(Consts.Format(Consts.GetInstance().QUEST_0022_WAVE_COUNT, (IDictionary) new Hashtable()
      {
        {
          (object) "number",
          (object) stageData.wave.wave_count
        }
      }));
      ((Component) this.Txt_Condition).gameObject.SetActive(false);
      ((Component) this.Txt_SubCondition).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.Txt_Condition).gameObject.SetActive(true);
      ((Component) this.Txt_SubCondition).gameObject.SetActive(true);
      this.Txt_Condition.SetTextLocalize(stageData.victory_name);
      this.Txt_SubCondition.SetTextLocalize(stageData.victory_sub_name);
      ((Component) this.Txt_Wave_Condition).gameObject.SetActive(false);
      ((Component) this.Txt_Wave_Number).gameObject.SetActive(false);
    }
    if (Object.op_Inequality((Object) this.TxtRest, (Object) null))
    {
      ((Component) this.TxtRest).GetComponent<UIWidget>().color = Color.white;
      if (stageData.remain_battle_count.HasValue)
      {
        int num1 = stageData.daily_limit <= 0 ? stageData.max_battle_count_limit : stageData.daily_limit;
        int num2 = stageData.remain_battle_count.Value;
        this.TxtRest.SetTextLocalize(Consts.Format(Consts.GetInstance().QUEST_0022_LIMIT, (IDictionary) new Hashtable()
        {
          {
            (object) "remains",
            (object) num2
          },
          {
            (object) "max",
            (object) num1
          }
        }));
        if (num2 == 0)
          ((Component) this.TxtRest).GetComponent<UIWidget>().color = Color.red;
      }
      else
        this.TxtRest.SetTextLocalize(Consts.GetInstance().QUEST_0022_LIMIT_NONE);
    }
    if (Object.op_Inequality((Object) this.SlcHiScroeBase, (Object) null))
      this.SlcHiScroeBase.SetActive(false);
    if (qscp != null)
      this.SetRankingEventHiScore(qscp.GetQuestSScore(stageData.id_S));
    int? buttonFolderId = stageData.button_folder_ID;
    int num3 = !buttonFolderId.HasValue ? 0 : buttonFolderId.Value;
    string empty = string.Empty;
    string str;
    if (stageData.type == CommonQuestType.Extra)
    {
      str = "Prefabs/Quest/Extra/DifficultImage/";
    }
    else
    {
      if (stageData.type != CommonQuestType.Story)
        return;
      str = "Prefabs/Quest/Story/DifficultImage/";
    }
    string path1 = str + string.Format("{0}/{1}a", (object) num3, (object) num);
    string path2;
    if (!Singleton<ResourceManager>.GetInstance().Contains(path1))
    {
      Debug.LogError((object) ("NotFoundResourcesPath : " + path1));
      path2 = str + "0/1a";
    }
    else
      path2 = path1;
    this.StartCoroutine(this.SpriteCreate(path2));
  }

  protected void SetRankingEventHiScore(int score)
  {
    this.SlcHiScroeBase.SetActive(true);
    this.TxtHiScroe.SetTextLocalize(Consts.Format(Consts.GetInstance().QUEST_00220_HISCORE_TEXT, (IDictionary) new Hashtable()
    {
      {
        (object) nameof (score),
        (object) score
      }
    }));
  }

  [DebuggerHidden]
  private IEnumerator SpriteCreate(string path)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022DetailDisplay.\u003CSpriteCreate\u003Ec__Iterator208()
    {
      path = path,
      \u003C\u0024\u003Epath = path,
      \u003C\u003Ef__this = this
    };
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
