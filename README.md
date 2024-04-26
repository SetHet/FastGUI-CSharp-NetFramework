## What is FastGUI?

FastGUI es un acelerador de revision de Inputs en Windows Forms.

- C#
- DotNet Framework 4.6.

## How Work?

En la carpeta `Modules` esta el comportamiento de la herramienta. Ademas hay evaluadores en la carpeta `Evaluations`.

1. En el GUI.cs hay que agregar la variable FastGUI
```cs
FastGUI fg = new FastGUI();
```
2. En el `load` de la pagina hay que agregar los elementos:
```cs
fg.Add(this.textBox1);
```
3. Se puede agregar a posterior o en la misma agregacion las evaluaciones:
```cs
fg.Add(this.textBox1).AddEvaluation(TextBoxEvaluation.NotEmpty);
```
4. Se puede evaluar por separado si el elemento cumple las condiciones:
```cs
fg.Get(this.textBox1).Evaluate();
```
5. Se puede evaluar todos los elementos:
```cs
fg.Evaluate();
```
