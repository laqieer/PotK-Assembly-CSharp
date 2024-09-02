// Decompiled with JetBrains decompiler
// Type: Battle0171111Event
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle0171111Event : BattleMonoBehaviour
{
  public GameObject DialogConteiner;
  public Transform skillTargetParent1;
  public Transform skillTargetParent2;
  public Transform weaponKindParent;
  public GearKind weaponKind;
  public BattleskillGenre? skillTargetID1;
  public BattleskillGenre? skillTargetID2;
  public string skillName;
  public string skillDesc;
  [SerializeField]
  private UILabel label_SkillName;
  [SerializeField]
  private UILabel label_SkillDesc;
  [SerializeField]
  private UILabel label_RemainTurn;
  private GameObject skillTgtIcon1;
  private GameObject skillTgtIcon2;
  private CommonElementIcon elementIcon;
  private BattleSkillIcon skillIcon;
  [SerializeField]
  private GameObject slc_Skillproperty_blank;
  [SerializeField]
  private GameObject dir_Lv;
  [SerializeField]
  private GameObject slc_SkillLv;
  [SerializeField]
  private UISprite slc_SkillLvMax;
  [SerializeField]
  private UILabel label_SkillLv;
  [SerializeField]
  private UILabel label_SkillLvMax;
  private BattleskillSkill displaySkill;
  private bool isShow;
  private bool is_popup_managed;

  public bool isPopupManaged
  {
    get => this.is_popup_managed;
    set
    {
      ((Component) ((Component) this).transform.parent).gameObject.GetComponent<Collider>().enabled = value;
      ((Behaviour) ((Component) ((Component) this).transform.parent).gameObject.GetComponent<UIButton>()).enabled = value;
      this.is_popup_managed = value;
    }
  }

  private void Awake()
  {
    ((Component) ((Component) this).transform.parent).gameObject.GetComponent<Collider>().enabled = false;
    ((Behaviour) ((Component) ((Component) this).transform.parent).gameObject.GetComponent<UIButton>()).enabled = false;
  }

  private void OnEnable()
  {
  }

  public void Show()
  {
    if (this.DialogConteiner.activeInHierarchy && this.isShow)
      return;
    this.isShow = true;
    this.DialogConteiner.SetActive(true);
    this.StopCoroutine("setIcons");
    this.StartCoroutine("setIcons");
    ((IEnumerable<UITweener>) ((Component) this).gameObject.GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (c =>
    {
      ((Behaviour) c).enabled = true;
      c.onFinished.Clear();
      c.PlayForward();
    }));
  }

  public void Hide()
  {
    if (!this.DialogConteiner.activeInHierarchy && !this.isShow)
      return;
    this.isShow = false;
    UITweener[] tweens = ((Component) this).gameObject.GetComponentsInChildren<UITweener>();
    if (tweens.Length <= 0)
      return;
    int finishCount = 0;
    EventDelegate.Callback onFinish = (EventDelegate.Callback) (() =>
    {
      if (!Object.op_Inequality((Object) this.DialogConteiner, (Object) null) || ++finishCount < tweens.Length)
        return;
      this.DialogConteiner.SetActive(false);
    });
    ((IEnumerable<UITweener>) tweens).ForEach<UITweener>((Action<UITweener>) (c =>
    {
      c.onFinished.Clear();
      c.AddOnFinished(onFinish);
      c.PlayReverse();
    }));
  }

  private GameObject createIcon(GameObject prefab, Transform trans)
  {
    GameObject icon = prefab.Clone(trans);
    UI2DSprite componentInChildren1 = icon.GetComponentInChildren<UI2DSprite>();
    BoxCollider componentInChildren2 = ((Component) trans).GetComponentInChildren<BoxCollider>();
    if (Object.op_Inequality((Object) componentInChildren1, (Object) null))
    {
      componentInChildren1.SetDimensions((int) componentInChildren2.size.x, (int) componentInChildren2.size.y);
      componentInChildren1.depth += 150;
    }
    return icon;
  }

  private void Update()
  {
    if (!Input.GetMouseButtonDown(0) || this.is_popup_managed)
      return;
    this.Hide();
  }

  public void onButtonClicked()
  {
  }

  [DebuggerHidden]
  private IEnumerator setIcons()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle0171111Event.\u003CsetIcons\u003Ec__Iterator885()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void setData(BattleskillSkill skill)
  {
    this.displaySkill = skill;
    this.skillDesc = skill.description;
    this.skillName = skill.name;
    this.skillTargetID1 = skill.genre1;
    this.skillTargetID2 = skill.genre2;
    this.weaponKind = MasterData.GearKind[3];
    this.setSkillLv(0, skill.upper_level);
    this.disableRemainTurn();
  }

  public void setSkillLv(int lv, int lv_upper = 0)
  {
    string str = lv.ToString();
    string text = lv_upper.ToString();
    if (lv < 1)
      str = "-";
    if (lv_upper < 1)
    {
      str = "-";
      text = "-";
    }
    if (lv < 1 && lv_upper > 0)
    {
      this.slc_SkillLv.gameObject.SetActive(false);
      ((Component) this.slc_SkillLvMax).gameObject.SetActive(true);
      ((Component) this.label_SkillLv).gameObject.SetActive(false);
      ((Component) this.label_SkillLvMax).gameObject.SetActive(true);
      this.label_SkillLvMax.SetText(text);
    }
    else
    {
      this.slc_SkillLv.gameObject.SetActive(true);
      ((Component) this.slc_SkillLvMax).gameObject.SetActive(false);
      ((Component) this.label_SkillLv).gameObject.SetActive(true);
      ((Component) this.label_SkillLvMax).gameObject.SetActive(false);
      this.label_SkillLv.SetText(str + "/" + text);
    }
  }

  public void enableSkillLv(bool enable) => this.dir_Lv.SetActive(enable);

  public void setSkillProperty(bool flg)
  {
    this.slc_Skillproperty_blank.SetActive(flg);
    ((Component) this.skillTargetParent1).gameObject.SetActive(flg);
    ((Component) this.skillTargetParent2).gameObject.SetActive(flg);
  }

  public void setRemainTurn(int turn)
  {
    if (!Object.op_Inequality((Object) this.label_RemainTurn, (Object) null))
      return;
    ((Component) this.label_RemainTurn).gameObject.SetActive(true);
    this.label_RemainTurn.SetTextLocalize(Consts.Format(Consts.GetInstance().AILMENT_REMAINTURN, (IDictionary) new Hashtable()
    {
      {
        (object) nameof (turn),
        (object) turn
      }
    }));
  }

  public void disableRemainTurn()
  {
    if (!Object.op_Inequality((Object) this.label_RemainTurn, (Object) null))
      return;
    ((Component) this.label_RemainTurn).gameObject.SetActive(false);
  }
}
