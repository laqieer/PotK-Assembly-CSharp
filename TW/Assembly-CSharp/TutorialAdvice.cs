// Decompiled with JetBrains decompiler
// Type: TutorialAdvice
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UniLinq;
using UnityEngine;

#nullable disable
public class TutorialAdvice : MonoBehaviour
{
  public System.Action FinishCallback = (System.Action) (() => { });
  [SerializeField]
  private UILabel label;
  [SerializeField]
  private GameObject messageArrow;
  [SerializeField]
  private GameObject wrap;
  [SerializeField]
  private GameObject mainPanel;
  [SerializeField]
  private Transform messageBoxOffset;
  [SerializeField]
  private Transform backgroundRoot;
  [SerializeField]
  private TutorialMessageBox[] messageBox;
  [SerializeField]
  private TutorialAdvice.Advice[] currentAdvices = new TutorialAdvice.Advice[0];
  [SerializeField]
  private int currentMessageIndex;
  private readonly Regex characterPattern = new Regex("#character (\\d+)");
  private readonly Regex backgroundPattern = new Regex("#background (\\w+)");
  private readonly Regex facePattern = new Regex("#face (\\w+)");
  private readonly Regex itemPattern = new Regex("#item ([a-z]+)");
  private readonly Regex keyPattern = new Regex("#item key(\\d+)");
  private readonly Regex yPattern = new Regex("#y ([+-]?\\d+)");
  private readonly Regex messageBoxPattern = new Regex("#messagebox (\\d+)");
  private bool on_tap_enable = true;
  private Dictionary<string, Func<Transform, UIButton>> next_button_info;
  private string _screenName;

  public bool IsShow => this.currentMessageIndex < this.currentAdvices.Length;

  public void SetMessage(
    string screenName,
    string message,
    Dictionary<string, Func<Transform, UIButton>> next_button_info = null)
  {
    if (screenName != null)
      this._screenName = screenName;
    this.userEvent4ScreenStart();
    this.next_button_info = next_button_info;
    this.currentMessageIndex = 0;
    this.currentAdvices = this.parseMessage(message);
    this.setBackgroundPrefabs();
    if (((IEnumerable<TutorialAdvice.Advice>) this.currentAdvices).Select<TutorialAdvice.Advice, string>((Func<TutorialAdvice.Advice, string>) (x => x.Background)).Where<string>((Func<string, bool>) (x => !string.IsNullOrEmpty(x) && x != "empty")).Count<string>() != 0)
      return;
    this.showMessage();
  }

  public void OnTap()
  {
    if (!this.on_tap_enable)
      return;
    this.OnTapAction();
  }

  private void OnTapAction()
  {
    ++this.currentMessageIndex;
    if (this.IsShow)
    {
      Debug.Log((object) ("tap show next message index=" + (object) this.currentMessageIndex));
      this.userEvent();
      this.showMessage();
    }
    else
    {
      Debug.Log((object) "tap finish");
      this.Hide();
      this.userEvent4ScreenEnd();
      this.FinishCallback();
    }
  }

  private void userEvent4ScreenStart()
  {
    UserEvent.SendEvent4TutorialScreenShow((MonoBehaviour) this, this._screenName);
  }

  private void userEvent4ScreenEnd()
  {
    UserEvent.SendEvent4TotorialScreenClose((MonoBehaviour) this, this._screenName);
  }

  private void userEvent()
  {
    int index = this.currentMessageIndex - 1;
    if (index >= 0 && index < this.currentAdvices.Length)
    {
      TutorialAdvice.Advice currentAdvice = this.currentAdvices[index];
      if (currentAdvice != null)
        UserEvent.SendByTutorialBGClose((MonoBehaviour) this, this._screenName, currentAdvice.Background);
    }
    if (!this.IsShow)
      return;
    TutorialAdvice.Advice currentAdvice1 = this.currentAdvices[this.currentMessageIndex];
    if (currentAdvice1 == null)
      return;
    UserEvent.SendByTutorialBGShow((MonoBehaviour) this, this._screenName, currentAdvice1.Background);
  }

  public void Init() => this.wrap.SetActive(false);

  public void Show() => this.wrap.SetActive(true);

  public void Hide()
  {
    this.wrap.SetActive(false);
    this.backgroundRoot.Clear();
  }

  private IEnumerable<string> getBackgrounds()
  {
    return ((IEnumerable<TutorialAdvice.Advice>) this.currentAdvices).Select<TutorialAdvice.Advice, string>((Func<TutorialAdvice.Advice, string>) (x => x.Background)).Where<string>((Func<string, bool>) (x => !string.IsNullOrEmpty(x) && x != "empty")).Distinct<string>();
  }

  private void setBackgroundPrefabs()
  {
    this.backgroundRoot.Clear();
    Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();
    foreach (string background in this.getBackgrounds())
      dictionary.Add(background, new GameObject(background)
      {
        transform = {
          parent = this.backgroundRoot,
          localScale = Vector3.one
        }
      });
    bool flag = true;
    foreach (string background in this.getBackgrounds())
    {
      string path = "Prefabs/Tutorial/Backgrounds/" + background;
      GameObject container = dictionary[background];
      if (flag)
        Singleton<ResourceManager>.GetInstance().LoadOrNull<GameObject>(path).RunOn<GameObject>((MonoBehaviour) this, (Action<GameObject>) (prefab =>
        {
          if (Object.op_Inequality((Object) prefab, (Object) null))
          {
            GameObject root = prefab.Clone(container.transform);
            this.setAnchor(root, path);
            root.transform.localScale = Vector3.one;
          }
          else
            Debug.LogWarning((object) ("Tutorial: not found background path=" + path));
          this.showMessage();
        }));
      else
        Singleton<ResourceManager>.GetInstance().LoadOrNull<GameObject>(path).RunOn<GameObject>((MonoBehaviour) this, (Action<GameObject>) (prefab =>
        {
          if (Object.op_Inequality((Object) prefab, (Object) null))
          {
            GameObject root = prefab.Clone(container.transform);
            this.setAnchor(root, path);
            root.transform.localScale = Vector3.one;
          }
          else
            Debug.LogWarning((object) ("Tutorial: not found background path=" + path));
        }));
      flag = false;
    }
  }

