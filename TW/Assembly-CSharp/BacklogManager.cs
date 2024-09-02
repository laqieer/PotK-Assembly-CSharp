// Decompiled with JetBrains decompiler
// Type: BacklogManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using UnityEngine;

#nullable disable
public class BacklogManager : MonoBehaviour
{
  [SerializeField]
  private GameObject message_obj;
  public GameObject scroll_view_obj;
  public GameObject bg_obj;
  public GameObject logContainer;
  public BoxCollider skipBtn;
  public BoxCollider logBtn;
  public GameObject closeBtn;
  public GameObject logHeader;
  private List<string> log_data = new List<string>();
  private List<GameObject> clone_data = new List<GameObject>();
  private UIScrollView scroll_view;
  private int scroll_height;
  private System.Action endAction;
  private readonly string patternBBCode = "(\\[[0-9a-f]{6}\\])|(\\[\\-\\])|(\\[b\\])|(\\[\\/b\\])|(\\[i\\])|(\\[\\/i\\])|(\\[u\\])|(\\[\\/u\\])|(\\[s\\])|(\\[\\/s\\])|(\\[sub\\])|(\\[\\/sub\\])|(\\[sup\\])|(\\[\\/sup\\])|(\\[url=.*?\\])|(\\[\\/url\\])";

  private void Start() => this.StartCoroutine(this.Initialize());

  private void Update()
  {
    if (!this.logContainer.activeSelf || !Input.GetKeyUp((KeyCode) 27))
      return;
    this.endAction();
  }

  [DebuggerHidden]
  private IEnumerator Initialize()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BacklogManager.\u003CInitialize\u003Ec__Iterator56A()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Add(string name, string msg)
  {
    if (msg == string.Empty)
      return;
    string str1 = this.NormalizeBBCode(name);
    string str2 = this.NormalizeBBCode(msg);
    this.log_data.Add("[" + (this.log_data.Count % 2 != 0 ? (object) "FFFFCC" : (object) "FFFFFF") + "]" + str1 + (object) '\n' + str2 + (object) '\n' + (object) '\n');
  }

  public void StartBacklog(System.Action endAction)
  {
    this.End();
    this.endAction = endAction;
    this.logContainer.SetActive(true);
    this.closeBtn.SetActive(true);
    this.logHeader.SetActive(true);
    ((Collider) this.skipBtn).enabled = false;
    ((Collider) this.logBtn).enabled = false;
    int num1 = this.scroll_height / 2;
    int num2 = 0;
    foreach (string str in this.log_data)
    {
      int crlf = this.GetCRLF(str);
      GameObject gameObject = Object.Instantiate((Object) this.message_obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
      UILabel component = gameObject.GetComponent<UILabel>();
      int num3 = (component.fontSize + component.spacingY) * crlf;
      component.SetText(str);
      component.height = num3;
      gameObject.transform.parent = this.scroll_view_obj.transform;
      gameObject.transform.localPosition = new Vector3(-3f, (float) (num1 - num3 / 2), 0.0f);
      gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
      this.clone_data.Add(gameObject);
      num1 -= num3;
      num2 += num3;
    }
    this.scroll_view.ResetPosition();
    if (num2 < this.scroll_height)
    {
      ((Behaviour) this.scroll_view).enabled = false;
    }
    else
    {
      ((Behaviour) this.scroll_view).enabled = true;
      float y = ((Component) this.scroll_view).GetComponent<UIPanel>().GetViewSize().y;
      this.scroll_view.MoveRelative(new Vector3(0.0f, (float) num2 - y, 0.0f));
    }
    this.bg_obj.SetActive(true);
    this.bg_obj.GetComponent<UIWidget>().alpha = 0.98f;
  }

  private string NormalizeBBCode(string input)
  {
    string empty = string.Empty;
    return Regex.Replace(input, this.patternBBCode, empty);
  }

  public void End()
  {
    foreach (Object @object in this.clone_data)
      Object.Destroy(@object);
    this.clone_data.Clear();
    this.logContainer.SetActive(false);
    this.closeBtn.SetActive(false);
    this.logHeader.SetActive(false);
    this.bg_obj.SetActive(false);
    ((Collider) this.skipBtn).enabled = true;
    ((Collider) this.logBtn).enabled = true;
  }

  public bool IsEnable() => this.bg_obj.activeSelf;

  private int GetCRLF(string s)
  {
    return s.Split(new char[1]{ '\n' }, StringSplitOptions.None).Length;
  }
}
