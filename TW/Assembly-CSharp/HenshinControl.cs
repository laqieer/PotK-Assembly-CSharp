// Decompiled with JetBrains decompiler
// Type: HenshinControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class HenshinControl : MonoBehaviour
{
  private GameObject prefab_;
  private bool isPause_ = true;
  private bool isPlaying_;
  private bool isSkip_;
  private HenshinContainer container_;
  private int id_;
  private GameObject unitBefore_;
  private GameObject unitAfter_;

  public bool isPlaying => this.isPlaying_;

  private void setUnit()
  {
    this.insertObject(this.container_.dirBefore.transform, this.unitBefore_.transform);
    this.insertObject(this.container_.dirAfter.transform, this.unitAfter_.transform);
  }

  private void insertObject(Transform forwardTrans, Transform inTrans)
  {
    Transform[] array = forwardTrans.GetChildren().ToArray<Transform>();
    Vector3 localPosition1 = inTrans.localPosition;
    Quaternion localRotation1 = inTrans.localRotation;
    Vector3 localScale1 = inTrans.localScale;
    inTrans.parent = forwardTrans;
    inTrans.localPosition = localPosition1;
    inTrans.localRotation = localRotation1;
    inTrans.localScale = localScale1;
    foreach (Transform transform in array)
    {
      Vector3 localPosition2 = transform.localPosition;
      Quaternion localRotation2 = transform.localRotation;
      Vector3 localScale2 = transform.localScale;
      transform.parent = inTrans;
      transform.localPosition = localPosition2;
      transform.localRotation = localRotation2;
      transform.localScale = localScale2;
    }
  }

  [DebuggerHidden]
  public IEnumerator coSetUnit(int id, GameObject unitBefore, GameObject unitAfter)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new HenshinControl.\u003CcoSetUnit\u003Ec__Iterator565()
    {
      id = id,
      unitBefore = unitBefore,
      unitAfter = unitAfter,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003EunitBefore = unitBefore,
      \u003C\u0024\u003EunitAfter = unitAfter,
      \u003C\u003Ef__this = this
    };
  }

  public void startHenshin() => this.isPause_ = false;

  public void skipHenshin() => this.isSkip_ = true;

  private void Update()
  {
    if (this.isPlaying_ && this.isSkip_)
    {
      this.isSkip_ = false;
      this.container_.skipHenshin();
    }
    if (this.isPause_ || !Object.op_Inequality((Object) this.container_, (Object) null))
      return;
    this.isPlaying_ = this.container_.updateHenshin();
  }

  public void replayHenshin()
  {
    if (!Object.op_Inequality((Object) this.container_, (Object) null))
      return;
    this.isPause_ = false;
    this.isPlaying_ = false;
    this.isSkip_ = false;
    this.container_.resetHenshin();
  }
}
