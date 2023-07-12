using HashFilesMA.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


using HashFilesMA.FileHelpers;

namespace HashFilesMA
{
    public partial class FrmHash : Form
    {
        //Propiedades
        private FileHashCalculator _calculadoraMd5;
        private FileSelect _archivoSeleccionado;
        private CancellationTokenSource _cancelarMd5;
        private TipoHash tipoHash;
        public FrmHash()
        {
            InitializeComponent();

            _archivoSeleccionado = new FileSelect();
            _archivoSeleccionado.CambioArchivo += _archivoSeleccionado_CambioArchivo;

            _calculadoraMd5 = new FileHashCalculator();
            _calculadoraMd5.Progreso += _calculadoraMd5_ProgressMd5;
            _calculadoraMd5.ProgresoCompletado += _calculadoraMd5_ProgresoCompletado;
            _calculadoraMd5.Error += _calculadoraMd5_Error;

            //extra
            _cancelarMd5 = new CancellationTokenSource();

            //otros
            tipoHash = TipoHash.MD5;
            LLenaComboBox();


        }

        //Checkbox metodos
        private void LLenaComboBox()
        {
            List<string> lst = new List<string>();


            lst.AddRange(Enum.GetNames(typeof(TipoHash)));


            cbxTipoHash.DataSource = lst;
        }




        private void _calculadoraMd5_Error(object sender, EventArgs e)
        {
            _cancelarMd5.Dispose();
            _cancelarMd5 = new CancellationTokenSource();
            MessageBox.Show("Ha ocurrido un error mientras se calculaba el MD5 o el procreso fue cancelado");
            Reset();
        }

        private void Reset()
        {
            _archivoSeleccionado.Clear();
            txtHASH.Clear();
            //txtMd5Comp.Clear();
            progressBar1.Value = 0;

        }
        private void _archivoSeleccionado_CambioArchivo(object sender, EventArgs e)
        {
            tolNombreArchivo.Text = _archivoSeleccionado.Nombre;
        }


        //Eventos
        private void _calculadoraMd5_ProgresoCompletado(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(5000, "Progreso", $"Calculado MD5 de {_archivoSeleccionado.Nombre}", ToolTipIcon.Info);
        }


        private void _calculadoraMd5_ProgressMd5(object sender, ProgressHashFileArgs e)
        {
            progressBar1.Value = (int) (e.Progreso * 100f);
           
        }

        void ProcesarArchivo(string ruta)
        {
            //Reset();

            _archivoSeleccionado.RutaArchivo = ruta;
            tipoHash =(TipoHash)Enum.Parse(typeof(TipoHash), cbxTipoHash.Text);

            Task.Run(() =>
            {
                string hashFile = this._calculadoraMd5.CalcularHashAll(tipoHash,ruta, _cancelarMd5.Token);
                txtHASH.Text = hashFile;

            });
        }


        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                ProcesarArchivo(openFileDialog1.FileName);

            }
        }

        #region BtnAbrirArchivoHoverDrag
        private string textOrigiguinal = "";
        private void btnOpenFile_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }


            btnOpenFile.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            textOrigiguinal = btnOpenFile.Text;
            btnOpenFile.Text = "Suelta el archivo";


            
        }

        private void btnOpenFile_DragLeave(object sender, EventArgs e)
        {
            btnOpenFile.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnOpenFile.Text = textOrigiguinal;
        }

        #endregion

        //Drop btn open file
        private void btnOpenFile_DragDrop(object sender, DragEventArgs e)
        {
            btnOpenFile.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnOpenFile.Text = textOrigiguinal;

            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            string[] rutas = (string[]) e.Data.GetData(DataFormats.FileDrop);

            if (rutas.Length == 0) return;

            string ruta = rutas[0];
            ProcesarArchivo(ruta);



        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            
            if ( txtHASH.Text == "" || txtHASHComp.Text == "" ) return;
            
               
            
            if( txtHASH.Text == txtHASHComp.Text )
            {
                MessageBox.Show("Los campos son iguales","Comparacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los campos son diferentes","Comparacion",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void backProcressFile_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Cancel = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_calculadoraMd5.EnProgreso)
            {
                _cancelarMd5.Cancel();
            }
        }
    }
}
