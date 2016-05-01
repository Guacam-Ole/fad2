using System;
using System.Windows.Forms;

namespace fad2.UI.UserControls
{
    /// <summary>
    /// Slider
    /// </summary>
    public class SettingsTimeSlider : SettingsSlider
    {
        /// <summary>
        /// Value types
        /// </summary>
        public enum ValueTypes
        {
#pragma warning disable 1591
            Millisecond,
            Second,
            Minute,
            Hour
#pragma warning restore 1591
        }

        /// <summary>
        /// Value Type
        /// </summary>
        public ValueTypes ValueType { get; set; } = ValueTypes.Millisecond;

        /// <summary>
        /// Value Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void SettingValue_ValueChanged(object sender, EventArgs e)
        {
            Application.DoEvents();
            MetroToolTip.SetToolTip(SettingValue, GetToolTip());
        }

        /// <summary>
        /// Get Text for Tooltip
        /// </summary>
        /// <returns>Tooltip-Text</returns>
        public string GetToolTip()
        {
            var ts = new TimeSpan();
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