  private void setAnchor(GameObject root, string path)
  {
    Transform transform = root.transform;
    for (int index = 0; index < transform.childCount; ++index)
    {
      Transform child = transform.GetChild(index);
      UIWidget component = ((Component) child).GetComponent<UIWidget>();
      if (Object.op_Inequality((Object) component, (Object) null))
      {
        switch (((Object) child).name.ToLower())
        {
          case "top":
            component.SetAnchor(this.mainPanel, 0, 0, 0, -960);
            component.bottomAnchor.relative = 1f;
            continue;
          case "bottom":
            component.SetAnchor(this.mainPanel, 0, 960, 0, 0);
            component.topAnchor.relative = 0.0f;
            continue;
          default:
            continue;
        }
      }
      else
        Debug.LogError((object) ("background bottom but widget not found. path=" + path));
    }
  }

  private void showMessage()
  {
    this.Show();
    TutorialAdvice.Advice currentAdvice = this.currentAdvices[this.currentMessageIndex];
    for (int index = 0; index < this.messageBox.Length; ++index)
    {
      bool flag = index == currentAdvice.MessageBoxType;
      ((Component) this.messageBox[index]).gameObject.SetActive(flag);
      if (flag)
        this.messageBox[currentAdvice.MessageBoxType].Init(currentAdvice.Message, currentAdvice.CharacterIndex, this.currentMessageIndex < this.currentAdvices.Length - 1, currentAdvice.Face, currentAdvice.Item, currentAdvice.Key);
    }
    this.messageBoxOffset.localPosition = new Vector3(0.0f, (float) currentAdvice.Y, 0.0f);
    this.on_tap_enable = true;
    for (int index = 0; index < this.backgroundRoot.childCount; ++index)
    {
      Transform child = this.backgroundRoot.GetChild(index);
      bool flag = ((Object) child).name == currentAdvice.Background;
      ((Component) child).gameObject.SetActive(flag);
      if (flag && this.next_button_info != null && this.next_button_info.ContainsKey(((Object) child).name))
      {
        UIButton uiButton = this.next_button_info[((Object) child).name](child);
        if (Object.op_Inequality((Object) uiButton, (Object) null))
        {
          this.on_tap_enable = false;
          EventDelegate.Add(uiButton.onClick, new EventDelegate.Callback(this.OnTapAction));
        }
      }
    }
  }

  private TutorialAdvice.Advice[] parseMessage(string message)
  {
    List<TutorialAdvice.Advice> adviceList = new List<TutorialAdvice.Advice>();
    int messageBoxType = 0;
    int characterIndex = 0;
    int positionY = 0;
    string background = string.Empty;
    string face = string.Empty;
    string item = string.Empty;
    int key = 1;
    string str1 = message.Replace("\r", string.Empty);
    string[] separator = new string[1]{ "\n\n" };
    foreach (string str2 in str1.Split(separator, StringSplitOptions.RemoveEmptyEntries))
    {
      List<string> self = new List<string>();
      string str3 = str2;
      char[] chArray = new char[1]{ '\n' };
      foreach (string input in str3.Split(chArray))
      {
        if (input.StartsWith("#"))
        {
          bool flag = this.find_int1(input, this.messageBoxPattern, (Action<int>) (num => messageBoxType = num)) || this.find_int1(input, this.characterPattern, (Action<int>) (num => characterIndex = num)) || this.find_int1(input, this.yPattern, (Action<int>) (num => positionY = num)) || this.find_string1(input, this.backgroundPattern, (Action<string>) (s => background = s)) || this.find_string1(input, this.facePattern, (Action<string>) (s => face = s)) || this.find_string1(input, this.itemPattern, (Action<string>) (s => item = s));
          if (flag)
            this.find_int1(input, this.keyPattern, (Action<int>) (num => key = num));
          if (!flag)
            Debug.LogWarning((object) ("Tutorial Can't parse " + input));
        }
        else
          self.Add(input);
      }
      adviceList.Add(new TutorialAdvice.Advice()
      {
        MessageBoxType = messageBoxType,
        CharacterIndex = characterIndex,
        Message = self.Join("\n"),
        Background = background,
        Face = face,
        Item = item,
        Key = key,
        Y = positionY
      });
    }
    return adviceList.ToArray();
  }

  private bool find_int1(string input, Regex regex, Action<int> callback)
  {
    return this.find_string1(input, regex, (Action<string>) (s =>
    {
      int result = 0;
      if (int.TryParse(s, out result))
        callback(result);
      else
        Debug.LogError((object) string.Format("PARSE ERROR regex={0} code={1}", (object) regex, (object) input));
    }));
  }

  private bool find_string1(string input, Regex regex, Action<string> callback)
  {
    Match match = regex.Match(input);
    if (match.Success)
      callback(match.Groups[1].Value);
    return match.Success;
  }

  [Serializable]
  private class Advice
  {
    public string Message;
    public int MessageBoxType;
    public int CharacterIndex;
    public string Background;
    public string Face;
    public string Item;
    public int Key;
    public int Y;
  }
}
