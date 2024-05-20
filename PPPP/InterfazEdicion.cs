using System;
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
        public Image imagenARecortar;
        private bool recortarActivo = false;
        int xDown = 0;
        int yDown = 0;
        int xUp = 0;
        int yUp = 0;
        Rectangle rectCropArea = new Rectangle();
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        Task timeout;
        string fn = "";

        int AuxRecortar = 0;
        int AuxTHoja;

        ///
        Metodos Metodo = new Metodos();//llamar Clase
        int inX, inY; 
        int innX,innY,NNC; String Direc;
        string FName;
        public StreamReader lector;
        PictureBox Hoja;
        
        PictureBox Imagen = new PictureBox();
        
        int NC=0;
        double zoomFactor = 1.0;

        public InterfazEdicion()
        {

            InitializeComponent();
            LRegistro.Visible = false;
            Metodos Metodos = new Metodos();   
            pnResoluciones.Visible = false;
            btnAplicar.Visible = false;

            VerificarRecorte();
        }

        public void ObtenerHoja(int HojaOriginal)
        {
            HojaOriginal1 = HojaOriginal;
        }

        private void VerificarRecorte()
        {

            if (ImageContainer.ImagenRecortada != null)
            {
                // Limpiar cualquier control existente en el panel
                pnPrevisualizacion.Controls.Clear();

                // Crear un nuevo PictureBox para la imagen recortada
                PictureBox Imagen = new PictureBox
                {
                    Size = pnPrevisualizacion.Size, // Tamaño de la imagen dentro del panel
                    SizeMode = PictureBoxSizeMode.StretchImage, // Escala la imagen para ajustarse al PictureBox
                    Image = ImageContainer.ImagenRecortada // Asigna la imagen recortada
                };

                // Agregar el PictureBox al panel
                pnPrevisualizacion.Controls.Add(Imagen);

                // Resetear la imagen recortada después de usarla
                //ImageContainer.ImagenRecortada = null;
                AuxRecortar = 10;
                TPHoja(1);
            }
        }


        private void AbrirImagen()
        {
            try
            {

                openFileDialog1.ShowDialog();
                FName = openFileDialog1.FileName;
                Console.WriteLine(FName);

                Imagen.Size = pnPrevisualizacion.Size; // Tamaño de la imagen dentro del panel
                Imagen.SizeMode = PictureBoxSizeMode.StretchImage; // Escala la imagen para ajustarse al PictureBox
                Imagen.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName); // Carga la imagen
                pnPrevisualizacion.Controls.Add(Imagen);// Agrega el PictureBox al panel

                imagenARecortar = Image.FromFile(openFileDialog1.FileName);
                // Configurar el cursor para el PictureBox de recorte
                fn = FName;

                //pbPrueba.Cursor = Cursors.Cross;

                AuxRecortar = 5;
            }
            catch
            {
                //error 

            }
        }


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
       
        private void AgrImgHoj(int nC, double zoomFactor,Image imagenRecortada = null)
        {
            int hojaAncho = Hoja.Width;
            int hojaAlto = Hoja.Height;

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
                Image imagenAUsar = imagenRecortada ?? Imagen.Image;

                Size tamanoImagen = new Size((int)(imagenAUsar.Width * zoomFactor), (int)(imagenAUsar.Height * zoomFactor));
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
                    Image = imagenAUsar,
                    Size = tamanoImagen,
                    Location = new Point(mejorEspacio.X, mejorEspacio.Y),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                Hoja.Controls.Add(pictureBox1);

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

        private void btnSalir_Click(object sender, EventArgs e)
        {

            InterfazPrincipal interfazPrincipal = new InterfazPrincipal();

            // Mostrar el nuevo formulario
            this.Visible = false;
            interfazPrincipal.Show();


        }


        public void TPHoja(int tipoH)
        {
            Size tamañoHoja;
            switch (tipoH)
            {
                case 1: // Carta
                    tamañoHoja = new Size(2550, 3300); // Tamaño en píxeles (ancho x alto)
                    break;

                case 2: // Oficio
                    tamañoHoja = new Size(2550, 4200); // Tamaño en píxeles (ancho x alto)
                    break;

                case 3: // A4
                    tamañoHoja = new Size(2480, 3508); // Tamaño en píxeles (ancho x alto)
                    break;

                // ------------------- 01/05/24 -----------------------------------------------
                case 4:
                    tamañoHoja = new Size(3508, 4961);
                    break;

                case 5:
                    tamañoHoja = new Size(5100, 6600);
                    break;


                default:
                    MessageBox.Show("Tipo de número no válido. Por favor, elija 1 para Carta o 2 para Oficio.");
                    return;
            }

            // Crear el PictureBox para la previsualización de la hoja
            Hoja = new PictureBox();
            Hoja.Left = 50;
            Hoja.BackColor = Color.White;
            Hoja.Top = 50;
            Hoja.Size = tamañoHoja; // Tamaño del PictureBox igual al tamaño de la hoja
            Hoja.SizeMode = PictureBoxSizeMode.Zoom; // Escalar la imagen para ajustarse al PictureBox

            // Cargar la imagen de la hoja en el PictureBox
            // (Asegúrate de reemplazar "HojaOriginal" con el nombre de tu imagen)
            //Hoja.Image = Properties.Resources.HojaOriginal; // Cambiar "HojaOriginal" por el nombre de tu imagen
            Hoja.Tag = tamañoHoja; // Almacenar el tamaño original de la imagen en el Tag del PictureBox
            //Hoja.SizeChanged += Hoja_SizeChanged;
            // Agregar el PictureBox al formulario
            this.PanelPre.Controls.Add(Hoja);

            if (AuxRecortar == 0)//REC
            { //REC
                AbrirImagen(); // SELECCIONAR IMAGEN AL ABRIR LA VENTANA
            }//REC
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
             ZoomIn(Hoja);
        }
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut(Hoja);

        }


        private void NCopias_ValueChanged(object sender, EventArgs e)
        {
            NC = (int)NCopias.Value;
            LeerRegistro();
            //AgrImgHoj(NC, zoomFactor);
            AgrImgHoj(NC, zoomFactor, ImageContainer.ImagenRecortada);

        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Crear un bitmap del tamaño del PictureBox
            Bitmap bmp = new Bitmap(Hoja.Width, Hoja.Height);

            // Dibujar el contenido del PictureBox en el bitmap
            Hoja.DrawToBitmap(bmp, new Rectangle(0, 0, Hoja.Width, Hoja.Height));
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void button4_Click(object sender, EventArgs e)
        {

            if (pnResoluciones.Visible == true)
            {
                pnResoluciones.Visible = false;
            }
            else {
                pnResoluciones.Visible = true;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void in5x7(object sender, EventArgs e)
        {
            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 5;
            inY = 7;

            // Usar la imagen recortada si está disponible
            Image imagenAUsar = ImageContainer.ImagenRecortada ?? Image.FromFile(openFileDialog1.FileName);

            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(imagenAUsar, inX * 300, inY * 300);

            // Mostrar la imagen redimensionada en el PictureBox
            Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
            Imagen.Size = resizedImage.Size;
            Imagen.Image = resizedImage;

            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;
            /*pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 5;
            inY = 7;

            Metodo.AddImageToPictureBox(openFileDialog1.FileName, Imagen, inX, inY);
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;*/
        }

        private void in4x6(object sender, EventArgs e)
        {
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value=0;
            NC = (int)NCopias.Value;
            inX = 4;
            inY = 6;
            
            Metodo.AddImageToPictureBox(openFileDialog1.FileName, Imagen, inX, inY);
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;
        }

        private void inInf(object sender, EventArgs e)
        {

            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 2;
            inY = 2;

            Metodo.AddImageToPictureBox(openFileDialog1.FileName, Imagen, inX, inY);
            pnPrevisualizacion.Controls.Add(Imagen);



            pnResoluciones.Visible = false;
        }
        

        private void SelectImg_Click(object sender, EventArgs e)
        {

            AbrirImagen();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Registro_Click(object sender, EventArgs e)
        {
            if (LRegistro.Visible == true)
            {
                LRegistro.Visible = false;
            }
            else {
                LRegistro.Visible = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            AuxRecortar = 100; //REC
            Recorte recorteForm = new Recorte(imagenARecortar);  //REC
            recorteForm.Show(); //REC
            //Recorte pnRecorte = new Recorte();
            //pnRecorte.Show();
            this.Visible = false;
            //recortarActivo = true;
            //btnAplicar.Visible = true;
        }



        private void Agregar_Click(object sender, EventArgs e)
        {
            LRegistro.Items.Add(openFileDialog1.FileName+ ',' + inX +','+ inY +',' + NC);
            LeerRegistro();
        }

        

        public void LeerRegistro()
        {
            LimpiarHoja();
          
            NNC = NC;
            innX = inX;
            innY = inY;
            Direc = openFileDialog1.FileName;
//--------------------------------------------//
for (int i = 0; i < LRegistro.Items.Count; i++)
            {
                string cadena = LRegistro.Items[i].ToString();
                string[] partes = cadena.Split(',');
                
                if (partes.Length >= 4) // Asegúrate de que haya al menos tres partes
                {
                     openFileDialog1.FileName= partes[0];
                     inX = int.Parse(partes[1]);
                     inY =  int.Parse(partes[2]);
                     NC= int.Parse(partes[3]);

                     Imagen.Size = pnPrevisualizacion.Size; // Tamaño de la imagen dentro del panel
                     Imagen.SizeMode = PictureBoxSizeMode.StretchImage; // Escala la imagen para ajustarse al PictureBox
                     Imagen.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName); // Carga la imagen
                  
                     Metodo.AddImageToPictureBox(openFileDialog1.FileName, Imagen, inX, inY);
                     AgrImgHoj(NC,zoomFactor);
                }
                else
                {
                    // El formato de la cadena no es válido
                    Console.WriteLine("Formato de cadena no válido: " + cadena);
                }
            }

            //--------------------------------------------//
            
                    openFileDialog1.FileName=Direc;
            inX = innX;
            inY = innY;
            NC = NNC;
            

        }

       
        public void LimpiarHoja()
        {
            // Remueve todas las imágenes de la hoja
            Hoja.Controls.Clear();

            // Limpia la lista de posiciones ocupadas
            posicionesOcupadas.Clear();
        }



        // ----------------------- METODOS RECORTAR IMAGEN -----------------------------
        private Image ObtenerImagenRecortada()
        {
            // Verificar si hay una región recortada
            if (rectCropArea.Width > 0 && rectCropArea.Height > 0)
            {
                // Crear un nuevo Bitmap para la imagen recortada
                Bitmap recortadaBitmap = new Bitmap(rectCropArea.Width, rectCropArea.Height);

                // Dibujar el área recortada en el nuevo Bitmap
                using (Graphics g = Graphics.FromImage(recortadaBitmap))
                {
                    g.DrawImage(pbRecortar.Image, new Rectangle(0, 0, rectCropArea.Width, rectCropArea.Height), rectCropArea, GraphicsUnit.Pixel);
                }

                // Devolver la imagen recortada
                return recortadaBitmap;
            }
            else
            {
                // Si no hay región recortada, devolver la imagen original del PictureBox pbRecortar
                return pbRecortar.Image;
            }

        }

        private void PanelPre_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnPrevisualizacion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

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

        private void pbRecortar_MouseUp(object sender, MouseEventArgs e)
        {
             if (recortarActivo)
            {
                // Guarda las coordenadas del punto final del área de recorte
                xUp = e.X;
                yUp = e.Y;

                // Calcula las coordenadas y dimensiones del área de recorte
                rectCropArea = new Rectangle(
                    Math.Min(xDown, xUp),
                    Math.Min(yDown, yUp),
                    Math.Abs(xUp - xDown),
                    Math.Abs(yUp - yDown));

                // Dibuja un rectángulo en el PictureBox para mostrar el área seleccionada
                using (Pen pen = new Pen(Color.YellowGreen, 3))
                {
                    pbRecortar.CreateGraphics().DrawRectangle(pen, rectCropArea);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Crea un nuevo Bitmap para la imagen recortada
                Bitmap recortadaBitmap = new Bitmap(rectCropArea.Width, rectCropArea.Height);

                // Dibuja el área recortada en el nuevo Bitmap
                using (Graphics g = Graphics.FromImage(recortadaBitmap))
                {
                    g.DrawImage(pbRecortar.Image, new Rectangle(0, 0, rectCropArea.Width, rectCropArea.Height), rectCropArea, GraphicsUnit.Pixel);
                }

                // Actualiza la imagen del PictureBox pbRecortar con la imagen recortada
                pbRecortar.Image = recortadaBitmap;

                // Oculta el botón para aplicar el recorte
                btnAplicar.Visible = false;
                recortarActivo = false;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir
                MessageBox.Show("Error al aplicar el recorte: " + ex.Message);
            }
        } ////
        }
}