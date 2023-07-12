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

    enum TipoSeleccionado
    {
        Hash,
        Hmac
    }

    public partial class FrmHash : Form
    {
        //Propiedades
        private FileHashCalculator _calculadoraHash;
        private FileHmacHashCalculator _calculadoraHmac;


        private FileSelect _archivoSeleccionado;
        private CancellationTokenSource _cancelarProcesoHash;
        private TipoHash tipoHash;
        private TipoHMACHash tipoHmac;

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

            tipoHash = TipoHash.MD5;

            //calculadora hmac
            _calculadoraHmac = new FileHmacHashCalculator();
            _calculadoraHmac.Progreso += _calculadoraHash_Progreso;
            _calculadoraHmac.ProgresoCompletado += _calculadoraHash_ProgresoCompletado;
            _calculadoraHmac.Error += _calculadoraHash_Error;

            tipoHmac = TipoHMACHash.HMACMD5;

            //extra
            _cancelarProcesoHash = new CancellationTokenSource();

            //otros
            LLenaComboBoxHash();


        }

        //Combobox metodos
        private void LLenaComboBoxHash()
        {
            cbxTipoHash.LLenaCbxDeEnum<TipoHash>();
            cbxTipoHmac.LLenaCbxDeEnum<TipoHMACHash>();
        }
        



        //Eventos calculadora hash
        private void _calculadoraHash_Error(object sender, ErrorHashFileArgs e)
        {
            _cancelarProcesoHash.Dispose();
            _cancelarProcesoHash = new CancellationTokenSource();
            MessageBox.Show("Ha ocurrido un error mientras se calculaba el hash o el procreso fue cancelado" +e.Mensaje);
            Reset();
            //Desabilita el boton de cancelar
            btnCancelar.Enabled = false;
            
        }
        private void _calculadoraHash_ProgresoCompletado(object sender, EventArgs e)
        {
            //Desabilita el boton de cancelar
            btnCancelar.Enabled = false;

            string nombreTipoSeleccionado = tipoSeleccionado == TipoSeleccionado.Hash ?tipoHash.ToString() :tipoHmac.ToString();

            if (habilitarNotificacionesToolStripMenuItem.Checked)
            {
                notifyIcon1.ShowBalloonTip(2000, "Completado", $"Calculado {nombreTipoSeleccionado} de {_archivoSeleccionado.Nombre}", ToolTipIcon.Info);

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
        private void Reset()
        {
            
            _archivoSeleccionado.Clear();
            txtHASH.Clear();
            //txtMd5Comp.Clear();
            prgFileHash.Value = 0;

        }



        void ProcesarArchivo(string ruta)
        {
            //Reset();
            btnCancelar.Enabled = true;
            tipoHash = cbxTipoHash.DevuelveEnumSeleccionado<TipoHash>();
            tipoHmac = cbxTipoHmac.DevuelveEnumSeleccionado<TipoHMACHash>();


            string hashFile = "";
            

            if(tipoSeleccionado == TipoSeleccionado.Hash)
            {

                hashFile = this._calculadoraHash.CalcularHashAll(tipoHash, ruta, _cancelarProcesoHash.Token);
            }
            else
            {
                if (!FrmClave.EsClaveValida)
                {
                    MessageBox.Show("No es una clave valida");
                    return;
                }
                string key = FrmClave.ObtenerClave();
                hashFile = this._calculadoraHmac.CalcularHashAll(tipoHmac, ruta, key, _cancelarProcesoHash.Token);
            }

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
            if (_calculadoraHash.EnProgreso)
            {
                _cancelarProcesoHash.Cancel();
            }
        }

        private void cbxTipoHash_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._archivoSeleccionado.Seleccionado && ((ComboBox)sender).Items.Count > 0)
            {
                backProcressFile.RunWorkerAsync();
            }
        }

        
        //Intercambiar entre hmac o hash
       
        private void IntercambiarSeleccionHash(bool hash)
        {
            if (hash)
            {
                tipoSeleccionado = TipoSeleccionado.Hash;
            }
            else
            {
                tipoSeleccionado = TipoSeleccionado.Hmac;
            }
            pnlConteHash.Enabled = hash;

            pnlConteHmac.Enabled = !hash;


        }
        private void btnIntercambiar_Click(object sender, EventArgs e)
        {
            IntercambiarSeleccionHash(!pnlConteHash.Enabled);
            if (_archivoSeleccionado.Seleccionado)
            {
                backProcressFile.RunWorkerAsync();
            }
        }



        //Clave
        private void btnClave_Click(object sender, EventArgs e)
        {
            new FrmClave().ShowDialog();



        }

        private void habilitarNotificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            habilitarNotificacionesToolStripMenuItem.Checked = !habilitarNotificacionesToolStripMenuItem.Checked;
        }
    }
}
