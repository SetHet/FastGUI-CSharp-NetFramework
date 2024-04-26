using FastGUI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastGUI.Evaluations
{
    public static class CheckBoxEvaluation
    {
        public static FastGUIControl.Evaluator Required(FastGUIControl fgc)
        {
            return (Control control) => 
            {
                if (!(control as CheckBox).Checked) return true;
                return fgc.Evaluate();
            };
        }

        public static FastGUIControl.Evaluator Required(Control otherControl, FastGUI.Modules.FastGUI fg)
        {
            return (Control control) =>
            {
                if (!(control as CheckBox).Checked) return true;
                return fg.Get(otherControl).Evaluate();
            };
        }
    }
}
