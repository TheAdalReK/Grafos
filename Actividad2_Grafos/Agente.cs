/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 12/10/2023
 * Time: 08:21 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace Actividad2_Grafos
{
	public class Agente
	{
		int posIndex;
		int verticeIndex;
		Point [] path;
		int vel;
		public Agente(int verticeIndex, int vel)
		{
			this.verticeIndex = verticeIndex;
			posIndex = 0;
			this.vel = vel;
		}
		public int VertexIndex{
			get{
				return verticeIndex;
			}
		}
		public Point [] Path{
			set{
				path = value;
			}
		}
		public bool walk(){
			if(posIndex+vel < path.Length){
				posIndex += vel;
				return true;
			}
			posIndex += path.Length-1;
			return false;
		}
		public Point  getActualPosition()
		{
			return path[posIndex];
		}
	}
}

