// Decompiled with JetBrains decompiler
// Type: EffectControllerGacha11
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class EffectControllerGacha11 : EffectControllerGacha
{
  protected List<Future<Sprite>> future_image_list;
  protected List<int> rarity_list;
  protected List<CommonRewardType> crt_list;
  protected int move_stone_count;
  protected int move_stone_color_change_count;
  protected List<GameObject> rarityStarObj;
  protected List<GameObject> tmp_star;
  public float wait_time;
  public GameObject change_effect;
  public GameObject tundere_effect;
  public List<Animator> ManaAnimatorList = new List<Animator>();
  public Animator started_camera;
  public int loop_sound_channnel = -1;
  [SerializeField]
  private List<StoneHolder> stone_holder_list;
  private float skip_wait;
  private bool canSkip;

  public List<StoneHolder> StoneHolderList
  {
    get => this.stone_holder_list;
    set => this.stone_holder_list = value;
  }

  private int[] GetStonePattern(int stoneCount)
  {
    switch (stoneCount)
    {
      case 2:
        return new int[2]{ 2, 8 };
      case 3:
        return new int[3]{ 0, 2, 8 };
      case 4:
        return new int[4]{ 1, 4, 6, 9 };
      case 5:
        return new int[5]{ 0, 2, 4, 6, 8 };
      case 6:
        return new int[6]{ 0, 2, 3, 5, 7, 8 };
      case 7:
        return new int[7]{ 0, 1, 3, 4, 6, 7, 9 };
      case 8:
        return new int[8]{ 1, 2, 3, 4, 6, 7, 8, 9 };
      case 9:
        return new int[9]{ 0, 1, 2, 3, 4, 6, 7, 8, 9 };
      case 10:
        return new int[10]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      default:
        Debug.LogWarning((object) "GetStonePattern　石の数がおかしい");
        return new int[10]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    }
  }

  private void UnUseStoneDisabled(GachaResultData.Result[] result_data)
  {
    List<StoneHolder> stoneHolderList = new List<StoneHolder>();
    List<Animator> animatorList = new List<Animator>();
    foreach (int index in this.GetStonePattern(result_data.Length))
    {
      stoneHolderList.Add(this.StoneHolderList[index]);
      animatorList.Add(this.ManaAnimatorList[index]);
    }
    this.StoneHolderList = stoneHolderList;
    this.ManaAnimatorList = animatorList;
  }

  [DebuggerHidden]
  protected override IEnumerator Renpatu(GachaResultData.Result[] result_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerGacha11.\u003CRenpatu\u003Ec__Iterator9CA()
    {
      result_data = result_data,
      \u003C\u0024\u003Eresult_data = result_data,
      \u003C\u003Ef__this = this
    };
  }

  public void SetStoneColor()
  {
    if (this.resultData != null)
      this.StoneHolderList.ForEachIndex<StoneHolder>((System.Action<StoneHolder, int>) ((x, n) =>
      {
        x.StoneChange(this.ConvertStringToStoneHolderID(this.resultData.patternGems[n].effect_gem_color_1st));
        x.SetChangeLight(this.resultData.patternGems[n].effect_brilliant);
      }));
    else
      this.StoneHolderList.ForEachIndex<StoneHolder>((System.Action<StoneHolder, int>) ((x, n) =>
      {
        x.StoneChange(this.ConvertStringToStoneHolderID("blue"));
        x.SetChangeLight(true);
      }));
    if (!Object.op_Inequality((Object) this.back_button_, (Object) null))
      return;
    this.back_button_.SetActive(true);
  }

  public void MoveManaStone()
  {
    if (this.resultData != null)
      this.ManaAnimatorList[this.move_stone_count].SetInteger("AnimationPattern", this.ConvertStringToAssaultType(this.resultData.patternGems[this.move_stone_count].effect_type));
    else
      this.ManaAnimatorList[this.move_stone_count].SetInteger("AnimationPattern", Random.Range(0, 3));
    ((Behaviour) this.ManaAnimatorList[this.move_stone_count]).enabled = true;
  }

  public void ImageOn(float keep_time)
  {
    this.move_stone_color_change_count = 1;
    this.skip_wait = 0.4f;
    this.tmp_star = (List<GameObject>) null;
    this.tmp_star = new List<GameObject>();
    if (this.crt_list != null)
    {
      CommonRewardType crt = this.crt_list[this.move_stone_count];
      PlayerUnit unit = crt.unit;
      PlayerItem gear = crt.gear;
      int num;
      int index1;
      if (unit != (PlayerUnit) null)
      {
        num = unit.unit.rarity.index;
        index1 = unit.unit.job.job_rank_UnitJobRank;
        if (unit.unit.IsMaterialUnit)
        {
          ((Renderer) this.common_rarity_anim_.image400_).material.mainTexture = (Texture) this.future_image_list[this.move_stone_count].Result.texture;
          ((Renderer) this.common_rarity_anim_.image400_blur_).material.mainTexture = (Texture) this.future_image_list[this.move_stone_count].Result.texture;
          ((Component) this.common_rarity_anim_.image_).gameObject.SetActive(false);
          ((Component) this.common_rarity_anim_.image400_).gameObject.SetActive(true);
        }
        else
        {
          ((Renderer) this.common_rarity_anim_.image_).material.mainTexture = (Texture) this.future_image_list[this.move_stone_count].Result.texture;
          ((Renderer) this.common_rarity_anim_.image_blur_).material.mainTexture = (Texture) this.future_image_list[this.move_stone_count].Result.texture;
          ((Component) this.common_rarity_anim_.image_).gameObject.SetActive(true);
          ((Component) this.common_rarity_anim_.image400_).gameObject.SetActive(false);
        }
      }
      else
      {
        num = gear.gear.rarity.index - 1;
        index1 = 2;
        ((Renderer) this.common_rarity_anim_.image_).material.mainTexture = (Texture) this.future_image_list[this.move_stone_count].Result.texture;
        ((Renderer) this.common_rarity_anim_.image_blur_).material.mainTexture = (Texture) this.future_image_list[this.move_stone_count].Result.texture;
        ((Component) this.common_rarity_anim_.image_).gameObject.SetActive(true);
      }
      this.sound_effect_.setResult(num);
      this.SetCommonRarity(this.common_rarity_anim_.rarity_obj_list_, num);
      this.new_eft_.SetActive(crt.is_new_);
      GameObject self = this.rarityStarObj[index1];
      for (int index2 = 0; index2 <= num; ++index2)
        this.tmp_star.Add(self.Clone(this.common_rarity_anim_.rarity_list[num].rarity_list[index2].transform));
      this.sound_effect_.setResult(this.rarity_list[this.move_stone_count]);
    }
    this.tanpatu_obj_.SetActive(true);
    ++this.move_stone_count;
    if (this.move_stone_count == this.ManaAnimatorList.Count)
    {
      this.animation_time = 0.0f;
      this.LoopSoundOff();
    }
    else
      this.StartCoroutine(this.ImageOff(keep_time));
  }

  [DebuggerHidden]
  public IEnumerator ImageOff(float keep_time)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerGacha11.\u003CImageOff\u003Ec__Iterator9CB()
    {
      keep_time = keep_time,
      \u003C\u0024\u003Ekeep_time = keep_time,
      \u003C\u003Ef__this = this
    };
  }

  public void TundereEffectOn(float keep_time)
  {
    this.tundere_effect.SetActive(true);
    this.StartCoroutine(this.TundereEffectOff(keep_time));
  }

  [DebuggerHidden]
  public IEnumerator TundereEffectOff(float keep_time)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerGacha11.\u003CTundereEffectOff\u003Ec__Iterator9CC()
    {
      keep_time = keep_time,
      \u003C\u0024\u003Ekeep_time = keep_time,
      \u003C\u003Ef__this = this
    };
  }

  public void ChangeEffectOn(float keep_time)
  {
    this.change_effect.SetActive(true);
    this.StartCoroutine(this.ChangeEffectOff(keep_time));
  }

  [DebuggerHidden]
  public IEnumerator ChangeEffectOff(float keep_time)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerGacha11.\u003CChangeEffectOff\u003Ec__Iterator9CD()
    {
      keep_time = keep_time,
      \u003C\u0024\u003Ekeep_time = keep_time,
      \u003C\u003Ef__this = this
    };
  }

  public void ChangeStoneColor(float keep_time)
  {
    string string_color_name = "blue";
    switch (this.move_stone_color_change_count)
    {
      case 0:
        string_color_name = this.resultData.patternGems[this.move_stone_count].effect_gem_color_1st;
        break;
      case 1:
        string_color_name = this.resultData.patternGems[this.move_stone_count].effect_gem_color_2nd;
        break;
      case 2:
        string_color_name = this.resultData.patternGems[this.move_stone_count].effect_gem_color_3rd;
        break;
      case 3:
        string_color_name = this.resultData.patternGems[this.move_stone_count].effect_gem_color_4th;
        break;
    }
    ++this.move_stone_color_change_count;
    this.stone_holder_list[this.move_stone_count].StoneChange(this.ConvertStringToStoneHolderID(string_color_name));
  }

  public void CameraAnimationOn(float keep_time)
  {
    this.started_camera.SetInteger("AnimationPattern", 2);
    this.StartCoroutine(this.CameraAnimationOff(keep_time));
  }

  [DebuggerHidden]
  public IEnumerator CameraAnimationOff(float keep_time)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerGacha11.\u003CCameraAnimationOff\u003Ec__Iterator9CE()
    {
      keep_time = keep_time,
      \u003C\u0024\u003Ekeep_time = keep_time,
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if ((double) this.skip_wait < 0.0)
      return;
    this.skip_wait -= 0.03f;
  }

  public void SkipOn() => this.canSkip = true;

  public void SkipOff() => this.canSkip = false;

  public void Skip()
  {
    if (!this.canSkip || (double) this.skip_wait > 0.0)
      return;
    if (this.tanpatu_obj_.activeSelf)
    {
      this.StopAllCoroutines();
      this.tundere_effect.SetActive(false);
      this.tundere_effect.transform.GetChild(0).GetChild(0).position = new Vector3(999f, 999f, 999f);
      this.change_effect.SetActive(false);
      this.new_eft_.GetComponent<Animator>().SetBool("end", true);
      this.started_camera.SetInteger("AnimationPattern", 1);
      if (this.tmp_star != null)
        this.tmp_star.ForEach((System.Action<GameObject>) (x => Object.Destroy((Object) x)));
      this.new_eft_.SetActive(false);
      this.tanpatu_obj_.SetActive(false);
      this.MoveManaStone();
    }
    else
      Time.timeScale = 100f;
  }

  public void SkipStop(float keep_time) => Time.timeScale = 1f;

  private StoneHolder.STONE_ID ConvertStringToStoneHolderID(string string_color_name)
  {
    StoneHolder.STONE_ID stoneHolderId = StoneHolder.STONE_ID.BLUE;
    string key = string_color_name;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (EffectControllerGacha11.\u003C\u003Ef__switch\u0024map23 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EffectControllerGacha11.\u003C\u003Ef__switch\u0024map23 = new Dictionary<string, int>(3)
        {
          {
            "blue",
            0
          },
          {
            "yellow",
            1
          },
          {
            "red",
            2
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (EffectControllerGacha11.\u003C\u003Ef__switch\u0024map23.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            stoneHolderId = StoneHolder.STONE_ID.BLUE;
            break;
          case 1:
            stoneHolderId = StoneHolder.STONE_ID.YELLOW;
            break;
          case 2:
            stoneHolderId = StoneHolder.STONE_ID.RED;
            break;
        }
      }
    }
    return stoneHolderId;
  }

  private int ConvertStringToAssaultType(string string_assault_type_name)
  {
    int assaultType = 0;
    string key = string_assault_type_name;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (EffectControllerGacha11.\u003C\u003Ef__switch\u0024map24 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EffectControllerGacha11.\u003C\u003Ef__switch\u0024map24 = new Dictionary<string, int>(3)
        {
          {
            "NORMAL",
            0
          },
          {
            "SINGLE",
            1
          },
          {
            "DOBULE",
            2
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (EffectControllerGacha11.\u003C\u003Ef__switch\u0024map24.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            assaultType = 0;
            break;
          case 1:
            assaultType = 1;
            break;
          case 2:
            assaultType = 2;
            break;
        }
      }
    }
    return assaultType;
  }

  public void LoopSoundOn()
  {
    if (Object.op_Equality((Object) Singleton<NGSoundManager>.GetInstanceOrNull(), (Object) null))
      return;
    this.loop_sound_channnel = Singleton<NGSoundManager>.GetInstance().PlaySe("SE_0520", channel: 520);
  }

  public void LoopSoundOff()
  {
    if (Object.op_Equality((Object) Singleton<NGSoundManager>.GetInstanceOrNull(), (Object) null) || this.loop_sound_channnel == -1)
      return;
    Singleton<NGSoundManager>.GetInstance().StopSe(this.loop_sound_channnel);
    this.loop_sound_channnel = -1;
  }

  public void OnPlayResult_5_1(float keep_time)
  {
    this.SkipStop(0.0f);
    this.TundereEffectOn(0.0f);
    this.ImageOn(2f);
    this.started_.GetComponent<GachaSEAfterUser>().OnPlayResult();
  }
}
