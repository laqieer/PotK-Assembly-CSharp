﻿// Decompiled with JetBrains decompiler
// Type: IllustController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class IllustController : MonoBehaviour
{
  [SerializeField]
  private GameObject targetPicture;
  [SerializeField]
  private UIScrollView scrollPicture;
  [SerializeField]
  [Tooltip("イラストの横幅")]
  private int illustWidth;
  [SerializeField]
  [Tooltip("ダブルクリックのインターバル時間")]
  private float doubleClickIntervalTime;
  [SerializeField]
  [Tooltip("ピンチインアウトする重み")]
  private float pinchiInOutWeight;
  [SerializeField]
  [Tooltip("画像の表示最大サイズ")]
  private float imageMaxSize;
  private System.Action callback;
  private IllustController.PhaseMode ePhase = IllustController.PhaseMode.None;
  private float fitScale;
  private bool isTapStart;
  private bool isPressFrame;
  private bool isReleaseFrame;

  public void Init(System.Action callback, float panel_width)
  {
    this.SetCameraAllowMultiTouch(true);
    this.fitScale = panel_width / (float) this.illustWidth;
    this.InitSize();
    this.callback = callback;
    this.ePhase = IllustController.PhaseMode.None;
  }

  private void SetCameraAllowMultiTouch(bool isAllow) => Singleton<CommonRoot>.GetInstance().getCamera().GetComponent<UICamera>().allowMultiTouch = isAllow;

  private void Update()
  {
    float axis = Input.GetAxis("Mouse ScrollWheel");
    if ((double) axis != 0.0)
      this.PinchiInOut(axis);
    if (this.isPressFrame)
      this.CheckTouch();
    if (Input.touchCount < 2)
      return;
    Touch touch1 = Input.GetTouch(0);
    Touch touch2 = Input.GetTouch(1);
    Vector2 vector2 = touch1.position - touch1.deltaPosition - (touch2.position - touch2.deltaPosition);
    double magnitude1 = (double) vector2.magnitude;
    vector2 = touch1.position - touch2.position;
    double magnitude2 = (double) vector2.magnitude;
    this.PinchiInOut((float) (magnitude1 - magnitude2) / -100f);
  }

  private void CheckTouch(bool isRelease = false)
  {
    int touchCount = Input.touchCount;
    if (this.isReleaseFrame)
      --touchCount;
    if (touchCount == 0)
    {
      if (this.ePhase == IllustController.PhaseMode.PinchiInOut)
      {
        this.scrollPicture.enabled = true;
        this.IsCheckRestrictWithinBounds();
      }
      this.ePhase = IllustController.PhaseMode.None;
    }
    if (touchCount == 1)
    {
      if (this.ePhase == IllustController.PhaseMode.PinchiInOut)
      {
        this.scrollPicture.enabled = true;
        this.IsCheckRestrictWithinBounds();
      }
      this.ePhase = IllustController.PhaseMode.Drag;
    }
    if (touchCount >= 2)
    {
      this.scrollPicture.enabled = false;
      this.ePhase = IllustController.PhaseMode.PinchiInOut;
    }
    this.isPressFrame = false;
    this.isReleaseFrame = false;
  }

  private void IsCheckRestrictWithinBounds()
  {
    this.scrollPicture.Press(true);
    this.scrollPicture.RestrictWithinBounds(true, true, true);
    this.scrollPicture.Press(false);
  }

  private void OnDestroy() => this.SetCameraAllowMultiTouch(false);

  private void PinchiInOut(float movement)
  {
    float delta = movement * this.pinchiInOutWeight;
    Vector3 picturePosition = new Vector3(this.targetPicture.transform.localPosition.x, this.targetPicture.transform.localPosition.y);
    Vector3 scrollPosition = new Vector3(this.scrollPicture.transform.localPosition.x, this.scrollPicture.transform.localPosition.y);
    Vector3 currentScale = new Vector3(this.targetPicture.transform.localScale.x, this.targetPicture.transform.localScale.y);
    Vector3 nextScale = this.SetNextScale(this.targetPicture.transform.localScale.x, delta);
    this.targetPicture.transform.localPosition = this.SetNextPosition(picturePosition, scrollPosition, currentScale, nextScale);
    this.targetPicture.transform.localScale = nextScale;
    this.IsCheckRestrictWithinBounds();
  }

  private Vector3 SetNextPosition(
    Vector3 picturePosition,
    Vector3 scrollPosition,
    Vector3 currentScale,
    Vector3 nextScale)
  {
    return new Vector3((picturePosition.x + scrollPosition.x) / currentScale.x * nextScale.x - scrollPosition.x, (picturePosition.y + scrollPosition.y) / currentScale.y * nextScale.y - scrollPosition.y);
  }

  private Vector3 SetNextScale(float scale, float delta)
  {
    double num = (double) Mathf.Min(Mathf.Max(scale + delta, this.fitScale), this.imageMaxSize);
    return new Vector3((float) num, (float) num);
  }

  private void InitSize()
  {
    this.targetPicture.transform.localScale = new Vector3(this.fitScale, this.fitScale, this.fitScale);
    this.targetPicture.transform.localPosition = Vector3.zero;
    this.scrollPicture.transform.localPosition = Vector3.zero;
  }

  private void OnDoubleClick()
  {
    this.isTapStart = false;
    this.InitSize();
  }

  private void OnClick()
  {
    this.isTapStart = true;
    this.StartCoroutine(this.ClickAction(this.doubleClickIntervalTime, false));
  }

  private void OnPress(bool isDown)
  {
    this.isPressFrame = true;
    if (isDown)
      return;
    this.isReleaseFrame = true;
  }

  private IEnumerator ClickAction(float delay, bool isDoubleClick)
  {
    yield return (object) new WaitForSeconds(delay);
    if (this.isTapStart)
      this.callback();
  }

  private enum PhaseMode
  {
    Drag,
    PinchiInOut,
    None,
  }
}
