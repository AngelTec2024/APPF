﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static PPPP.Metodos;

namespace PPPP
{
    public partial class InterfazEdicion : Form
    {
        private int HojaOriginal1;

        private int maxAlturaFila = 0; // Declaración de la variable maxAlturaFila
        private List<Rectangle> posicionesOcupadas = new List<Rectangle>();
        
        // RECORTAR
        //public Image imagenARecortar;
        private bool recortarActivo = false;
        int xDown = 0;
        int yDown = 0;
        int xUp = 0;
        int yUp = 0;
        Rectangle rectCropArea = new Rectangle();
        Task timeout;
        
        int AuxRecortar = 0;

        ///
        Metodos Metodo = new Metodos();//llamar Clase
        
        public StreamReader lector;
       // PictureBox Hoja;



        PictureBox Imagen = new PictureBox();
        PictureBox ImagenL = new PictureBox();


        int NC = 0;
        double zoomFactor = 1.0;

        public InterfazEdicion()
        {

            InitializeComponent();
            InicializaListBox();
            Globales.Registro.Visible = false;;
            pnResoluciones.Visible = false;
            
            
            //VerificarRecorte();
            
            RecuperaInfo();
            this.PanelPre.Controls.Add(Globales.Hoja);
           

        }

        private void InicializaListBox()
        {
            //desactivo Variables Principales
            NCopias.Enabled = false;
            Resolucion.Enabled = false;
            Recortar.Enabled = false;




            Globales.Registro.Location = new Point(16, 408); // Establecer la ubicación
            Globales.Registro.Size = new Size(225, 238);    // Establecer el tamaño
            panel1.Controls.Add(Globales.Registro);
        }

        private void RecuperaInfo()
        {
            if (Globales.AlertaRecorte == true)
            {


                NCopias.Value = 0;
                NC = (int)NCopias.Value;
                Globales.inX = 0;
                Globales.inY = 0;

                Imagen.Image = System.Drawing.Image.FromFile(Globales.RutaImagen);
                Imagen.Size = pnPrevisualizacion.Size; // Tamaño de la imagen dentro del panel
                Imagen.SizeMode = PictureBoxSizeMode.StretchImage; // Escala la imagen para ajustarse al PictureBox
                pnPrevisualizacion.Controls.Add(Imagen);// Agrega el PictureBox al panel
                LeerRegistro();

            }
            else {
                Globales.Hoja.Tag = Globales.TamañoHoja; // Almacenar el tamaño original de la imagen en el Tag del PictureBox

            }

            LeerRegistro();
            //  VerificarRecorte();
        }



        /*    private void VerificarRecorte()
            {

                // Limpiar cualquier control existente en el panel
                pnPrevisualizacion.Controls.Clear();

                Imagen.Image = ImageContainer.ImagenRecortada ?? Imagen.Image ; // SI NO NADA EN ImageContainer, usa la ImagenGlobal

                if (Imagen.Image == null)
                {
                    MessageBox.Show("No se encontró ninguna imagen para mostrar.");

                }

            }
          */
        private void AbrirImagen()
        {
            try
            {
                
                NCopias.Value = 0;
                NC = (int)NCopias.Value;
                Globales.inX = 0;
                Globales.inY = 0;
                openFileDialog1.ShowDialog();
                Globales.RutaImagen = openFileDialog1.FileName;
                Globales.RutaImagenCP = openFileDialog1.FileName;
                Imagen.Size = pnPrevisualizacion.Size; // Tamaño de la imagen dentro del panel
                Imagen.SizeMode = PictureBoxSizeMode.StretchImage; // Escala la imagen para ajustarse al PictureBox
                Imagen.Image = System.Drawing.Image.FromFile(Globales.RutaImagen); // Carga la imagen
                pnPrevisualizacion.Controls.Add(Imagen);// Agrega el PictureBox al panel
                
                Globales.ImagenGlobal = System.Drawing.Image.FromFile(Globales.RutaImagen);
                Globales.ImagenGlobalCP = System.Drawing.Image.FromFile(Globales.RutaImagen);
                if (Globales.RutaImagen != null)
                {
                    NCopias.Enabled = true;
                    Resolucion.Enabled = true;
                    Recortar.Enabled = true;
                }
                else {

                    MessageBox.Show("Ingresa Una Imagen");
                }

                // Configurar el cursor para el PictureBox de recorte
            }
            catch{}}


