// Decompiled with JetBrains decompiler
// Type: EffectControllerGacha
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class EffectControllerGacha : EffectController
{
  [SerializeField]
  protected float acceleration_;
  [SerializeField]
  protected float animation_time = 9f;
  private EffectControllerGacha.STATE stateId;
  public float go_time_;
  protected bool button_up;
  protected bool button_down;
  protected float move_y;
  protected float elapsed_time_;
  protected int pattern;
  protected int se_0500;
  protected int se_0508;
  [SerializeField]
  protected Camera my_camera_;
  [SerializeField]
  protected Animator camera_;
  [SerializeField]
  protected Animator mana_;
  [SerializeField]
  protected List<Animator> stone_list_;
  [SerializeField]
  protected List<Animator> stone_change_list_;
  [SerializeField]
  protected GameObject back_ground_;
  [SerializeField]
  protected GameObject mana_pull_;
  [SerializeField]
  protected GameObject started_;
  [SerializeField]
  protected GameObject gacha_arrow_;
  [SerializeField]
  protected GameObject tanpatu_obj_;
  [SerializeField]
  protected GameObject new_eft_;
  [SerializeField]
  protected List<GetSumContainerList> renpatu_obj_;
  [SerializeField]
  protected List<AnimationItemIcon> renpatu_item_;
  [SerializeField]
  protected List<AnimationUnitIcon> renpatu_unit_;
  [SerializeField]
  protected GameObject high_effect_;
  [SerializeField]
  protected GameObject middle_effect_;
  [SerializeField]
  protected GameObject low_effect_;
  [SerializeField]
  protected CommonRarityAnim common_rarity_anim_;
  [SerializeField]
  protected GachaResultData.ResultData resultData;
  protected GameObject AnimationUnitIconPrefab;
  protected GameObject AnimationItemIconPrefab;
  public List<Sprite> imgList;
  public GachaSEAfterUser sound_effect_;
  [SerializeField]
  private float defaultSEVolume;
  [SerializeField]
  private float soundHiritu;

  [DebuggerHidden]
  public IEnumerator SetNeedData(GachaResultData.ResultData result_data, GameObject back_button)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerGacha.\u003CSetNeedData\u003Ec__Iterator9C4()
    {
      result_data = result_data,
      back_button = back_button,
      \u003C\u0024\u003Eresult_data = result_data,
      \u003C\u0024\u003Eback_button = back_button,
      \u003C\u003Ef__this = this
    };
  }

  protected void StartLoopSe()
  {
    this.se_0500 = Singleton<NGSoundManager>.GetInstance().playSE("SE_0500");
    Debug.Log((object) "kiseki sound");
  }

  public void EndSE() => this.sound_effect_.OnPlayResult();

  public int OnSE_0500()
  {
    int num = Singleton<NGSoundManager>.GetInstance().playSE("SE_0500");
    Debug.Log((object) "kiseki sound");
    return num;
  }

  public int OnSE_0508()
  {
    int num = Singleton<NGSoundManager>.GetInstance().playSE("SE_0508");
    Debug.Log((object) "loop sound");
    return num;
  }

  private void InitFlagAndValue()
  {
    this.stateId = EffectControllerGacha.STATE.MAX;
    this.isAnimation = true;
    this.back_ground_.SetActive(true);
    this.started_.SetActive(false);
    this.mana_pull_.SetActive(false);
    this.back_button_.SetActive(false);
    this.sound_effect_.result = false;
    this.se_0500 = -1;
    this.se_0508 = -1;
    this.soundHiritu = 60f;
    this.defaultSEVolume = Singleton<NGSoundManager>.GetInstance().volume.seVolume;
    Singleton<NGSoundManager>.GetInstance().SetVolumeSe(0.0f);
    this.acceleration_ = this.GetAcceralation();
  }

  private float GetAcceralation()
  {
    return !((Enum) (object) Application.platform).Equals((object) (RuntimePlatform) 2) ? 3.5f : (Screen.height >= 200 ? (Screen.height >= 500 ? 10f : 30f) : 50f);
  }

  [DebuggerHidden]
  private IEnumerator LoadFlashImage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerGacha.\u003CLoadFlashImage\u003Ec__Iterator9C5()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SetKisekiSeFadeOut()
  {
    Singleton<NGSoundManager>.GetInstance().volume.seVolume = this.defaultSEVolume;
    if (this.se_0500 == -1)
      return;
    Singleton<NGSoundManager>.GetInstance().fadeOutSE(this.se_0500);
  }

  private void StartAnimation()
  {
    this.mana_pull_.SetActive(true);
    this.AnimSet();
    if (this.se_0500 != -1)
      return;
    this.StartLoopSe();
  }

  [DebuggerHidden]
  private IEnumerator InitResultImage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerGacha.\u003CInitResultImage\u003Ec__Iterator9C6()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void AnimSet()
  {
    this.AnimSpeed(0.0f);
    this.mana_.Play("Mana_hipparu", 0, 0.0f);
    this.camera_.Play("camera_start", 0, 0.0f);
    this.stone_list_[this.pattern].Play("Play", 0, 0.0f);
    this.mana_.SetFloat("Progress", 0.0f);
    this.stateId = EffectControllerGacha.STATE.WAIT;
  }

  private void OnDoubleClick()
  {
  }

  private void OnPress(bool isDown)
  {
    if (isDown)
      this.button_down = true;
    else
      this.button_up = true;
  }

  private void OnDrag(Vector2 delta)
  {
    this.move_y = -delta.y * Time.deltaTime * this.acceleration_;
    Debug.Log((object) ("delta.y = " + (object) (float) -(double) delta.y));
  }

  private void Wait()
  {
    if (!this.button_down)
      return;
    this.stateId = EffectControllerGacha.STATE.INIT;
  }

  private void Init()
  {
    this.AnimSpeed(0.0f);
    Singleton<NGSoundManager>.GetInstance().volume.seVolume = 0.0f;
    this.stateId = EffectControllerGacha.STATE.ACTION;
  }

  private void EffectAction()
  {
    AnimatorStateInfo animatorStateInfo1 = this.mana_.GetCurrentAnimatorStateInfo(0);
    if (!((AnimatorStateInfo) ref animatorStateInfo1).IsName("end"))
    {
      AnimatorStateInfo animatorStateInfo2 = this.camera_.GetCurrentAnimatorStateInfo(0);
      if (!((AnimatorStateInfo) ref animatorStateInfo2).IsName("camera_start_loop"))
      {
        this.go_time_ += this.move_y;
        Singleton<NGSoundManager>.GetInstance().volume.seVolume = (double) this.go_time_ * ((double) this.defaultSEVolume / (double) this.soundHiritu) <= (double) this.defaultSEVolume ? this.go_time_ * (this.defaultSEVolume / this.soundHiritu) : this.defaultSEVolume;
        if ((double) this.go_time_ <= 0.0)
        {
          this.AnimSpeed(0.0f);
          this.go_time_ = 0.0f;
        }
        else
          this.AnimSpeed(this.move_y);
        if (this.button_up)
          this.stateId = EffectControllerGacha.STATE.REVERSE;
        this.move_y = 0.0f;
        return;
      }
    }
    if (this.se_0508 == -1)
      this.se_0508 = this.OnSE_0508();
    this.gacha_arrow_.SetActive(false);
    this.AnimSpeed(1f);
    if (!this.button_up)
      return;
    Singleton<NGSoundManager>.GetInstance().volume.seVolume = this.defaultSEVolume;
    this.stateId = EffectControllerGacha.STATE.END;
    if (this.se_0500 != -1)
      Singleton<NGSoundManager>.GetInstance().fadeOutSE(this.se_0500);
    if (this.se_0508 != -1)
      Singleton<NGSoundManager>.GetInstance().fadeOutSE(this.se_0508);
    this.StartCoroutine(this.bugFix());
    this.back_button_.SetActive(false);
  }

  private void Reverse()
  {
    this.go_time_ -= 2f;
    Singleton<NGSoundManager>.GetInstance().volume.seVolume = (double) this.go_time_ / (double) this.soundHiritu <= (double) this.defaultSEVolume ? this.go_time_ / this.soundHiritu : this.defaultSEVolume;
    AnimatorStateInfo animatorStateInfo = this.mana_.GetCurrentAnimatorStateInfo(0);
    if ((double) ((AnimatorStateInfo) ref animatorStateInfo).normalizedTime <= 0.0)
    {
      this.AnimSpeed(0.0f);
      this.go_time_ = 0.0f;
      this.mana_.Play("Mana_hipparu", 0, 0.0f);
      this.camera_.Play("camera_start", 0, 0.0f);
      this.stone_list_[this.pattern].Play("Play", 0, 0.0f);
      this.mana_.SetFloat("Progress", 0.0f);
      this.stateId = EffectControllerGacha.STATE.WAIT;
    }
    else
      this.AnimSpeed(-2f);
  }

  private void End()
  {
    this.elapsed_time_ += Time.deltaTime;
    if ((double) this.elapsed_time_ <= (double) this.animation_time)
      return;
    this.back_button_.SetActive(true);
    this.OnAnimationEnd();
  }

  private void AnimSpeed(float speed)
  {
    float num1 = Mathf.Abs(speed);
    float num2 = (double) speed >= 0.0 ? num1 : -num1;
    this.mana_.SetFloat("Speed", num2);
    this.camera_.SetFloat("Speed", num2);
    this.stone_list_[this.pattern].SetFloat("Speed", num2);
    this.mana_.SetFloat("Progress", this.mana_.GetFloat("Progress") + speed);
  }

  private void LateUpdate()
  {
    switch (this.stateId)
    {
      case EffectControllerGacha.STATE.SET:
        this.AnimSet();
        break;
      case EffectControllerGacha.STATE.INIT:
        this.Init();
        break;
      case EffectControllerGacha.STATE.WAIT:
        this.Wait();
        break;
      case EffectControllerGacha.STATE.ACTION:
        this.EffectAction();
        break;
      case EffectControllerGacha.STATE.END:
        this.End();
        break;
      case EffectControllerGacha.STATE.REVERSE:
        this.Reverse();
        break;
    }
    this.button_down = false;
    this.button_up = false;
  }

  [DebuggerHidden]
  private IEnumerator bugFix()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerGacha.\u003CbugFix\u003Ec__Iterator9C7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator Tanpatu(GachaResultData.Result result_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerGacha.\u003CTanpatu\u003Ec__Iterator9C8()
    {
      result_data = result_data,
      \u003C\u0024\u003Eresult_data = result_data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected virtual IEnumerator Renpatu(GachaResultData.Result[] result_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerGacha.\u003CRenpatu\u003Ec__Iterator9C9()
    {
      result_data = result_data,
      \u003C\u0024\u003Eresult_data = result_data,
      \u003C\u003Ef__this = this
    };
  }

  protected void SetUseStone()
  {
    int index = 0;
    int num1 = 0;
    List<GameObject> gameObjectList = new List<GameObject>();
    List<GameObject> list = this.stone_change_list_.Select<Animator, GameObject>((Func<Animator, GameObject>) (x => ((Component) x).gameObject)).ToList<GameObject>();
    if (this.resultData.patternID != null)
    {
      string key1 = this.resultData.patternID[0];
      int num2;
      if (key1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (EffectControllerGacha.\u003C\u003Ef__switch\u0024map1F == null)
        {
          // ISSUE: reference to a compiler-generated field
          EffectControllerGacha.\u003C\u003Ef__switch\u0024map1F = new Dictionary<string, int>(3)
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
        // ISSUE: reference to a compiler-generated field
        if (EffectControllerGacha.\u003C\u003Ef__switch\u0024map1F.TryGetValue(key1, out num2))
        {
          switch (num2)
          {
            case 0:
              index = 10;
              break;
            case 1:
              index = 20;
              break;
            case 2:
              index = 30;
              break;
          }
        }
      }
      string key2 = this.resultData.patternID[1];
      if (key2 != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (EffectControllerGacha.\u003C\u003Ef__switch\u0024map20 == null)
        {
          // ISSUE: reference to a compiler-generated field
          EffectControllerGacha.\u003C\u003Ef__switch\u0024map20 = new Dictionary<string, int>(3)
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
        // ISSUE: reference to a compiler-generated field
        if (EffectControllerGacha.\u003C\u003Ef__switch\u0024map20.TryGetValue(key2, out num2))
        {
          switch (num2)
          {
            case 0:
              ++index;
              break;
            case 1:
              index += 2;
              break;
            case 2:
              index += 3;
              break;
          }
        }
      }
      if (this.resultData.patternID.Length > 3)
      {
        string key3 = this.resultData.patternID[3];
        if (key3 != null)
        {
          // ISSUE: reference to a compiler-generated field
          if (EffectControllerGacha.\u003C\u003Ef__switch\u0024map21 == null)
          {
            // ISSUE: reference to a compiler-generated field
            EffectControllerGacha.\u003C\u003Ef__switch\u0024map21 = new Dictionary<string, int>(3)
            {
              {
                "LOW",
                0
              },
              {
                "MIDDLE",
                1
              },
              {
                "HIGH",
                2
              }
            };
          }
          // ISSUE: reference to a compiler-generated field
          if (EffectControllerGacha.\u003C\u003Ef__switch\u0024map21.TryGetValue(key3, out num2))
          {
            switch (num2)
            {
              case 0:
                num1 = 0;
                break;
              case 1:
                num1 = 1;
                break;
              case 2:
                num1 = 2;
                break;
            }
          }
        }
      }
    }
    switch (index)
    {
      case 0:
        index = 6;
        this.SetActiveList(list, 3);
        break;
      case 11:
        index = 0;
        this.SetActiveList(list, 0);
        break;
      case 12:
        index = 1;
        this.SetActiveList(list, 1);
        break;
      case 13:
        index = 2;
        this.SetActiveList(list, 2);
        break;
      case 22:
        index = 3;
        this.SetActiveList(list, 1);
        break;
      case 23:
        index = 4;
        this.SetActiveList(list, 2);
        break;
      case 33:
        index = 5;
        this.SetActiveList(list, 2);
        break;
    }
    ((Component) this.stone_list_[index]).gameObject.SetActive(true);
    this.pattern = index;
    switch (num1)
    {
      case 0:
        this.low_effect_.SetActive(true);
        this.sound_effect_.setTundere(0);
        break;
      case 1:
        this.middle_effect_.SetActive(true);
        this.sound_effect_.setTundere(1);
        break;
      case 2:
        this.high_effect_.SetActive(true);
        this.sound_effect_.setTundere(2);
        break;
    }
  }

  protected void StoneChange()
  {
    int num1 = 0;
    if (this.resultData == null)
      return;
    if (this.resultData.patternID != null)
    {
      string key = this.resultData.patternID[2];
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (EffectControllerGacha.\u003C\u003Ef__switch\u0024map22 == null)
        {
          // ISSUE: reference to a compiler-generated field
          EffectControllerGacha.\u003C\u003Ef__switch\u0024map22 = new Dictionary<string, int>(3)
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
        int num2;
        // ISSUE: reference to a compiler-generated field
        if (EffectControllerGacha.\u003C\u003Ef__switch\u0024map22.TryGetValue(key, out num2))
        {
          switch (num2)
          {
            case 0:
              num1 = 1;
              break;
            case 1:
              num1 = 2;
              break;
            case 2:
              num1 = 3;
              break;
          }
        }
      }
    }
    List<GameObject> gameObjectList = new List<GameObject>();
    List<GameObject> list = this.stone_change_list_.Select<Animator, GameObject>((Func<Animator, GameObject>) (x => ((Component) x).gameObject)).ToList<GameObject>();
    switch (num1)
    {
      case 0:
        this.SetActiveList(list, 3);
        break;
      case 1:
        this.SetActiveList(list, 0);
        break;
      case 2:
        this.SetActiveList(list, 1);
        break;
      case 3:
        this.SetActiveList(list, 2);
        break;
    }
  }

  private enum STATE
  {
    SET,
    INIT,
    WAIT,
    ACTION,
    END,
    START,
    REVERSE,
    MAX,
  }
}
