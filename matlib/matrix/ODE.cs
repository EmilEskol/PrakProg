using System;
using static System.Console;
using static System.Math;
using static matrix;

public static class ODE{
	public static (vector,vector) rkstep23(Func<double,vector,vector> f,double x,vector y,double h){
	vector k0 = f(x,y);
	vector k1 = f(x+h/2,y+k0*(h/2));
	vector k2 = f(x+h*3.0/4,y+k1*(h*3.0/4));
	vector k3 = f(x+h,y+(k0*(2.0/9)+k1*(1.0/3)+k2*(4.0/9))*h);
	vector k= k0*(7.0/24)+k1*(1.0/4)+k2*(1.0/3)+k3*(1.0/8);
	vector yh = y+k*h;
	vector er = (k-(k0*(2.0/9)+k1*(1.0/3)+k2*(4.0/9)))*h;
	return (yh,er);
	}
	public static vector driver(Func<double,vector,vector> f, double a,
		double b, vector ya, genlist<double> xs=null,genlist<vector> ys=null, double h=0.01,double acc=0.01,
		double eps=0.01){
		vector tol= new vector(ya.size);
		bool acceptStep;
		double hFactor;
		if(a>b)
			throw new ArgumentException("driver: a>b");
		double x=a;
		vector y=ya.copy();
		while(true){
			if(x>=b)
				return y;
			if(x+h>b)
				h=b-x;
			var (yh,errV) = rkstep23(f,x,y,h);
			acceptStep=true;
			for(int i=0;i<ya.size;i++){
				tol[i]=Max(acc,Abs(yh[i])*eps)*Sqrt(h/(b-a));
				if(errV[i]>=tol[i])
					acceptStep=false;	
			}
			if(acceptStep){
				x+=h;
				y=yh;
				if(xs!=null&&ys!=null){
					xs.add(x);
					ys.add(y);
				}
			}
			hFactor=tol[0]/Abs(errV[0]);
			for(int i=0;i<ya.size;i++)
				hFactor=Min(hFactor,tol[i]/Abs(errV[i]));
			
			h*=Min(Pow(hFactor,0.25)*0.95, 2);
		}
		
	}
}
