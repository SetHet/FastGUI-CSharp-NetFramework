using FastGUI.FastGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastGUI.Modules
{
    public class ValidatorControlCollection : Evaluation
    {
        Dictionary<Control, ValidatorControlElement> controls;

        public ValidatorControlCollection()
        {
            controls = new Dictionary<Control, ValidatorControlElement>();
        }

        public ValidatorControlElement Add(Control control)
        {
            ValidatorControlElement fgc= new ValidatorControlElement(control);
            controls.Add(control, fgc);
            return fgc;
        }

        public bool Evaluate()
        {
            var list = controls.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].Value.Evaluate()) return false;
            }
            return true;
        }

        public bool EvaluateRequiredOthers()
        {
            var list = controls.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].Value.EvaluateRequiredControls(this)) return false;
            }
            return true;
        }

        public ValidatorControlElement Get(Control control)
        {
            if(controls.ContainsKey(control))
            {
                return controls[control];
            }
            else
            {
                return null;
            }
        }

        public ValidatorControlElement this[Control control]
        {
            get => this.controls[control];
        }

        public ValidatorControlElement this[int index]
        {
            get => this.controls.ToArray()[index].Value;
        }

        public int Count { get { return controls.Count; } }

        public IEnumerable<KeyValuePair<Control, ValidatorControlElement>> ToEnumerable
        {
            get => this.controls.AsEnumerable();
        }
    }
}
