using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{


    public partial class frm_Impressao : Form
    {
        Bitmap captura = null;
        public frm_Impressao(string cadastro, string codigo, string nome)
        {
            InitializeComponent();
            txtCadastro.Text = cadastro;
            txtCodigo.Text = codigo;
            txtNome.Text = nome;
        }

        private void CapturarForm()
        {
            var formBorderStyleAnterior = this.FormBorderStyle;

            try
            {
                this.FormBorderStyle = FormBorderStyle.None;

                WindowHelper.Rect rect;
                WindowHelper.DwmGetWindowAttribute(this.Handle, (int)WindowHelper.Dwmwindowattribute.DwmwaExtendedFrameBounds,
                    out rect, System.Runtime.InteropServices.Marshal.SizeOf(typeof(WindowHelper.Rect)));
                var rectangle = rect.ToRectangle();

                captura = new Bitmap(457, 271);
                var graphics = Graphics.FromImage(captura);
                graphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            }
            finally
            {
                this.FormBorderStyle = formBorderStyleAnterior;
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CapturarForm();
            printDocument1.Print();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(captura, 20, 20);
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}