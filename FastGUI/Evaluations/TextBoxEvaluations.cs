using FastGUI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastGUI.Evaluations
{
    public static class TextBoxEvaluations
    {
        public static bool NotEmpty(Control control)
        {
            return control.Text != "";
        }

        public static bool IsInt(Control control)
        {
            return int.TryParse(control.Text, out int x);
        }

        public static bool IsFloat(Control control)
        {
            return float.TryParse(control.Text, out float x);
        }

        //public static bool Max(Control control, float max) { 
            
        //    if (float.TryParse(control.Text, out float val))
        //    {
        //        return max > val;
        //    }
        //    return false;
        //}


        public static Modules.FastGUIControl.Evaluator Max(float max)
        {
            return (Control control) =>
            {
                if (float.TryParse(control.Text, out float val))
                {
                    return max > val;
                }
                return false;
            };
        }

        public static Modules.FastGUIControl.Evaluator MaxEqual(float max)
        {
            return (Control control) =>
            {
                if (float.TryParse(control.Text, out float val))
                {
                    return max >= val;
                }
                return false;
            };
        }

        public static Modules.FastGUIControl.Evaluator Min(float min)
        {
            return (Control control) =>
            {
                if (float.TryParse(control.Text, out float val))
                {
                    return min < val;
                }
                return false;
            };
        }

        public static Modules.FastGUIControl.Evaluator MinEqual(float min)
        {
            return (Control control) =>
            {
                if (float.TryParse(control.Text, out float val))
                {
                    return min <= val;
                }
                return false;
            };
        }

        public static Modules.FastGUIControl.Evaluator RegExp(string re)
        {
            return (Control control) =>
            {
                return Regex.IsMatch(control.Text, re);
            };
        }

        public static Modules.FastGUIControl.Evaluator FirstLetters(string subtxt)
        {
            return (Control control) =>
            {
                int num = subtxt.Length;
                if (num < 1) return false;
                var text = control.Text;
                if (text.Length < num) return false;
                var subString = text.Substring(0, num);

                return subString == subtxt;
            };
        }

        public static Modules.FastGUIControl.Evaluator LastLetters(string subtxt)
        {
            return (Control control) =>
            {
                int num = subtxt.Length;
                if (num < 1) return false;
                var text = control.Text;
                if (text.Length < num) return false;
                var subString = text.Substring(text.Length-(num), num);

                return subString == subtxt;
            };
        }

        public static Modules.FastGUIControl.Evaluator Contains(string subtxt)
        {
            return (Control control) =>
            {
                return control.Text.Contains(subtxt);
            };
        }

        public static Modules.FastGUIControl.Evaluator Length(int length)
        {
            return (Control control) =>
            {
                return control.Text.Length == length;
            };
        }

        public static Modules.FastGUIControl.Evaluator LengthNot(int length)
        {
            return (Control control) =>
            {
                return control.Text.Length != length;
            };
        }

        public static Modules.FastGUIControl.Evaluator LengthMax(int length)
        {
            return (Control control) =>
            {
                return control.Text.Length < length;
            };
        }

        public static Modules.FastGUIControl.Evaluator LengthMaxEqual(int length)
        {
            return (Control control) =>
            {
                return control.Text.Length <= length;
            };
        }

        public static Modules.FastGUIControl.Evaluator LengthMin(int length)
        {
            return (Control control) =>
            {
                return control.Text.Length > length;
            };
        }

        public static Modules.FastGUIControl.Evaluator LengthMinEqual(int length)
        {
            return (Control control) =>
            {
                return control.Text.Length >= length;
            };
        }

        public static FastGUIControl.Evaluator RequiredCheckBox(Control checkbox)
        {
            return (Control control) =>
            {
                return (control as CheckBox).Checked;
            };
        }

        public static FastGUIControl.Evaluator RequiredCheckBox_Uncheck(Control checkbox)
        {
            return (Control control) =>
            {
                return !(control as CheckBox).Checked;
            };
        }
    }
}
