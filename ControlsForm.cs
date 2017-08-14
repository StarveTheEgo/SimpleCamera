// Decompiled with JetBrains decompiler
// Type: SimpleCamera.ControlsForm
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace SimpleCamera
{
  public class ControlsForm : Form
  {
    private List<HotkeyBox> hotkeys = new List<HotkeyBox>();
    private Hashtable hotkeyHash = new Hashtable(50);
    private IContainer components;
    private HotkeyBox hbFPS;
    private Label label16;
    private HotkeyBox hbFacing;
    private Label label15;
    private HotkeyBox hbActivateToggle;
    private Label label14;
    private Label label12;
    private Label label11;
    private HotkeyBox hbDistanceDecrease;
    private HotkeyBox hbFollow;
    private HotkeyBox hbDistanceIncrease;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private HotkeyBox hbMoveRight;
    private HotkeyBox hbMoveLeft;
    private HotkeyBox hbMoveBackward;
    private HotkeyBox hbMoveForward;
    private Label label1;
    private HotkeyBox hbRotateRight;
    private HotkeyBox hbRotateLeft;
    private Label label7;
    private Button btnOk;
    private Label label8;
    private HotkeyBox hbDescend;
    private Label label9;
    private HotkeyBox hbAscend;
    private Label label10;
    private HotkeyBox[] ctrlMemory;
    private HotkeyBox hbCtrl;
    public HotkeyBox activationHotkey;

    public ControlsForm()
    {
      this.InitializeComponent();
      foreach (object control in (ArrangedElementCollection) this.Controls)
      {
        if (control is HotkeyBox)
        {
          HotkeyBox hotkeyBox = (HotkeyBox) control;
          this.hotkeys.Add(hotkeyBox);
          if (hotkeyBox.Name.Equals("hbActivateToggle"))
            this.activationHotkey = hotkeyBox;
        }
      }
      this.ctrlMemory = new HotkeyBox[10];
      for (int index = 0; index < 10; ++index)
      {
        this.hotkeys.Add(this.ctrlMemory[index] = new HotkeyBox());
        this.ctrlMemory[index].Name = "hb" + (object) index;
      }
      this.ctrlMemory[0].Hotkey = Keys.D0;
      this.ctrlMemory[1].Hotkey = Keys.D1;
      this.ctrlMemory[2].Hotkey = Keys.D2;
      this.ctrlMemory[3].Hotkey = Keys.D3;
      this.ctrlMemory[4].Hotkey = Keys.D4;
      this.ctrlMemory[5].Hotkey = Keys.D5;
      this.ctrlMemory[6].Hotkey = Keys.D6;
      this.ctrlMemory[7].Hotkey = Keys.D7;
      this.ctrlMemory[8].Hotkey = Keys.D8;
      this.ctrlMemory[9].Hotkey = Keys.D9;
      this.hotkeys.Add(this.hbCtrl = new HotkeyBox());
      this.hbCtrl.Name = "hbCtrl";
      this.hbCtrl.Hotkey = Keys.ControlKey;
      foreach (HotkeyBox hotkey in this.hotkeys)
        this.hotkeyHash.Add((object) hotkey.Name, (object) hotkey);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.hbFPS = new HotkeyBox();
      this.label16 = new Label();
      this.hbFacing = new HotkeyBox();
      this.label15 = new Label();
      this.hbActivateToggle = new HotkeyBox();
      this.label14 = new Label();
      this.label12 = new Label();
      this.label11 = new Label();
      this.hbDistanceDecrease = new HotkeyBox();
      this.hbFollow = new HotkeyBox();
      this.hbDistanceIncrease = new HotkeyBox();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.hbMoveRight = new HotkeyBox();
      this.hbMoveLeft = new HotkeyBox();
      this.hbMoveBackward = new HotkeyBox();
      this.hbMoveForward = new HotkeyBox();
      this.label1 = new Label();
      this.hbRotateRight = new HotkeyBox();
      this.hbRotateLeft = new HotkeyBox();
      this.label7 = new Label();
      this.btnOk = new Button();
      this.label8 = new Label();
      this.hbDescend = new HotkeyBox();
      this.label9 = new Label();
      this.hbAscend = new HotkeyBox();
      this.label10 = new Label();
      this.SuspendLayout();
      this.hbFPS.AccessibleName = "";
      this.hbFPS.AllowModifiers = false;
      this.hbFPS.Hotkey = Keys.F1;
      this.hbFPS.HotkeyModifiers = Keys.None;
      this.hbFPS.Location = new Point(252, 107);
      this.hbFPS.MaximumSize = new Size(9999, 20);
      this.hbFPS.MinimumSize = new Size(20, 20);
      this.hbFPS.Name = "hbFPS";
      this.hbFPS.Size = new Size(80, 20);
      this.hbFPS.TabIndex = 53;
      this.label16.AutoSize = true;
      this.label16.Location = new Point(182, 110);
      this.label16.Name = "label16";
      this.label16.Size = new Size(65, 13);
      this.label16.TabIndex = 54;
      this.label16.Text = "First Person:";
      this.hbFacing.AccessibleName = "";
      this.hbFacing.AllowModifiers = false;
      this.hbFacing.Hotkey = Keys.F;
      this.hbFacing.HotkeyModifiers = Keys.None;
      this.hbFacing.Location = new Point(252, 162);
      this.hbFacing.MaximumSize = new Size(9999, 20);
      this.hbFacing.MinimumSize = new Size(20, 20);
      this.hbFacing.Name = "hbFacing";
      this.hbFacing.Size = new Size(80, 20);
      this.hbFacing.TabIndex = 51;
      this.label15.AutoSize = true;
      this.label15.Location = new Point(182, 165);
      this.label15.Name = "label15";
      this.label15.Size = new Size(66, 13);
      this.label15.TabIndex = 52;
      this.label15.Text = "Lock facing:";
      this.hbActivateToggle.AccessibleName = "";
      this.hbActivateToggle.AllowModifiers = false;
      this.hbActivateToggle.Hotkey = Keys.Return;
      this.hbActivateToggle.HotkeyModifiers = Keys.None;
      this.hbActivateToggle.Location = new Point(252, 84);
      this.hbActivateToggle.MaximumSize = new Size(9999, 20);
      this.hbActivateToggle.MinimumSize = new Size(20, 20);
      this.hbActivateToggle.Name = "hbActivateToggle";
      this.hbActivateToggle.Size = new Size(80, 20);
      this.hbActivateToggle.TabIndex = 50;
      this.label14.AutoSize = true;
      this.label14.Location = new Point(181, 61);
      this.label14.Name = "label14";
      this.label14.Size = new Size(137, 13);
      this.label14.TabIndex = 49;
      this.label14.Text = "Activate/Deactivate plugin:";
      this.label12.AutoSize = true;
      this.label12.Location = new Point(181, 35);
      this.label12.Name = "label12";
      this.label12.Size = new Size(55, 13);
      this.label12.TabIndex = 48;
      this.label12.Text = "Zoom out:";
      this.label11.AutoSize = true;
      this.label11.Location = new Point(181, 9);
      this.label11.Name = "label11";
      this.label11.Size = new Size(48, 13);
      this.label11.TabIndex = 47;
      this.label11.Text = "Zoom in:";
      this.hbDistanceDecrease.AccessibleName = "";
      this.hbDistanceDecrease.AllowModifiers = false;
      this.hbDistanceDecrease.Hotkey = Keys.Prior;
      this.hbDistanceDecrease.HotkeyModifiers = Keys.None;
      this.hbDistanceDecrease.Location = new Point(252, 32);
      this.hbDistanceDecrease.MaximumSize = new Size(9999, 20);
      this.hbDistanceDecrease.MinimumSize = new Size(20, 20);
      this.hbDistanceDecrease.Name = "hbDistanceDecrease";
      this.hbDistanceDecrease.Size = new Size(80, 20);
      this.hbDistanceDecrease.TabIndex = 46;
      this.hbFollow.AccessibleName = "";
      this.hbFollow.AllowModifiers = false;
      this.hbFollow.Hotkey = Keys.Space;
      this.hbFollow.HotkeyModifiers = Keys.None;
      this.hbFollow.Location = new Point(82, 217);
      this.hbFollow.MaximumSize = new Size(9999, 20);
      this.hbFollow.MinimumSize = new Size(20, 20);
      this.hbFollow.Name = "hbFollow";
      this.hbFollow.Size = new Size(80, 20);
      this.hbFollow.TabIndex = 43;
      this.hbDistanceIncrease.AccessibleName = "";
      this.hbDistanceIncrease.AllowModifiers = false;
      this.hbDistanceIncrease.Hotkey = Keys.Next;
      this.hbDistanceIncrease.HotkeyModifiers = Keys.None;
      this.hbDistanceIncrease.Location = new Point(252, 6);
      this.hbDistanceIncrease.MaximumSize = new Size(9999, 20);
      this.hbDistanceIncrease.MinimumSize = new Size(20, 20);
      this.hbDistanceIncrease.Name = "hbDistanceIncrease";
      this.hbDistanceIncrease.Size = new Size(80, 20);
      this.hbDistanceIncrease.TabIndex = 45;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(12, 139);
      this.label6.Name = "label6";
      this.label6.Size = new Size(60, 13);
      this.label6.TabIndex = 42;
      this.label6.Text = "Move right:";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(12, 113);
      this.label5.Name = "label5";
      this.label5.Size = new Size(54, 13);
      this.label5.TabIndex = 41;
      this.label5.Text = "Move left:";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(12, 87);
      this.label4.Name = "label4";
      this.label4.Size = new Size(66, 13);
      this.label4.TabIndex = 40;
      this.label4.Text = "Move down:";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(12, 61);
      this.label3.Name = "label3";
      this.label3.Size = new Size(52, 13);
      this.label3.TabIndex = 39;
      this.label3.Text = "Move up:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(12, 9);
      this.label2.Name = "label2";
      this.label2.Size = new Size(65, 13);
      this.label2.TabIndex = 38;
      this.label2.Text = "Rotate right:";
      this.hbMoveRight.AccessibleName = "";
      this.hbMoveRight.AllowModifiers = false;
      this.hbMoveRight.Hotkey = Keys.Right;
      this.hbMoveRight.HotkeyModifiers = Keys.None;
      this.hbMoveRight.Location = new Point(82, 136);
      this.hbMoveRight.MaximumSize = new Size(9999, 20);
      this.hbMoveRight.MinimumSize = new Size(20, 20);
      this.hbMoveRight.Name = "hbMoveRight";
      this.hbMoveRight.Size = new Size(80, 20);
      this.hbMoveRight.TabIndex = 37;
      this.hbMoveLeft.AccessibleName = "";
      this.hbMoveLeft.AllowModifiers = false;
      this.hbMoveLeft.Hotkey = Keys.Left;
      this.hbMoveLeft.HotkeyModifiers = Keys.None;
      this.hbMoveLeft.Location = new Point(82, 110);
      this.hbMoveLeft.MaximumSize = new Size(9999, 20);
      this.hbMoveLeft.MinimumSize = new Size(20, 20);
      this.hbMoveLeft.Name = "hbMoveLeft";
      this.hbMoveLeft.Size = new Size(80, 20);
      this.hbMoveLeft.TabIndex = 36;
      this.hbMoveBackward.AccessibleName = "";
      this.hbMoveBackward.AllowModifiers = false;
      this.hbMoveBackward.Hotkey = Keys.Down;
      this.hbMoveBackward.HotkeyModifiers = Keys.None;
      this.hbMoveBackward.Location = new Point(82, 84);
      this.hbMoveBackward.MaximumSize = new Size(9999, 20);
      this.hbMoveBackward.MinimumSize = new Size(20, 20);
      this.hbMoveBackward.Name = "hbMoveBackward";
      this.hbMoveBackward.Size = new Size(80, 20);
      this.hbMoveBackward.TabIndex = 35;
      this.hbMoveForward.AccessibleName = "";
      this.hbMoveForward.AllowModifiers = false;
      this.hbMoveForward.Hotkey = Keys.Up;
      this.hbMoveForward.HotkeyModifiers = Keys.None;
      this.hbMoveForward.Location = new Point(82, 58);
      this.hbMoveForward.MaximumSize = new Size(9999, 20);
      this.hbMoveForward.MinimumSize = new Size(20, 20);
      this.hbMoveForward.Name = "hbMoveForward";
      this.hbMoveForward.Size = new Size(80, 20);
      this.hbMoveForward.TabIndex = 34;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 35);
      this.label1.Name = "label1";
      this.label1.Size = new Size(59, 13);
      this.label1.TabIndex = 33;
      this.label1.Text = "Rotate left:";
      this.hbRotateRight.AccessibleName = "";
      this.hbRotateRight.AllowModifiers = false;
      this.hbRotateRight.Hotkey = Keys.Delete;
      this.hbRotateRight.HotkeyModifiers = Keys.None;
      this.hbRotateRight.Location = new Point(82, 6);
      this.hbRotateRight.MaximumSize = new Size(9999, 20);
      this.hbRotateRight.MinimumSize = new Size(20, 20);
      this.hbRotateRight.Name = "hbRotateRight";
      this.hbRotateRight.Size = new Size(80, 20);
      this.hbRotateRight.TabIndex = 32;
      this.hbRotateLeft.AccessibleName = "";
      this.hbRotateLeft.AllowModifiers = false;
      this.hbRotateLeft.Hotkey = Keys.Insert;
      this.hbRotateLeft.HotkeyModifiers = Keys.None;
      this.hbRotateLeft.Location = new Point(82, 32);
      this.hbRotateLeft.MaximumSize = new Size(9999, 20);
      this.hbRotateLeft.MinimumSize = new Size(20, 20);
      this.hbRotateLeft.Name = "hbRotateLeft";
      this.hbRotateLeft.Size = new Size(80, 20);
      this.hbRotateLeft.TabIndex = 31;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(12, 220);
      this.label7.Name = "label7";
      this.label7.Size = new Size(73, 13);
      this.label7.TabIndex = 44;
      this.label7.Text = "Toggle follow:";
      this.btnOk.Location = new Point(257, 268);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(75, 23);
      this.btnOk.TabIndex = 55;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.label8.AutoSize = true;
      this.label8.Location = new Point(12, 266);
      this.label8.Name = "label8";
      this.label8.Size = new Size(220, 26);
      this.label8.TabIndex = 56;
      this.label8.Text = "0-9 will load a previously stored camera state.\r\nCtrl + 0-9 will save the current camera state.";
      this.hbDescend.AccessibleName = "";
      this.hbDescend.AllowModifiers = false;
      this.hbDescend.Hotkey = Keys.NumPad0;
      this.hbDescend.HotkeyModifiers = Keys.None;
      this.hbDescend.Location = new Point(82, 191);
      this.hbDescend.MaximumSize = new Size(9999, 20);
      this.hbDescend.MinimumSize = new Size(20, 20);
      this.hbDescend.Name = "hbDescend";
      this.hbDescend.Size = new Size(80, 20);
      this.hbDescend.TabIndex = 59;
      this.label9.AutoSize = true;
      this.label9.Location = new Point(12, 168);
      this.label9.Name = "label9";
      this.label9.Size = new Size(46, 13);
      this.label9.TabIndex = 58;
      this.label9.Text = "Ascend:";
      this.hbAscend.AccessibleName = "";
      this.hbAscend.AllowModifiers = false;
      this.hbAscend.Hotkey = Keys.NumPad1;
      this.hbAscend.HotkeyModifiers = Keys.None;
      this.hbAscend.Location = new Point(82, 165);
      this.hbAscend.MaximumSize = new Size(9999, 20);
      this.hbAscend.MinimumSize = new Size(20, 20);
      this.hbAscend.Name = "hbAscend";
      this.hbAscend.Size = new Size(80, 20);
      this.hbAscend.TabIndex = 57;
      this.label10.AutoSize = true;
      this.label10.Location = new Point(12, 194);
      this.label10.Name = "label10";
      this.label10.Size = new Size(53, 13);
      this.label10.TabIndex = 60;
      this.label10.Text = "Descend:";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(344, 303);
      this.Controls.Add((Control) this.hbDescend);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.hbAscend);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.btnOk);
      this.Controls.Add((Control) this.hbFPS);
      this.Controls.Add((Control) this.label16);
      this.Controls.Add((Control) this.hbFacing);
      this.Controls.Add((Control) this.label15);
      this.Controls.Add((Control) this.hbActivateToggle);
      this.Controls.Add((Control) this.label14);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.hbDistanceDecrease);
      this.Controls.Add((Control) this.hbFollow);
      this.Controls.Add((Control) this.hbDistanceIncrease);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.hbMoveRight);
      this.Controls.Add((Control) this.hbMoveLeft);
      this.Controls.Add((Control) this.hbMoveBackward);
      this.Controls.Add((Control) this.hbMoveForward);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.hbRotateRight);
      this.Controls.Add((Control) this.hbRotateLeft);
      this.Controls.Add((Control) this.label7);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "ControlsForm";
      this.Text = "Controls";
      this.FormClosing += new FormClosingEventHandler(this.ControlsForm_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public bool isHotkeyPressed(string key)
    {
      return ((HotkeyBox) this.hotkeyHash[(object) key]).IsKeyPressed();
    }

    private void ControlsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason != CloseReason.UserClosing)
        return;
      e.Cancel = true;
      this.Hide();
    }

    public void startAll()
    {
      foreach (HotkeyBox hotkey in this.hotkeys)
        hotkey.RegisterGlobalHotkey();
    }

    public void stopAll()
    {
      foreach (HotkeyBox hotkey in this.hotkeys)
        hotkey.UnregisterGlobalHotkey();
    }

    public void startActivation()
    {
      this.activationHotkey.RegisterGlobalHotkey();
    }

    public void loadSettings()
    {
      foreach (HotkeyBox hotkey in this.hotkeys)
        hotkey.Hotkey = Settings.getSettingKey(hotkey.Name, hotkey.Hotkey);
    }

    public void saveSettings()
    {
      foreach (HotkeyBox hotkey in this.hotkeys)
        Settings.setSetting(hotkey.Name, hotkey.Hotkey);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      this.Hide();
    }
  }
}
