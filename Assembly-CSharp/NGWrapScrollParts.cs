// Decompiled with JetBrains decompiler
// Type: NGWrapScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

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
    if (!((UnityEngine.Object) this.tempPartsObj == (UnityEngine.Object) null))
      return;
    this.tempPartsObj = new GameObject("tempParts");
    this.tempPartsObj.transform.parent = this.transform;
    this.tempPartsObj.SetActive(false);
  }

  private void Awake()
  {
    this.initTempParts();
    for (int index = 0; index < this.content.gameObject.transform.childCount; ++index)
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
      gameObject.transform.parent = this.content.gameObject.transform;
      gameObject.transform.localPosition = Vector3.zero;
      gameObject.transform.localScale = Vector3.one;
    }
    else
      gameObject = NGUITools.AddChild(this.content.gameObject, partsPrefab);
    this.addNbParts();
    return gameObject;
  }

  public void destroyParts(bool isChache = true)
  {
    if (isChache)
    {
      List<Transform> transformList = new List<Transform>();
      foreach (Transform transform in this.content.gameObject.transform)
      {
        transform.localPosition = Vector3.zero;
        transformList.Add(transform);
      }
      foreach (Transform transform in transformList)
      {
        transform.parent = this.tempPartsObj.transform;
        this.tempParts.Enqueue(transform.gameObject);
      }
      transformList.Clear();
    }
    else
      this.content.gameObject.transform.Clear();
    if ((UnityEngine.Object) this.dot != (UnityEngine.Object) null)
    {
      this.dot.transform.Clear();
      this.dotList.Clear();
    }
    this.nbParts = 0;
    this.scrollX = float.NaN;
    this.selected = -1;
  }

  protected void addNbParts()
  {
    ++this.nbParts;
    if (!((UnityEngine.Object) this.dot != (UnityEngine.Object) null) || !((UnityEngine.Object) this.dotPrefab != (UnityEngine.Object) null))
      return;
    SelectParts component = this.dotPrefab.CloneAndGetComponent<SelectParts>(this.dot.transform);
    foreach (NGTweenParts componentsInChild in component.GetComponentsInChildren<NGTweenParts>(true))
      componentsInChild.timeOutTime = 0.2f;
    this.dotList.Add(component);
    this.resetDotTranslate();
  }

  private void resetDotTranslate()
  {
    if ((UnityEngine.Object) this.dot == (UnityEngine.Object) null || (UnityEngine.Object) this.dotPrefab == (UnityEngine.Object) null)
      return;
    float width = (float) this.dotPrefab.GetComponent<UIWidget>().width;
    float num1 = width * 1.2f;
    float num2 = (float) ((double) (-this.dotList.Count / 2) * (double) num1 + (this.dotList.Count % 2 == 1 ? 0.0 : (double) width / 2.0));
    float num3 = 0.0f;
    foreach (SelectParts dot in this.dotList)
    {
      dot.transform.localPosition = new Vector3(num3 + num2, dot.transform.localPosition.y, dot.transform.localPosition.z);
      num3 += num1;
    }
    this.setDotAndArrow(this.selected);
  }

  private int calcSelectPosition()
  {
    int num1 = this.content.itemSize * this.nbParts;
    int num2 = (int) ((double) this.scrollView.transform.localPosition.x - (double) this.getScrollCenterOffsetX()) % num1;
    return (num2 <= 0 ? -num2 : num1 - num2) / this.content.itemSize;
  }

  private float getScrollCenterOffsetX()
  {
    UIScrollView component = this.scrollView.GetComponent<UIScrollView>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      return (float) (this.content.itemSize / 2);
    switch (component.contentPivot)
    {
      case UIWidget.Pivot.TopLeft:
      case UIWidget.Pivot.Left:
      case UIWidget.Pivot.BottomLeft:
        return 0.0f;
      case UIWidget.Pivot.TopRight:
      case UIWidget.Pivot.Right:
      case UIWidget.Pivot.BottomRight:
        return (float) this.content.itemSize;
      default:
        return (float) (this.content.itemSize / 2);
    }
  }

  private void setDotAndArrow(int idx)
  {
    if ((UnityEngine.Object) this.dot == (UnityEngine.Object) null || (UnityEngine.Object) this.dotPrefab == (UnityEngine.Object) null)
      return;
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
    if (idx != -1 && (UnityEngine.Object) this.leftArrow != (UnityEngine.Object) null)
      this.leftArrow.GetComponent<NGTweenParts>().isActive = (uint) idx > 0U;
    if (idx == -1 || !((UnityEngine.Object) this.rightArrow != (UnityEngine.Object) null))
      return;
    this.rightArrow.GetComponent<NGTweenParts>().isActive = idx < this.nbParts - 1;
  }

  private void setDotAndArrowForth(int idx)
  {
    this.setDotAndArrow(idx);
    if (idx != -1 && (UnityEngine.Object) this.leftArrow != (UnityEngine.Object) null)
    {
      UIWidget component = this.leftArrow.GetComponent<UIWidget>();
      if (idx != 0)
        component.alpha = 1f;
    }
    if (idx == -1 || !((UnityEngine.Object) this.rightArrow != (UnityEngine.Object) null))
      return;
    UIWidget component1 = this.rightArrow.GetComponent<UIWidget>();
    if (idx >= this.nbParts - 1)
      return;
    component1.alpha = 1f;
  }

  private void LateUpdate()
  {
    if (this.nbParts <= 0 || (double) this.scrollX == (double) this.scrollView.transform.localPosition.x && Time.frameCount % 50 != 1)
      return;
    this.scrollX = this.scrollView.transform.localPosition.x;
    int idx = this.calcSelectPosition();
    if (idx == this.selected)
      return;
    this.setDotAndArrow(idx);
    this.selected = idx;
    this.playSE();
    if (!((UnityEngine.Object) this.eventReceiver != (UnityEngine.Object) null) || string.IsNullOrEmpty(this.functionName))
      return;
    SpringPanel component = this.scrollView.GetComponent<SpringPanel>();
    if (!this.isSpringPanelCheck || (UnityEngine.Object) component == (UnityEngine.Object) null || !component.enabled)
      this.eventReceiver.SendMessage(this.functionName, (object) this.selected, SendMessageOptions.DontRequireReceiver);
    else
      component.onFinished = (SpringPanel.OnFinished) (() => this.eventReceiver.SendMessage(this.functionName, (object) this.selected, SendMessageOptions.DontRequireReceiver));
  }

  public void playSE()
  {
    if (!this.seEnable)
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!((UnityEngine.Object) instance != (UnityEngine.Object) null))
      return;
    instance.playSE(Singleton<NGGameDataManager>.GetInstance().IsSea ? "SE_1043" : "SE_1005");
  }

  public void setItemPosition(int idx)
  {
    UICenterOnChild component = this.content.gameObject.GetComponent<UICenterOnChild>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      return;
    this.selected = -1;
    if (idx < 0)
      return;
    if (idx >= this.content.gameObject.transform.childCount)
      return;
    try
    {
      Transform child = this.content.gameObject.transform.GetChild(idx);
      component.CenterOn(child);
    }
    catch (Exception ex)
    {
    }
  }

  public void setItemPositionQuick(int idx)
  {
    if (idx < 0 || idx >= this.content.gameObject.transform.childCount)
    {
      Debug.LogWarning((object) ("invalid childIndex=" + (object) idx));
    }
    else
    {
      this.selected = idx;
      Vector3 localPosition = this.scrollView.transform.localPosition;
      this.scrollView.transform.localPosition = new Vector3((float) (-this.content.itemSize * this.selected), localPosition.y, localPosition.z);
      this.scrollView.GetComponent<UIPanel>().clipOffset = (Vector2) new Vector3((float) (this.content.itemSize * this.selected), localPosition.y, localPosition.z);
      this.setDotAndArrow(this.selected);
    }
  }

  public GameObject getItem(int idx, Transform tra = null)
  {
    if ((UnityEngine.Object) tra == (UnityEngine.Object) null)
      tra = this.content.gameObject.transform;
    int num = 0;
    foreach (Transform transform in tra)
    {
      if (num == idx)
        return transform.gameObject;
      ++num;
    }
    return (GameObject) null;
  }

  public GameObject GetContentChild(int index) => this.content.gameObject.transform.GetChild(index).gameObject;

  public IEnumerable<GameObject> GetContentChildren() => this.content.gameObject.transform.GetChildren().Select<Transform, GameObject>((Func<Transform, GameObject>) (t => t.gameObject));

  public void ResetPosition()
  {
    this.scrollView.transform.localPosition = Vector3.zero;
    UIPanel component = this.scrollView.GetComponent<UIPanel>();
    component.clipOffset = Vector2.zero;
    component.Refresh();
  }
}
