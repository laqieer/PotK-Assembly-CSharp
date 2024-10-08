﻿// Decompiled with JetBrains decompiler
// Type: Startup00010DLMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UniLinq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup00010DLMenu : MonoBehaviour
{
  [SerializeField]
  private NGWrapScrollParts scroll;
  [SerializeField]
  private UILabel TxtPercentage;
  [SerializeField]
  private NGTweenGaugeScale gaugeScale;
  [SerializeField]
  private TweenAlpha fade;
  [SerializeField]
  private GameObject DownLoadVar;
  [SerializeField]
  private GameObject LeftArrow;
  [SerializeField]
  private GameObject RightArrow;
  private int count;
  private bool isArrowBtn = true;
  private bool prevDragging;
  private bool isScrolling;
  private GameObject tipsLabelObject;
  private StartupDownLoad.State state;

  public void onStartSceneAsync()
  {
    this.fade.PlayForward();
    this.gaugeScale.setValue(0, 100, false);
    StartupDownLoad.StartDownload(true);
  }

  public void Update()
  {
    float f = Mathf.Clamp((float) StartupDownLoad.progressNum() / (float) StartupDownLoad.progressDem() * 100f, 0.0f, 100f);
    this.TxtPercentage.SetTextLocalize(((int) f).ToString() + "％");
    this.gaugeScale.setValue(Mathf.FloorToInt(f), 100, false);
    this.state = StartupDownLoad.state;
    switch (this.state)
    {
      case StartupDownLoad.State.Processing:
        if ((int) StartupDownLoad.progressNum() == 0)
          break;
        this.DLStart();
        break;
      case StartupDownLoad.State.Completed:
        this.DLComplete();
        break;
    }
  }

  private void DLStart()
  {
    this.DownLoadVar.SetActive(true);
    if (!this.LeftArrow.activeSelf)
      this.LeftArrow.SetActive(true);
    if (this.RightArrow.activeSelf)
      return;
    this.RightArrow.SetActive(true);
  }

  private void DLComplete() => this.StartCoroutine(this.SceneChange());

  private IEnumerator SceneChange()
  {
    yield return (object) new WaitForSeconds(0.1f);
    SceneManager.LoadScene("main");
  }

  public void IbtnLeftArrow()
  {
    if (!this.isArrowBtn)
      return;
    this.isArrowBtn = false;
    this.isScrolling = true;
    this.count = this.scroll.selected - 1;
    if (this.count < 0)
      this.count = this.scroll.GetContentChildren().Count<GameObject>() - 1;
    this.scroll.centerOnChild.onFinished = (SpringPanel.OnFinished) (() =>
    {
      this.isArrowBtn = true;
      this.isScrolling = false;
    });
    this.scroll.setItemPosition(this.count);
  }

  public void IbtnRightArrow()
  {
    if (!this.isArrowBtn)
      return;
    this.isArrowBtn = false;
    this.isScrolling = true;
    this.count = this.scroll.selected + 1;
    if (this.count >= this.scroll.GetContentChildren().Count<GameObject>())
      this.count = 0;
    this.scroll.centerOnChild.onFinished = (SpringPanel.OnFinished) (() =>
    {
      this.isArrowBtn = true;
      this.isScrolling = false;
    });
    this.scroll.setItemPosition(this.count);
  }
}