        /*
        private void AgrImgHoj(int nC, double zoomFactor)
        {
            int hojaAncho = Hoja.Width; // Ancho del contenedor Hoja
            int hojaAlto = Hoja.Height; // Alto del contenedor Hoja

            // Puntero para encontrar la posición donde colocar la próxima imagen
            Point posicion = new Point(0, 0);

            // Iterar sobre cada imagen
            for (int i = 0; i < nC; i++)
            {
                // Crear un nuevo PictureBox para la imagen
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Image = Imagen.Image; // Asignar la imagen
                pictureBox1.Size = Imagen.Size; // Asignar el tamaño de la imagen

                // Verificar si la imagen cabe en la fila actual
                if (posicion.X + pictureBox1.Width <= hojaAncho)
                {
                    // La imagen cabe en la fila actual, se agrega en la posición actual
                    pictureBox1.Location = posicion;
                    posicion.X += pictureBox1.Width + 10; // Actualizar la posición X con el espacio entre imágenes
                }
                else
                {
                    // La imagen no cabe en la fila actual, se reinicia el puntero
                    posicion = new Point(0, posicion.Y + maxAlturaFila + 10);

                    // Reiniciar la altura máxima de la fila
                    maxAlturaFila = 0;

                    // Mover el puntero hacia abajo hasta encontrar espacio libre
                    while (true)
                    {
                        // Verificar si hay espacio disponible en la posición actual
                        bool espacioDisponible = true;
                        foreach (PosicionOcupada pos in posicionesOcupadas)
                        {
                            if (posicion.X >= pos.X && posicion.X + pictureBox1.Width <= pos.X + pos.Width &&
                                posicion.Y >= pos.Y && posicion.Y + pictureBox1.Height <= pos.Y + pos.Height)
                            {
                                espacioDisponible = false;
                                break;
                            }
                        }

                        // Si hay espacio disponible, se coloca la imagen en la posición actual y se actualiza el puntero
                        if (espacioDisponible)
                        {
                            pictureBox1.Location = posicion;
                            posicion.X += pictureBox1.Width + 10; // Actualizar la posición X con el espacio entre imágenes

                            // Actualizar la altura máxima de la fila si es necesario
                            maxAlturaFila = Math.Max(maxAlturaFila, pictureBox1.Height);

                            break;
                        }
                        else
                        {
                            // Si no hay espacio disponible, se mueve hacia abajo
                            posicion.X = 0;
                            posicion.Y += maxAlturaFila + 10; // Mover a la siguiente fila, usando la altura máxima de la fila actual
                        }
                    }
                }

                // Agregar el PictureBox al PictureBox de la hoja
                Hoja.Controls.Add(pictureBox1);

                // Guardar la posición ocupada
                posicionesOcupadas.Add(new PosicionOcupada(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height));
            }
        }
*/

        // Campo de clase para almacenar las posiciones ocupadas
       
