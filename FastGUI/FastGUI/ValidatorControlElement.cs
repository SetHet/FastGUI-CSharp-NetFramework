using FastGUI.FastGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastGUI.Modules
{
    public class ValidatorControlElement : Evaluation
    {
        public Control control;
        public List<Evaluator> evaluations;
        public bool required;
        public List<Control> requiredControls;

        public enum TypeControl
        {
            text
        }

        public struct EvaluateOutput
        {
            public bool correct;
            public string errorMessage;
        }

        /// <summary>
        /// Este delegado permite crear una funcion que se entrega al FastGUIControl.
        /// Esta funcion evaluara el control y si cumple la condicion se aprovara (true) y en caso contrario se reprueba (false)
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public delegate string Evaluator(Control control);

        public ValidatorControlElement(Control control, bool required = false)
        {
            this.control = control;
            this.required = required;
            requiredControls = new List<Control>();
            evaluations = new List<Evaluator>();
            Get = new GetClass(this);
            Is = new IsClass(this);
        }

        public static ValidatorControlElement Use(Control control, bool required = false)
        {
            ValidatorControlElement fgc = new ValidatorControlElement(control, required);
            return fgc;
        }

        public EvaluateOutput Evaluate()
        {
            string efull = ""; 
            for (int i = 0; i < evaluations.Count; i++)
            {
                var e = evaluations[i](control);
                if (e != "")
                {
                    efull += e + "\n";
                }
            }
            var output = new EvaluateOutput() { 
                correct = efull == "",
                errorMessage = efull
            };
            return output;
        }

        //public bool EvaluateRequiredControls(ValidatorControlCollection fastGUI)
        //{
        //    for (int i = 0; i < requiredControls.Count; i++)
        //    {
        //        if (!fastGUI.Get(requiredControls[i]).Evaluate()) return false;
        //    }
        //    return true;
        //}

        public ValidatorControlElement AddEvaluation(Evaluator evaluator)
        {
            evaluations.Add(evaluator);
            return this;
        }

        public ValidatorControlElement AddRequiredControl(Control otherControl)
        {
            if (!requiredControls.Contains(otherControl))
                requiredControls.Add(otherControl);
            return this;
        }


        /// <summary>
        /// Tiene una lista de retorno de tipos
        /// </summary>
        public GetClass Get { get; }

        public class GetClass
        {
            public GetClass(ValidatorControlElement fgc) { this.fgc = fgc; }
            ValidatorControlElement fgc;


            public string String()
            {
                return fgc.control.Text;
            }

            public string StringOrEmpty()
            {
                if (fgc.Evaluate().correct)
                    return fgc.control.Text;
                return "";
            }


            public string Int()
            {
                return fgc.control.Text;
            }

            public string IntOrZero()
            {
                if (fgc.Evaluate().correct)
                    return fgc.control.Text;
                return "";
            }
        }

        /// <summary>
        /// Comprueba si el elemento es un tipo en concreto
        /// </summary>
        public IsClass Is { get; }
        
        public class IsClass
        {
            public IsClass(ValidatorControlElement fgc) { this.fgc = fgc; }
            ValidatorControlElement fgc;

            public bool Int()
            {
                return int.TryParse(fgc.control.Text, out int result);
            }

            public bool Float()
            {
                return float.TryParse(fgc.control.Text, out float result);
            }
        }



    }
}
