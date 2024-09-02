// Decompiled with JetBrains decompiler
// Type: ExtraSkillIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraSkillIcon : IconPrefabBase
{
  public static readonly int Width = 123;
  public static readonly int Height = 147;
  public static readonly int ColumnValue = 5;
  public static readonly int RowValue = 8;
  public static readonly int RowScreenValue = 5;
  public static readonly int ScreenValue = ExtraSkillIcon.ColumnValue * ExtraSkillIcon.RowScreenValue;
  public static readonly int MaxValue = ExtraSkillIcon.ColumnValue * ExtraSkillIcon.RowValue;
  private static readonly int SelectedIndexFontSize = 22;
  [SerializeField]
  private GameObject removeObject;
  [SerializeField]
  private GameObject skillObject;
  [SerializeField]
  private UILabel txtSkillLV;
  [SerializeField]
  private UI2DSprite dynExtraSkill;
  [SerializeField]
  private GameObject forbattle;
  [SerializeField]
  private GameObject favorite;
  [SerializeField]
  private GameObject selectedBack;
  [SerializeField]
  private GameObject selectedCheck;
  [SerializeField]
  private GameObject selectedNum;
  [SerializeField]
  private GameObject slcSelected;
  [SerializeField]
  private UnityEngine.Sprite[] selectNumSprite;
  [SerializeField]
  private GameObject objSkillGetInfo;
  private System.Action<InventoryExtraSkill> clickAction;
  private System.Action clickActionNoArg;
  private InventoryExtraSkill invExtraSkill;

  public bool ForBattle
  {
    get => (UnityEngine.Object) this.forbattle != (UnityEngine.Object) null && this.forbattle.activeSelf;
    set
    {
      if (!((UnityEngine.Object) this.forbattle != (UnityEngine.Object) null))
        return;
      this.forbattle.SetActive(value);
    }
  }

  public bool Favorite
  {
    get => (UnityEngine.Object) this.favorite != (UnityEngine.Object) null && this.favorite.activeSelf;
    set
    {
      if (!((UnityEngine.Object) this.favorite != (UnityEngine.Object) null))
        return;
      this.favorite.SetActive(value);
    }
  }

  public bool IsSelected => (UnityEngine.Object) this.selectedBack != (UnityEngine.Object) null && this.selectedBack.activeSelf;

  public System.Action<InventoryExtraSkill> ClickAction
  {
    get => this.clickAction;
    set => this.clickAction = value;
  }

  public InventoryExtraSkill InvExtraSkill => this.invExtraSkill;

  public override bool Gray
  {
    get => this.gray;
    set
    {
      if (this.gray == value)
        return;
      this.gray = value;
      NGTween.playTweens(this.GetComponentsInChildren<UITweener>(true), NGTween.Kind.GRAYOUT, !value);
    }
  }

  public void InitByRemoveButton(System.Action<InventoryExtraSkill> btnAct = null)
  {
    this.removeObject.SetActive(true);
    this.skillObject.SetActive(false);
    this.ClickAction = btnAct;
    this.clickActionNoArg = (System.Action) null;
  }

  public IEnumerator Init(
    InventoryExtraSkill invSkill,
    Dictionary<int, UnityEngine.Sprite> spriteCache,
    System.Action<InventoryExtraSkill> btnAct = null)
  {
    this.setActiveSkillGetInfo(false);
    this.removeObject.SetActive(false);
    this.skillObject.SetActive(true);
    this.invExtraSkill = invSkill;
    this.ClickAction = btnAct;
    this.clickActionNoArg = (System.Action) null;
    this.txtSkillLV.SetTextLocalize(Consts.Format(Consts.GetInstance().extra_skillI_thumb_skill_level_text, (IDictionary) new Hashtable()
    {
      {
        (object) "level",
        (object) this.invExtraSkill.level
      },
      {
        (object) "max",
        (object) this.invExtraSkill.GetMaxLevel()
      }
    }));
    BattleskillSkill masterData = this.invExtraSkill.skill.masterData;
    UnityEngine.Sprite sprite;
    if (spriteCache.TryGetValue(masterData.ID, out sprite))
    {
      this.dynExtraSkill.sprite2D = sprite;
    }
    else
    {
      Future<UnityEngine.Sprite> spriteF = masterData.LoadBattleSkillIcon();
      IEnumerator e = spriteF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.dynExtraSkill.sprite2D = spriteF.Result;
      spriteCache[masterData.ID] = spriteF.Result;
      spriteF = (Future<UnityEngine.Sprite>) null;
    }
  }

  public void InitByCache(
    InventoryExtraSkill invSkill,
    Dictionary<int, UnityEngine.Sprite> spriteCache,
    System.Action<InventoryExtraSkill> btnAct = null)
  {
    this.setActiveSkillGetInfo(false);
    this.removeObject.SetActive(false);
    this.skillObject.SetActive(true);
    this.invExtraSkill = invSkill;
    this.ClickAction = btnAct;
    this.clickActionNoArg = (System.Action) null;
    this.txtSkillLV.SetTextLocalize(Consts.Format(Consts.GetInstance().extra_skillI_thumb_skill_level_text, (IDictionary) new Hashtable()
    {
      {
        (object) "level",
        (object) this.invExtraSkill.level
      },
      {
        (object) "max",
        (object) this.invExtraSkill.GetMaxLevel()
      }
    }));
    this.dynExtraSkill.sprite2D = spriteCache[this.invExtraSkill.skill.masterData.ID];
  }

  public IEnumerator Init(
    int skillId,
    Dictionary<int, UnityEngine.Sprite> spriteCache,
    System.Action<int> btnAct = null)
  {
    this.setActiveSkillGetInfo(false);
    this.removeObject.SetActive(false);
    this.skillObject.SetActive(true);
    this.ClickAction = (System.Action<InventoryExtraSkill>) null;
    this.clickActionNoArg = btnAct != null ? (System.Action) (() => btnAct(skillId)) : (System.Action) null;
    this.txtSkillLV.SetTextLocalize(Consts.Format(Consts.GetInstance().extra_skillI_thumb_skill_level_text, (IDictionary) new Hashtable()
    {
      {
        (object) "level",
        (object) 1
      },
      {
        (object) "max",
        (object) 1
      }
    }));
    UnityEngine.Sprite result;
    BattleskillSkill battleskillSkill;
    if (!spriteCache.TryGetValue(skillId, out result) && MasterData.BattleskillSkill.TryGetValue(skillId, out battleskillSkill))
    {
      Future<UnityEngine.Sprite> loader = battleskillSkill.LoadBattleSkillIcon();
      IEnumerator e = loader.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      result = loader.Result;
      spriteCache.Add(skillId, result);
      loader = (Future<UnityEngine.Sprite>) null;
    }
    this.dynExtraSkill.sprite2D = result;
  }

  public Rect GetDrawRect()
  {
    float num1 = 0.0f;
    float num2 = 0.0f;
    float num3 = 0.0f;
    float num4 = 0.0f;
    bool flag = true;
    foreach (Transform child in this.skillObject.transform.GetChildren())
    {
      GameObject gameObject = child.gameObject;
      if (gameObject.activeSelf)
      {
        UIWidget component = gameObject.GetComponent<UIWidget>();
        if (!((UnityEngine.Object) component == (UnityEngine.Object) null) && component.enabled && (component is UI2DSprite || component is UISprite))
        {
          Vector2 localPosition = (Vector2) child.localPosition;
          Vector2 localScale = (Vector2) child.localScale;
          Vector2 pivotOffset = component.pivotOffset;
          float num5 = localPosition.x - pivotOffset.x * (float) component.width * localScale.x;
          float num6 = localPosition.y - pivotOffset.y * (float) component.height * localScale.y;
          float num7 = num5 + (float) component.width * localScale.x;
          float num8 = num6 + (float) component.height * localScale.y;
          if (flag)
          {
            flag = false;
            num1 = num5;
            num2 = num6;
            num3 = num7;
            num4 = num8;
          }
          else
          {
            if ((double) num1 > (double) num5)
              num1 = num5;
            if ((double) num2 > (double) num6)
              num2 = num6;
            if ((double) num3 < (double) num7)
              num3 = num7;
            if ((double) num4 < (double) num8)
              num4 = num8;
          }
        }
      }
    }
    float width = num3 - num1;
    float height = num4 - num2;
    return new Rect(num1 + width * 0.5f, num2 + height * 0.5f, width, height);
  }

  public void Deselect()
  {
    if ((UnityEngine.Object) this.selectedBack != (UnityEngine.Object) null)
      this.selectedBack.SetActive(false);
    if ((UnityEngine.Object) this.selectedCheck != (UnityEngine.Object) null)
      this.selectedCheck.SetActive(false);
    if ((UnityEngine.Object) this.selectedNum != (UnityEngine.Object) null)
      this.selectedNum.SetActive(false);
    if (!((UnityEngine.Object) this.slcSelected != (UnityEngine.Object) null))
      return;
    this.slcSelected.SetActive(false);
  }

  public void SelectByCheckIcon()
  {
    if ((UnityEngine.Object) this.selectedBack != (UnityEngine.Object) null)
      this.selectedBack.SetActive(true);
    if ((UnityEngine.Object) this.selectedCheck != (UnityEngine.Object) null)
      this.selectedCheck.SetActive(true);
    if ((UnityEngine.Object) this.selectedNum != (UnityEngine.Object) null)
      this.selectedNum.SetActive(false);
    if (!((UnityEngine.Object) this.slcSelected != (UnityEngine.Object) null))
      return;
    this.slcSelected.SetActive(false);
  }

  public void SelectByCheck2Icon()
  {
    if ((UnityEngine.Object) this.selectedBack != (UnityEngine.Object) null)
      this.selectedBack.SetActive(false);
    if ((UnityEngine.Object) this.selectedCheck != (UnityEngine.Object) null)
      this.selectedCheck.SetActive(false);
    if ((UnityEngine.Object) this.selectedNum != (UnityEngine.Object) null)
      this.selectedNum.SetActive(false);
    if (!((UnityEngine.Object) this.slcSelected != (UnityEngine.Object) null))
      return;
    this.slcSelected.SetActive(true);
  }

  public void Select(int selectCount)
  {
    if ((UnityEngine.Object) this.selectedBack != (UnityEngine.Object) null)
      this.selectedBack.SetActive(true);
    if ((UnityEngine.Object) this.selectedCheck != (UnityEngine.Object) null)
      this.selectedCheck.SetActive(false);
    if ((UnityEngine.Object) this.selectedNum != (UnityEngine.Object) null)
      this.selectedNum.SetActive(true);
    if ((UnityEngine.Object) this.slcSelected != (UnityEngine.Object) null)
      this.slcSelected.SetActive(false);
    UI2DSprite component = this.selectedNum.GetComponent<UI2DSprite>();
    component.SetDimensions((int) this.selectNumSprite[selectCount].textureRect.width, ExtraSkillIcon.SelectedIndexFontSize);
    component.sprite2D = this.selectNumSprite[selectCount];
  }

  public void onClick()
  {
    if (this.ClickAction != null)
      this.ClickAction(this.invExtraSkill);
    if (this.clickActionNoArg == null)
      return;
    this.clickActionNoArg();
  }

  public void setActiveSkillGetInfo(bool bEnable)
  {
    if (!((UnityEngine.Object) this.objSkillGetInfo != (UnityEngine.Object) null))
      return;
    this.objSkillGetInfo.SetActive(bEnable);
  }
}
