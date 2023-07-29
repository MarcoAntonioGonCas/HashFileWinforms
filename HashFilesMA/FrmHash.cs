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
        private enum TipoSeleccionado
        {
            Hash,
            Hmac
        }
        //Propiedades
        private FileHashCalculator _calculadoraHash;
        private FileHmacHashCalculator _calculadoraHmac;


        private FileSelect _archivoSeleccionado;
        private CancellationTokenSource _cancelarProcesoHash;

        private TipoHash[] tiposHashCalcular;

        //TODO: Completar hmac
        private TipoHMACHash[] tiposHmac;

        //Indica el tipo que se calculara hmac o hash
        TipoSeleccionado tipoSeleccionado = TipoSeleccionado.Hash;

        public FrmHash()
        {
            InitializeComponent();

            _archivoSeleccionado = new FileSelect();
            _archivoSeleccionado.CambioArchivo += _archivoSeleccionado_CambioArchivo;

            //Calculadora hash
            _calculadoraHash = new FileHashCalculator();
            _calculadoraHash.Progreso += _calculadoraHash_Progreso;
            _calculadoraHash.ProgresoCompletado += _calculadoraHash_ProgresoCompletado;
            _calculadoraHash.Error += _calculadoraHash_Error;

            tiposHashCalcular = new TipoHash[0];

            //calculadora hmac
            _calculadoraHmac = new FileHmacHashCalculator();
            _calculadoraHmac.Progreso += _calculadoraHash_Progreso;
            _calculadoraHmac.ProgresoCompletado += _calculadoraHash_ProgresoCompletado;
            _calculadoraHmac.Error += _calculadoraHash_Error;

            tiposHmac = new TipoHMACHash[0];

            //extra
            _cancelarProcesoHash = new CancellationTokenSource();


        }


        



        //Eventos calculadora hash
        private void _calculadoraHash_Error(object sender, ErrorHashFileArgs e)
        {
            
            MessageBox.Show("Ha ocurrido un error mientras se calculaba el hash o el procreso fue cancelado" + e.Mensaje);
            Reset();
            
            
        }
        private void _calculadoraHash_ProgresoCompletado(object sender, EventArgs e)
        {
            //Desabilita el boton de cancelar
            btnCancelar.Enabled = false;

            if (habilitarNotificacionesToolStripMenuItem.Checked)
            {
                notifyIcon1.ShowBalloonTip(2000, "Completado", $"Calculado {tipoSeleccionado.ToString()} de {_archivoSeleccionado.Nombre}", ToolTipIcon.Info);

            }            
        }

        private void _calculadoraHash_Progreso(object sender, ProgressHashFileArgs e)
        {
            prgFileHash.Value = (int) (e.Progreso * 100f);
            lblProgreso.Text = prgFileHash.Value.ToString()+"%";
        }


        //Eventos archivo seleccionado
        private void _archivoSeleccionado_CambioArchivo(object sender, EventArgs e)
        {
            tolNombreArchivo.Text = _archivoSeleccionado.Nombre;
        }

        //Helpers
        /// <summary>
        /// Limpia los controles para volver a calcular
        /// un nuevo hash.
        /// </summary>
        private void Reset()
        {
            _cancelarProcesoHash.Dispose();
            _cancelarProcesoHash = new CancellationTokenSource();

            btnCancelar.Enabled = false;
            _archivoSeleccionado.Clear();
            prgFileHash.Value = 0;

        }
        private void LimpiaControlesDeUsuario()
        {
            this.fileHashSelectorControl1.LimpiaCampos();
            this.fileHmacSelectorControl1.LimpiaCampos();
            
        }


        void ProcesarArchivo(string ruta)
        {
            LimpiaControlesDeUsuario();
            txtInput.Clear();
            btnCancelar.Enabled = true;
            prgFileHash.Value = 0;




            if (tipoSeleccionado == TipoSeleccionado.Hash)
            {
                tiposHashCalcular = fileHashSelectorControl1.ObtieneTiposSeleccionados();
                HashValue[] hashValues = this._calculadoraHash.CalcularMultipleHashFile(tiposHashCalcular, ruta, _cancelarProcesoHash.Token);
                fileHashSelectorControl1.LLenaTextbox(hashValues);

            }
            else if(tipoSeleccionado == TipoSeleccionado.Hmac )
            {
                if (!FrmClave.EsClaveValida)
                {
                    MessageBox.Show("No es una clave valida");
                    return;
                }

                tiposHmac = fileHmacSelectorControl1.ObtieneTiposSeleccionados();
                string key = FrmClave.ObtenerClave();
                HmacValue[] hmacValues = this._calculadoraHmac.CalcularMultipleHashFile(tiposHmac, ruta, key, _cancelarProcesoHash.Token);
                this.fileHmacSelectorControl1.LLenaTextbox(hmacValues);

            }

        }
        void ProcesaTexto(string texto)
        {
            if (tipoSeleccionado == TipoSeleccionado.Hash)
            {
                tiposHashCalcular = fileHashSelectorControl1.ObtieneTiposSeleccionados();
                HashValue[] hashValues = this._calculadoraHash.CalcularMultipleHashText(tiposHashCalcular, texto);
                fileHashSelectorControl1.LLenaTextbox(hashValues);

            }
            else if (tipoSeleccionado == TipoSeleccionado.Hmac)
            {
                if (!FrmClave.EsClaveValida)
                {
                    MessageBox.Show("No es una clave valida");
                    return;
                }

                tiposHmac = fileHmacSelectorControl1.ObtieneTiposSeleccionados();
                string key = FrmClave.ObtenerClave();
                HmacValue[] hmacValues = this._calculadoraHmac.CalcularMultipleHashText(tiposHmac, texto,key);
                this.fileHmacSelectorControl1.LLenaTextbox(hmacValues);

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
        //Todo repara
        private void btnComparar_Click(object sender, EventArgs e)
        {
            
            //if ( txtHASH.Text == "" || txtHASHComp.Text == "" ) return;
            
               
            
            //if( txtHASH.Text == txtHASHComp.Text )
            //{
            //    MessageBox.Show("Los campos son iguales","Comparacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Los campos son diferentes","Comparacion",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_calculadoraHash.EnProgreso)
            {
                _cancelarProcesoHash.Cancel();
            }
        }

        private void habilitarNotificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            habilitarNotificacionesToolStripMenuItem.Checked = !habilitarNotificacionesToolStripMenuItem.Checked;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                this.tipoSeleccionado = TipoSeleccionado.Hash;
            }
            else
            {
                this.tipoSeleccionado = TipoSeleccionado.Hmac;
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            string input = txtInput.Text.Trim();
            if (input == ""){
                LimpiaControlesDeUsuario();
                return;
            }

            Reset();
            LimpiaControlesDeUsuario();
            ProcesaTexto(input);
        }

        private void fileHashSelectorControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
