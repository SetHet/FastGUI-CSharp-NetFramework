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
        public static string NotEmpty(Control control)
        {
            return control.Text != ""? "" : "Ingresar un valor";
        }

        public static string IsInt(Control control)
        {
            return int.TryParse(control.Text, out int x)? "" : "Ingrese un valor entero";
        }

        public static string IsFloat(Control control)
        {
            return float.TryParse(control.Text, out float x)? "" : "Ingrese un valor decimal";
        }

        public static Modules.ValidatorControlElement.Evaluator Max(float max)
        {
            return (Control control) =>
            {
                if (float.TryParse(control.Text, out float val))
                {
                     return max > val? "" : $"El valor tiene que ser menor a {max}";
                }
                return "Ingrese un valor numerico";
            };
        }

        public static Modules.ValidatorControlElement.Evaluator MaxEqual(float max)
        {
            return (Control control) =>
            {
                if (float.TryParse(control.Text, out float val))
                {
                    return max >= val ? "" : $"El valor tiene que ser menor o igual a {max}";
                }
                return "Ingrese un valor numerico";
            };
        }

        public static Modules.ValidatorControlElement.Evaluator Min(float min)
        {
            return (Control control) =>
            {
                if (float.TryParse(control.Text, out float val))
                {
                    return min < val? "" : $"El valor tiene que ser mayor a {min}";
                }
                return "Ingrese un valor numerico";
            };
        }

        public static Modules.ValidatorControlElement.Evaluator MinEqual(float min)
        {
            return (Control control) =>
            {
                if (float.TryParse(control.Text, out float val))
                {
                    return min <=val ? "" : $"El valor tiene que ser mayor o igual a {min}";
                }
                return "Ingrese un valor numerico";
            };
        }

        public static Modules.ValidatorControlElement.Evaluator RegExp(string re)
        {
            return (Control control) =>
            {
                return Regex.IsMatch(control.Text, re)? "" : "No coincide con el formato";
            };
        }
        
        public static string IsRut(Control control)
        {
            var re = Regex.IsMatch(control.Text, "^(\\d{1,3}(?:\\.\\d{3}){2}-[\\dkK])$");

            if (re)
            {
                var vals = control.Text.Split('-');
                vals[0] = vals[0].Replace(".", "");

                int num;
                if (!int.TryParse(vals[0], out num)) return "Al analizar el rut no se pudo parsear el numero";

                string digitoCalculado = FastGUI.Utils.Rut.CalcularDigitoVerificador(num);

                return digitoCalculado == vals[1] ? "" : "Digito verificador no coincide";
            }

            return "Ingrese el rut con el formato: XX.XXX.XXX-Y";
        }

        public static Modules.ValidatorControlElement.Evaluator FirstLetters(string subtxt)
        {
            return (Control control) =>
            {
                int num = subtxt.Length;
                if (num < 1) return "Debe ingresar un valor no vacio de primeras letras a comprobar";
                var text = control.Text;
                if (text.Length < num) return $"El campo no tiene la cantidad minima de letras requerido, ingrese por lo menos {num} digitos";
                var subString = text.Substring(0, num);

                return subString == subtxt? "" : $"El campo no tiene el formato '{subtxt}.......'";
            };
        }

        public static Modules.ValidatorControlElement.Evaluator LastLetters(string subtxt)
        {
            return (Control control) =>
            {
                int num = subtxt.Length;
                if (num < 1) return "Debe ingresar un valor no vacio de primeras letras a comprobar";
                var text = control.Text;
                if (text.Length < num) return $"El campo no tiene la cantidad minima de letras requerido, ingrese por lo menos {num} digitos";
                var subString = text.Substring(text.Length-(num), num);

                return subString == subtxt? "" : $"El campo no tiene el formato '.......{subtxt}'";
            };
        }

        public static Modules.ValidatorControlElement.Evaluator Contains(string subtxt)
        {
            return (Control control) =>
            {
                return control.Text.Contains(subtxt)? "" : $"El campo no contiene en algun punto '{subtxt}' ('....{subtxt}....')";
            };
        }

        public static Modules.ValidatorControlElement.Evaluator Length(int length)
        {
            return (Control control) =>
            {
                return control.Text.Length == length? "" : $"El campo debe contener {length} digitos";
            };
        }

        public static Modules.ValidatorControlElement.Evaluator LengthNot(int length)
        {
            return (Control control) =>
            {
                return control.Text.Length != length? "" : $"El campo no debe contener {length} digitos, ingrese una cantidad menor o mayor";
            };
        }

        public static Modules.ValidatorControlElement.Evaluator LengthMax(int length)
        {
            return (Control control) =>
            {
                return control.Text.Length < length? "" : $"El campo tiene un largo maximo de {length-1} digitos";
            };
        }

        public static Modules.ValidatorControlElement.Evaluator LengthMaxEqual(int length)
        {
            return (Control control) =>
            {
                return control.Text.Length <= length ? "" : $"El campo tiene un largo maximo de {length} digitos";
            };
        }

        public static Modules.ValidatorControlElement.Evaluator LengthMin(int length)
        {
            return (Control control) =>
            {
                return control.Text.Length > length? "" : $"El campo tiene un largo minimo de {length+1} digitos";
            };
        }

        public static Modules.ValidatorControlElement.Evaluator LengthMinEqual(int length)
        {
            return (Control control) =>
            {
                return control.Text.Length >= length? "" : $"El campo tiene un largo minimo de {length} digitos";
            };
        }

        public static ValidatorControlElement.Evaluator RequiredCheckBox(Control checkbox, string nombreCheckBox = "")
        {
            return (Control control) =>
            {
                var cb = control as CheckBox;
                if (nombreCheckBox == "") nombreCheckBox = cb.Text;
                return cb.Checked? "" : $"Requiere que el CheckBox {nombreCheckBox} este activo";
            };
        }

        public static ValidatorControlElement.Evaluator RequiredCheckBox_Uncheck(Control checkbox, string nombreCheckBox = "")
        {
            return (Control control) =>
            {
                var cb = control as CheckBox;
                if (nombreCheckBox == "") nombreCheckBox = cb.Text;
                return !cb.Checked ? "" : $"Requiere que el CheckBox {nombreCheckBox} este activo";
            };
        }
    }
}
