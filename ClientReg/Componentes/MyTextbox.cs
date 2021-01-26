using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientReg.Componentes
{
    public class MyTextbox : TextBox
    {
        public String CaracteresValidos { get; set; } = "abcdefghijklmnopqrstuvwxyz0123456789çàèòùáéíóúâêîôûãñõäëïöüÿ";

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = !((this.CaracteresValidos.Contains(e.KeyChar.ToString().ToLower())) || (Keys.Back == (Keys)e.KeyChar) || (Keys.Delete == (Keys)e.KeyChar) || (Keys.Space == (Keys)e.KeyChar));
            
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x302 && Clipboard.ContainsText())
            {
                return;
            }
            base.WndProc(ref m);
        }
    }
}
