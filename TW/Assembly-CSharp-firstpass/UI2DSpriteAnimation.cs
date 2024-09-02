// Decompiled with JetBrains decompiler
// Type: UI2DSpriteAnimation
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
public class UI2DSpriteAnimation : MonoBehaviour
{
  public int framerate = 20;
  public bool ignoreTimeScale = true;
  public Sprite[] frames;
  private SpriteRenderer mUnitySprite;
  private UI2DSprite mNguiSprite;
  private int mIndex;
  private float mUpdate;

  private void Start()
  {
    this.mUnitySprite = ((Component) this).GetComponent<SpriteRenderer>();
    this.mNguiSprite = ((Component) this).GetComponent<UI2DSprite>();
    if (this.framerate <= 0)
      return;
    this.mUpdate = (float) ((!this.ignoreTimeScale ? (double) Time.time : (double) RealTime.time) + 1.0 / (double) this.framerate);
  }

  private void Update()
  {
    if (this.framerate == 0 || this.frames == null || this.frames.Length <= 0)
      return;
    float num = !this.ignoreTimeScale ? Time.time : RealTime.time;
    if ((double) this.mUpdate >= (double) num)
      return;
    this.mUpdate = num;
    this.mIndex = NGUIMath.RepeatIndex(this.framerate <= 0 ? this.mIndex - 1 : this.mIndex + 1, this.frames.Length);
    this.mUpdate = num + Mathf.Abs(1f / (float) this.framerate);
    if (Object.op_Inequality((Object) this.mUnitySprite, (Object) null))
    {
      this.mUnitySprite.sprite = this.frames[this.mIndex];
    }
    else
    {
      if (!Object.op_Inequality((Object) this.mNguiSprite, (Object) null))
        return;
      this.mNguiSprite.nextSprite = this.frames[this.mIndex];
    }
  }
}
