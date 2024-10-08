﻿// Decompiled with JetBrains decompiler
// Type: NGWrapScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class NGWrapScrollParts : MonoBehaviour
{
  public GameObject dotPrefab;
  public GameObject scrollView;
  public GameObject leftArrow;
  public GameObject rightArrow;
  public UIWidget dot;
  public UIWrapContent content;
  public UICenterOnChild centerOnChild;
  public GameObject eventReceiver;
  public string functionName = "onItemChanged";
  public bool isSpringPanelCheck;
  protected int nbParts;
  private bool forceArrowDisplay;
  [SerializeField]
  private bool seEnable = true;
  private List<SelectParts> dotList = new List<SelectParts>();
  private Queue<GameObject> tempParts = new Queue<GameObject>();
  private GameObject tempPartsObj;
  private float scrollX = float.NaN;
  public int selected = -1;

  public bool SeEnable
  {
    get => this.seEnable;
    set => this.seEnable = value;
  }

  public void ForceArrowDisplay(bool flg = false)
  {
    this.forceArrowDisplay = true;
    this.leftArrow.GetComponent<NGTweenParts>().isActive = flg;
    this.rightArrow.GetComponent<NGTweenParts>().isActive = flg;
  }

  private void initTempParts()
  {
    if (!Object.op_Equality((Object) this.tempPartsObj, (Object) null))
      return;
    this.tempPartsObj = new GameObject("tempParts");
    this.tempPartsObj.transform.parent = ((Component) this).transform;
    this.tempPartsObj.SetActive(false);
  }

  private void Awake()
  {
    this.initTempParts();
    for (int index = 0; index < ((Component) this.content).gameObject.transform.childCount; ++index)
      this.addNbParts();
  }

  public void initParts(GameObject prefab, int nb)
  {
    this.initTempParts();
    for (int index = 0; index < nb; ++index)
    {
      GameObject gameObject = NGUITools.AddChild(this.tempPartsObj, prefab);
      gameObject.transform.localScale = Vector3.one;
      this.tempParts.Enqueue(gameObject);
    }
  }

  public GameObject instantiateParts(GameObject partsPrefab, bool isChache = true)
  {
    GameObject gameObject;
    if (isChache && this.tempParts.Count > 0)
    {
      gameObject = this.tempParts.Dequeue();
      gameObject.transform.parent = ((Component) this.content).gameObject.transform;
      gameObject.transform.localPosition = Vector3.zero;
      gameObject.transform.localScale = Vector3.one;
    }
    else
      gameObject = NGUITools.AddChild(((Component) this.content).gameObject, partsPrefab);
    this.addNbParts();
    return gameObject;
  }

  public void destroyParts(bool isChache = true)
  {
    if (isChache)
    {
      List<Transform> transformList = new List<Transform>();
      foreach (Transform transform in ((Component) this.content).gameObject.transform)
      {
        transform.localPosition = Vector3.zero;
        transformList.Add(transform);
      }
      foreach (Transform transform in transformList)
      {
        transform.parent = this.tempPartsObj.transform;
        this.tempParts.Enqueue(((Component) transform).gameObject);
      }
      transformList.Clear();
    }
    else
      ((Component) this.content).gameObject.transform.Clear();
    if (Object.op_Inequality((Object) this.dot, (Object) null))
    {
      ((Component) this.dot).transform.Clear();
      this.dotList.Clear();
    }
    this.nbParts = 0;
    this.scrollX = float.NaN;
    this.selected = -1;
  }

  protected void addNbParts()
  {
    ++this.nbParts;
    if (!Object.op_Inequality((Object) this.dot, (Object) null) || !Object.op_Inequality((Object) this.dotPrefab, (Object) null))
      return;
    SelectParts component = this.dotPrefab.CloneAndGetComponent<SelectParts>(((Component) this.dot).transform);
    foreach (NGTweenParts componentsInChild in ((Component) component).GetComponentsInChildren<NGTweenParts>(true))
      componentsInChild.timeOutTime = 0.2f;
    this.dotList.Add(component);
    this.resetDotTranslate();
  }

  private void resetDotTranslate()
  {
    if (Object.op_Equality((Object) this.dot, (Object) null) || Object.op_Equality((Object) this.dotPrefab, (Object) null))
      return;
    float width = (float) this.dotPrefab.GetComponent<UIWidget>().width;
    float num1 = width * 1.2f;
    float num2 = (float) ((double) (-this.dotList.Count / 2) * (double) num1 + (this.dotList.Count % 2 != 1 ? (double) width / 2.0 : 0.0));
    float num3 = 0.0f;
    foreach (SelectParts dot in this.dotList)
    {
      ((Component) dot).transform.localPosition = new Vector3(num3 + num2, ((Component) dot).transform.localPosition.y, ((Component) dot).transform.localPosition.z);
      num3 += num1;
    }
    this.setDotAndArrow(this.selected);
  }

  private int calcSelectPosition()
  {
    float num1 = this.scrollView.transform.localPosition.x % (float) (this.content.itemSize * this.nbParts);
    if ((double) num1 <= 0.0)
      return (int) Mathf.Abs((num1 - (float) (this.content.itemSize / 2)) / (float) this.content.itemSize);
    float num2 = num1 + (float) (this.content.itemSize / 2);
    return this.nbParts - (int) Mathf.Abs(num2 / (float) this.content.itemSize) >= this.nbParts ? this.nbParts - 1 : this.nbParts - (int) Mathf.Abs(num2 / (float) this.content.itemSize);
  }

  private void setDotAndArrow(int idx)
  {
    int num = 0;
    foreach (SelectParts dot in this.dotList)
    {
      if (num == idx)
        dot.setValue(1);
      else
        dot.setValue(0);
      ++num;
    }
    if (this.forceArrowDisplay)
      return;
    if (idx != -1 && Object.op_Inequality((Object) this.leftArrow, (Object) null))
      this.leftArrow.GetComponent<NGTweenParts>().isActive = idx != 0;
    if (idx == -1 || !Object.op_Inequality((Object) this.rightArrow, (Object) null))
      return;
    this.rightArrow.GetComponent<NGTweenParts>().isActive = idx < this.nbParts - 1;
  }

  private void setDotAndArrowForth(int idx)
  {
    this.setDotAndArrow(idx);
    if (idx != -1 && Object.op_Inequality((Object) this.leftArrow, (Object) null))
    {
      UIWidget component = this.leftArrow.GetComponent<UIWidget>();
      if (idx != 0)
        component.alpha = 1f;
    }
    if (idx == -1 || !Object.op_Inequality((Object) this.rightArrow, (Object) null))
      return;
    UIWidget component1 = this.rightArrow.GetComponent<UIWidget>();
    if (idx >= this.nbParts - 1)
      return;
    component1.alpha = 1f;
  }

  private void LateUpdate()
  {
    if ((double) this.scrollX == (double) this.scrollView.transform.localPosition.x)
      return;
    this.scrollX = this.scrollView.transform.localPosition.x;
    int idx = this.calcSelectPosition();
    if (idx == this.selected)
      return;
    this.setDotAndArrow(idx);
    this.selected = idx;
    this.playSE();
    if (!Object.op_Inequality((Object) this.eventReceiver, (Object) null) || string.IsNullOrEmpty(this.functionName))
      return;
    SpringPanel component = this.scrollView.GetComponent<SpringPanel>();
    if (!this.isSpringPanelCheck || Object.op_Equality((Object) component, (Object) null) || !((Behaviour) component).enabled)
      this.eventReceiver.SendMessage(this.functionName, (object) this.selected, (SendMessageOptions) 1);
    else
      component.onFinished = (SpringPanel.OnFinished) (() => this.eventReceiver.SendMessage(this.functionName, (object) this.selected, (SendMessageOptions) 1));
  }

  public void playSE()
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!Object.op_Inequality((Object) instance, (Object) null) || !this.seEnable)
      return;
    instance.playSE("SE_1005");
  }

  public void setItemPosition(int idx)
  {
    UICenterOnChild component = ((Component) this.content).gameObject.GetComponent<UICenterOnChild>();
    if (Object.op_Equality((Object) component, (Object) null))
      return;
    this.selected = -1;
    if (idx < 0)
      return;
    if (idx >= ((Component) this.content).gameObject.transform.childCount)
      return;
    try
    {
      Transform child = ((Component) this.content).gameObject.transform.GetChild(idx);
      component.CenterOn(child);
    }
    catch (Exception ex)
    {
    }
  }

  public void setItemPositionQuick(int idx)
  {
    if (idx < 0 || idx >= ((Component) this.content).gameObject.transform.childCount)
    {
      Debug.LogWarning((object) ("invalid childIndex=" + (object) idx));
    }
    else
    {
      this.selected = idx;
      Vector3 localPosition = this.scrollView.transform.localPosition;
      this.scrollView.transform.localPosition = new Vector3((float) (-this.content.itemSize * this.selected), localPosition.y, localPosition.z);
      this.scrollView.GetComponent<UIPanel>().clipOffset = Vector2.op_Implicit(new Vector3((float) (this.content.itemSize * this.selected), localPosition.y, localPosition.z));
      this.setDotAndArrow(this.selected);
    }
  }

  public GameObject getItem(int idx, Transform tra = null)
  {
    if (Object.op_Equality((Object) tra, (Object) null))
      tra = ((Component) this.content).gameObject.transform;
    int num = 0;
    foreach (Transform transform in tra)
    {
      if (num == idx)
        return ((Component) transform).gameObject;
      ++num;
    }
    return (GameObject) null;
  }

  public GameObject GetContentChild(int index)
  {
    return ((Component) ((Component) this.content).gameObject.transform.GetChild(index)).gameObject;
  }

  public IEnumerable<GameObject> GetContentChildren()
  {
    return ((Component) this.content).gameObject.transform.GetChildren().Select<Transform, GameObject>((Func<Transform, GameObject>) (t => ((Component) t).gameObject));
  }

  public void ResetPosition()
  {
    this.scrollView.transform.localPosition = Vector3.zero;
    this.scrollView.GetComponent<UIPanel>().clipOffset = Vector2.zero;
  }
}
