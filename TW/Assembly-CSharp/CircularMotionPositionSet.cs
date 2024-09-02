// Decompiled with JetBrains decompiler
// Type: CircularMotionPositionSet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class CircularMotionPositionSet : CircularMotionBase
{
  private const int TARGET_HEIGHT = 130;
  private const int TEXTURE_FULL_SIZE = 585;
  [SerializeField]
  private List<MypageSlidePanelDragged> MotionTargets = new List<MypageSlidePanelDragged>();
  [SerializeField]
  private UIPanel mPanel;
  [SerializeField]
  private Transform DragArea;
  private int MotionTargetQuantity;
  private float SpaceAngle = 70f;
  public int SpringSpeed = 15;
  private MypageSlidePanelDragged NextCenterObject;
  private bool ChangeCenterObj;
  private bool SetNextCenterObj;
  public int Tolerance = 2;
  private float Goal;
  private float[] rate;
  private jogDialSE jog;
  public CircularMotionPositionSet.CirculCondition condition = CircularMotionPositionSet.CirculCondition.START;

  public List<MypageSlidePanelDragged> GetTargets => this.MotionTargets;

  private Vector2 CenterSetValue(MypageSlidePanelDragged centerObject)
  {
    float num1 = 0.0f * this.SpaceAngle;
    int num2 = 0;
    while ((double) num1 > (double) this.SpaceAngle)
    {
      num1 -= this.SpaceAngle;
      ++num2;
    }
    while ((double) num1 < -(double) this.SpaceAngle)
    {
      num1 += this.SpaceAngle;
      ++num2;
    }
    float num3 = this.radius * Mathf.Cos(num1 * ((float) Math.PI / 180f));
    float num4 = (float) ((double) this.radius * (double) Mathf.Sin(num1 * ((float) Math.PI / 180f)) * 1.0);
    Vector2 frompos = new Vector2((float) ((double) num3 + (double) this.CenterPosition.x - 1000.0), -num4 + this.CenterPosition.y);
    Vector2 topos = new Vector2(num3 + this.CenterPosition.x, -num4 + this.CenterPosition.y);
    ((IEnumerable<TweenPosition>) ((Component) centerObject).GetComponents<TweenPosition>()).ForEach<TweenPosition>((Action<TweenPosition>) (x =>
    {
      if (x.tweenGroup == MypageMenu.START_TWEEN_GROUP_JOGDIAL)
      {
        x.from = Vector2.op_Implicit(frompos);
        x.to = Vector2.op_Implicit(topos);
      }
      else if (x.tweenGroup == MypageMenu.END_TWEEN_GROUP_JOGDIAL)
      {
        x.from = Vector2.op_Implicit(topos);
        x.to = Vector2.op_Implicit(frompos);
      }
      else if (x.tweenGroup == MypageMenu.START_TWEENGROUP)
      {
        x.from = Vector2.op_Implicit(frompos);
        x.to = Vector2.op_Implicit(topos);
      }
      else
      {
        if (x.tweenGroup != MypageMenu.END_TWEENGROUP)
          return;
        x.from = Vector2.op_Implicit(topos);
        x.to = Vector2.op_Implicit(frompos);
      }
    }));
    return topos;
  }

  public override void Init(MypageSlidePanelDragged centerObject)
  {
    base.Init(centerObject);
    this.condition = CircularMotionPositionSet.CirculCondition.START_EFFECT;
    this.ChangeCenterObj = false;
    this.SetNextCenterObj = false;
    ((Component) this.mPanel).transform.localPosition = new Vector3(0.0f, 0.0f);
    this.mPanel.clipOffset = new Vector2(0.0f, 0.0f);
    this.jog = ((Component) this).gameObject.GetOrAddComponent<jogDialSE>();
    int? centerIndex = this.MotionTargets.FirstIndexOrNull<MypageSlidePanelDragged>((Func<MypageSlidePanelDragged, bool>) (x => Object.op_Equality((Object) x, (Object) this.CenterTarget)));
    Vector2 centerToX = this.CenterSetValue(this.MotionTargets[centerIndex.Value]);
    this.NextCenterObject = this.MotionTargets[centerIndex.Value];
    for (int i = 0; i < this.MotionTargets.Count; ++i)
    {
      if ((i != centerIndex.GetValueOrDefault() ? 0 : (centerIndex.HasValue ? 1 : 0)) == 0)
      {
        float num1 = (float) (!centerIndex.HasValue ? new int?() : new int?(i - centerIndex.Value)).Value * this.SpaceAngle;
        int num2 = 0;
        while ((double) num1 > (double) this.SpaceAngle)
        {
          num1 -= this.SpaceAngle;
          ++num2;
        }
        while ((double) num1 < -(double) this.SpaceAngle)
        {
          num1 += this.SpaceAngle;
          ++num2;
        }
        float num3 = this.radius * Mathf.Cos(num1 * ((float) Math.PI / 180f)) + (float) (-1000 * num2);
        float num4 = this.radius * Mathf.Sin(num1 * ((float) Math.PI / 180f)) * (float) (num2 + 1);
        Vector2 frompos = new Vector2((float) ((double) num3 + (double) this.CenterPosition.x - 1000.0), -num4 + this.CenterPosition.y);
        Vector2 topos = new Vector2(num3 + this.CenterPosition.x, -num4 + this.CenterPosition.y);
        ((IEnumerable<TweenPosition>) ((Component) this.MotionTargets[i]).GetComponents<TweenPosition>()).ForEach<TweenPosition>((Action<TweenPosition>) (x =>
        {
          if (x.tweenGroup == MypageMenu.START_TWEEN_GROUP_JOGDIAL)
          {
            int num5 = i;
            int? nullable1 = !centerIndex.HasValue ? new int?() : new int?(centerIndex.Value - 1);
            int valueOrDefault1 = nullable1.GetValueOrDefault();
            if ((num5 != valueOrDefault1 ? 0 : (nullable1.HasValue ? 1 : 0)) == 0)
            {
              int num6 = i;
              int? nullable2 = !centerIndex.HasValue ? new int?() : new int?(centerIndex.Value + 1);
              int valueOrDefault2 = nullable2.GetValueOrDefault();
              if ((num6 != valueOrDefault2 ? 0 : (nullable2.HasValue ? 1 : 0)) == 0)
              {
                x.from = Vector2.op_Implicit(frompos);
                goto label_5;
              }
            }
            x.from = Vector2.op_Implicit(centerToX);
label_5:
            x.to = Vector2.op_Implicit(topos);
          }
          else if (x.tweenGroup == MypageMenu.END_TWEEN_GROUP_JOGDIAL)
          {
            x.from = Vector2.op_Implicit(topos);
            x.to = Vector2.op_Implicit(frompos);
          }
          else if (x.tweenGroup == MypageMenu.START_TWEENGROUP)
          {
            x.from = Vector2.op_Implicit(frompos);
            x.to = Vector2.op_Implicit(topos);
          }
          else
          {
            if (x.tweenGroup != MypageMenu.END_TWEENGROUP)
              return;
            x.from = Vector2.op_Implicit(topos);
            x.to = Vector2.op_Implicit(frompos);
          }
        }));
        int num7 = i;
        int? nullable3 = !centerIndex.HasValue ? new int?() : new int?(centerIndex.Value - 1);
        int valueOrDefault3 = nullable3.GetValueOrDefault();
        if ((num7 != valueOrDefault3 ? 0 : (nullable3.HasValue ? 1 : 0)) == 0)
        {
          int num8 = i;
          int? nullable4 = !centerIndex.HasValue ? new int?() : new int?(centerIndex.Value + 1);
          int valueOrDefault4 = nullable4.GetValueOrDefault();
          if ((num8 != valueOrDefault4 ? 0 : (nullable4.HasValue ? 1 : 0)) == 0)
            continue;
        }
        this.MotionTargets[i].PanelEffectMin();
      }
    }
    this.MotionTargets.ForEach((Action<MypageSlidePanelDragged>) (x =>
    {
      MypageSlidePanelDragged component = ((Component) x).gameObject.GetComponent<MypageSlidePanelDragged>();
      component.drag = this;
      if (Object.op_Equality((Object) x, (Object) this.CenterTarget))
      {
        ((Behaviour) x.GetEnableButton()).enabled = true;
        ((Component) component.GetButton()).gameObject.SetActive(true);
      }
      else
      {
        ((Behaviour) x.GetEnableButton()).enabled = false;
        ((Component) component.GetButton()).gameObject.SetActive(true);
      }
    }));
    ((Component) this.DragArea).gameObject.GetComponent<MypageSlidePanelDragged>().drag = this;
    this.DragArea.localPosition = new Vector3(this.DragArea.localPosition.x, this.CenterPosition.y);
    this.mPanel.baseClipRegion = new Vector4(this.mPanel.baseClipRegion.x, this.CenterPosition.y, 1000f, (float) (130 * this.MotionTargets.Count * 3));
  }

  private void Update()
  {
    if (this.condition == CircularMotionPositionSet.CirculCondition.START_EFFECT)
      return;
    if (this.condition == CircularMotionPositionSet.CirculCondition.START)
    {
      this.Rating();
      float panelY = this.mPanel.baseClipRegion.y + this.mPanel.clipOffset.y;
      if (Object.op_Inequality((Object) this.NextCenterObject, (Object) null))
        this.NextCenterObject.PanelEffect(panelY);
    }
    if (this.condition == CircularMotionPositionSet.CirculCondition.DRAG || this.condition == CircularMotionPositionSet.CirculCondition.RELEASE)
    {
      this.XposCalculation();
      this.jogSE();
      this.UpdateCenterObject();
    }
    if (this.condition == CircularMotionPositionSet.CirculCondition.RELEASE && this.SetNextCenterObj)
      this.CenterNearHear();
    if (this.condition != CircularMotionPositionSet.CirculCondition.DRAG && this.ChangeCenterObj)
      this.SpringValue();
    if (this.condition != CircularMotionPositionSet.CirculCondition.SET)
      return;
    this.SetAndKeepCenter();
  }

  private void ScrollWheel(float d)
  {
    float nPosY = 50f;
    if ((double) d > 0.0)
      this.StartCoroutine(this.ScrollSmooth(nPosY));
    else
      this.StartCoroutine(this.ScrollSmooth(-nPosY));
  }

  [DebuggerHidden]
  private IEnumerator ScrollSmooth(float nPosY)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CircularMotionPositionSet.\u003CScrollSmooth\u003Ec__Iterator9DB()
    {
      nPosY = nPosY,
      \u003C\u0024\u003EnPosY = nPosY,
      \u003C\u003Ef__this = this
    };
  }

  private void jogSE()
  {
    foreach (MypageSlidePanelDragged motionTarget in this.MotionTargets)
    {
      if (((Object) motionTarget).Equals((object) this.NextCenterObject))
      {
        Vector3 spriteObjectScale = this.NextCenterObject.GetSpriteObjectScale();
        if ((double) spriteObjectScale.x == 1.0 && (double) spriteObjectScale.y == 1.0)
        {
          if (!motionTarget.jogPlayed)
          {
            if (Object.op_Inequality((Object) this.jog, (Object) null))
            {
              Debug.LogWarning((object) "Play Jog SE");
              this.jog.playSE();
            }
            motionTarget.jogPlayed = true;
          }
        }
        else
          motionTarget.jogPlayed = false;
      }
      else
        motionTarget.jogPlayed = false;
    }
  }

  private void XposCalculation()
  {
    float radius = this.radius;
    float num1 = this.mPanel.clipOffset.y * -1f;
    foreach (MypageSlidePanelDragged motionTarget in this.MotionTargets)
    {
      float num2 = this.CenterPosition.y - (((Component) motionTarget).transform.localPosition.y + num1);
      Vector3 localPosition = ((Component) motionTarget).transform.localPosition;
      localPosition.x = (double) radius < (double) Mathf.Abs(num2) ? -1000f : Mathf.Sqrt((float) ((double) radius * (double) radius - (double) num2 * (double) num2)) + this.CenterPosition.x;
      ((Component) motionTarget).transform.localPosition = localPosition;
    }
    this.Rating();
    float panelY = this.mPanel.baseClipRegion.y + this.mPanel.clipOffset.y;
    this.MotionTargets.ForEach((Action<MypageSlidePanelDragged>) (x => ((Component) x).GetComponent<MypageSlidePanelDragged>().PanelEffect(panelY)));
    Vector3 localPosition1 = this.DragArea.localPosition;
    this.DragArea.localPosition = new Vector3(localPosition1.x, panelY, localPosition1.z);
    this.MotionTargets.ForEach((Action<MypageSlidePanelDragged>) (x =>
    {
      TweenPosition tweenPosition = ((IEnumerable<TweenPosition>) ((Component) x).GetComponents<TweenPosition>()).Where<TweenPosition>((Func<TweenPosition, bool>) (y => y.tweenGroup == MypageMenu.END_TWEEN_GROUP_JOGDIAL)).First<TweenPosition>();
      tweenPosition.from = new Vector3(((Component) x).transform.localPosition.x, ((Component) x).transform.localPosition.y);
      tweenPosition.to = new Vector3(-1000f, ((Component) x).transform.localPosition.y);
    }));
  }

  private void Rating()
  {
    if (this.MotionTargets == null || this.MotionTargets.Count <= 0)
      return;
    this.rate = new float[this.MotionTargets.Count];
    for (int index = 0; index < this.MotionTargets.Count; ++index)
    {
      if (!Object.op_Equality((Object) this.MotionTargets[index], (Object) null))
      {
        this.rate[index] = Mathf.Abs(((Component) this.MotionTargets[index]).transform.localPosition.x / (this.CenterPosition.x - -100f)) - 1f;
        this.rate[index] = (double) this.rate[index] <= 1.0 ? this.rate[index] : 1f;
      }
    }
  }

  private void UpdateCenterObject()
  {
    float num = this.mPanel.clipOffset.y * -1f;
    int index1 = 0;
    for (int index2 = 0; index2 < this.MotionTargets.Count; ++index2)
    {
      if ((double) this.rate[index2] <= (double) this.rate[index1])
        index1 = index2;
    }
    if ((double) this.rate[index1] >= 1.0)
      index1 = (double) num >= 0.0 ? index1 : 0;
    this.NextCenterObject = this.MotionTargets[index1];
  }

  private void CenterNearHear()
  {
    this.UpdateCenterObject();
    this.SetNextCenterObj = false;
    this.ChangeCenterObj = true;
  }

  private void SpringValue()
  {
    float num1 = this.mPanel.clipOffset.y * -1f;
    float num2 = this.CenterPosition.y - ((Component) this.NextCenterObject).transform.localPosition.y;
    float num3 = num2 - num1;
    Transform transform = ((Component) this.mPanel).transform;
    transform.localPosition = Vector3.op_Addition(transform.localPosition, new Vector3(0.0f, num3 * (float) this.SpringSpeed * Time.deltaTime));
    this.mPanel.clipOffset = new Vector2(((Component) this.mPanel).transform.localPosition.x * -1f, ((Component) this.mPanel).transform.localPosition.y * -1f);
    if ((int) ((Component) this.mPanel).transform.localPosition.y > (int) num2 + this.Tolerance || (int) ((Component) this.mPanel).transform.localPosition.y <= (int) num2 - this.Tolerance)
      return;
    this.ChangeCenterObj = false;
    this.Goal = (float) (int) num2;
    this.SetAndKeepCenter();
    this.XposCalculation();
    this.condition = CircularMotionPositionSet.CirculCondition.SET;
    this.MotionTargets.ForEach((Action<MypageSlidePanelDragged>) (x =>
    {
      if (Object.op_Equality((Object) this.NextCenterObject, (Object) x))
      {
        ((Behaviour) x.GetEnableButton()).enabled = true;
        ((Component) ((Component) x).GetComponent<MypageSlidePanelDragged>().GetButton()).gameObject.SetActive(true);
      }
      else
      {
        ((Behaviour) x.GetEnableButton()).enabled = false;
        ((Component) ((Component) x).GetComponent<MypageSlidePanelDragged>().GetButton()).gameObject.SetActive(false);
      }
    }));
  }

  private void SetAndKeepCenter()
  {
    ((Component) this.mPanel).transform.localPosition = new Vector3(((Component) this.mPanel).transform.localPosition.x, this.Goal);
    this.mPanel.clipOffset = new Vector2(((Component) this.mPanel).transform.localPosition.x * -1f, ((Component) this.mPanel).transform.localPosition.y * -1f);
  }

  public void onPress()
  {
    this.condition = CircularMotionPositionSet.CirculCondition.DRAG;
    this.MotionTargets.ForEach((Action<MypageSlidePanelDragged>) (x =>
    {
      MypageSlidePanelDragged component = ((Component) x).GetComponent<MypageSlidePanelDragged>();
      component.DisableSlcPressedEffect();
      if (Object.op_Equality((Object) this.NextCenterObject, (Object) x))
        component.EnableSlcPressedEffect();
      ((Component) component.GetButton()).gameObject.SetActive(true);
    }));
  }

  public void onRelease()
  {
    this.condition = CircularMotionPositionSet.CirculCondition.RELEASE;
    this.SetNextCenterObj = true;
    this.MotionTargets.ForEach((Action<MypageSlidePanelDragged>) (x => ((Component) x).GetComponent<MypageSlidePanelDragged>().DisableSlcPressedEffect()));
  }

  public void End()
  {
    this.condition = CircularMotionPositionSet.CirculCondition.START;
    List<UITweener> EndTween = new List<UITweener>();
    this.MotionTargets.ForEach((Action<MypageSlidePanelDragged>) (x => EndTween.Add((UITweener) ((IEnumerable<TweenPosition>) ((Component) x).GetComponents<TweenPosition>()).Where<TweenPosition>((Func<TweenPosition, bool>) (y => y.tweenGroup == MypageMenu.END_TWEEN_GROUP_JOGDIAL)).First<TweenPosition>())));
    EndTween.ForEach((Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  public enum CirculCondition
  {
    START_EFFECT,
    START,
    DRAG,
    RELEASE,
    SET,
  }
}
