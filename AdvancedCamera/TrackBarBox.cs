// Decompiled with JetBrains decompiler
// Type: AdvancedCamera.TrackBarBox
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedCamera
{
  public class TrackBarBox : UserControl
  {
    private float maxFloat = 1f;
    private bool m_isFloat;
    private int m_value;
    private float minFloat;
    private bool m_onlyUser;
    private bool tempDisabled;
    private IContainer components;
    private TrackBar barValue;
    private TextBox txtValue;

    public TickStyle TickStyle
    {
      get
      {
        return this.barValue.TickStyle;
      }
      set
      {
        this.barValue.TickStyle = value;
      }
    }

    public int TickFrequency
    {
      get
      {
        return this.barValue.TickFrequency;
      }
      set
      {
        this.barValue.TickFrequency = value;
      }
    }

    public float TickFrequencyFloat
    {
      get
      {
        return (float) ((double) this.barValue.TickFrequency / 10000.0 * ((double) this.maxFloat - (double) this.minFloat));
      }
      set
      {
        float num = this.maxFloat - this.minFloat;
        this.barValue.TickFrequency = (int) (10000.0 * (double) value / (double) num);
      }
    }

    public int Minimum
    {
      get
      {
        return this.barValue.Minimum;
      }
      set
      {
        this.barValue.Minimum = value;
      }
    }

    public int Maximum
    {
      get
      {
        return this.barValue.Maximum;
      }
      set
      {
        this.barValue.Maximum = value;
      }
    }

    public float MinimumFloat
    {
      get
      {
        return this.minFloat;
      }
      set
      {
        this.minFloat = value;
        this.Refresh();
      }
    }

    public float MaximumFloat
    {
      get
      {
        return this.maxFloat;
      }
      set
      {
        this.maxFloat = value;
        this.Refresh();
      }
    }

    public int SmallChange
    {
      get
      {
        return this.barValue.SmallChange;
      }
      set
      {
        this.barValue.SmallChange = value;
      }
    }

    public int LargeChange
    {
      get
      {
        return this.barValue.LargeChange;
      }
      set
      {
        this.barValue.LargeChange = value;
      }
    }

    public override RightToLeft RightToLeft
    {
      get
      {
        return RightToLeft.No;
      }
      set
      {
        this.barValue.RightToLeft = value;
      }
    }

    public bool IsFloat
    {
      get
      {
        return this.m_isFloat;
      }
      set
      {
        this.m_isFloat = value;
        if (!value)
          return;
        this.barValue.Maximum = 10000;
        this.barValue.Minimum = 0;
      }
    }

    public bool EventsOnlyOnUserInput
    {
      get
      {
        return this.m_onlyUser;
      }
      set
      {
        this.m_onlyUser = value;
      }
    }

    public float FloatValue
    {
      get
      {
        return (float) ((double) this.m_value / 10000.0 * ((double) this.maxFloat - (double) this.minFloat)) + this.minFloat;
      }
      set
      {
        this.m_value = (int) ((double) ((Math.Max(this.MinimumFloat, Math.Min(this.MaximumFloat, value)) - this.MinimumFloat) / (this.MaximumFloat - this.MinimumFloat)) * 10000.0);
        this.Refresh();
      }
    }

    public int IntValue
    {
      get
      {
        return Math.Max(this.Minimum, Math.Min(this.Maximum, this.m_value));
      }
      set
      {
        this.m_value = Math.Max(this.Minimum, Math.Min(this.Maximum, value));
        this.Refresh();
      }
    }

    public event ChangeEvent ValueChanged;

    public TrackBarBox()
    {
      this.InitializeComponent();
    }

    public override void Refresh()
    {
      base.Refresh();
      this.tempDisabled = true;
      if (this.IsFloat)
      {
        this.barValue.Value = this.IntValue;
        if (!this.txtValue.Focused)
          this.txtValue.Text = string.Concat((object) this.FloatValue);
      }
      else
      {
        this.barValue.Value = this.IntValue;
        if (!this.txtValue.Focused)
          this.txtValue.Text = string.Concat((object) this.IntValue);
      }
      this.tempDisabled = false;
    }

    protected virtual void OnValueChanged()
    {
      if (this.ValueChanged == null)
        return;
      this.ValueChanged((object) this);
    }

    private void barValue_Scroll(object sender, EventArgs e)
    {
      if (this.tempDisabled)
        return;
      this.m_value = this.barValue.Value;
      this.Refresh();
      this.OnValueChanged();
    }

    private void txtValue_TextChanged(object sender, EventArgs e)
    {
      if (this.tempDisabled)
        return;
      if (this.IsFloat)
      {
        float result = 0.0f;
        if (float.TryParse(this.txtValue.Text, out result))
          this.FloatValue = result;
      }
      else
      {
        int result = 0;
        if (int.TryParse(this.txtValue.Text, out result))
          this.IntValue = result;
      }
      this.Refresh();
      this.OnValueChanged();
    }

    private void txtValue_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.Refresh();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.barValue = new TrackBar();
      this.txtValue = new TextBox();
      this.barValue.BeginInit();
      this.SuspendLayout();
      this.barValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.barValue.Location = new Point(53, -1);
      this.barValue.Name = "barValue";
      this.barValue.Size = new Size(47, 45);
      this.barValue.TabIndex = 0;
      this.barValue.Scroll += new EventHandler(this.barValue_Scroll);
      this.txtValue.Location = new Point(0, 0);
      this.txtValue.Name = "txtValue";
      this.txtValue.Size = new Size(52, 20);
      this.txtValue.TabIndex = 1;
      this.txtValue.TextChanged += new EventHandler(this.txtValue_TextChanged);
      this.txtValue.KeyDown += new KeyEventHandler(this.txtValue_KeyDown);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.txtValue);
      this.Controls.Add((Control) this.barValue);
      this.Margin = new Padding(0);
      this.MaximumSize = new Size(1000, 33);
      this.MinimumSize = new Size(100, 33);
      this.Name = "TrackBarBox";
      this.Size = new Size(100, 33);
      this.barValue.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
