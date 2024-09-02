// Decompiled with JetBrains decompiler
// Type: EffectControllerGachaDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControllerGachaDetail : MonoBehaviour
{
  [SerializeField]
  public UI2DSprite mainImageUnit;
  [SerializeField]
  public UI2DSprite mainImageGear;
  [SerializeField]
  public SpriteRenderer subImage;
  [SerializeField]
  public UILabel mainName;
  [SerializeField]
  public UILabel subName;
  [SerializeField]
  public UILabel englishNamePickUp;
  [SerializeField]
  public UILabel englishNameDetail;
  [SerializeField]
  public SpriteRenderer flavorText;
  [SerializeField]
  public GameObject newArrivals;
  [SerializeField]
  public List<GameObject> pickUp;
  [SerializeField]
  public List<GameObject> normal;
  [SerializeField]
  public List<UISprite> rarityStars;
  [SerializeField]
  public Animator animator;
  [SerializeField]
  public GameObject fullScreenEffect;
  private bool is_temporary = GachaResultData.GetInstance().GetData().is_retry;

  public EffectControllerGachaDetail.IGachaDetail Current { get; private set; }

  public EffectControllerGacha Controller { private get; set; }

  public void FinishAnimation() => this.Controller.FinishDetailAnimation();

  public void SetActive(bool active)
  {
    this.gameObject.SetActive(active);
    this.fullScreenEffect.SetActive(active);
    if (!active)
      return;
    this.animator.Play(this.Current.AnimationName, 0, 0.0f);
  }

  public void SetAniamationEnabled(bool enabled)
  {
    this.animator.speed = enabled ? 1f : 0.0f;
    this.animator.enabled = this.enabled;
  }

  public GachaResultData.Result ResultData
  {
    set
    {
      int id = this.is_temporary ? value.reward_id : value.reward_result_id;
      CommonRewardType reward = new CommonRewardType(value.reward_type_id, id, value.reward_result_quantity, value.is_new, value.is_reserves, this.is_temporary);
      if (reward.isUnit)
        this.Current = (EffectControllerGachaDetail.IGachaDetail) new EffectControllerGachaDetail.GachaDetailUnit(this, reward, value.directionType);
      else if (reward.isMaterialUnit)
        this.Current = (EffectControllerGachaDetail.IGachaDetail) new EffectControllerGachaDetail.GachaDetailMaterialUnit(this, reward, value.directionType);
      else
        this.Current = (EffectControllerGachaDetail.IGachaDetail) new EffectControllerGachaDetail.GachaDetailOther(this, reward, value.directionType);
    }
  }

  public IEnumerator CreateResult(bool isPreview)
  {
    this.Current.isPreview = isPreview;
    return this.Current.SetGameObject();
  }

  public void PlaySoundForPickUp()
  {
    Singleton<NGSoundManager>.GetInstance().stopSE();
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0573");
    Singleton<NGSoundManager>.GetInstance().stopVoice();
    if (this.Current.VoicePattern == null)
      return;
    Singleton<NGSoundManager>.GetInstance().playVoiceByID(this.Current.VoicePattern, 400);
  }

  private void PlaySoundForDetail()
  {
    Singleton<NGSoundManager>.GetInstance().stopSE();
    Singleton<NGSoundManager>.GetInstance().playSE(this.Current.SEName);
  }

  public interface IGachaDetail
  {
    bool IsLoaded { get; }

    bool IsPickUp { get; }

    bool IsPickUpAnimation { get; }

    string AnimationName { get; }

    string VoiceName { get; }

    UnitVoicePattern VoicePattern { get; }

    string SEName { get; }

    IEnumerator SetGameObject();

    bool isPreview { get; set; }
  }

  public class GachaDetailOther : EffectControllerGachaDetail.IGachaDetail
  {
    protected EffectControllerGachaDetail detail;
    protected CommonRewardType reward;
    protected GachaDirectionType type;

    public bool IsLoaded { get; protected set; }

    public virtual bool IsPickUp => this.type == GachaDirectionType.pickup;

    public virtual bool IsPickUpAnimation => false;

    protected virtual void SetMainImage(UnityEngine.Sprite sprite)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.detail.mainImageUnit.sprite2D);
      UnityEngine.Object.Destroy((UnityEngine.Object) this.detail.mainImageGear.sprite2D);
      this.detail.mainImageUnit.sprite2D = (UnityEngine.Sprite) null;
      this.detail.mainImageGear.sprite2D = sprite;
      this.detail.mainImageGear.width = sprite.texture.width;
      this.detail.mainImageGear.height = sprite.texture.height;
      this.detail.mainImageUnit.gameObject.SetActive(false);
      this.detail.mainImageGear.gameObject.SetActive(true);
    }

    protected void SetSubImage(UnityEngine.Sprite sprite) => this.detail.subImage.sprite = sprite;

    protected void SetMainName(string text) => this.detail.mainName.text = text;

    protected void SetSubName(string text)
    {
      if (string.IsNullOrEmpty(text))
      {
        this.detail.subName.transform.parent.gameObject.SetActive(false);
      }
      else
      {
        this.detail.subName.text = text;
        this.detail.subName.transform.parent.gameObject.SetActive(true);
      }
    }

    protected void SetEnglishNamePickUp(string text) => this.detail.englishNamePickUp.text = text;

    protected void SetEnglishNameDetail(string text) => this.detail.englishNameDetail.text = text;

    protected void SetFlavorText(UnityEngine.Sprite sprite)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.detail.flavorText.sprite);
      this.detail.flavorText.sprite = sprite;
    }

    protected void SetNewArrivals(bool active) => this.detail.newArrivals.SetActive(active);

    protected void SetPickUp(bool actice)
    {
      this.detail.pickUp.ForEach((System.Action<GameObject>) (x => x.SetActive(actice)));
      this.detail.normal.ForEach((System.Action<GameObject>) (x => x.SetActive(!actice)));
    }

    protected string GetJobRankSpriteName() => "slc_rarity_star";

    protected void SetRatiry(int rarity) => this.detail.rarityStars.ForEachIndex<UISprite>((System.Action<UISprite, int>) ((obj, index) =>
    {
      obj.gameObject.SetActive(index <= rarity);
      obj.spriteName = this.GetJobRankSpriteName();
    }));

    protected void SetRaritySound(int rarity)
    {
      switch (rarity)
      {
        case 0:
          this.SEName = "SE_0502";
          break;
        case 1:
          this.SEName = "SE_0503";
          break;
        case 2:
          this.SEName = "SE_0504";
          break;
        case 3:
          this.SEName = "SE_0505";
          break;
        default:
          this.SEName = "SE_0506";
          break;
      }
    }

    public virtual string AnimationName => "gacha_unit_spawn_other";

    public string SEName { get; private set; }

    public virtual string VoiceName => (string) null;

    public virtual UnitVoicePattern VoicePattern => (UnitVoicePattern) null;

    public bool isPreview { get; set; }

    public GachaDetailOther(
      EffectControllerGachaDetail detail,
      CommonRewardType reward,
      GachaDirectionType type)
    {
      this.detail = detail;
      this.reward = reward;
      this.type = type;
    }

    public virtual IEnumerator SetGameObject()
    {
      GearGear reward = (GearGear) null;
      reward = this.reward.isGear || this.reward.isSupply ? this.reward.gear.gear : this.reward.materialGear.gear;
      yield return (object) null;
      this.SetSubImage((UnityEngine.Sprite) null);
      yield return (object) null;
      this.SetMainName(reward.name);
      this.SetSubName((string) null);
      this.SetEnglishNamePickUp((string) null);
      this.SetEnglishNameDetail((string) null);
      yield return (object) null;
      this.SetFlavorText((UnityEngine.Sprite) null);
      yield return (object) null;
      this.SetNewArrivals(this.reward.is_new_);
      yield return (object) null;
      this.SetPickUp(this.IsPickUp);
      yield return (object) null;
      this.SetRatiry(reward.rarity.index - 1);
      yield return (object) null;
      this.SetRaritySound(reward.rarity.index - 1);
      yield return (object) null;
      Future<UnityEngine.Sprite> future = reward.LoadSpriteBasic(100f);
      IEnumerator e = future.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.SetMainImage(future.Result);
      yield return (object) null;
      this.IsLoaded = true;
    }
  }

  public class GachaDetailMaterialUnit : EffectControllerGachaDetail.GachaDetailOther
  {
    public GachaDetailMaterialUnit(
      EffectControllerGachaDetail detail,
      CommonRewardType reward,
      GachaDirectionType type)
      : base(detail, reward, type)
    {
    }

    private string GetSpriteName(UnitUnit unit)
    {
      string str = string.Empty;
      switch (unit.rarity.index + 1)
      {
        case 1:
        case 2:
        case 3:
        case 4:
          str = "slc_rarity_star_silver";
          break;
        case 5:
          str = "slc_rarity_star";
          break;
        case 6:
          str = "slc_rarity_star_pink";
          break;
        default:
          Debug.LogError((object) ("想定していないレアリティのため、レアリティ画像名を取得できません: " + (object) unit.rarity.index + (object) 1));
          break;
      }
      return str;
    }

    protected void SetRatiryStar(UnitUnit unit) => this.detail.rarityStars.ForEachIndex<UISprite>((System.Action<UISprite, int>) ((obj, index) =>
    {
      obj.gameObject.SetActive(index <= unit.rarity.index);
      obj.spriteName = this.GetSpriteName(unit);
    }));

    public override IEnumerator SetGameObject()
    {
      EffectControllerGachaDetail.GachaDetailMaterialUnit detailMaterialUnit = this;
      UnitUnit reward = detailMaterialUnit.reward.materialUnit.unit;
      yield return (object) null;
      detailMaterialUnit.SetSubImage((UnityEngine.Sprite) null);
      yield return (object) null;
      detailMaterialUnit.SetMainName(reward.name);
      detailMaterialUnit.SetSubName((string) null);
      detailMaterialUnit.SetEnglishNamePickUp(reward.english_name);
      detailMaterialUnit.SetEnglishNameDetail(reward.english_name);
      yield return (object) null;
      detailMaterialUnit.SetFlavorText((UnityEngine.Sprite) null);
      yield return (object) null;
      detailMaterialUnit.SetNewArrivals(detailMaterialUnit.reward.is_new_);
      yield return (object) null;
      detailMaterialUnit.SetPickUp(detailMaterialUnit.IsPickUp);
      yield return (object) null;
      detailMaterialUnit.SetRatiryStar(reward);
      yield return (object) null;
      detailMaterialUnit.SetRaritySound(reward.rarity.index);
      yield return (object) null;
      Future<UnityEngine.Sprite> future = reward.LoadSpriteMedium(100f);
      IEnumerator e = future.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      detailMaterialUnit.SetMainImage(future.Result);
      yield return (object) null;
      detailMaterialUnit.IsLoaded = true;
    }
  }

  public class GachaDetailUnit : EffectControllerGachaDetail.GachaDetailMaterialUnit
  {
    public override bool IsPickUpAnimation => this.IsPickUp && this.reward.is_new_;

    protected override void SetMainImage(UnityEngine.Sprite sprite)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.detail.mainImageUnit.sprite2D);
      UnityEngine.Object.Destroy((UnityEngine.Object) this.detail.mainImageGear.sprite2D);
      this.detail.mainImageUnit.sprite2D = sprite;
      this.detail.mainImageUnit.width = sprite.texture.width;
      this.detail.mainImageUnit.height = sprite.texture.height;
      this.detail.mainImageGear.sprite2D = (UnityEngine.Sprite) null;
      this.detail.mainImageUnit.gameObject.SetActive(true);
      this.detail.mainImageGear.gameObject.SetActive(false);
    }

    public override string AnimationName
    {
      get
      {
        if (this.IsPickUpAnimation)
          return "gacha_unit_pickup";
        return this.IsPickUp ? "gacha_unit_spawn_pickup" : "gacha_unit_spawn_normal";
      }
    }

    public override string VoiceName => this.reward.unit.unit.unitVoicePattern.file_name;

    public override UnitVoicePattern VoicePattern => this.reward.unit.unit.unitVoicePattern;

    public GachaDetailUnit(
      EffectControllerGachaDetail detail,
      CommonRewardType reward,
      GachaDirectionType type)
      : base(detail, reward, type)
    {
    }

    public override IEnumerator SetGameObject()
    {
      EffectControllerGachaDetail.GachaDetailUnit gachaDetailUnit = this;
      UnitUnit reward = gachaDetailUnit.reward.unit.unit;
      yield return (object) null;
      gachaDetailUnit.SetMainName(reward.name);
      gachaDetailUnit.SetSubName(reward.SecondaryName);
      gachaDetailUnit.SetEnglishNamePickUp(reward.english_name);
      gachaDetailUnit.SetEnglishNameDetail(reward.english_name);
      yield return (object) null;
      gachaDetailUnit.SetNewArrivals(gachaDetailUnit.reward.is_new_);
      yield return (object) null;
      gachaDetailUnit.SetPickUp(gachaDetailUnit.IsPickUp);
      yield return (object) null;
      gachaDetailUnit.SetRatiryStar(reward);
      yield return (object) null;
      gachaDetailUnit.SetRaritySound(reward.rarity.index);
      yield return (object) null;
      Future<UnityEngine.Sprite> future = reward.LoadFullSprite();
      IEnumerator e = future.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      gachaDetailUnit.SetMainImage(future.Result);
      yield return (object) null;
      if (gachaDetailUnit.IsPickUpAnimation)
      {
        future = reward.LoadSpriteEventImage(100f);
        e = future.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        gachaDetailUnit.SetSubImage(future.Result);
      }
      else
        gachaDetailUnit.SetSubImage((UnityEngine.Sprite) null);
      yield return (object) null;
      if (gachaDetailUnit.IsPickUpAnimation)
      {
        future = reward.LoadSpriteFlavorText(100f);
        e = future.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        gachaDetailUnit.SetFlavorText(future.Result);
      }
      else
        gachaDetailUnit.SetFlavorText((UnityEngine.Sprite) null);
      yield return (object) null;
      gachaDetailUnit.IsLoaded = true;
      // ISSUE: explicit non-virtual call
      if (__nonvirtual (gachaDetailUnit.isPreview))
        Singleton<CommonRoot>.GetInstance().isLoading = false;
    }
  }
}
