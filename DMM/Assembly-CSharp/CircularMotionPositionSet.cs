﻿// Decompiled with JetBrains decompiler
// Type: CircularMotionPositionSet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class CircularMotionPositionSet : CircularMotionBase
{
  [SerializeField]
  private List<MypageSlidePanelDragged> MotionTargets = new List<MypageSlidePanelDragged>();
  [SerializeField]
  private UIPanel mPanel;
  [SerializeField]
  private Transform DragArea;
  private int MotionTargetQuantity;
  private float SpaceAngle = 70f;
  private const int TARGET_HEIGHT = 130;
  public int SpringSpeed = 15;
  private MypageSlidePanelDragged NextCenterObject;
  private bool ChangeCenterObj;
  private bool SetNextCenterObj;
  public int Tolerance = 2;
  private float Goal;
  private float[] rate;
  private const int TEXTURE_FULL_SIZE = 585;
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
    float num3 = (float) ((double) this.radius * (double) Mathf.Cos(num1 * ((float) Math.PI / 180f)) + 0.0);
    float num4 = (float) ((double) this.radius * (double) Mathf.Sin(num1 * ((float) Math.PI / 180f)) * 1.0);
    Vector2 frompos = new Vector2((float) ((double) num3 + (double) this.CenterPosition.x - 1000.0), -num4 + this.CenterPosition.y);
    Vector2 topos = new Vector2(num3 + this.CenterPosition.x, -num4 + this.CenterPosition.y);
    ((IEnumerable<TweenPosition>) centerObject.GetComponents<TweenPosition>()).ForEach<TweenPosition>((System.Action<TweenPosition>) (x =>
    {
      if (x.tweenGroup == MypageMenuBase.START_TWEEN_GROUP_JOGDIAL)
      {
        x.from = (Vector3) frompos;
        x.to = (Vector3) topos;
      }
      else if (x.tweenGroup == MypageMenuBase.END_TWEEN_GROUP_JOGDIAL)
      {
        x.from = (Vector3) topos;
        x.to = (Vector3) frompos;
      }
      else if (x.tweenGroup == MypageMenuBase.START_TWEENGROUP)
      {
        x.from = (Vector3) frompos;
        x.to = (Vector3) topos;
      }
      else
      {
        if (x.tweenGroup != MypageMenuBase.END_TWEENGROUP)
          return;
        x.from = (Vector3) topos;
        x.to = (Vector3) frompos;
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
    this.mPanel.transform.localPosition = new Vector3(0.0f, 0.0f);
    this.mPanel.clipOffset = new Vector2(0.0f, 0.0f);
    this.jog = this.gameObject.GetOrAddComponent<jogDialSE>();
    int? centerIndex = this.MotionTargets.FirstIndexOrNull<MypageSlidePanelDragged>((Func<MypageSlidePanelDragged, bool>) (x => (UnityEngine.Object) x == (UnityEngine.Object) this.CenterTarget));
    Vector2 centerToX = this.CenterSetValue(this.MotionTargets[centerIndex.Value]);
    this.NextCenterObject = this.MotionTargets[centerIndex.Value];
    for (int i = 0; i < this.MotionTargets.Count; i++)
    {
      int num1 = i;
      int? nullable1 = centerIndex;
      int valueOrDefault1 = nullable1.GetValueOrDefault();
      if (!(num1 == valueOrDefault1 & nullable1.HasValue))
      {
        int num2 = i;
        nullable1 = centerIndex;
        int? nullable2;
        int? nullable3;
        if (!nullable1.HasValue)
        {
          nullable2 = new int?();
          nullable3 = nullable2;
        }
        else
          nullable3 = new int?(num2 - nullable1.GetValueOrDefault());
        nullable2 = nullable3;
        float num3 = (float) nullable2.Value * this.SpaceAngle;
        int num4 = 0;
        while ((double) num3 > (double) this.SpaceAngle)
        {
          num3 -= this.SpaceAngle;
          ++num4;
        }
        while ((double) num3 < -(double) this.SpaceAngle)
        {
          num3 += this.SpaceAngle;
          ++num4;
        }
        float num5 = this.radius * Mathf.Cos(num3 * ((float) Math.PI / 180f)) + (float) (-1000 * num4);
        float num6 = this.radius * Mathf.Sin(num3 * ((float) Math.PI / 180f)) * (float) (num4 + 1);
        Vector2 frompos = new Vector2((float) ((double) num5 + (double) this.CenterPosition.x - 1000.0), -num6 + this.CenterPosition.y);
        Vector2 topos = new Vector2(num5 + this.CenterPosition.x, -num6 + this.CenterPosition.y);
        ((IEnumerable<TweenPosition>) this.MotionTargets[i].GetComponents<TweenPosition>()).ForEach<TweenPosition>((System.Action<TweenPosition>) (x =>
        {
          if (x.tweenGroup == MypageMenuBase.START_TWEEN_GROUP_JOGDIAL)
          {
            int num1 = i;
            int? nullable1 = centerIndex;
            int? nullable2 = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() - 1) : new int?();
            int valueOrDefault1 = nullable2.GetValueOrDefault();
            if (!(num1 == valueOrDefault1 & nullable2.HasValue))
            {
              int num2 = i;
              nullable1 = centerIndex;
              nullable2 = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() + 1) : new int?();
              int valueOrDefault2 = nullable2.GetValueOrDefault();
              if (!(num2 == valueOrDefault2 & nullable2.HasValue))
              {
                x.from = (Vector3) frompos;
                goto label_5;
              }
            }
            x.from = (Vector3) centerToX;
label_5:
            x.to = (Vector3) topos;
          }
          else if (x.tweenGroup == MypageMenuBase.END_TWEEN_GROUP_JOGDIAL)
          {
            x.from = (Vector3) topos;
            x.to = (Vector3) frompos;
          }
          else if (x.tweenGroup == MypageMenuBase.START_TWEENGROUP)
          {
            x.from = (Vector3) frompos;
            x.to = (Vector3) topos;
          }
          else
          {
            if (x.tweenGroup != MypageMenuBase.END_TWEENGROUP)
              return;
            x.from = (Vector3) topos;
            x.to = (Vector3) frompos;
          }
        }));
        int num9 = i;
        nullable2 = centerIndex;
        nullable1 = nullable2.HasValue ? new int?(nullable2.GetValueOrDefault() - 1) : new int?();
        int valueOrDefault4 = nullable1.GetValueOrDefault();
        if (!(num9 == valueOrDefault4 & nullable1.HasValue))
        {
          int num7 = i;
          nullable2 = centerIndex;
          nullable1 = nullable2.HasValue ? new int?(nullable2.GetValueOrDefault() + 1) : new int?();
          int valueOrDefault2 = nullable1.GetValueOrDefault();
          if (!(num7 == valueOrDefault2 & nullable1.HasValue))
            continue;
        }
        this.MotionTargets[i].PanelEffectMin();
      }
    }
    this.MotionTargets.ForEach((System.Action<MypageSlidePanelDragged>) (x =>
    {
      MypageSlidePanelDragged component = x.gameObject.GetComponent<MypageSlidePanelDragged>();
      component.drag = this;
      if ((UnityEngine.Object) x == (UnityEngine.Object) this.CenterTarget)
      {
        x.GetEnableButton().enabled = true;
        component.GetButton().gameObject.SetActive(true);
      }
      else
      {
        x.GetEnableButton().enabled = false;
        component.GetButton().gameObject.SetActive(true);
      }
    }));
    this.DragArea.gameObject.GetComponent<MypageSlidePanelDragged>().drag = this;
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
      if ((UnityEngine.Object) this.NextCenterObject != (UnityEngine.Object) null)
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
    if (this.condition == CircularMotionPositionSet.CirculCondition.SET)
      this.SetAndKeepCenter();
    if (GuildChatManager.scrollWheel_flg || Singleton<PopupManager>.GetInstance().isOpen)
      return;
    float axis = Input.GetAxis("Mouse ScrollWheel");
    if ((double) axis == 0.0)
      return;
    foreach (RaycastHit raycastHit in Physics.RaycastAll(Singleton<CommonRoot>.GetInstance().getCamera().ScreenPointToRay(Input.mousePosition)))
    {
      if ((UnityEngine.Object) raycastHit.collider.gameObject == (UnityEngine.Object) this.DragArea.gameObject)
      {
        this.ScrollWheel(axis);
        break;
      }
    }
  }

  private void ScrollWheel(float d)
  {
    float nPosY = 50f;
    if ((double) d > 0.0)
      this.StartCoroutine(this.ScrollSmooth(nPosY));
    else
      this.StartCoroutine(this.ScrollSmooth(-nPosY));
  }

  private IEnumerator ScrollSmooth(float nPosY)
  {
    float duration = 0.15f;
    float y1 = this.mPanel.transform.localPosition.y;
    float targetPosY = y1 + nPosY;
    this.condition = CircularMotionPositionSet.CirculCondition.DRAG;
    float startPosY = y1;
    for (float t = 0.0f; (double) t < (double) duration; t += Time.deltaTime)
    {
      float y2 = (float) (int) Mathf.Lerp(startPosY, targetPosY, t / duration);
      this.mPanel.transform.localPosition = new Vector3(this.mPanel.transform.localPosition.x, y2);
      this.mPanel.clipOffset = new Vector2(this.mPanel.clipOffset.x, -y2);
      this.XposCalculation();
      this.UpdateCenterObject();
      yield return (object) null;
    }
    this.SetNextCenterObj = true;
    this.condition = CircularMotionPositionSet.CirculCondition.RELEASE;
  }

  private void jogSE()
  {
    foreach (MypageSlidePanelDragged motionTarget in this.MotionTargets)
    {
      if (motionTarget.Equals((object) this.NextCenterObject))
      {
        Vector3 spriteObjectScale = this.NextCenterObject.GetSpriteObjectScale();
        if ((double) spriteObjectScale.x == 1.0 && (double) spriteObjectScale.y == 1.0)
        {
          if (!motionTarget.jogPlayed)
          {
            if ((UnityEngine.Object) this.jog != (UnityEngine.Object) null)
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
    float num = this.mPanel.clipOffset.y * -1f;
    foreach (MypageSlidePanelDragged motionTarget in this.MotionTargets)
    {
      float f = this.CenterPosition.y - (motionTarget.transform.localPosition.y + num);
      Vector3 localPosition = motionTarget.transform.localPosition;
      localPosition.x = (double) radius >= (double) Mathf.Abs(f) ? Mathf.Sqrt((float) ((double) radius * (double) radius - (double) f * (double) f)) + this.CenterPosition.x : -1000f;
      motionTarget.transform.localPosition = localPosition;
    }
    this.Rating();
    float panelY = this.mPanel.baseClipRegion.y + this.mPanel.clipOffset.y;
    this.MotionTargets.ForEach((System.Action<MypageSlidePanelDragged>) (x => x.GetComponent<MypageSlidePanelDragged>().PanelEffect(panelY)));
    Vector3 localPosition1 = this.DragArea.localPosition;
    this.DragArea.localPosition = new Vector3(localPosition1.x, panelY, localPosition1.z);
    this.MotionTargets.ForEach((System.Action<MypageSlidePanelDragged>) (x =>
    {
      TweenPosition tweenPosition = ((IEnumerable<TweenPosition>) x.GetComponents<TweenPosition>()).Where<TweenPosition>((Func<TweenPosition, bool>) (y => y.tweenGroup == MypageMenuBase.END_TWEEN_GROUP_JOGDIAL)).First<TweenPosition>();
      tweenPosition.from = new Vector3(x.transform.localPosition.x, x.transform.localPosition.y);
      tweenPosition.to = new Vector3(-1000f, x.transform.localPosition.y);
    }));
  }

  private void Rating()
  {
    if (this.MotionTargets == null || this.MotionTargets.Count <= 0)
      return;
    this.rate = new float[this.MotionTargets.Count];
    for (int index = 0; index < this.MotionTargets.Count; ++index)
    {
      if (!((UnityEngine.Object) this.MotionTargets[index] == (UnityEngine.Object) null))
      {
        this.rate[index] = Mathf.Abs(this.MotionTargets[index].transform.localPosition.x / (this.CenterPosition.x - -100f)) - 1f;
        this.rate[index] = (double) this.rate[index] > 1.0 ? 1f : this.rate[index];
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
      index1 = (double) num < 0.0 ? 0 : index1;
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
    float num2 = this.CenterPosition.y - this.NextCenterObject.transform.localPosition.y;
    this.mPanel.transform.localPosition += new Vector3(0.0f, (num2 - num1) * (float) this.SpringSpeed * Time.deltaTime);
    this.mPanel.clipOffset = new Vector2(this.mPanel.transform.localPosition.x * -1f, this.mPanel.transform.localPosition.y * -1f);
    if ((int) this.mPanel.transform.localPosition.y > (int) num2 + this.Tolerance || (int) this.mPanel.transform.localPosition.y <= (int) num2 - this.Tolerance)
      return;
    this.ChangeCenterObj = false;
    this.Goal = (float) (int) num2;
    this.SetAndKeepCenter();
    this.XposCalculation();
    this.condition = CircularMotionPositionSet.CirculCondition.SET;
    this.MotionTargets.ForEach((System.Action<MypageSlidePanelDragged>) (x =>
    {
      if ((UnityEngine.Object) this.NextCenterObject == (UnityEngine.Object) x)
      {
        x.GetEnableButton().enabled = true;
        x.GetComponent<MypageSlidePanelDragged>().GetButton().gameObject.SetActive(true);
      }
      else
      {
        x.GetEnableButton().enabled = false;
        x.GetComponent<MypageSlidePanelDragged>().GetButton().gameObject.SetActive(false);
      }
    }));
  }

  private void SetAndKeepCenter()
  {
    this.mPanel.transform.localPosition = new Vector3(this.mPanel.transform.localPosition.x, this.Goal);
    this.mPanel.clipOffset = new Vector2(this.mPanel.transform.localPosition.x * -1f, this.mPanel.transform.localPosition.y * -1f);
  }

  public void onPress()
  {
    this.condition = CircularMotionPositionSet.CirculCondition.DRAG;
    this.MotionTargets.ForEach((System.Action<MypageSlidePanelDragged>) (x =>
    {
      MypageSlidePanelDragged component = x.GetComponent<MypageSlidePanelDragged>();
      component.DisableSlcPressedEffect();
      if ((UnityEngine.Object) this.NextCenterObject == (UnityEngine.Object) x)
        component.EnableSlcPressedEffect();
      component.GetButton().gameObject.SetActive(true);
    }));
  }

  public void onRelease()
  {
    this.condition = CircularMotionPositionSet.CirculCondition.RELEASE;
    this.SetNextCenterObj = true;
    this.MotionTargets.ForEach((System.Action<MypageSlidePanelDragged>) (x => x.GetComponent<MypageSlidePanelDragged>().DisableSlcPressedEffect()));
  }

  public void End()
  {
    this.condition = CircularMotionPositionSet.CirculCondition.START;
    List<UITweener> EndTween = new List<UITweener>();
    this.MotionTargets.ForEach((System.Action<MypageSlidePanelDragged>) (x => EndTween.Add((UITweener) ((IEnumerable<TweenPosition>) x.GetComponents<TweenPosition>()).Where<TweenPosition>((Func<TweenPosition, bool>) (y => y.tweenGroup == MypageMenuBase.END_TWEEN_GROUP_JOGDIAL)).First<TweenPosition>())));
    EndTween.ForEach((System.Action<UITweener>) (x =>
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
