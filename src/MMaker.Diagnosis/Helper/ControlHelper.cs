using System;
using System.Collections;
using System.Windows.Forms;

namespace MMaker.Diagnosis.Helper
{
    public static class ControlHelper
    {
        public static Control[] GetAllControls(this Control parentControl, Type type)
        {
            ArrayList allControls = new ArrayList();
            Queue queue = new Queue();
            queue.Enqueue(parentControl.Controls);

            while (queue.Count > 0)
            {
                Control.ControlCollection controls = (Control.ControlCollection)queue.Dequeue();
                if (controls == null || controls.Count == 0) continue;

                foreach (Control control in controls)
                {
                    if (control.GetType() == type)
                    {
                        allControls.Add(control);
                    }
                    queue.Enqueue(control.Controls);
                }
            }
            return (Control[])allControls.ToArray(typeof(Control));
        }
    }
}