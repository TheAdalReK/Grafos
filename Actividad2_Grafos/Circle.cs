/*
 * Created by SharpDevelop.
 * User: Adalberto
 * Date: 12/10/2023
 * Time: 08:23 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace Actividad2_Grafos
{
	public class Circle
	{
		Point p_c;
		int radio;
		int id;
		int d;
		public Circle()
		{
		}
		public Circle(Point p_c, int id,int radio, int d)
		{
			this.p_c = p_c;
			this.radio = radio;
			this.id = id;
			this.d = d;
		}
		public int getP_cX()
		{
			return p_c.X;
		}
		public int getP_cY()
		{
			return p_c.Y;
		}
		public int getRadio()
		{
			return radio;
		}
		public int getId()
		{
			return id;
		}
		public int getD()
		{
			return d;
		}
		public Point P_c
		{
				get{ 
					return p_c;
				}
				set{ 
					p_c = value;
				}
		}
		public int Id{
			get{
				return id;
			}
		}
		
		
	}
}
