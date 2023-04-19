using System;
using static System.Console;
using static matrix;

public class main{
	public static void Main(string[] args){
		double a= 0,b=3.14159*3;
		vector ya= new vector(1,0);
		Func<double,vector,vector> f = (x,y) => (new vector(y[1], -y[0]));
		var xList = new genlist<double>();
		var yList = new genlist<vector>();
		(xList,yList)=ODE.driver(f,a,b,ya);
		IOputs.WriteXY(args,xList,yList,"Oscilation.data");
	}
}
