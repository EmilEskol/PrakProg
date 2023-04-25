using System;
using static System.Console;
using static System.Math;
using static matrix;

public class main{
	public static void Main(string[] args){
		//u''=-u
		double a= 0,b=3.14159*3;
		vector ya= new vector(1,0);
		Func<double,vector,vector> f = (x,y) => (new vector(y[1], -y[0]));
		var xList = new genlist<double>();
		var yList = new genlist<vector>();
		vector yb=ODE.driver(f,a,b,ya,xList,yList);
		yb.print("yb for u''=-u at b={b}");
		IOputs.WriteXY(args,xList,yList,"Oscilation.data");
		//scipy exampel 1
		f = (x,y) => (new vector(y[1],-0.25*y[1]-5*Sin(y[0])));
		b=10;
		ya[0]=PI-0.1;
		ya[1]=0;
		xList= new genlist<double>();
		yList= new genlist<vector>();
		yb=ODE.driver(f,a,b,ya,xList,yList);
		yb.print("yb for scipy exampel 1 at b={b}");
		IOputs.WriteXY(args,xList,yList,"scipyPlot.data");
		//scipy exampel 2 (Lotka-Volterra System)
		f = (x,y) => (new vector(1.5*y[0]-y[0]*y[1],-3*y[1]+y[0]*y[1]));
		b=15;
		ya[0]=10;
		ya[1]=5;
		xList= new genlist<double>();
		yList= new genlist<vector>();
		yb=ODE.driver(f,a,b,ya,xList,yList);
		yb.print("yb for Lotka-Volterra System at b={b}");
		IOputs.WriteXY(args,xList,yList,"scipyPlot2.data");
	}
}