        private void AgrImgHoj(int nC, double zoomFactor,Image Imagen)
        {
            int hojaAncho = Globales.Hoja.Width;
            int hojaAlto = Globales.Hoja.Height;

            // Inicializar la lista de espacios libres con el espacio completo de la hoja si es la primera vez
            List<Rectangle> espaciosLibres;
            if (posicionesOcupadas.Count == 0)
            {
                espaciosLibres = new List<Rectangle>
        {
            new Rectangle(0, 0, hojaAncho, hojaAlto)
        };
            }
            else
            {
                // Si ya hay posiciones ocupadas, calcular los espacios libres restantes
                espaciosLibres = CalcularEspaciosLibres(hojaAncho, hojaAlto);
            }

            for (int i = 0; i < nC; i++)
            {
                // Usar la imagen recortada si está disponible, de lo contrario usar la imagen original
                //Image imagenAUsar = Imagen.Image;    // MODIFICADO 

                Size tamanoImagen = new Size((int)(Imagen.Width * zoomFactor), (int)(Imagen.Height * zoomFactor));
                Rectangle mejorEspacio = Rectangle.Empty;
                int mejorIndice = -1;

                // Buscar el mejor espacio para la imagen
                for (int j = 0; j < espaciosLibres.Count; j++)
                {
                    Rectangle espacio = espaciosLibres[j];
                    if (tamanoImagen.Width <= espacio.Width && tamanoImagen.Height <= espacio.Height)
                    {
                        if (mejorEspacio == Rectangle.Empty || espacio.Width * espacio.Height < mejorEspacio.Width * mejorEspacio.Height)
                        {
                            mejorEspacio = espacio;
                            mejorIndice = j;
                        }
                    }
                }

                // Si no se encuentra un espacio adecuado, salir del bucle
                if (mejorEspacio == Rectangle.Empty)
                {
                    MessageBox.Show("No hay suficiente espacio en la hoja para colocar todas las imágenes.");
                    break;
                }

                // Crear el PictureBox y ubicarlo en el mejor espacio encontrado
                PictureBox pictureBox1 = new PictureBox
                {
                    Image = Imagen,
                    Size = tamanoImagen,
                    Location = new Point(mejorEspacio.X, mejorEspacio.Y),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                Globales.Hoja.Controls.Add(pictureBox1);

                // Actualizar la lista de posiciones ocupadas
                Rectangle espacioUsado = new Rectangle(mejorEspacio.X, mejorEspacio.Y, tamanoImagen.Width, tamanoImagen.Height);
                posicionesOcupadas.Add(espacioUsado);

                // Actualizar la lista de espacios libres
                espaciosLibres.RemoveAt(mejorIndice);
                // Agregar los nuevos espacios libres generados por el espacio ocupado
                espaciosLibres.Add(new Rectangle(espacioUsado.Right, espacioUsado.Top, mejorEspacio.Width - espacioUsado.Width, espacioUsado.Height)); // Espacio a la derecha
                espaciosLibres.Add(new Rectangle(espacioUsado.Left, espacioUsado.Bottom, espacioUsado.Width, mejorEspacio.Height - espacioUsado.Height)); // Espacio debajo

                // Eliminar espacios libres que tengan ancho o alto cero
                espaciosLibres = espaciosLibres.Where(e => e.Width > 0 && e.Height > 0).ToList();
            }
        }

        public  List<Rectangle> CalcularEspaciosLibres(int hojaAncho, int hojaAlto)
        {
            List<Rectangle> espaciosLibres = new List<Rectangle>
    {
        new Rectangle(0, 0, hojaAncho, hojaAlto)
    };

            foreach (var pos in posicionesOcupadas)
            {
                for (int i = espaciosLibres.Count - 1; i >= 0; i--)
                {
                    var espacio = espaciosLibres[i];
                    if (pos.IntersectsWith(espacio))
                    {
                        espaciosLibres.RemoveAt(i);
                        var interseccion = Rectangle.Intersect(pos, espacio);
                        if (interseccion.Top > espacio.Top)
                        {
                            espaciosLibres.Add(new Rectangle(espacio.Left, espacio.Top, espacio.Width, interseccion.Top - espacio.Top));
                        }
                        if (interseccion.Bottom < espacio.Bottom)
                        {
                            espaciosLibres.Add(new Rectangle(espacio.Left, interseccion.Bottom, espacio.Width, espacio.Bottom - interseccion.Bottom));
                        }
                        if (interseccion.Left > espacio.Left)
                        {
                            espaciosLibres.Add(new Rectangle(espacio.Left, interseccion.Top, interseccion.Left - espacio.Left, interseccion.Height));
                        }
                        if (interseccion.Right < espacio.Right)
                        {
                            espaciosLibres.Add(new Rectangle(interseccion.Right, interseccion.Top, espacio.Right - interseccion.Right, interseccion.Height));
                        }
                    }
                }
            }

            return espaciosLibres;
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

   


     


        private void ZoomIn(PictureBox pictureBox)
        {
            Size tamañoOriginal = (Size)pictureBox.Tag;
            Size tamañoActual = pictureBox.ClientSize;
            int nuevoAncho = (int)(tamañoActual.Width * 1.1);
            int nuevoAlto = (int)(tamañoActual.Height * 1.1);
            nuevoAncho = Math.Min(nuevoAncho, tamañoOriginal.Width);
            nuevoAlto = Math.Min(nuevoAlto, tamañoOriginal.Height);
            pictureBox.ClientSize = new Size(nuevoAncho, nuevoAlto);
        }

        // Método para alejar la imagen de la hoja
        private void ZoomOut(PictureBox pictureBox)
        {
            Size tamañoActual = pictureBox.ClientSize;
            int nuevoAncho = (int)(tamañoActual.Width / 1.1);
            int nuevoAlto = (int)(tamañoActual.Height / 1.1);
            pictureBox.ClientSize = new Size(nuevoAncho, nuevoAlto);
        }
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
             ZoomIn(    Globales.Hoja);
        }
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut(Globales.Hoja);

        }


