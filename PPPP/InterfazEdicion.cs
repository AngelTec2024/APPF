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
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Timers;
using static PPPP.Metodos;

namespace PPPP
{
    public partial class InterfazEdicion : Form
    {
        private int HojaOriginal1;
        PictureBox Hoja;
        private int maxAlturaFila = 0; // Declaración de la variable maxAlturaFila
        private List<Rectangle> posicionesOcupadas = new List<Rectangle>();
        
        
        int AuxRecortar = 0;

        ///
        Metodos Metodo = new Metodos();//llamar Clase
        
        public StreamReader lector;
       // PictureBox Hoja;



        PictureBox Imagen = new PictureBox();
        PictureBox ImagenL = new PictureBox();


        int NC = 0,inX=0,inY=0;
        double zoomFactor = 1.0;


        private System.Timers.Timer backupTimer;



        public InterfazEdicion()
        {

            InitializeComponent();
            TPHoja();
            VerificarRecorte();
            InicializaListBox();
            LeerRegistro();
            Globales.Registro.Visible = false;;
            pnResoluciones.Visible = false;
            btnEliminar.Visible = false;
            if(Globales.AuxAgregarImagen == 0 )
            {
                NCopias.Enabled = false;
                Recortar.Enabled = false;
                Resolucion.Enabled = false;
                AgregarImg.Enabled = false;
            }

            InitializeBackupTimer();

        }
        private void InitializeBackupTimer()         //  BKUPAUTO
        {
            backupTimer = new System.Timers.Timer();
            backupTimer.Interval = 60000; // Intervalo en milisegundos (60000 ms = 1 minuto)
            backupTimer.Elapsed += BackupTimer_Elapsed;
            backupTimer.AutoReset = true; // Para que se repita automáticamente
            backupTimer.Start();
        }

        private void BackupTimer_Elapsed(object sender, ElapsedEventArgs e)       //  BKUPAUTO
        {
            CrearRespaldo();
        }

        private void CrearRespaldo()   //  BKUPAUTO
        {
            string backupFileName = $"configuracion_{DateTime.Now:yyyyMMdd_HHmmss}.json";
            string filePath = Path.Combine(Globales.BackupDirectory, backupFileName);
            Globales.GuardarConfiguracion(filePath);
        }





        private void InicializaListBox()
        {
            //desactivo Variables Principales
          
            Globales.Registro.Location = new Point(16, 408); // Establecer la ubicación
            Globales.Registro.Size = new Size(225, 238);    // Establecer el tamaño
            panel1.Controls.Add(Globales.Registro);
         
           


        }

      /*  private void RecuperaInfo()
        {

            PanelPre.Controls.Clear();
            PanelPre.Controls.Add(Globales.Hoja);
            LimpiarHoja();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 0;
            inY = 0;
            zoomFactor = 1;
            LeerRegistro();

            Imagen.Image = System.Drawing.Image.FromFile(Globales.RutaImagen);
            Imagen.Size = pnPrevisualizacion.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.StretchImage; // Escala la imagen para ajustarse al PictureBox
            pnPrevisualizacion.Controls.Add(Imagen); // Agrega el PictureBox al panel
            
            Globales.Hoja.Tag = Globales.TamañoHoja; // Almacenar el tamaño original de la imagen en el Tag del PictureBox
            
            //  VerificarRecorte();
        }
      */


            private void VerificarRecorte()
            {

            // Limpiar cualquier control existente en el panel
            //pnPrevisualizacion.Controls.Clear();
            Imagen.Size = pnPrevisualizacion.Size; // Tamaño de la imagen dentro del panel

            //Imagen.SizeMode = PictureBoxSizeMode.StretchImage; // Escala la imagen para ajustarse al PictureBox
            
            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;

            Imagen.Image = ImageContainer.ImagenRecortada ??Globales.ImagenGlobalCP; // SI NO NADA EN ImageContainer, usa la ImagenGlobal
            pnPrevisualizacion.Controls.Add(Imagen);
            if (Imagen.Image == null)
                {
                    //MessageBox.Show("No se encontró ninguna imagen para mostrar.");
                }

            }
        
