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
        public static ValidatorControlElement.Evaluator RequiredOnTrue(ValidatorControlElement fgc)
        {
            return (Control control) => 
            {
                if ((control as CheckBox).Checked) return fgc.Evaluate().errorMessage;
                return "";
            };
        }

        public static ValidatorControlElement.Evaluator RequiredOnTrue(Control otherControl, ValidatorControlCollection fg)
        {
            return (Control control) =>
            {
                if ((control as CheckBox).Checked) return fg.Get(otherControl).Evaluate().errorMessage;
                return "";
            };
        }

        public static ValidatorControlElement.Evaluator RequiredOnFalse(ValidatorControlElement fgc)
        {
            return (Control control) =>
            {
                if (!(control as CheckBox).Checked) return fgc.Evaluate().errorMessage;
                return "";
            };
        }

        public static ValidatorControlElement.Evaluator RequiredOnFalse(Control otherControl, ValidatorControlCollection fg)
        {
            return (Control control) =>
            {
                if (!(control as CheckBox).Checked) return fg.Get(otherControl).Evaluate().errorMessage;
                return "";
            };
        }
    }
}
