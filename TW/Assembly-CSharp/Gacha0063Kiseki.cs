// Decompiled with JetBrains decompiler
// Type: Gacha0063Kiseki
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Gacha0063Kiseki : Gacha0063hindicator
{
  [SerializeField]
  private GameObject dyn_Chara;
  [SerializeField]
  private GameObject dyn_CharaShadow;
  [SerializeField]
  private GameObject dyn_mask;
  [SerializeField]
  private GameObject dyn_mask_CharaShadow;
  [SerializeField]
  private UI2DSprite dyn_Star;
  [SerializeField]
  private BattleSkillIcon dyn_Unit_Skill;
  [SerializeField]
  private GearKindIcon dyn_Weapon;
  [SerializeField]
  private UILabel txt_Title;
  [SerializeField]
  private UILabel txt_Skillexplanation;
  [SerializeField]
  private UILabel txt_leaderskill_description;
  [SerializeField]
  private UILabel txt_LeaderSkillname;
  [SerializeField]
  private UILabel txt_JobName;
  [SerializeField]
  private Transform modelLocator;
  [SerializeField]
  private Animator animator_;
  [SerializeField]
  private BoxCollider buyKisekiButton;
  [SerializeField]
  private UI2DSprite ui3DModel2D;
  [SerializeField]
  private GameObject slc_Kiseki_Bonus;
  [SerializeField]
  private GameObject slc_Kiseki_BonusEx;
  private Modified<CoinBonus[]> coinBonus;
  [SerializeField]
  private GameObject singleGachaMode;
  [SerializeField]
  private GameObject multiGachaMode;
  [SerializeField]
  private UI2DSprite TitleImg;
  [SerializeField]
  private UISprite TitleImgBase;
  [SerializeField]
  private UI2DSprite kakuteiImg;
  [SerializeField]
  private UI2DSprite kakuteiImgEx;
  [SerializeField]
  private MeshRenderer kakuteiEffect;
  [SerializeField]
  private UI2DSprite TopImg;
  [SerializeField]
  private GameObject NoneTopImgObj;
  [SerializeField]
  private UIWidget charactersWidget;
  [SerializeField]
  private Gacha0063KisekiExtention kisekiEx;
  private UI3DModel ui3DModel;
  private int pickupUnitIdNumber;
  private List<int> pickupUnitIdList;
  private List<GameObject> imagePrefabList;
  private List<Sprite> pickupImageList;
  private List<GameObject> modelPrefabList;
  private List<Sprite> spriteList;
  private bool gachaExFlag;
  private bool gachaIntroduction;
  private DateTime? serverTime;
  private bool CreateCharacterImageEnd;
  private bool CreateSimpleCharacter3DImageEnd;
  private bool CreateSkillImageEnd;

  private void Start()
  {
    this.coinBonus = SMManager.Observe<CoinBonus[]>();
    this.coinBonus.NotifyChanged();
  }

  public override void PlayAnim()
  {
    ((Behaviour) ((Component) this.kakuteiEffect).GetComponent<Animator>()).enabled = true;
    ((Component) this.kakuteiEffect).gameObject.SetActive(true);
  }

  public override void EndAnim()
  {
    ((Behaviour) ((Component) this.kakuteiEffect).GetComponent<Animator>()).enabled = false;
    ((Component) this.kakuteiEffect).gameObject.SetActive(false);
  }

  public override void InitGachaModuleGacha(
    Gacha0063Menu gacha0063Menu,
    GachaModule gachaModule,
    DateTime serverTime,
    UIScrollView scrollView)
  {
    this.GachaModule = gachaModule;
    this.Menu = gacha0063Menu;
    this.serverTime = new DateTime?(serverTime);
    if (gachaModule.type == 1)
    {
      if (gachaModule.gacha.Length > 1)
      {
        this.multiGachaMode.SetActive(true);
        this.singleGachaMode.SetActive(false);
        ((IEnumerable<GachaModuleGacha>) gachaModule.gacha).ForEachIndex<GachaModuleGacha>((Action<GachaModuleGacha, int>) ((x, n) => this.gachaButton[n].Init(gachaModule.name, x, this.Menu, gachaModule.type)));
      }
      else
      {
        this.singleGachaMode.SetActive(true);
        this.multiGachaMode.SetActive(false);
        this.singleGachaButton.Init(gachaModule.name, gachaModule.gacha[0], this.Menu, gachaModule.type);
      }
      this.gachaExFlag = false;
    }
    else
    {
      if (gachaModule.gacha.Length > 1)
      {
        this.multiGachaMode.SetActive(true);
        this.singleGachaMode.SetActive(false);
        ((IEnumerable<GachaModuleGacha>) gachaModule.gacha).ForEachIndex<GachaModuleGacha>((Action<GachaModuleGacha, int>) ((x, n) => this.gachaButton[n].Init(gachaModule.name, x, this.Menu, gachaModule.type)));
        this.gachaExFlag = false;
      }
      else
      {
        this.singleGachaButtonEx.Init(gachaModule.name, gachaModule.gacha[0], this.Menu, gachaModule.type);
        this.singleGachaButtonEx.ChangeButtonEvent(this.GachaModule);
        this.kisekiEx.SetKisekiEx(gachaModule, this.Menu);
        this.gachaExFlag = true;
      }
      if (gachaModule.type != 6)
        ;
    }
    if (!this.GachaModule.period.display_count_down)
      return;
    this.kisekiEx.SetTimiLimit(this.GachaModule);
  }

  private void Init() => this.pickupUnitIdNumber = -1;

  [DebuggerHidden]
  public override IEnumerator Set(GameObject detailPopup)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Kiseki.\u003CSet\u003Ec__Iterator438()
    {
      detailPopup = detailPopup,
      \u003C\u0024\u003EdetailPopup = detailPopup,
      \u003C\u003Ef__this = this
    };
  }

  private void CreatePickupUnitIdList()
  {
    this.pickupUnitIdList = (List<int>) null;
    this.pickupUnitIdList = new List<int>();
    foreach (GachaModuleNewentity gachaModuleNewentity in this.GachaModule.newentity)
    {
      if (gachaModuleNewentity.reward_type_id == 1 || gachaModuleNewentity.reward_type_id == 24)
        this.pickupUnitIdList.Add(gachaModuleNewentity.reward_id);
    }
  }

  [DebuggerHidden]
  private IEnumerator CreateCharacterImage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Kiseki.\u003CCreateCharacterImage\u003Ec__Iterator439()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateSkillImage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Kiseki.\u003CCreateSkillImage\u003Ec__Iterator43A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateSimpleCharacter3DImage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Kiseki.\u003CCreateSimpleCharacter3DImage\u003Ec__Iterator43B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateCharacterModel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Kiseki.\u003CCreateCharacterModel\u003Ec__Iterator43C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CashClean()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Gacha0063Kiseki.\u003CCashClean\u003Ec__Iterator43D cleanCIterator43D = new Gacha0063Kiseki.\u003CCashClean\u003Ec__Iterator43D();
    return (IEnumerator) cleanCIterator43D;
  }

  public override void IbtnBuyKiseki()
  {
    base.IbtnBuyKiseki();
    this.Menu.IbtnBuyKiseki();
    this.StartCoroutine(PopupUtility.BuyKiseki());
  }

  public void ChangeCharacter(int flag)
  {
    if (this.pickupUnitIdNumber >= this.pickupUnitIdList.Count)
    {
      this.pickupUnitIdNumber = 0;
      if (this.gachaIntroduction)
      {
        this.ChangeTopImg();
        return;
      }
    }
    this.NoneTopImgObj.SetActive(true);
    ((Component) this.TopImg).gameObject.SetActive(false);
    this.ChangeCharacterImage(this.pickupUnitIdNumber);
    this.ChangeSimpleCharacter3DImage(this.pickupUnitIdNumber);
    this.SetStatus(this.pickupUnitIdList[this.pickupUnitIdNumber]);
    this.ChangeSkillIcon(this.pickupUnitIdNumber);
    if (flag == 1)
      this.animator_.Play("Fade", 0, 0.0f);
    ++this.pickupUnitIdNumber;
  }

  public void ChangeTopImg()
  {
    this.NoneTopImgObj.SetActive(false);
    ((Component) this.TopImg).gameObject.SetActive(true);
    this.imagePrefabList.ForEach((Action<GameObject>) (x => x.SetActive(false)));
    this.animator_.Play("FadeTopImg", 0, 0.0f);
  }

  private void ChangeCharacterImage(int id)
  {
    this.imagePrefabList.ForEachIndex<GameObject>((Action<GameObject, int>) ((x, n) => x.SetActive(n == id)));
  }

  private void ChangeSimpleCharacter3DImage(int id)
  {
    this.pickupImageList.ForEachIndex<Sprite>((Action<Sprite, int>) ((x, n) =>
    {
      if (n != id)
        return;
      this.ui3DModel2D.sprite2D = x;
    }));
  }

  [DebuggerHidden]
  private IEnumerator CreateModel(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Kiseki.\u003CCreateModel\u003Ec__Iterator43E()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  private void ChangeCharacterModel(int id)
  {
    this.ui3DModel.ModelTarget.localEulerAngles = new Vector3(0.0f, -45f, 0.0f);
    this.modelPrefabList.ForEachIndex<GameObject>((Action<GameObject, int>) ((x, n) => x.SetActive(n == id)));
  }

  private void ChangeSkillIcon(int id)
  {
    if (this.spriteList.Count<Sprite>() <= id)
      return;
    this.dyn_Unit_Skill.Init(this.spriteList[id]);
    this.dyn_Unit_Skill.iconSprite.SetDimensions(this.dyn_Unit_Skill.iconSprite.mainTexture.width != 60 ? 64 : 60, this.dyn_Unit_Skill.iconSprite.mainTexture.height != 62 ? 58 : 62);
  }

  private void SetStatus(int unitId)
  {
    UnitUnit unit = MasterData.UnitUnit[unitId];
    RarityIcon.SetRarity(unit, this.dyn_Star, true);
    this.txt_Title.SetTextLocalize(unit.name);
    this.dyn_Weapon.Init(unit.kind, unit.GetElement());
    this.txt_JobName.SetTextLocalize(unit.job.name.ToConverter());
    BattleskillSkill pickupSkill = unit.PickupSkill;
    if (pickupSkill != null)
      this.txt_Skillexplanation.SetTextLocalize(pickupSkill.description.ToConverter());
    else
      this.txt_Skillexplanation.text = string.Empty;
    BattleskillSkill rememberLeaderSkill = unit.RememberLeaderSkill;
    if (rememberLeaderSkill != null)
    {
      this.txt_LeaderSkillname.SetTextLocalize(rememberLeaderSkill.name.ToConverter());
      this.txt_leaderskill_description.SetTextLocalize(rememberLeaderSkill.description.ToConverter());
    }
    else
    {
      this.txt_LeaderSkillname.text = string.Empty;
      this.txt_leaderskill_description.text = string.Empty;
    }
  }

  private void LateUpdate()
  {
    if (this.coinBonus != null && this.coinBonus.IsChangedOnce())
    {
      if (this.gachaExFlag)
        this.slc_Kiseki_BonusEx.SetActive(this.coinBonus.Value.Length > 0);
      else
        this.slc_Kiseki_Bonus.SetActive(this.coinBonus.Value.Length > 0);
    }
    if (this.serverTime.HasValue && this.GachaModule.period.end_at.HasValue)
      this.serverTime = new DateTime?(ServerTime.NowAppTimeAddDelta());
    if (!this.GachaModule.period.display_count_down)
      return;
    this.kisekiEx.UpdateLimitTime(this.GachaModule, this.serverTime.Value);
  }
}