        private void NCopias_ValueChanged(object sender, EventArgs e)
        {
            NC = (int)NCopias.Value;
            LeerRegistro();
            AgrImgHoj(NC, zoomFactor, Imagen.Image);

        }


   

        public void LeerRegistro()
        {
            LimpiarHoja();

            for (int i = 0; i < Globales.Registro.Items.Count; i++)
                {
                    string cadena = Globales.Registro.Items[i].ToString();
                    string[] partes = cadena.Split(',');
                    String RutaImagen;
                    int inX, inY,nc;
                
                    if (partes.Length >= 4) // Asegúrate de que haya al menos tres partes
                    {
                         RutaImagen= partes[0];
                         inX = int.Parse(partes[1]);
                         inY =  int.Parse(partes[2]);
                         nc= int.Parse(partes[3]);

                         ImagenL.Size = pnPrevisualizacion.Size; // Tamaño de la imagen dentro del panel
                         ImagenL.SizeMode = PictureBoxSizeMode.StretchImage; // Escala la imagen para ajustarse al PictureBox
                         ImagenL.Image = System.Drawing.Image.FromFile(RutaImagen); // Carga la imagen
                         Metodo.AddImageToPictureBox(RutaImagen, ImagenL, inX, inY);
                         AgrImgHoj(nc,zoomFactor,ImagenL.Image);
                }
                else
                    {
                        // El formato de la cadena no es válido
                        Console.WriteLine("Formato de cadena no válido: " + cadena);
                    }
            }
    
        }

       
        public void LimpiarHoja()
        {
            // Remueve todas las imágenes de la hoja
            Globales.Hoja.Controls.Clear();
            posicionesOcupadas.Clear();

        }

   
        private void PanelPre_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnPrevisualizacion_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guardar_Click(object sender, EventArgs e)
        {

            // Crear un bitmap del tamaño del PictureBox
            Bitmap bmp = new Bitmap(Globales.Hoja.Width, Globales.Hoja.Height);

            // Dibujar el contenido del PictureBox en el bitmap
            Globales.Hoja.DrawToBitmap(bmp, new Rectangle(0, 0, Globales.Hoja.Width, Globales.Hoja.Height));
            // Crear un cuadro de diálogo para guardar archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de imagen (*.jpg)|*.jpg|Documentos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*";
            saveFileDialog.Title = "Guardar como";

            // Si el usuario selecciona una ruta y hace clic en "Guardar"
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                bmp.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                MessageBox.Show("La hoja se ha guardado correctamente en formato JPG.");

            }

