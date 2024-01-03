/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 12/10/2023
 * Time: 08:24 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Actividad2_Grafos
{
	public class Grafo
	{
		List< Vertice> vl;
		public Grafo(List<Circle> cL)
		{
			vl = new List<Vertice>();
			foreach(Circle c_i in cL){
				Vertice v_new = new Vertice(c_i,c_i.Id);
				vl.Add(v_new);
			}
			Point [] path;
			Point [] path2;
			for(int i = 0; i < vl.Count; i++){
				for(int j = i+1; j < vl.Count; j++){
					path = makePath(vl[i].CIRCLE.P_c,vl[j].CIRCLE.P_c);
					path2 = makePath(vl[j].CIRCLE.P_c,vl[i].CIRCLE.P_c);
					vl[i].addAristas(vl[j], 0, path);
					vl[j].addAristas(vl[i], 0, path2);
					
				}
			}
		}
		Point[] makePath(Point p_o, Point p_f)
		{
			float x_k, y_k;
			float m,b;
			float x_o,y_o;
			float x_f,y_f;
			float inc = 1;
			int count = 0;
			Point [] path;
			
			x_o = p_o.X;
			x_f = p_f.X;
			y_o = p_o.Y;
			y_f = p_f.Y;
			m = (y_f - y_o)/(x_f-x_o);
			b = y_o - m * x_o;
			
			if(x_f - x_o == 0){
				path = new Point[(int)Math.Abs(y_f - y_o)];
				if(y_f < y_o)
					inc = -1;
				for(y_k = y_o; y_k != y_f; y_k+=inc){
					path[count].X = (int)Math.Round(x_o);
					path[count++].Y = (int)Math.Round(y_k);
				}
			}
			else if(m < 1 && m > -1){
					path = new Point[(int)Math.Abs(x_f - x_o)];
					if(x_f < x_o){
						inc = -1;
					}
					
					for(x_k = x_o; x_k != x_f; x_k+= inc){
						y_k = m * x_k + b;
						path[count].X = (int)Math.Round(x_k);
						path[count++].Y = (int)Math.Round(y_k);
					}
			}
				else{
					path = new Point[(int)Math.Abs(y_f - y_o)]; //posible error
					if(y_f < y_o){
						inc = -1;
					}
					for(y_k = y_o; y_k != y_f; y_k+= inc){
						x_k = (y_k - b)/m;
						path[count].X = (int)Math.Round(x_k);
						path[count++].Y = (int)Math.Round(y_k);
						
					}
				}
			return path;
		}
		public int Count{
			get{
				return vl.Count;
			}
		}
		public Vertice getVerticeAt(int pos){
			return vl[pos];
		}
		public Circle getCircleAt(int pos){
			return vl[pos].CIRCLE;
		}
		
		public Vertice getDestinationAt(int pos){
			return vl[pos];
		}
		
	}
	
	public class Vertice
	{
		Circle circle;
		List<Arista> al;
		int id;
		public Vertice()
		{
			
		}
		public Vertice(Circle circle, int id)
		{
			al = new List<Arista>();
			this.circle = circle;
			this.id = id;
		}
		public Circle CIRCLE{
			get{
				return circle; 
			}
		}
		public Point[] getPathAt(int index)
		{
			return al[index].Path;
		}
		public void addAristas(Vertice v_d, float weight,Point [] path){
			Arista a_new = new Arista(v_d,weight,path);
			al.Add(a_new);
		}
		public int Id{
			get{
				return id;
			}
		}
		public int AristasCount{
			get{
				return al.Count;
			}
		}
		public Vertice getDestinationAt(int pos){
			return al[pos].Destination;
		}
		public void eliminarArista(int pos){
			al.RemoveAt(pos);
		}
		public List<Arista> Al{
			get{
				return al;
			}
		}
		
	}
	public class Arista
	{
		Vertice destination;
		float weight;
		Point [] path;
		public Arista()
		{
			
		}
		public Arista(Vertice destination, float weight,Point [] path)
		{
			this.destination = destination;
			this.weight = weight;
			this.path = path;
		}
		public Vertice Destination{
			get{
				return destination;
			}
		}
		public Point[] Path{
			get{
				return path;
			}
		}
	}
}

