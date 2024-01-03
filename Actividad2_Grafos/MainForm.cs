/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 12/10/2023
 * Time: 08:19 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Actividad2_Grafos
{
	public partial class MainForm : Form
	{
		int pairClick;
		Bitmap bmpGrafo;
		Bitmap bmpAnimacion; 	//new
		Grafo grafo;			//new
		Agente agente;
		Agente objetivo;
		List<Circle> cl;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			cl = new List<Circle>();
			pairClick = 1;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ButtonImagenClick(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			bmpGrafo = new Bitmap(openFileDialog1.FileName);
			bmpAnimacion = new Bitmap(openFileDialog1.FileName);
			pictureBoxImage.Image = bmpGrafo;
			pictureBoxImage.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBoxImage.BackgroundImage = bmpAnimacion;
			
			treeViewGrafo.Nodes.Clear();
			cl.Clear();
			pictureBoxImage.Refresh();
		}
		
		void ButtonAnalizarClick(object sender, EventArgs e)
		{
			//ENCONTRAR CIRCULO
			Color c_i;
			for(int y_i = 0; y_i < bmpGrafo.Height; y_i++){
				for(int x_i = 0; x_i < bmpGrafo.Width; x_i++)
				{
					c_i = bmpGrafo.GetPixel(x_i,y_i);
					if(isBlack(c_i))
					{
						//ENCUENTRA CENTRO
						Color c_n;
						int y_superior = y_i;
						
						int y_inferior = y_i;
						do{
							y_inferior++;
							c_n = bmpGrafo.GetPixel(x_i,y_inferior);
						}while(!isWhite(c_n));
						
						int y_centro = (y_superior + y_inferior)/2;
						
						int x_derecha = x_i;
						do{
							x_derecha++;
							c_n = bmpGrafo.GetPixel(x_derecha,y_centro);
						}while(!isWhite(c_n));
						
						int x_izquierda = x_i;
						do{
							x_izquierda--;
							c_n = bmpGrafo.GetPixel(x_izquierda,y_centro);
						}while(!isWhite(c_n));
						
						int x_centro = (x_derecha + x_izquierda)/2;
						
						//DIBIJAR PARA EVITAR CIRCULOS REPETIDOS
						int d = y_inferior - y_superior + 10;
						int r = y_centro - y_superior + 5;
						Graphics g = Graphics.FromImage(bmpGrafo);
						Brush brocha = new SolidBrush(Color.White);
						g.FillEllipse(brocha, x_centro - d/2, y_centro - d/2, d,d);
						pictureBoxImage.Refresh();
						
						cl.Add(new Circle(new Point(x_centro,y_centro),cl.Count+1,r,d));
						
						break;
					}
				}
			}
			
			
			grafo = new Grafo(cl);
//			drawCircles(cl);
			ShowGrafo();
			
//			grafoCopia = grafo;
			//DIBUJA LOS CIRCULOS Y SU ID
			Brush brochaCrimson = new SolidBrush(Color.Gainsboro);
			Brush brochaRed = new SolidBrush(Color.Red);
			Brush brochaBlack = new SolidBrush(Color.Black);
			for(int i = 0; i<cl.Count; i++){
				Graphics g = Graphics.FromImage(bmpGrafo);
				Graphics f = Graphics.FromImage(bmpAnimacion);
				Font drawFont = new Font("Arial",15);
				g.FillEllipse(brochaCrimson, cl[i].getP_cX() - cl[i].getD()/2, cl[i].getP_cY() - cl[i].getD()/2, cl[i].getD(),cl[i].getD());
				g.FillEllipse(brochaRed, cl[i].getP_cX() - 15/2, cl[i].getP_cY() - 15/2, 15,15);
				g.DrawString(cl[i].getId().ToString(), drawFont, brochaBlack, cl[i].getP_cX() - 15, cl[i].getP_cY() - 15);
				f.FillEllipse(brochaCrimson, cl[i].getP_cX() - cl[i].getD()/2, cl[i].getP_cY() - cl[i].getD()/2, cl[i].getD(),cl[i].getD());
				f.FillEllipse(brochaRed, cl[i].getP_cX() - 15/2, cl[i].getP_cY() - 15/2, 15,15);
				f.DrawString(cl[i].getId().ToString(), drawFont, brochaBlack, cl[i].getP_cX() - 15, cl[i].getP_cY() - 15);
				pictureBoxImage.Refresh();
			}
			
		}
		public void ShowGrafo()
		{
			Pen aristaPen = new Pen(Color.Green,5);
			Brush brochaVertice = new SolidBrush(Color.DarkGreen);
			Graphics g = Graphics.FromImage(bmpGrafo);
			Graphics f = Graphics.FromImage(bmpAnimacion);
			Circle c_o,c_d;
			
			
			
//			Valida que las no existe intervenciones en el camino
//			for(int i = 0; i < grafo.Count; i++){
//				Vertice v_o = grafo.getVerticeAt(i);
//				for(int j = i+1; j < grafo.Count; j++){
//					Vertice v_d = grafo.getVerticeAt(j);
//					isObstruccion(v_o,v_d);
//				}
//			}
			
			
			for(int i = 0; i < grafo.Count; i++){
				Vertice v_o = grafo.getVerticeAt(i);
				c_o = v_o.CIRCLE;
				for(int j = 0; j < v_o.AristasCount; j++){
					Vertice v_d = v_o.getDestinationAt(j);
					c_d = v_d.CIRCLE;
					g.DrawLine(aristaPen,c_o.P_c,c_d.P_c);
					f.DrawLine(aristaPen,c_o.P_c,c_d.P_c);
					
				}
			}
			for(int i = 0; i < grafo.Count; i++){
				Vertice v_o = grafo.getVerticeAt(i);
				TreeNode node = new TreeNode(v_o.Id.ToString());
				for(int j = 0; j < v_o.AristasCount; j++){
					Vertice v_d = v_o.getDestinationAt(j);
					TreeNode node_son = new TreeNode(v_d.Id.ToString());
					node.Nodes.Add(node_son);
					
				}
				treeViewGrafo.Nodes.Add(node);
			}
		}
		void PictureBoxImageMouseClick(object sender, MouseEventArgs e)
		{
			float[] x_y = ConvertirTamanio(e);
			construcion(x_y);
		}
		void construcion(float[] x_y)
		{
			Vertice v;
			int index_v = belongsToAVertice(x_y[0], x_y[1]);
			if(index_v != -1){
				pairClick *= -1;
				if(pairClick==-1){
					v = VbelongsToAVertice(x_y[0], x_y[1]);
					agente = new Agente(index_v,12);
					Brush VerticeBrush = new SolidBrush(Color.Brown);
					Graphics g = Graphics.FromImage(bmpGrafo);
					g.FillEllipse(VerticeBrush, v.CIRCLE.P_c.X - v.CIRCLE.getRadio(), v.CIRCLE.P_c.Y - v.CIRCLE.getRadio(),v.CIRCLE.getD(),v.CIRCLE.getD());
					pictureBoxImage.Refresh();
				}
				else{
					v = VbelongsToAVertice(x_y[0], x_y[1]);
					objetivo = new Agente(index_v,12);
					Brush VerticeBrush = new SolidBrush(Color.Blue);
					Graphics g = Graphics.FromImage(bmpGrafo);
					g.FillEllipse(VerticeBrush, v.CIRCLE.P_c.X - v.CIRCLE.getRadio(), v.CIRCLE.P_c.Y - v.CIRCLE.getRadio(),v.CIRCLE.getD(),v.CIRCLE.getD());
					pictureBoxImage.Refresh();
					simulationStar();
				}
			}
		}
		void simulationStar() 		//new ->
		{
			int r = 20;
			Point p_k;
			float [] x_y;
			x_y = new float[2];
			Brush agentBrush = new SolidBrush(Color.Gold);
			Brush eraserParticleBrush = new SolidBrush(Color.Transparent);
			
			grafo = new Grafo(cl);
			
			label1.Text = "";
			
			Random rand = new Random();
			//agente.vertex es la posición del arreglo NO el id del vertice
			Graphics g = Graphics.FromImage(bmpGrafo);//bmpAnimation
			while(agente.VertexIndex != objetivo.VertexIndex ){
				Vertice v = grafo.getVerticeAt(agente.VertexIndex);
				
				
				//Aqui se eligira el ramdom
				int randAristaIndex = rand.Next(0,v.Al.Count);
				
				Point [] path = v.getPathAt(randAristaIndex);
				agente.Path = path;
				
				
				label1.Text += v.Id.ToString() +" "+ v.Al[randAristaIndex].Destination.Id  +"\n";
				
				
				Vertice vc = grafo.getVerticeAt(v.Al[randAristaIndex].Destination.Id - 1);
				for(int i=0; i<vc.Al.Count; i++){
					if(v.Id == vc.Al[i].Destination.Id){
						v.eliminarArista(randAristaIndex);
						vc.eliminarArista(i);
						break;
					}
				}
				
				while(agente.walk()){
					g.Clear(Color.Transparent);
					p_k = agente.getActualPosition();
					g.FillEllipse(agentBrush, p_k.X - r, p_k.Y - r,r*2,r*2);
					//g.FillEllipse(eraserParticleBrush, p_k.X - r, p_k.Y - r,r*2,r*2);
					pictureBoxImage.Refresh();
					x_y[0] = p_k.X;
					x_y[1] = p_k.Y;
				}
				int index_v = belongsToAVertice(x_y[0], x_y[1]);
				agente = new Agente(index_v,12);
			}
		}
		int belongsToAVertice(float x_i, float y_i)			//new->
		{
			Circle c_i;
			Vertice v_i;
			float s;
			float x_c;
			float y_c;
			float r;
			for(int i = 0; i < grafo.Count; i++){
				v_i = grafo.getVerticeAt(i);
				c_i = v_i.CIRCLE;
				x_c = c_i.P_c.X;
				y_c = c_i.P_c.Y;
				r = c_i.getRadio();
				s = (float)Math.Sqrt((x_i - x_c)*(x_i - x_c)+(y_i - y_c)*(y_i - y_c));
				if(s < r)
					return i;
			}
			return -1;
		}
		Vertice VbelongsToAVertice(float x_i, float y_i)			//new->
		{
			Circle c_i;
			Vertice v_i;
			float s;
			float x_c;
			float y_c;
			float r;
			for(int i = 0; i < grafo.Count; i++){
				v_i = grafo.getVerticeAt(i);
				c_i = v_i.CIRCLE;
				x_c = c_i.P_c.X;
				y_c = c_i.P_c.Y;
				r = c_i.getRadio();
				s = (float)Math.Sqrt((x_i - x_c)*(x_i - x_c)+(y_i - y_c)*(y_i - y_c));
				if(s < r)
					return v_i;
			}
			return null;
		}
		bool Pertenece(float x_i, float y_i, Vertice v_i)			//new->
		{
			Circle c_i;
			float s;
			float x_c;
			float y_c;
			float r;
			c_i = v_i.CIRCLE;
			x_c = c_i.P_c.X;
			y_c = c_i.P_c.Y;
			r = c_i.getRadio();
			s = (float)Math.Sqrt((x_i - x_c)*(x_i - x_c)+(y_i - y_c)*(y_i - y_c));
			if(s < r)
				return true;
			return false;
		}
		float [] ConvertirTamanio(MouseEventArgs e)
		{
			float w_p,h_p,w_b,h_b;
			float d_x,d_y,x_p,y_p;
			float r,r_x,r_y;
			float [] x_y;
			x_y = new float[2];
			w_b = bmpGrafo.Width;
			h_b = bmpGrafo.Height;
			w_p = pictureBoxImage.Width;
			h_p = pictureBoxImage.Height;
			x_p = e.X;
			y_p = e.Y;
			r_x = w_p/w_b;
			r_y = h_p/h_b;
			r = r_x;
			if(r_x < r_y)
				r = r_x;
			else
				r = r_y;
			d_x = (w_p - w_b * r)/2;
			d_y = (h_p - h_b * r)/2;
			
			x_y[0] = (x_p - d_x)/r;
			x_y[1] = (y_p - d_y)/r;
			return x_y;
		}
//		SEGUIR CONSTROYENDO
		void isObstruccion(Vertice v_o, Vertice v_d)
		{
			int indexDestino = indexAristaDestination(v_o,v_d);
			int indexDestinoAristaOrigen = indexAristaDestination(v_d,v_o);
			Point [] path = v_o.getPathAt(indexDestino);
			Color c_i;
			foreach(var values in path){
				c_i = bmpGrafo.GetPixel(values.X,values.Y);
				if(!isWhite(c_i)){
					if(!Pertenece(values.X,values.Y,v_o)){
						if(!Pertenece(values.X,values.Y,v_d)){
							v_o.eliminarArista(indexDestino);
							v_d.eliminarArista(indexDestinoAristaOrigen);
							return ;
//							HAY OBSTRUCCION
						}
					}
				}
			}
			return ;
//			NO HAY OBSTRUCCIÓN
		}
		bool isWhite(Color color)
		{
			if(color.R==255)
				if(color.G==255)
					if(color.B==255)
						return true;
			return false;
		}
		bool isBlack(Color color)
		{
			if(color.R==0)
				if(color.G==0)
					if(color.B==0)
						return true;
			return false;
		}
//		devuelve el indice de la arista que es el vertice destino
		int indexAristaDestination(Vertice v_o,Vertice v_d){
			for(int i = 0; i < v_o.Al.Count; i++){
				if(v_d.Id == v_o.Al[i].Destination.Id){
					return i;
				}
			}
			return -1;
		}
		void drawCircles(List<Circle> cl){
			Brush brochaBlack = new SolidBrush(Color.Black);
			for(int i = 0; i<cl.Count; i++){
				Graphics g = Graphics.FromImage(bmpGrafo);
				Graphics f = Graphics.FromImage(bmpAnimacion);
				g.FillEllipse(brochaBlack, (cl[i].getP_cX() - cl[i].getD()/2) + 10 , (cl[i].getP_cY() - cl[i].getD()/2) + 10 , cl[i].getD() - 15 ,cl[i].getD() - 15);
				f.FillEllipse(brochaBlack, (cl[i].getP_cX() - cl[i].getD()/2) + 10 , (cl[i].getP_cY() - cl[i].getD()/2) + 10 , cl[i].getD() - 15,cl[i].getD() - 15);
				
				pictureBoxImage.Refresh();
			}
		}
	}
}

