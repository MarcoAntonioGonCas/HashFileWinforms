using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace HashFilesMA.Controles
{
    //TODO: no terminado corregir categorias,nombres etc
    public class ButtonCustom : Button
    {
        //Borde
        private int _borderSizePx;
        private int _borderRadiusPercent;
        private Color _borderColor;
        private Color _borderColor2;
        private DashStyle _borderLineStyle;
        private DashCap _borderDashStyle;
        private bool _gradientBorder;
        private int _gradientBorderAngle;
        //Background
        private Color _backgroundColor;
        private Color _backgroundColor2;

        public int BorderRadiusPercent
        {
            get
            {
                return _borderRadiusPercent;
            }

            set
            {
                if (value >= 0 && value <= 100)
                {
                    _borderRadiusPercent = value;
                }
                Invalidate();
            }
        }

        
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }

            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        public Color BorderColor2
        {
            get
            {
                return _borderColor2;
            }

            set
            {
                _borderColor2 = value;
                Invalidate();
            }
        }

        public DashStyle BorderLineStyle
        {
            get
            {
                return _borderLineStyle;
            }

            set
            {
                _borderLineStyle = value;
                Invalidate();
            }
        }

        public DashCap BorderDashStyle
        {
            get
            {
                return _borderDashStyle;
            }

            set
            {
                _borderDashStyle = value;
                Invalidate();
            }
        }

        public bool GradientBorder
        {
            get
            {
                return _gradientBorder;
            }

            set
            {
                _gradientBorder = value;
                Invalidate();
            }
        }

        public int GradientBorderAngle
        {
            get
            {
                return _gradientBorderAngle;
            }

            set
            {
                _gradientBorderAngle = value;
                Invalidate();
            }
        }

        public int BorderSizePx
        {
            get
            {
                return _borderSizePx;
            }

            set
            {
                _borderSizePx = value;
                Invalidate();
            }
        }

        public ButtonCustom()
        {

            _borderRadiusPercent = 20;
            _borderSizePx = 8;
            _gradientBorder = true;
            _gradientBorderAngle = 45;

            _borderColor = Color.Crimson;
            _borderColor2 = Color.RoyalBlue;
            _borderLineStyle = DashStyle.Solid;
            _borderDashStyle = DashCap.Round;

            //Propiedades base
            Cursor = Cursors.Hand;
            FlatStyle = FlatStyle.Flat;

        }
        private GraphicsPath ObtieneRadioPath(Rectangle rec, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            if (radio <= 1) radio = 1;


            path.StartFigure();

            //Arriba izquierda
            path.AddArc(rec.X, rec.Y, radio, radio, 180, 90);
            //Arriba derecha
            path.AddArc(rec.Right - radio, rec.Y, radio, radio, 270, 90);

            //Abajo derecha
            path.AddArc(rec.Right - radio, rec.Bottom - radio, radio, radio, 0, 90);

            //Abajo izquierda
            path.AddArc(rec.X, rec.Bottom - radio, radio, radio, 90, 90);

            path.CloseFigure();



            return path;

        }
        private int CalculaRadio(Size tamanio, int percent)
        {
            int max = Math.Min(tamanio.Width, tamanio.Height);

            int tamanioPx = max * percent / 100;

            return tamanioPx;
        }

        private GraphicsPath ObtienePath(Rectangle superficie)
        {

            GraphicsPath path = new GraphicsPath();

            if (BorderRadiusPercent <= 1)
            {
                path.AddRectangle(superficie);
            }
            else
            {
                path.Dispose();
                int nuevoTamanioRadio = CalculaRadio(superficie.Size, BorderRadiusPercent);
                path = ObtieneRadioPath(superficie, nuevoTamanioRadio);
            }


            return path;
        }



        private void DibujaSuavizado(Graphics g, Rectangle rec, int tamanioPincelSuavizado)
        {
            Color color = Parent.BackColor;
            using (GraphicsPath pathSuavizado = ObtienePath(rec))
            using (Pen pincelSuavizado = new Pen(color, tamanioPincelSuavizado))
            {
                Region = new Region(pathSuavizado);
                g.DrawPath(pincelSuavizado, pathSuavizado);
            }
        }


        private Brush ObtieneLapizBorde(GraphicsPath superficieBorde)
        {
            if (GradientBorder)
            {
                return new LinearGradientBrush(superficieBorde.GetBounds(), BorderColor, BorderColor2, GradientBorderAngle);
            }
            else
            {
                return new SolidBrush(BorderColor);
            }
        }
        private void DibujaBorde(Graphics g, Rectangle rec, int tamanioPincel)
        {
            if (tamanioPincel <= 0)
            {
                return;
            }
            using (GraphicsPath pathBorde = ObtienePath(rec))
            using (Brush brus = ObtieneLapizBorde(pathBorde))
            using (Pen pincelborde = new Pen(brus, tamanioPincel))
            {
                pincelborde.DashStyle = BorderLineStyle;
                pincelborde.DashCap = BorderDashStyle;
                g.DrawPath(pincelborde, pathBorde);
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int espacioSuavizado = 2;
            int tamanioPincelSuavizado = BorderSizePx * 2 + 3;
            int espacioBorde = BorderSizePx / 2 + 2;


            Rectangle recSuavizado = Rectangle.Inflate(ClientRectangle, -espacioSuavizado, -espacioSuavizado);
            Rectangle recBorde = Rectangle.Inflate(recSuavizado, -espacioBorde, -espacioBorde);

            DibujaSuavizado(g, recSuavizado, tamanioPincelSuavizado);
            DibujaBorde(g, recBorde, BorderSizePx);
        }

    }
}
