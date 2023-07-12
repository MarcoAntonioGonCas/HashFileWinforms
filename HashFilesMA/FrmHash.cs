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

        //Combobox metodos
        private void LLenaComboBox()
        {
            List<string> lst = new List<string>();


            lst.AddRange(Enum.GetNames(typeof(TipoHash)));


            cbxTipoHash.DataSource = lst;
        }




        //Eventos calculadora hash
        private void _calculadoraMd5_Error(object sender, ErrorHashFileArgs e)
        {
            _cancelarMd5.Dispose();
            _cancelarMd5 = new CancellationTokenSource();
            MessageBox.Show("Ha ocurrido un error mientras se calculaba el MD5 o el procreso fue cancelado" +e.Mensaje);
            Reset();
            //Desabilita el boton de cancelar
            btnCancelar.Enabled = false;
            
        }
        private void _calculadoraMd5_ProgresoCompletado(object sender, EventArgs e)
        {
            //Desabilita el boton de cancelar
            btnCancelar.Enabled = false;
            notifyIcon1.ShowBalloonTip(2000, "Progreso", $"Calculado {tipoHash} de {_archivoSeleccionado.Nombre}", ToolTipIcon.Info);


            
            
        }
        private void _calculadoraMd5_ProgressMd5(object sender, ProgressHashFileArgs e)
        {
            progressBar1.Value = (int) (e.Progreso * 100f);
            lblProgreso.Text = progressBar1.Value.ToString()+"%";
        }


        //Eventos archivo seleccionado
        private void _archivoSeleccionado_CambioArchivo(object sender, EventArgs e)
        {
            tolNombreArchivo.Text = _archivoSeleccionado.Nombre;
        }

        //Helpers
        private void Reset()
        {
            
            _archivoSeleccionado.Clear();
            txtHASH.Clear();
            //txtMd5Comp.Clear();
            progressBar1.Value = 0;

        }



        void ProcesarArchivo(string ruta)
        {
            //Reset();
            btnCancelar.Enabled = true;
            tipoHash = (TipoHash)Enum.Parse(typeof(TipoHash), cbxTipoHash.Text);

            string hashFile = this._calculadoraMd5.CalcularHashAll(tipoHash, ruta, _cancelarMd5.Token);

            txtHASH.Text = hashFile;
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


        //Metodo asyncrono
        private void backProcressFile_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!_archivoSeleccionado.Seleccionado) return;

            ProcesarArchivo(_archivoSeleccionado.RutaArchivo);
        }

        //Drop btn open file
        private void btnOpenFile_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _archivoSeleccionado.RutaArchivo = openFileDialog1.FileName;
                backProcressFile.RunWorkerAsync();

            }
        }
        private void btnOpenFile_DragDrop(object sender, DragEventArgs e)
        {
            //Estilos por defecto
            btnOpenFile.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnOpenFile.Text = textOrigiguinal;

            //Si no existen archivos que se estan arrastrando
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            string[] rutas = (string[]) e.Data.GetData(DataFormats.FileDrop);

            if (rutas.Length == 0) return;

            _archivoSeleccionado.RutaArchivo = rutas[0];
            backProcressFile.RunWorkerAsync();

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_calculadoraMd5.EnProgreso)
            {
                _cancelarMd5.Cancel();
            }
        }

        private void cbxTipoHash_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._archivoSeleccionado.Seleccionado && cbxTipoHash.Items.Count > 0)
            {
                backProcressFile.RunWorkerAsync();
            }
        }
    }
}
