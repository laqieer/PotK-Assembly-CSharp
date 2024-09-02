// Decompiled with JetBrains decompiler
// Type: Quest00219List
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using UnityEngine;

[AddComponentMenu("Scenes/QuestExtra/M_ListItem")]
public class Quest00219List : MonoBehaviour
{
  [SerializeField]
  private Quest00219List.ColorSet ColorNormal;
  [SerializeField]
  private Quest00219List.ColorSet ColorDisable;
  [SerializeField]
  public UIButton Dock;
  [SerializeField]
  public UILabel Name;
  [SerializeField]
  public UISprite Clear;
  [SerializeField]
  public UISprite New;
  [SerializeField]
  private GameObject ClearedToday;

  public IEnumerator Init(
    PlayerExtraQuestS extra,
    bool isClear,
    bool isNew,
    bool isClearedToday)
  {
    this.Clear.gameObject.SetActive(isClear);
    this.New.gameObject.SetActive(isNew);
    this.Name.SetTextLocalize(MasterData.QuestExtraM[extra.quest_extra_s.quest_m_QuestExtraM].name);
    this.setClearedToday(isClearedToday);
    yield break;
  }

  protected void setClearedToday(bool bActive)
  {
    if ((UnityEngine.Object) this.ClearedToday == (UnityEngine.Object) null)
      return;
    this.ClearedToday.SetActive(bActive);
    Quest00219List.ColorSet colorSet = bActive ? this.ColorDisable : this.ColorNormal;
    this.Dock.gameObject.GetComponent<UISprite>().color = this.Dock.defaultColor = colorSet.default_;
    this.Dock.hover = colorSet.hover_;
    this.Dock.pressed = colorSet.pressed_;
  }

  [Serializable]
  private class ColorSet
  {
    public Color default_;
    public Color hover_;
    public Color pressed_;
  }
}
