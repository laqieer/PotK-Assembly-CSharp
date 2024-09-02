// Decompiled with JetBrains decompiler
// Type: RuleMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class RuleMenu : BackButtonMenuBase
{
  private GameObject textPrefab;
  [SerializeField]
  private UIScrollView text_scroll;
  [SerializeField]
  private UILabel uiTitle;
  private int panel_width;
  private int height;

  public virtual void IbtnPopupOk()
  {
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void InitRulePopup(string title, PvpRuleDescription[] rule, GameObject textPrefab)
  {
    this.textPrefab = textPrefab;
    this.uiTitle.SetText(title);
    this.panel_width = (int) ((Component) this.text_scroll).GetComponent<UIPanel>().width;
    if (rule.Length <= 0)
      return;
    foreach (PvpRuleDescription data in rule)
      this.SetRuleText(data);
    this.text_scroll.ResetPosition();
  }

  private void SetRuleText(PvpRuleDescription data)
  {
    GameObject instance = this.textPrefab.Clone(((Component) this.text_scroll).transform);
    string text = data.ID.ToString() + "、" + data.disp_text;
    this.SetTextBox(instance.GetComponent<TextBoxPrefab>(), instance, text);
  }

  public void InitRewardPopup(
    string title,
    Dictionary<int, List<PvpClassReward>> resultDict,
    GameObject textPrefab)
  {
    this.textPrefab = textPrefab;
    this.uiTitle.SetText(title);
    this.panel_width = (int) ((Component) this.text_scroll).GetComponent<UIPanel>().width;
    int index = 0;
    foreach (int key in resultDict.Keys)
    {
      List<PvpClassReward> dic;
      if (resultDict.TryGetValue(key, out dic))
      {
        this.SetRewardText(dic, index);
        ++index;
      }
    }
    this.text_scroll.ResetPosition();
  }

  private void SetRewardText(List<PvpClassReward> dic, int index)
  {
    GameObject instance1 = this.textPrefab.Clone(((Component) this.text_scroll).transform);
    string text = (index + 1).ToString() + "、";
    Consts instance2 = Consts.GetInstance();
    for (int index1 = 0; index1 < dic.Count; ++index1)
    {
      string str1 = text + dic[index1].class_kind.name;
      if (index1 + 1 == dic.Count)
      {
        string str2 = dic.Count != 1 ? str1 + "：" + instance2.ClassReward_multi : str1 + "：" + instance2.ClassReward_single;
        if (dic[index1].reward_id > 0)
        {
          if (dic[index1].reward_type == MasterDataTable.CommonRewardType.emblem)
            text = str2 + dic[index1].reward_quantity.ToString() + instance2.CLASS_REWARD_NUM + "[" + MasterData.EmblemEmblem[dic[index1].reward_id].description + "]" + instance2.UNIQUE_ICON_EMBLEM;
          else
            text = str2 + dic[index1].reward_quantity.ToString() + instance2.CLASS_REWARD_NUM + CommonRewardType.GetRewardName(dic[index1].reward_type, dic[index1].reward_id);
        }
        else
          text = str2 + dic[index1].reward_message;
      }
      else
        text = str1 + "、";
    }
    this.SetTextBox(instance1.GetComponent<TextBoxPrefab>(), instance1, text);
  }

  public void SetTextBox(TextBoxPrefab textBox, GameObject instance, string text)
  {
    UILabel component1 = textBox.uiDescription.GetComponent<UILabel>();
    component1.SetText(text);
    int crlf = this.GetCRLF(text, component1.fontSize);
    int num1 = (component1.fontSize + component1.spacingY) * crlf;
    BoxCollider component2 = textBox.uiDescription.GetComponent<BoxCollider>();
    component2.size = new Vector3((float) component1.width, (float) num1);
    component2.center = new Vector3(-8f, 0.0f);
    float num2 = (float) this.height + (float) (num1 / 2);
    instance.transform.localPosition = new Vector3(0.0f, -num2, 0.0f);
    this.height += num1;
  }

  private int GetCRLF(string s, int fontsize)
  {
    int crlf = Mathf.CeilToInt((float) s.Trim().Length / Mathf.Floor((float) (this.panel_width / fontsize)));
    if (crlf == 0)
      crlf = 1;
    return crlf;
  }
}