            // Liberar los recursos del bitmap
            bmp.Dispose();

        }

        private void Recortar_Click(object sender, EventArgs e)
        {
            AuxRecortar = 100; //REC
            Recorte recorteForm = new Recorte();  //REC
            recorteForm.Show(); //REC
            //Recorte pnRecorte = new Recorte();
            //pnRecorte.Show();
            this.Visible = false;
            //recortarActivo = true;
            //btnAplicar.Visible = true;
        }

        private void Regist_Click(object sender, EventArgs e)
        {


            Globales.Registro.Visible = !(Globales.Registro.Visible);


        }

        private void Resolucion_Click(object sender, EventArgs e)
        {
            if (Globales.RutaImagen!=null)
            {
                pnResoluciones.Visible = !pnResoluciones.Visible;
            }
            else {
                MessageBox.Show("Seleciona Una IMG Primero");
            }

            
        }

        private void Seleccionar_Click(object sender, EventArgs e)
        {
            AbrirImagen();
        }

        private void AgregarImg_Click(object sender, EventArgs e)
        {


            //Reglas Basicas Para Agregar Img A Registro
            if (NC > 0)
            {
                if (Globales.inX != 0 && Globales.inY != 0)
                {

                    if (!string.IsNullOrEmpty(Globales.RutaImagen))
                    {
                       // LRegistro.Items.Add(openFileDialog1.FileName + ',' + inX.ToString() + ',' + inY.ToString() + ',' + NC);
                        Globales.Registro.Items.Add(Globales.RutaImagen + ',' + Globales.inX.ToString() + ',' + Globales.inY.ToString() + ',' + NC);
                        LeerRegistro();
                    }
                    else
                    {
                        MessageBox.Show("El nombre del archivo no puede ser nulo o vacío");
                    }

                }
                else
                {
                    MessageBox.Show("Ingresa Un Formato");
                }
            }
            else
            {

                MessageBox.Show("Ingresa un Numero de Copias Valido");
            }



        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result != DialogResult.Cancel)
            { 
            InterfazPrincipal interfazPrincipal = new InterfazPrincipal();

            // Mostrar el nuevo formulario
            this.Visible = false;
            interfazPrincipal.Show();
                //System.exit()
            }



        }

        private void i5x7_Click(object sender, EventArgs e)
        {

            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            Globales.inX = 5;
            Globales.inY = 7;

            // Usar la imagen recortada si está disponible

            
            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, Globales.inX * 300, Globales.inY * 300);

            // Mostrar la imagen redimensionada en el PictureBox
            Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
            Imagen.Size = resizedImage.Size;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;

        }



        private void i4x6_Click(object sender, EventArgs e)
        {
            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            Globales.inX = 4;
            Globales.inY = 6;

            // Usar la imagen recortada si está disponible
           
            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, Globales.inX * 300, Globales.inY * 300);
            // Mostrar la imagen redimensionada en el PictureBox
            Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
            Imagen.Size = resizedImage.Size;
            Imagen.Image = resizedImage;


            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;
        }

        private void infantil_Click(object sender, EventArgs e)
        {

            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            Globales.inX = 2;
            Globales.inY = 2;

            // Usar la imagen recortada si está disponible
            
            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, Globales.inX * 300, Globales.inY * 300);

            // Mostrar la imagen redimensionada en el PictureBox
            Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
            Imagen.Size = resizedImage.Size;
            Imagen.Image = resizedImage;

            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;

        }

        private void pbRecortar_MouseDown(object sender, MouseEventArgs e)
        {
            if (recortarActivo)
            {
                // Guarda las coordenadas del punto inicial del área de recorte
                xDown = e.X;
                yDown = e.Y;
            }
        }

     
        }
}