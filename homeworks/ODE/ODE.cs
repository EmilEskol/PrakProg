using System;
using static System.Console;
using static System.Math;
using static matrix;

public static class ODE{
	public static (vector,vector) rkstep12(Func<double,vector,vector> f,double x,vector y,double h){
	vector k0 = f(x,y);
	vector k1 = f(x+h/2,y+k0*(h/2));
	vector yh = y+k1*h;
	vector er = (k1-k0)*h;
	return (yh,er);
	}
	public static (genlist<double>,genlist<vector>) driver(Func<double,vector,vector> f, double a,
		double b, vector ya, double h=0.01,double acc=0.01,double eps=0.01){
		if(a>b)
			throw new ArgumentException("driver: a>b");
		double x=a;
		vector y=ya.copy();
		var xList = new genlist<double>();
		xList.add(x);
		var yList = new genlist<vector>();
		yList.add(y);
		while(true){
			if(x>=b)
				return(xList,yList);
			if(x+h>b)
				h=b-x;
			var (yh,errV) = rkstep12(f,x,y,h);
			double tol = Max(acc,yh.norm()*eps)*Sqrt(h/(b-a));
			double err = errV.norm();
			if(err<=tol){
				x+=h;
				y=yh;
				xList.add(x);
				yList.add(y);
			}
			h*=Min(Pow(tol/err,0.25)*0.95, 2);
		}
	}
}