        private void AbrirImagen()
        {
            try
            {
                
                NCopias.Value = 0;
                NC = (int)NCopias.Value;
                inX = 0;
                inY = 0;
                openFileDialog1.ShowDialog();
                Globales.RutaImagen = openFileDialog1.FileName;
                Globales.RutaImagenCP = openFileDialog1.FileName;
                
                Globales.ImagenGlobalCP = System.Drawing.Image.FromFile(Globales.RutaImagen);


                pnPrevisualizacion.BackColor = Color.Gray;
                Imagen.Size = pnPrevisualizacion.Size; // Tamaño de la imagen dentro del panel
                Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
                Imagen.Dock = DockStyle.Fill;
                Imagen.Image = System.Drawing.Image.FromFile(Globales.RutaImagen); // Carga la imagen
                pnPrevisualizacion.Controls.Add(Imagen);


                /*
                Imagen.Size = pnPrevisualizacion.Size; // Tamaño de la imagen dentro del panel
                Imagen.SizeMode = PictureBoxSizeMode.StretchImage; // Escala la imagen para ajustarse al PictureBox
                Imagen.Image = System.Drawing.Image.FromFile(Globales.RutaImagen); // Carga la imagen
                pnPrevisualizacion.Controls.Add(Imagen);// Agrega el PictureBox al panel
                */
                
                if (Globales.RutaImagen != null)
                {
                    NCopias.Enabled = true;
                    Resolucion.Enabled = true;
                    Recortar.Enabled = true;
                 
                    AgregarImg.Enabled = true;
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

        // Version PreUlti
        
         private void AgrImgHoj(int nC, double zoomFactor,Image Imagen)
         {
             int hojaAncho =Hoja.Width;
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
            Hoja.Controls.Clear();
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

        private void Recortar_Click(object sender, EventArgs e)
        {

            if (Imagen.Image != null)
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
            else {

                MessageBox.Show("favor de seleccionar Una Foto");
            }

        }

        private void Regist_Click(object sender, EventArgs e)
        {


            Globales.Registro.Visible = !(Globales.Registro.Visible);
            btnEliminar.Visible = !(btnEliminar.Visible);

        }

        private void Resolucion_Click(object sender, EventArgs e)
        {
            if (Imagen.Image!=null)
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
            Globales.AuxAgregarImagen = 1;
        }

        private void AgregarImg_Click(object sender, EventArgs e)
        {


            //Reglas Basicas Para Agregar Img A Registro
            if (NC > 0)
            {
                if (inX != 0 && inY != 0)
                {

                    if (!string.IsNullOrEmpty(Globales.RutaImagen))
                    {
                       // LRegistro.Items.Add(openFileDialog1.FileName + ',' + inX.ToString() + ',' + inY.ToString() + ',' + NC);
                        Globales.Registro.Items.Add(Globales.RutaImagen + ',' + inX.ToString() + ',' + inY.ToString() + ',' + NC);
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

            var result = MessageBox.Show("¿Desea guardar el estado del programa?", "Estado del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = Globales.BackupDirectory;
                    saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    saveFileDialog.DefaultExt = "json";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.FileName = $"configuracion_{DateTime.Now:yyyyMMdd_HHmmss}.json";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        Globales.GuardarConfiguracion(filePath);
                    }
                }

               

            }
            Globales.ReiniciarVariables();

            // Detén el temporizador al salir
            if (backupTimer != null)
            {
                backupTimer.Stop();
                backupTimer.Dispose();
            }

            InterfazPrincipal interfazPrincipal = new InterfazPrincipal();
            this.Visible = false;
            interfazPrincipal.Show();

        }

        private void i5x7_Click(object sender, EventArgs e)
        {

            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 5;
            inY = 7;

            // Usar la imagen recortada si está disponible

            
            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, inX * 300, inY * 300);




            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.Size = resizedImage.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;


            // Mostrar la imagen redimensionada en el PictureBox
            /*
            Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
            Imagen.Size = resizedImage.Size;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;
            */
        }



        private void i4x6_Click(object sender, EventArgs e)
        {
            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 4;
            inY = 6;

            // Usar la imagen recortada si está disponible
           
            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, inX * 300, inY * 300);



            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.Size = resizedImage.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;

            /*
            // Mostrar la imagen redimensionada en el PictureBox
            Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
            Imagen.Size = resizedImage.Size;
            Imagen.Image = resizedImage;
             pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;*/
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int selectedIndex = Globales.Registro.SelectedIndex;

            // Verificar si hay un elemento seleccionado
            if (selectedIndex != -1)
            {
                // Eliminar el elemento seleccionado
                Globales.Registro.Items.RemoveAt(selectedIndex);
                LeerRegistro();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void infantil_Click(object sender, EventArgs e)
        {

            pnResoluciones.Visible = false;
            pnPrevisualizacion.Controls.Clear();
            NCopias.Value = 0;
            NC = (int)NCopias.Value;
            inX = 2;
            inY = 2;

            // Usar la imagen recortada si está disponible
            
            // Redimensionar la imagen
            Image resizedImage = Metodo.ResizeImage(Imagen.Image, inX * 300, inY * 300);

            // Mostrar la imagen redimensionada en el PictureBox
            pnPrevisualizacion.BackColor = Color.Gray;
            Imagen.Size = resizedImage.Size; // Tamaño de la imagen dentro del panel
            Imagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que se vea completa
            Imagen.Dock = DockStyle.Fill;
            Imagen.Image = resizedImage;
            pnPrevisualizacion.Controls.Add(Imagen);
            pnResoluciones.Visible = false;

        }


        public void TPHoja()
        {
            Size tamañoHoja;
            switch (Globales.tipoH)
            {
                case 1: // Carta
                    tamañoHoja = new Size(2550, 3300); // Tamaño en píxeles (ancho x alto)
                    break;

                case 2: // Oficio
                    tamañoHoja = new Size(2550, 4200); // Tamaño en píxeles (ancho x alto)
                    break;

                case 3: // A4
                    tamañoHoja = new Size(2490, 3510); // Tamaño en píxeles (ancho x alto)
                    break;

                case 4://A3
                    tamañoHoja = new Size(3510, 4950);
                    break;

                case 5://A2
                    tamañoHoja = new Size(4950, 7020);
                    break;

                case 6:
                    tamañoHoja = new Size(3300, 5100);
                    break;

                default:
                    MessageBox.Show("Tipo de número no válido. Por favor, elija 1 para Carta o 2 para Oficio.");
                    return;
            }

            /*PanelPre.BackColor = Color.Gray;
            Hoja = new PictureBox
            {
                BackColor = Color.White,
                SizeMode = PictureBoxSizeMode.Zoom // Ajustar la imagen manteniendo la proporción
            };

            // Calcular las dimensiones del PictureBox para que se ajuste dentro del Panel manteniendo la proporción
            Size panelSize = PanelPre.ClientSize;
            float ratioHoja = (float)tamañoHoja.Width / tamañoHoja.Height;
            float ratioPanel = (float)panelSize.Width / panelSize.Height;

            if (ratioHoja > ratioPanel)
            {
                Hoja.Width = panelSize.Width;
                Hoja.Height = (int)(panelSize.Width / ratioHoja);
            }
            else
            {
                Hoja.Height = panelSize.Height;
                Hoja.Width = (int)(panelSize.Height * ratioHoja);
            }

            // Centrando el PictureBox dentro del Panel
            Hoja.Location = new Point(
                (panelSize.Width - Hoja.Width) / 2,
                (panelSize.Height - Hoja.Height) / 2
            );

            // Añadir el PictureBox grande (Hoja) al Panel
            PanelPre.Controls.Clear(); // Limpiar controles previos si existen
            PanelPre.Controls.Add(Hoja);
            PanelPre.BackColor = Color.Gray;
        
        //-------------
        */





       

            
            // funciona con scroll
            Hoja = new PictureBox();

            Hoja.Left = 50;
            Hoja.BackColor = Color.White;
            Hoja.Top = 50;
            Hoja.Size = tamañoHoja; // Tamaño del PictureBox igual al tamaño de la hoja
            Hoja.SizeMode = PictureBoxSizeMode.Zoom; // Escalar la imagen para ajustarse al PictureBox

            PanelPre.Controls.Add(Hoja);
            
        }
 


    }
}