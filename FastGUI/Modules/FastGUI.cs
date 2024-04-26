using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastGUI.Modules
{
    public class FastGUI
    {
        Dictionary<Control, FastGUIControl> controls;

        public FastGUI()
        {
            controls = new Dictionary<Control, FastGUIControl>();
        }

        public FastGUIControl Add(Control control)
        {
            FastGUIControl fgc= new FastGUIControl(control);
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

        public FastGUIControl Get(Control control)
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

        public FastGUIControl this[Control control]
        {
            get => this.controls[control];
        }

        public FastGUIControl this[int index]
        {
            get => this.controls.ToArray()[index].Value;
        }

        public int Count { get { return controls.Count; } }

        public IEnumerable<KeyValuePair<Control, FastGUIControl>> ToEnumerable
        {
            get => this.controls.AsEnumerable();
        }
    }
}
