using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fad2.UI.UserControls
{
    public class SettingsTimeSlider      :SettingsSlider
    {
        public enum ValueTypes
        {
            Millisecond,
            Second,
            Minute,
            Hour
        }
        public ValueTypes ValueType { get; set; } = ValueTypes.Millisecond;

        protected override void SettingValue_ValueChanged(object sender, EventArgs e)
        {
            Application.DoEvents();
            MetroToolTip.SetToolTip(SettingValue, GetToolTip());
        }

        public string GetToolTip()
        {
            TimeSpan ts = new TimeSpan();
                 switch (ValueType)
            {
                case ValueTypes.Millisecond:
                    ts = TimeSpan.FromMilliseconds(Value);
                    break;
                case ValueTypes.Second:
                    ts = TimeSpan.FromSeconds(Value);
                    break;
                case ValueTypes.Minute:
                    ts = TimeSpan.FromMinutes(Value);
                    break;
                case ValueTypes.Hour:
                    ts = TimeSpan.FromHours(Value);
                    break;
            }
            return $"{ts:hh\\:mm\\.ss}";
        }

    }
}
