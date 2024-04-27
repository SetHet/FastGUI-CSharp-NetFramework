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
        public static ValidatorControlElement.Evaluator Required(ValidatorControlElement fgc)
        {
            return (Control control) => 
            {
                if (!(control as CheckBox).Checked) return true;
                return fgc.Evaluate();
            };
        }

        public static ValidatorControlElement.Evaluator Required(Control otherControl, FastGUI.Modules.ValidatorControlCollection fg)
        {
            return (Control control) =>
            {
                if (!(control as CheckBox).Checked) return true;
                return fg.Get(otherControl).Evaluate();
            };
        }
    }
}
