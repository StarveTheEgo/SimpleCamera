// Decompiled with JetBrains decompiler
// Type: SimpleCamera.HotkeyBox
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SimpleCamera
{
  public class HotkeyBox : UserControl
  {
    private bool m_AllowModifiers = true;
    private IContainer components;
    private TextBox txtBox;
    private Keys m_Key;
    private Keys m_Mod;
    private bool m_IsRegistred;

    public bool AllowModifiers
    {
      get
      {
        return this.m_AllowModifiers;
      }
      set
      {
        this.m_AllowModifiers = value;
      }
    }

    public Keys Hotkey
    {
      get
      {
        return this.m_Key;
      }
      set
      {
        this.m_Key = value;
        this.update();
      }
    }

    public Keys HotkeyModifiers
    {
      get
      {
        return this.m_Mod;
      }
      set
      {
        this.m_Mod = value;
        this.update();
      }
    }

    public event HotkeyEvent HotkeyChanged;

    public event HotkeyEvent HotkeyClicked;

    public HotkeyBox()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.txtBox = new TextBox();
      this.SuspendLayout();
      this.txtBox.AcceptsTab = true;
      this.txtBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtBox.BackColor = SystemColors.Window;
      this.txtBox.Location = new Point(0, 0);
      this.txtBox.Multiline = true;
      this.txtBox.Name = "txtBox";
      this.txtBox.ReadOnly = true;
      this.txtBox.Size = new Size(80, 20);
      this.txtBox.TabIndex = 0;
      this.txtBox.Text = "None";
      this.txtBox.KeyDown += new KeyEventHandler(this.txtBox_KeyDown);
      this.AccessibleName = "";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.txtBox);
      this.MaximumSize = new Size(9999, 20);
      this.MinimumSize = new Size(20, 20);
      this.Name = "HotkeyBox";
      this.Size = new Size(80, 20);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    [DllImport("user32.dll")]
    private static extern short GetKeyState(int nVirtKey);

    public bool IsKeyPressed()
    {
      bool flag;
      switch (HotkeyBox.GetKeyState((int) this.m_Key))
      {
        case 0:
          flag = false;
          break;
        case 1:
          flag = false;
          break;
        default:
          flag = true;
          break;
      }
      return flag;
    }

    protected virtual void OnHotkeyChanged()
    {
      if (this.HotkeyChanged == null)
        return;
      this.HotkeyChanged((object) this);
      if (!this.m_IsRegistred)
        return;
      this.RegisterGlobalHotkey();
    }

    protected virtual void OnHotkeyClicked()
    {
      if (this.HotkeyClicked == null)
        return;
      this.HotkeyClicked((object) this);
    }

    public void RegisterGlobalHotkey()
    {
      this.UnregisterGlobalHotkey();
      this.m_IsRegistred = true;
      if (this.m_Key == Keys.None)
        return;
      HotkeyBox.RegisterHotKey(this.Handle, this.GetHashCode(), ((this.m_Mod & Keys.Alt) != Keys.None ? 1 : 0) | ((this.m_Mod & Keys.Control) != Keys.None ? 2 : 0) | ((this.m_Mod & Keys.Shift) != Keys.None ? 4 : 0), (int) this.m_Key);
    }

    public void UnregisterGlobalHotkey()
    {
      this.m_IsRegistred = false;
      HotkeyBox.UnregisterHotKey(this.Handle, this.GetHashCode());
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 786)
        this.OnHotkeyClicked();
      base.WndProc(ref m);
    }

    private void update()
    {
      this.txtBox.Text = (this.m_Mod != Keys.None ? (object) (((int) this.m_Mod).ToString() + " + ") : (object) "").ToString() + (object) this.m_Key;
      this.OnHotkeyChanged();
    }

    private void txtBox_KeyDown(object sender, KeyEventArgs e)
    {
      this.m_Key = e.KeyCode != Keys.ControlKey ? e.KeyCode : Keys.None;
      this.m_Mod = !this.m_AllowModifiers ? Keys.None : e.Modifiers;
      this.update();
    }
  }
}
