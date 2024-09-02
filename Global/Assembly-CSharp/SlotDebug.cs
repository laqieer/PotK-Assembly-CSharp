// Decompiled with JetBrains decompiler
// Type: SlotDebug
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class SlotDebug : MonoBehaviour
{
  private const int lilleTextureNum = 7;
  private const int lilleLookingIndex = 6;
  private NGSoundManager SM;
  public bool isReady;
  public bool isEnd;
  public bool isSkip;
  private Animator animator;
  [SerializeField]
  private GameObject lille_1;
  [SerializeField]
  private GameObject lille_2;
  [SerializeField]
  private GameObject lille_3;
  [SerializeField]
  private GameObject prize_1;
  [SerializeField]
  private GameObject prize_2;
  [SerializeField]
  private GameObject prize_3;
  [SerializeField]
  private GameObject slotMain;
  [SerializeField]
  private GameObject rarity1;
  [SerializeField]
  private GameObject rarity2;
  [SerializeField]
  private GameObject rarity3;
  [SerializeField]
  private GameObject rarity4;
  [SerializeField]
  private GameObject rarity5;
  [SerializeField]
  private GameObject rarity6;
  [SerializeField]
  private GameObject cutin;
  [SerializeField]
  private List<string> ReelTextureNames;
  private Shop00720EffectController main_script;
  private EffectSE effect_se_script;
  public int state_index;
  private string lilleTexturePath = "AssetBundle/Resources/Animations/slot/Texture/lilleImages/";
  private List<Texture2D> textures = new List<Texture2D>();
  private SpriteRenderer spriteRenderer_p1;
  private SpriteRenderer spriteRenderer_p2;
  private SpriteRenderer spriteRenderer_p3;
  private Sprite sprite_p1;
  private Sprite sprite_p2;
  private Sprite sprite_p3;
  [SerializeField]
  private GameObject lamp_blue;
  [SerializeField]
  private GameObject lamp_lightblue;
  [SerializeField]
  private GameObject lamp_red;
  [SerializeField]
  private ParticleSystem ps_light_lightblue;
  [SerializeField]
  private ParticleSystem ps_light_red;
  [SerializeField]
  private ParticleSystem ps_lightblue_1;
  [SerializeField]
  private ParticleSystem ps_lightblue_2;
  [SerializeField]
  private ParticleSystem ps_lightblue_3;
  [SerializeField]
  private ParticleSystem ps_lightblue_4;
  [SerializeField]
  private ParticleSystem ps_red_1;
  [SerializeField]
  private ParticleSystem ps_red_2;
  [SerializeField]
  private ParticleSystem ps_red_3;
  [SerializeField]
  private ParticleSystem ps_red_4;

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new SlotDebug.\u003CInit\u003Ec__Iterator3DB()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator GetTexture(string filename)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new SlotDebug.\u003CGetTexture\u003Ec__Iterator3DC()
    {
      filename = filename,
      \u003C\u0024\u003Efilename = filename,
      \u003C\u003Ef__this = this
    };
  }

  private void LilleResultTextureChange()
  {
    this.SetTextureByName(this.main_script.textureNameList_1[this.main_script.stopTextureId_1 - 1], this.lille_1, 6);
    this.SetTextureByName(this.main_script.textureNameList_2[this.main_script.stopTextureId_2 - 1], this.lille_2, 6);
    this.SetTextureByName(this.main_script.textureNameList_3[this.main_script.stopTextureId_3 - 1], this.lille_3, 6);
    this.sprite_p1 = Sprite.Create(this.GetTextureByName(this.main_script.textureNameList_1[this.main_script.stopTextureId_1 - 1]), new Rect(0.0f, 0.0f, 128f, 128f), new Vector2(0.5f, 0.5f));
    this.sprite_p2 = Sprite.Create(this.GetTextureByName(this.main_script.textureNameList_2[this.main_script.stopTextureId_2 - 1]), new Rect(0.0f, 0.0f, 128f, 128f), new Vector2(0.5f, 0.5f));
    this.sprite_p3 = Sprite.Create(this.GetTextureByName(this.main_script.textureNameList_3[this.main_script.stopTextureId_3 - 1]), new Rect(0.0f, 0.0f, 128f, 128f), new Vector2(0.5f, 0.5f));
    this.spriteRenderer_p1.sprite = this.sprite_p1;
    this.spriteRenderer_p2.sprite = this.sprite_p2;
    this.spriteRenderer_p3.sprite = this.sprite_p3;
    Debug.Log((object) ("テクスチャ数:" + (object) this.main_script.textureNameList_1.Length));
    this.SetTextureByName(this.main_script.textureNameList_1[this.GetReelTextureNameId(this.main_script.textureNameList_1, this.main_script.stopTextureId_1)], this.lille_1, 0);
    this.SetTextureByName(this.main_script.textureNameList_2[this.GetReelTextureNameId(this.main_script.textureNameList_2, this.main_script.stopTextureId_2)], this.lille_2, 0);
    this.SetTextureByName(this.main_script.textureNameList_3[this.GetReelTextureNameId(this.main_script.textureNameList_3, this.main_script.stopTextureId_3)], this.lille_3, 0);
    this.SetTextureByName(this.main_script.textureNameList_1[this.GetReelTextureNameId(this.main_script.textureNameList_1, this.main_script.stopTextureId_1 - 2)], this.lille_1, 5);
    this.SetTextureByName(this.main_script.textureNameList_2[this.GetReelTextureNameId(this.main_script.textureNameList_2, this.main_script.stopTextureId_2 - 2)], this.lille_2, 5);
    this.SetTextureByName(this.main_script.textureNameList_3[this.GetReelTextureNameId(this.main_script.textureNameList_3, this.main_script.stopTextureId_3 - 2)], this.lille_3, 5);
  }

  private int GetReelTextureNameId(string[] list, int id)
  {
    int length = list.Length;
    return id <= length - 1 ? (id >= 0 ? id : length - 1) : 0;
  }

  private void SetTextureByName(string texture_name, GameObject target_gb, int setid)
  {
    target_gb.GetComponent<Renderer>().materials[setid].mainTexture = (Texture) this.textures.SingleOrDefault<Texture2D>((Func<Texture2D, bool>) (f => ((Object) f).name == texture_name));
  }

  private Texture2D GetTextureByName(string texture_name)
  {
    return this.textures.SingleOrDefault<Texture2D>((Func<Texture2D, bool>) (f => ((Object) f).name == texture_name));
  }

  public void SlotInit()
  {
    this.rarity1.SetActive(false);
    this.rarity2.SetActive(false);
    this.rarity3.SetActive(false);
    this.rarity4.SetActive(false);
    this.rarity5.SetActive(false);
    this.rarity6.SetActive(false);
    this.ChangeState(3000);
    this.isEnd = false;
    this.isReady = true;
    this.isSkip = false;
    this.Lamp_switch("blue");
    this.cutin.SetActive(false);
  }

  public void SlotStart()
  {
    this.isReady = false;
    this.isSkip = true;
    this.state_index = 0;
    this.ChangeState(1000);
  }

  public void SlotEnd()
  {
    this.isEnd = true;
    this.isSkip = false;
  }

  private void NextState()
  {
    if (this.state_index < this.main_script.transitionPlanList.Length)
      this.ChangeState(this.main_script.transitionPlanList[this.state_index++]);
    else
      this.ChangeState(2000);
  }

  private void ChangeState(int id) => this.animator.SetInteger("transition_id", id);

  public void Skip()
  {
    if (!this.isSkip || this.state_index <= 1 || this.state_index >= 4)
      return;
    this.isSkip = false;
    this.state_index = 3;
    this.ChangeState(this.main_script.transitionPlanList[this.state_index++]);
  }

  [DebuggerHidden]
  public IEnumerator CheckLoadState()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new SlotDebug.\u003CCheckLoadState\u003Ec__Iterator3DD()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Lamp_switch(string color)
  {
    string key = color;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SlotDebug.\u003C\u003Ef__switch\u0024map17 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SlotDebug.\u003C\u003Ef__switch\u0024map17 = new Dictionary<string, int>(3)
      {
        {
          "blue",
          0
        },
        {
          "lightblue",
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
    if (!SlotDebug.\u003C\u003Ef__switch\u0024map17.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.lamp_blue.SetActive(true);
        this.lamp_lightblue.SetActive(false);
        this.lamp_red.SetActive(false);
        break;
      case 1:
        this.lamp_blue.SetActive(false);
        this.lamp_lightblue.SetActive(true);
        this.lamp_red.SetActive(false);
        this.ps_light_lightblue.Play();
        this.ps_lightblue_1.Play();
        this.ps_lightblue_2.Play();
        this.ps_lightblue_3.Play();
        this.ps_lightblue_4.Play();
        break;
      case 2:
        this.lamp_blue.SetActive(false);
        this.lamp_lightblue.SetActive(false);
        this.lamp_red.SetActive(true);
        this.ps_light_red.Play();
        this.ps_red_1.Play();
        this.ps_red_2.Play();
        this.ps_red_3.Play();
        this.ps_red_4.Play();
        break;
    }
  }

  public void getItemSoundPlay()
  {
    string empty = string.Empty;
    string id;
    switch (this.main_script.rarity)
    {
      case 1:
        id = "SE_0502";
        break;
      case 2:
        id = "SE_0503";
        break;
      case 3:
        id = "SE_0504";
        break;
      case 4:
        id = "SE_0505";
        break;
      default:
        id = "SE_0506";
        break;
    }
    if (Debug.isDebugBuild)
      Debug.Log((object) ("Play SE: " + id + " for rarity: " + (object) this.main_script.rarity + ". " + ((Object) ((Component) this).gameObject).name));
    this.SoundPlay(id);
  }

  public void PlayShowItemEffect()
  {
    switch (this.main_script.rarity)
    {
      case 1:
        this.rarity1.SetActive(true);
        break;
      case 2:
        this.rarity2.SetActive(true);
        break;
      case 3:
        this.rarity3.SetActive(true);
        break;
      case 4:
        this.rarity4.SetActive(true);
        break;
      case 5:
        this.rarity5.SetActive(true);
        break;
      case 6:
        this.rarity6.SetActive(true);
        break;
      default:
        this.rarity1.SetActive(true);
        break;
    }
  }

  public void PlayShowCutin()
  {
    this.cutin.GetComponent<Animator>().speed = 1f;
    this.cutin.SetActive(true);
    this.main_script.duelCutin.PlaySkillCutin();
    this.effect_se_script.StartCoroutine(this.effect_se_script.PlaySE());
  }

  public void HideCutin()
  {
    this.cutin.GetComponent<Animator>().speed = 0.0f;
    this.cutin.SetActive(false);
  }

  public void SoundPlay(string id) => this.SM.playSE(id);

  public void SoundPlayLoop(string id) => this.SM.playSE(id, true);

  public void SoundStop() => this.SM.StopSe();
}
