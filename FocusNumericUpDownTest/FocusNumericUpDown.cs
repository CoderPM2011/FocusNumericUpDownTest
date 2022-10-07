using System;
using System.Windows.Forms;

namespace FocusNumericUpDownTest
{
    public class FocusNumericUpDown :
        NumericUpDown
    {
        public FocusNumericUpDown() :
            base()
        {
            MouseLeave += FocusNumericUpDown_MouseLeave;
            MouseWheel += FocusNumericUpDown_MouseWheel;
        }

        private void FocusNumericUpDown_MouseLeave(object sender, EventArgs e)
        {
            if (Focused)
            {
                for (Control parent = Parent;
                    parent != null;
                    parent = parent.Parent)
                {
                    if (parent.CanFocus)
                    {
                        _ = parent.Focus();
                        break;
                    }
                }
            }
        }

        private void FocusNumericUpDown_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = !Focused;
            if (!Focused)
            {
                for (Control parent = Parent;
                    parent != null;
                    parent = parent.Parent)
                {
                    if (parent is ScrollableControl scrollableControl &&
                        scrollableControl.AutoScroll &&
                        scrollableControl.VerticalScroll.Enabled &&
                        scrollableControl.VerticalScroll.Visible)
                    {
                        int delta = scrollableControl.VerticalScroll.Value - e.Delta;
                        if (delta < 0)
                        {
                            delta = 0;
                        }
                        else if (delta > scrollableControl.VerticalScroll.Maximum)
                        {
                            delta = scrollableControl.VerticalScroll.Maximum;
                        }

                        scrollableControl.VerticalScroll.Value = delta;
                        break;
                    }
                }
            }
        }
    }
}
