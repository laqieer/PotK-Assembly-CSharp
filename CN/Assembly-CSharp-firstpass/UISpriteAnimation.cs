// Decompiled with JetBrains decompiler
// Type: UISpriteAnimation
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[RequireComponent(typeof (UISprite))]
[AddComponentMenu("NGUI/UI/Sprite Animation")]
public class UISpriteAnimation : MonoBehaviour
{
  [HideInInspector]
  [SerializeField]
  private int mFPS = 30;
  [HideInInspector]
  [SerializeField]
  private string mPrefix = string.Empty;
  [SerializeField]
  [HideInInspector]
  private bool mLoop = true;
  private UISprite mSprite;
  private float mDelta;
  private int mIndex;
  private bool mActive = true;
  private List<string> mSpriteNames = new List<string>();

  public int frames => this.mSpriteNames.Count;

  public int framesPerSecond
  {
    get => this.mFPS;
    set => this.mFPS = value;
  }

  public string namePrefix
  {
    get => this.mPrefix;
    set
    {
      if (!(this.mPrefix != value))
        return;
      this.mPrefix = value;
      this.RebuildSpriteList();
    }
  }

  public bool loop
  {
    get => this.mLoop;
    set => this.mLoop = value;
  }

  public bool isPlaying => this.mActive;

  private void Start() => this.RebuildSpriteList();

  private void Update()
  {
    if (!this.mActive || this.mSpriteNames.Count <= 1 || !Application.isPlaying || (double) this.mFPS <= 0.0)
      return;
    this.mDelta += RealTime.deltaTime;
    float num = 1f / (float) this.mFPS;
    if ((double) num >= (double) this.mDelta)
      return;
    this.mDelta = (double) num <= 0.0 ? 0.0f : this.mDelta - num;
    if (++this.mIndex >= this.mSpriteNames.Count)
    {
      this.mIndex = 0;
      this.mActive = this.loop;
    }
    if (!this.mActive)
      return;
    this.mSprite.spriteName = this.mSpriteNames[this.mIndex];
    this.mSprite.MakePixelPerfect();
  }

  private void RebuildSpriteList()
  {
    if (Object.op_Equality((Object) this.mSprite, (Object) null))
      this.mSprite = ((Component) this).GetComponent<UISprite>();
    this.mSpriteNames.Clear();
    if (!Object.op_Inequality((Object) this.mSprite, (Object) null) || !Object.op_Inequality((Object) this.mSprite.atlas, (Object) null))
      return;
    List<UISpriteData> spriteList = this.mSprite.atlas.spriteList;
    int index = 0;
    for (int count = spriteList.Count; index < count; ++index)
    {
      UISpriteData uiSpriteData = spriteList[index];
      if (string.IsNullOrEmpty(this.mPrefix) || uiSpriteData.name.StartsWith(this.mPrefix))
        this.mSpriteNames.Add(uiSpriteData.name);
    }
    this.mSpriteNames.Sort();
  }

  public void Reset()
  {
    this.mActive = true;
    this.mIndex = 0;
    if (!Object.op_Inequality((Object) this.mSprite, (Object) null) || this.mSpriteNames.Count <= 0)
      return;
    this.mSprite.spriteName = this.mSpriteNames[this.mIndex];
    this.mSprite.MakePixelPerfect();
  }
}
